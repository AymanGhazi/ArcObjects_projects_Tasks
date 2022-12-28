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
using static System.Windows.Forms.CheckedListBox;
using GeoDatabaseInventory;

namespace GeoDatabaseInventory
{
    public partial class InventoryMain : Form
    {
        public InventoryMain()
        {
            InitializeComponent();
        }

        public string SelectedDSName { get; set; }
        IList<IFeatureClass> FCList = new List<IFeatureClass>();
        List<FieldsList> Fieldslist = new List<FieldsList>();
        IWorkspaceFactory Pwsf = null;
        IWorkspace Pws = null;
        IFeatureWorkspace FeatureWS = null;
        public string lastSelected { get; set; }
        public string mappingFileLoC { get; set; }
        public List<MappingInfo> mapping_Info { get; set; }

        private void btnFCPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fBD = new FolderBrowserDialog();
            if (fBD.ShowDialog()==DialogResult.OK)
            {
               
            } 
        }
        private void btnFCLoad_Click(object sender, EventArgs e)
        {
            cmbFC.Items.Clear();
            Fieldslist.Clear();
            FCList.Clear();
            CHLBOX.ClearSelected();
            if (string.IsNullOrEmpty(txtGeoDatabasePath.Text))
            {
                MessageBox.Show("GDB path can not be empty ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                var FileExists = false;

                if (rdbFile.Checked == true)
                {
                    Pwsf = new FileGDBWorkspaceFactoryClass();

                    FileExists = txtGeoDatabasePath.Text.EndsWith(".gdb");
                }
                if (rdbPersonal.Checked == true)
                {
                    Pwsf = new AccessWorkspaceFactoryClass(); //mdb file access
                    FileExists = txtGeoDatabasePath.Text.EndsWith(".mdb");
                }
                if (rdbSHP.Checked == true)
                {
                    Pwsf = new ShapefileWorkspaceFactoryClass();
                    FileExists = Path.HasExtension(txtGeoDatabasePath.Text + "/:.shp");

                }
                if ((Directory.Exists(txtGeoDatabasePath.Text) || File.Exists(txtGeoDatabasePath.Text))&& FileExists)
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
                            FeatureWS = (IFeatureWorkspace)Pws;

                            //Getting feature classes outside the feature DataSet
                            #region stand-alone Feature Classes
                            IEnumDataset PEnumDS = Pws.get_Datasets(esriDatasetType.esriDTFeatureClass);
                            //IEnum gets the pointer to each one of the enum list
                            IDataset pDs = PEnumDS.Next();
                           
                            lblProgress.Text = "Fetching Feature Classes .... ";
                            System.Windows.Forms.Application.DoEvents();
                            cmbFC.Enabled = true;
                            while (pDs != null)
                            {
                                IFeatureClass FC = (IFeatureClass)pDs;

                                string pDsName = pDs.Name;
                                if (!FCList.Contains(FC))
                                {
                                    FCList.Add(FC);
                                    cmbFC.Items.Add( pDs.Name);
                                    //draw beside the list of the comboBox
                                    cmbFC.DrawItem += new DrawItemEventHandler(FCList_DrawItem);
                                 
                                }
                                pDs = PEnumDS.Next();
                            }
                            #endregion

                            #region Feature Datasets
                            //getting the Feature dataset
                            PEnumDS = Pws.get_Datasets(esriDatasetType.esriDTFeatureDataset);
                            pDs = PEnumDS.Next();  
                                while (pDs != null)
                                {
                                string DSname = pDs.Name;
                                IEnumDataset pDSInsideEnum = pDs.Subsets;

                                    IDataset pds1Inside = pDSInsideEnum.Next();
                                    while (pds1Inside != null)
                                    {
                                        string Name = pds1Inside.Name;
                                        if (pds1Inside is IFeatureClass)
                                        {
                                            IFeatureClass FC = (IFeatureClass)pds1Inside;
                                            cmbFC.Items.Add(pDs.Name);
                                            cmbFC.DrawItem += new DrawItemEventHandler(FCList_DrawItem);
                                            if (!FCList.Contains(FC))
                                            {
                                                FCList.Add(FC);
                                            }
                                            pds1Inside = pDSInsideEnum.Next();
                                        }
                                    }
                                    pDs = PEnumDS.Next();
                                }
                            lblProgress.Text = "Feature classes Found ";
                            System.Windows.Forms.Application.DoEvents();
                            //cmbFC.SelectedIndex = 0;
                        }
                          
                            
                        #endregion
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
            IGxDialog GxDialog = new GxDialogClass();
            GxDialog.Name = "Select Data";
            IGxObjectFilter DialogFilter = null;
            if (rdbFile.Checked == true)
            {
                lblProgress.Text = "File Geodatabase Selected ";
                System.Windows.Forms.Application.DoEvents();
                GxDialog.Title = "Select File GeoDatabase";
                DialogFilter = new GxFilterFileGeodatabasesClass();
            }
            if (rdbPersonal.Checked == true)
            {
                lblProgress.Text = "Personal Geodatabase Selected ";
                System.Windows.Forms.Application.DoEvents();
                GxDialog.Title = "Select Personal GeoDatabase";
                DialogFilter = new GxFilterPersonalGeodatabasesClass();

            }
            if (rdbSHP.Checked == true)
            {
                lblProgress.Text = "ShapeFile Selected ";
                System.Windows.Forms.Application.DoEvents();
                GxDialog.Title = "Select ShapeFile";
                GxDialog.ObjectFilter = new GxFilterShapefilesClass();
            }
            IEnumGxObject GxObjectEnum = null;
            if (GxDialog.DoModalOpen(0,out GxObjectEnum)==true)
            {
              IGxObject selection = GxObjectEnum.Next();
              txtGeoDatabasePath.Text = selection.FullName;         
            }
        }
        /// <summary>
        /// filter Data on the feature class to get the number of features
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbFC_SelectedIndexChanged(object sender, EventArgs e)
        {
            IFeatureClass featureSelected = FCList.FirstOrDefault(x => x.AliasName == cmbFC.SelectedItem.ToString());
            IQueryFilter QF = new QueryFilter();
            QF.SubFields = "*";
            QF.WhereClause = "1=1";
            lblCount.Text = featureSelected.FeatureCount(QF).ToString();
            System.Windows.Forms.Application.DoEvents();

            //adding to checkBox selection for Fields of the newly selected Feature Class
            CHLBOX.Items.Clear();
            IFields F = featureSelected.Fields;
            for (int i = 0; i < F.FieldCount; i++)
            {
                //selecting the non-Spatial fields
                if (F.Field[i].Type != esriFieldType.esriFieldTypeGeometry || F.Field[i].Name != "creationuser")
                {
                    CHLBOX.Items.Add(F.Field[i].AliasName);
                }
            }

            lastSelected = cmbFC.SelectedItem.ToString();
        }
        /// <summary>
        /// event handler to add an image infront of the selections 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Generating the report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            //open the dialog to select the location to save on
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    //ToolTip bar and refresh the screen
                    lblProgress.Text = "Generating Report .... ";
                    System.Windows.Forms.Application.DoEvents();

                    dialog.SelectedPath = dialog.SelectedPath;
                }
            }

            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                // App ==> WorkBook ==> WorkSheet
                _Application App = new Microsoft.Office.Interop.Excel.Application();  
                //Giving it a template to make the new file
                Workbook WB = App.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                //generating the first worksheet ==> the feature classes and the number of each feature included
                Worksheet WS = WB.Worksheets[1];
                //heading 
                Range CellRange = WS.Range["A1:C1"];
                CellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, new[] { "Feature Class Name", "Feature Class Alias Name", "Features Count" });
                CellRange.Font.Bold = true;
                var DatabaseName = Path.GetFileNameWithoutExtension(txtGeoDatabasePath.Text);

                dialog.SelectedPath = dialog.SelectedPath + "\\" + DatabaseName + "_Geo_report.xlsx";
                // 2 as we make the first row for heading 
                int row = 2;
                // Writing Data on excel

                //TODO writing according to mapping File 

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
                    row += 1;
                }

                //generating the other worksheets ==> attribute(spatial & Non-Spatial) table for every feature class
                //casting IWorkspace to IFeatureWorkSpace ==> just to get the feature opened
                int Sheetcount = 2;
                for (int i = 0; i < Fieldslist.Count; i++)
                {
                    int row2 = 1;
                    int column = 1;

                    //loop through sheets of the feature classes ==> 1 is the first worksheet we begin from 2 
                    //getting features
                    Worksheet WSs=  WB.Worksheets.Add();
                      //Worksheet WSs = WB.Worksheets[Sheetcount];

                   IFeatureCursor FeatureCursor= Fieldslist[i].FeatureClass.Search(null,false);

                 
                      

                        IFeature feature = FeatureCursor.NextFeature();
                        //loop to get next feature 
                while (feature != null)
                 {
                            //headings 
                            ((Microsoft.Office.Interop.Excel.Range)WSs.Cells[1, 1]).Value = "OBJECTID";
                            ((Microsoft.Office.Interop.Excel.Range)WSs.Cells[1, 1]).Font.Bold = true;
                            ((Microsoft.Office.Interop.Excel.Range)WSs.Cells[2, 1]).Value = feature.OID.ToString();
                                //loop through fields (heading and values 2D array)
                                column = 2;
                                row2 = 2;
                       foreach (var SelectedField in Fieldslist[i].fieldsSelected)
                          {
                                
                            ((Microsoft.Office.Interop.Excel.Range)WSs.Cells[1, column]).Value = SelectedField.Name;
                            ((Microsoft.Office.Interop.Excel.Range)WSs.Cells[1, column]).Font.Bold = true;

                            //Actual Data of each field and OBJECTID

                            //find index of the selected field
                            int FieldIndex = Fieldslist[i].FeatureClass.Fields.FindField(SelectedField.Name);
                            var value = feature.get_Value(FieldIndex);

                            string fieldValue = Convert.ToString(feature.Value[FieldIndex]);
                            //var fieldValue =Convert.ToString(feature.get_Value(FieldIndex));
                            

                            ((Microsoft.Office.Interop.Excel.Range)WSs.Cells[row2, column]).Value = fieldValue;
                            //range.Font.Bold = true;
                            column += 1;
                            row2 += 1;
                          }
                            //TODO not all feature are loaded just one
                            feature = FeatureCursor.NextFeature();
                        }

                    
                }
                Sheetcount++;
                //save file
                WB.SaveAs(dialog.SelectedPath);
                //close the edit mode
                WB.Close();
                //toolTip bar
                lblProgress.Text = "Report Created on "+ dialog.SelectedPath;
                //refresh the screen
                System.Windows.Forms.Application.DoEvents();
                MessageBox.Show("Report Generated SuccessFully");
                //open the file after save 
                if (File.Exists(dialog.SelectedPath))
                {
                    Process.Start(dialog.SelectedPath);
                }
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void lblCount_Click(object sender, EventArgs e)
        {
         
        }

        private void btn_mapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog()==DialogResult.OK)
            {
                mappingFileLoC = fileDialog.FileName;
            }
            lblProgress.Text = "Mapping file selected on  " + fileDialog.FileName;
            //refresh the screen
            System.Windows.Forms.Application.DoEvents();
            if (!string.IsNullOrWhiteSpace(mappingFileLoC))
            {
                LoadMappingFile();
            }

        }
        /// <summary>
        /// this where we load the mapping file
        /// to get the criteria according to we filter feature class
        /// </summary>
        private void LoadMappingFile()
        {
          mapping_Info = new List<MappingInfo>();
            try
            {
                string[] MappingFilelines = File.ReadAllLines(mappingFileLoC);
                for (int i = 0; i < MappingFilelines.Length; i++)
                {
                    if (i == 0) continue;
                    else
                    {
                        string[] values = MappingFilelines[i].Split(',');
                        if (values.Length == 5)
                        {
                            var mapRow = new MappingInfo
                            {
                                FeatureClass = values[0],
                                Condition = values[1],
                                Field = values[2],
                                Field_type = values[3],
                                value = values[4]
                            };
                            mapping_Info.Add(mapRow);
                        }
                    }
                }

                lblProgress.Text = "Mapping file loaded successfully ";
                //refresh the screen
                System.Windows.Forms.Application.DoEvents();

            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void writingToFileOnMapping(string filePath,Worksheet WS)
        {
           
            Range CellRange = WS.Range["A1:C1"];
            CellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, new[] { "Feature Class Name", "Feature Class Alias Name", "Features Count" });
            CellRange.Font.Bold = true;
            var DatabaseName = Path.GetFileNameWithoutExtension(txtGeoDatabasePath.Text);
            
            // 2 as we make the first row for heading 
            int row = 2;
            // Writing Data on excel

            //TODO writing according to mapping File 
            try
            {
                lblProgress.Text = "Reading Mapping file ...";
                //refresh the screen
                System.Windows.Forms.Application.DoEvents();
                foreach (MappingInfo item in mapping_Info)
                {
                    IFeatureClass FC = FeatureWS.OpenFeatureClass(item.FeatureClass);
                    //like selection on arcMap if there is no condition it gives us all the feature classes count 
                    if (item.Condition.ToUpper() == "FALSE")
                    {
                        //count
                        int numberOfFClasses = FC.FeatureCount(null);
                        int column = 1;
                        ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = item.FeatureClass;
                        column += 1;
                        ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = item.Field;
                        column += 1;
                        ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = item.Field_type;
                        column += 1;
                        ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = numberOfFClasses.ToString();
                    }
                    else
                    {
                        IQueryFilter qf = new QueryFilterClass();
                        if (item.Condition.IndexOf('=') != -1)
                        {
                            qf.WhereClause = item.Condition;
                        }
                        else
                        {
                            if (item.Field_type.ToUpper() == "STRING")
                            {
                                qf.WhereClause = $"{item.Field} = '{item.value}'";
                            }
                            else
                            {
                                qf.WhereClause = $"{item.Field} = {item.value}";
                            }
                        }


                        int numberOfFClasses = FC.FeatureCount(null);
                        int column = 1;
                        ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = item.FeatureClass;
                        column += 1;
                        ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = item.Field;
                        column += 1;
                        ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = item.Field_type;
                        column += 1;
                        ((Microsoft.Office.Interop.Excel.Range)WS.Cells[row, column]).Value = numberOfFClasses.ToString();
                    }

                    row += 1;

                }
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    

        private void FeatureAdd_Click(object sender, EventArgs e)
        {
            //getting the feature class and open the data inside it 

            ////this feature class from IWorkspace we have only declarations and names (NO DATA)
            //IFeatureClass selectedFeature = FCList.FirstOrDefault(x => x.AliasName == lastSelected);


            //making list of fields selected and their featureClass
            IFeatureClass selectedFeature = FeatureWS.OpenFeatureClass(cmbFC.SelectedItem.ToString());
            FieldsList FeatureAddedBefore = Fieldslist.FirstOrDefault(x => x.FeatureClass.FeatureClassID == selectedFeature.FeatureClassID);
            if (selectedFeature != null && FeatureAddedBefore ==null)
            {
                FieldsList list = new FieldsList
                {
                    FeatureClass = selectedFeature,
                    //setting the list to empty to get the new selected fields of feature class selected
                    fieldsSelected = new List<IField>()
                };
                //adding items selected to the list of FieldsList to get them down when generating the report
                foreach (var checkItem in CHLBOX.CheckedItems)
                {
                    IFields Fields = selectedFeature.Fields;

                    for (int i = 0; i < Fields.FieldCount; i++)
                    {
                        if (Fields.Field[i].AliasName == checkItem.ToString())
                        {
                            list.fieldsSelected.Add(Fields.Field[i]);
                        }
                    }
                }
                Fieldslist.Add(list);
            }
            else
            {
                MessageBox.Show("feature already added before", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}