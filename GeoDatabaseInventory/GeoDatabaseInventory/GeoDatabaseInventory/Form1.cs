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
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.Catalog;

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
        IWorkspaceFactory Pwsf = null;
        IWorkspace Pws = null;

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
           

            if (string.IsNullOrEmpty(txtGeoDatabasePath.Text))
            {
                MessageBox.Show("GDB path can not be empty ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                bool FileExists = false;

                if (rdbFile.Checked == true)
                {
                    FileExists = txtGeoDatabasePath.Text.EndsWith(".gdb");
                }
                else if (rdbPersonal.Checked == true)
                {
                    FileExists = Path.HasExtension(txtGeoDatabasePath.Text + "/:.mdb");
                }
                else if (rdbSHP.Checked == true)
                {
                    FileExists = Path.HasExtension(txtGeoDatabasePath.Text + "/:.shp");
                }

                if ((Directory.Exists(txtGeoDatabasePath.Text) || File.Exists(txtGeoDatabasePath.Text)) && FileExists)
                {
                    try
                    {
                        var isWorkSpace = Pwsf.IsWorkspace(txtGeoDatabasePath.Text);
                        var WorkspaceType = Pwsf.WorkspaceType.ToString();
                        if (isWorkSpace)
                        {
                            lblProgress.Text = "File Geodatabase is Found ";
                            System.Windows.Forms.Application.DoEvents();

                            Pws = Pwsf.OpenFromFile(txtGeoDatabasePath.Text, 0);

                            //Getting feature classes outside the feature DataSet
                            #region stand-alone Feature Classes
                            IEnumDataset PEnumDS = Pws.get_Datasets(esriDatasetType.esriDTFeatureClass);
                            IDataset pDs = PEnumDS.Next();
                            int Index = 0;
                            lblProgress.Text = "Fetching Feature Classes .... ";
                            System.Windows.Forms.Application.DoEvents();
                            while (pDs != null)
                            {
                                if (pDs is IFeatureClass)
                                {
                                    IFeatureClass FC = pDs as IFeatureClass;
                                    string pDsName = pDs.Name;
                                    if (!FCList.Contains(FC))
                                    {
                                        FCList.Add(FC);
                                        cmbFC.Items.Insert(Index, pDs.Name);
                                        cmbFC.DrawItem += new DrawItemEventHandler(FCList_DrawItem);
                                        Index++;
                                    }
                                    pDs = PEnumDS.Next();
                                }


                            }

                            #endregion

                            #region Feature Datasets
                            PEnumDS = Pws.get_Datasets(esriDatasetType.esriDTFeatureDataset);
                            pDs = PEnumDS.Next();
                            if (pDs != null)
                            {
                                string DSname = pDs.Name;
                                while (pDs != null)
                                {

                                    IEnumDataset pDSInsideEnum = pDs.Subsets;

                                    IDataset pds1Inside = pDSInsideEnum.Next();
                                    while (pds1Inside != null)
                                    {
                                        string Name = pds1Inside.Name;
                                        if (pds1Inside is IFeatureClass)
                                        {
                                            IFeatureClass FC = pds1Inside as IFeatureClass;
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
                                    pDs = PEnumDS.Next();
                                }
                            }

                            lblProgress.Text = "Feature classes Loaded ";
                            System.Windows.Forms.Application.DoEvents();

                            cmbFC.SelectedIndex = 0;

                            #endregion
                        }
                    }

                    catch (Exception ex)
                    {
                        lblProgress.Text = "Error ";
                        System.Windows.Forms.Application.DoEvents();

                        MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error in File Formatting", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            IGxDialog dialog = new GxDialogClass();
            dialog.AllowMultiSelect = false;
            IGxObjectFilter filter = null;

            if (rdbFile.Checked == true)
            {
                lblProgress.Text = "File Geodatabase Selected ";
                System.Windows.Forms.Application.DoEvents();

                Pwsf = new FileGDBWorkspaceFactoryClass();
               

                dialog.Title = "Select File GeoDatabase";
                filter = new GxFilterFileGeodatabasesClass();
                dialog.ObjectFilter = filter;
            }
            if (rdbPersonal.Checked == true)
            {
                lblProgress.Text = "Personal Geodatabase Selected ";
                System.Windows.Forms.Application.DoEvents();
                Pwsf = new AccessWorkspaceFactoryClass(); //mdb file access
               
                dialog.Title = "Select Personal GeoDatabase";

                filter = new GxFilterPersonalGeodatabasesClass();
                dialog.ObjectFilter = filter;
            }
            if (rdbSHP.Checked == true)
            {
                lblProgress.Text = "Shape File Selected ";
                System.Windows.Forms.Application.DoEvents();

                Pwsf = new ShapefileWorkspaceFactoryClass();
                dialog.Title = "Select Shape File";
                //
                filter = new GxFilterShapefilesClass();
                dialog.ObjectFilter = filter;
            }
            IEnumGxObject selectionEnum = null;
            if (dialog.DoModalOpen(0, out selectionEnum) == true)
            {
             IGxObject selection = selectionEnum.Next();
             txtGeoDatabasePath.Text = selection.FullName;
            }
         

            //FolderBrowserDialog dialog = new FolderBrowserDialog();

            //if (dialog.ShowDialog() ==DialogResult.OK)
            //{
            //    if (!string.IsNullOrEmpty(dialog.SelectedPath))
            //    {
            //        txtGeoDatabasePath.Text = dialog.SelectedPath;
            //    }
            //}
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

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    lblProgress.Text = "Generating Report .... ";
                    System.Windows.Forms.Application.DoEvents();

                    dialog.SelectedPath = dialog.SelectedPath;
                }
            }
            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                _Application App = new Microsoft.Office.Interop.Excel.Application();
              
                object misValue = System.Reflection.Missing.Value;

                Workbook WB = App.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet WS = WB.Worksheets[1];
                Range CellRange = WS.Range["A1:C1"];
                CellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, new[] { "Feature Class Name", "Feature Class Alias Name", "Features Count" });

                var DatabaseName = Path.GetFileNameWithoutExtension(txtGeoDatabasePath.Text);

                dialog.SelectedPath = dialog.SelectedPath + "\\" + DatabaseName + "_Geo_report.xlsx";
             
                int row = 2;
               
                foreach (IFeatureClass item   in FCList)
                {
                    int numberOfFClasses = item.FeatureCount(null);
                    IDataset TempDs = (IDataset)item;

                    int column = 1;
                    ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = TempDs.Name;
                    column += 1;
                    ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = item.AliasName;
                    column += 1;
                    ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = numberOfFClasses.ToString();

                    //foreach (DataColumn column in thisTable.Columns)
                    //{
                    //    Console.WriteLine(row[column]);
                    //}
                    row += 1;
                }
                WB.SaveAs(dialog.SelectedPath);
                WB.Close();
                lblProgress.Text = "Report Created on "+ dialog.SelectedPath;
                System.Windows.Forms.Application.DoEvents();

                MessageBox.Show("Report Generated SuccessFully");
                if (File.Exists(dialog.SelectedPath))
                {
                    Process.Start(dialog.SelectedPath);
                }
            }
        }

    }
}