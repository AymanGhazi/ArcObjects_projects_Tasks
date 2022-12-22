using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geodatabase;
using System.IO;
using ESRI.ArcGIS.esriSystem;

namespace GeoDatabaseInventory
{
    public partial class Inventory : Form
    {


        public Inventory()
        {
            InitializeComponent();
        }

        public string SelectedDSName { get; set; }
        IList<IFeatureClass> FCList = new List<IFeatureClass>();


        private void btnFCPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBD = new FolderBrowserDialog();
            if (fBD.ShowDialog()==DialogResult.OK)
            {
               
            } 
        }

        private void btnFCLoad_Click(object sender, EventArgs e)
        {
            SelectedDSName = cmbFC.SelectedText;
           cmbFC.Items.Clear();
           IWorkspaceFactory Pwsf = null;
            IWorkspace Pws = null;

            if (string.IsNullOrEmpty(txtGeoDatabasePath.Text))
            {
                MessageBox.Show("GDB path textbox can not be empty ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                var FileExists = false;

                if (rdbFile.Checked == true)
                {
                    MessageBox.Show("file GDB selected");
                    Pwsf = new FileGDBWorkspaceFactoryClass();
                    FileExists = txtGeoDatabasePath.Text.EndsWith(".gdb");

                }
                if (rdbPersonal.Checked == true)
                {
                    MessageBox.Show("Personal GDB selected");
                    Pwsf = new AccessWorkspaceFactoryClass(); //mdb file access
                    FileExists = txtGeoDatabasePath.Text.EndsWith(".gdb");

                }
                if (rdbSHP.Checked == true)
                {
                    MessageBox.Show("ShapeFile selected");
                    Pwsf = new ShapefileWorkspaceFactoryClass();
                    FileExists = Path.HasExtension(txtGeoDatabasePath.Text + "/:.shp");

                }

                if (Directory.Exists(txtGeoDatabasePath.Text) && FileExists)
                {
                    try
                    {
                        var isWorkSpace = Pwsf.IsWorkspace(txtGeoDatabasePath.Text);
                        var WorkspaceType = Pwsf.WorkspaceType.ToString();
                        if (isWorkSpace)
                        {
                            Pws = Pwsf.OpenFromFile(txtGeoDatabasePath.Text, 0);
                            //Getting feature classes outside the feature DataSet

                            #region stand-alone Feature Classes
                            IEnumDataset PEnumDS = Pws.get_Datasets(esriDatasetType.esriDTFeatureClass);
                            IDataset pDs = PEnumDS.Next();
                            // IDataset pDs2 = PEnumDS.Next(); //second Dataset
                            int Index = 0;
                            while (pDs != null)
                            {
                                IFeatureClass FC = (IFeatureClass)pDs;
                                string pDsName = pDs.Name;
                                if (!FCList.Contains(FC))
                                {
                                    FCList.Add(FC);
                                    cmbFC.Items.Insert(Index, pDs.Name);
                                    Index++;
                                }
                                pDs = PEnumDS.Next();
                            }
                     
                            #endregion

                            #region Feature Datasets
                            PEnumDS = Pws.get_Datasets(esriDatasetType.esriDTFeatureDataset);
                            pDs = PEnumDS.Next();
                            string DSname = pDs.Name;
                            while (pDs != null)
                            {
                              
                                IEnumDataset pDSInsideEnum = pDs.Subsets;
                                //if (pDs.Name == SelectedDSName)
                                //{
                                    IDataset pds1Inside = pDSInsideEnum.Next();
                                    while (pds1Inside != null)
                                    {
                                        string Name = pds1Inside.Name;
                                    if (pds1Inside is IFeatureClass)
                                        {
                                        IFeatureClass FC = (IFeatureClass)pds1Inside;
                                        cmbFC.Items.Insert(Index, FC.AliasName);
                                        cmbFC.DrawItem += new DrawItemEventHandler(FCList_DrawItem);
                                        Index++;
                                        if (!FCList.Contains(FC))
                                        {
                                            FCList.Add(FC);
                                        }
                                        pds1Inside = pDSInsideEnum.Next();
                                        }
                                    }
                               
                                //}
                                pDs = PEnumDS.Next();
                            }

                            cmbFC.SelectedIndex = 0;

                            #endregion

                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //private void CalculateFeatureClassesInDataSets(IEnumDataset Dataset)
        //{
        //    IDataset pds1Inside = pDSInsideEnum.Next();
        //    while (pds1Inside != null)
        //    {
        //        string Name = pds1Inside.Name;

        //        if (pds1Inside is IFeatureClass)
        //        {
        //            IFeatureClass FC = (IFeatureClass)pds1Inside;

        //            pds1Inside = pDSInsideEnum.Next();
        //        }
        //    }
        //    lblCount.Text = FCList.Count.ToString();
        //}

        private void btnFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() ==DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    txtGeoDatabasePath.Text = dialog.SelectedPath;
                }
            }
        }
        private void cmbFC_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFeatureClass item = FCList.FirstOrDefault(x=>x.AliasName == cmbFC.SelectedItem.ToString());
            IQueryFilter QF = new QueryFilter();
            QF.SubFields = "*";
            QF.WhereClause = "1=1";

            lblCount.Text = item.FeatureCount(QF).ToString();
        }

        private void FCList_DrawItem(object sender,DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Define the default color of the brush as black.
            Brush myBrush = Brushes.Black;

            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.
            switch (e.Index)
            {
                case 0:
                    myBrush = Brushes.Red;
                    break;
                case 1:
                    myBrush = Brushes.Orange;
                    break;
                case 2:
                    myBrush = Brushes.Purple;
                    break;
            }

            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(FCList[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
    }
}