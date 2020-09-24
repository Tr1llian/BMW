
using System;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using DGVPrinterHelper;

namespace DataGridView_Import_Excel
{
    public
    partial class Form1 : Form
    {
        private
            string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private
            string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";

        public
            Form1()
        {

            InitializeComponent();
            dataGridView1.Visible = false;
            btnPrint.Visible = false;
            button1.Visible = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DefaultCellStyle.WrapMode= DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private
            void btnSelect_Click(object sender, EventArgs e)
        {

            Cursor = Cursors.WaitCursor;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                dataGridView1.Visible = true;
                btnPrint.Visible = true;
                button1.Visible = true;
               
            }
            Cursor = Cursors.Arrow;
        }

        private
            void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            string filePath = openFileDialog1.FileName;
            string extension = Path.GetExtension(filePath);
            string header = "YES";
            string conStr, sheetName;

            conStr = string.Empty;
            switch (extension)
            {

                case ".xls": //Excel 97-03
                    conStr = string.Format(Excel03ConString, filePath, header);
                    break;

                case ".xlsx": //Excel 07
                    conStr = string.Format(Excel07ConString, filePath, header);
                    break;
            }

            //Get the name of the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = con;
                    con.Open();
                    DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //sheetName = "data";
                    sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                    //sheetName1 = dtExcelSchema.Rows[2]["TABLE_NAME"].ToString();
                    con.Close();
                }
            }
            List<string> MyList = new List<string>();
            List<string> MyListNd = new List<string>();

            //Read Data from the First Sheet.
            using (OleDbConnection con = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {

                    using (OleDbDataAdapter oda = new OleDbDataAdapter())
                    {
                        try
                        {
                            DataTable dt = new DataTable();
                            DataTable dt1 = new DataTable();

                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();



                            Saloon G11 = new Saloon("G11");
                            Saloon G3 = new Saloon("G3");
                           
                            foreach (DataRow row in dt.Rows)
                            {
                               

                                if (row[6].ToString().ToUpper().Contains("G1"))
                                {
                                    if (row[6].ToString().ToUpper().Contains("FC"))
                                    {
                                        G11.FCcount += 1;
                                        G11.FCtime += Convert.ToInt16(row[7].ToString());
                                    }
                                    else if (row[6].ToString().ToUpper().Contains("FB"))
                                    {
                                        G11.FBcount +=1;
                                        G11.FBtime += Convert.ToInt16(row[7].ToString());
                                    }
                                    else if (row[6].ToString().ToUpper().Contains("RC"))
                                    {
                                        if (row[6].ToString().ToUpper().Contains("RC100"))
                                        {
                                            G11.RC100count += 1;
                                            G11.RC100time += Convert.ToInt16(row[7].ToString());
                                        }
                                        else
                                        {
                                            G11.RC40count += 1;
                                            G11.RC40time += Convert.ToInt16(row[7].ToString());
                                        }

                                        
                                    }
                                    else if (row[6].ToString().ToUpper().Contains("RB"))
                                    {
                                        G11.RBcount += 1;
                                        G11.RBtime += Convert.ToInt16(row[7].ToString());
                                    }

                                }
                                else if(row[6].ToString().ToUpper().Contains("G3Y") || row[6].ToString().ToUpper().Contains("F90"))
                                {
                                    if (row[6].ToString().ToUpper().Contains("FC"))
                                    {
                                        G3.FCcount += 1;
                                        G3.FCtime += Convert.ToInt16(row[7].ToString());
                                    }
                                    else if (row[6].ToString().ToUpper().Contains("FB"))
                                    {
                                        G3.FBcount += 1;
                                        G3.FBtime += Convert.ToInt16(row[7].ToString());
                                    }
                                    else if (row[6].ToString().ToUpper().Contains("RC"))
                                    {
                                        if (row[6].ToString().ToUpper().Contains("RC100"))
                                        {
                                            G3.RC100count += 1;
                                            G3.RC100time += Convert.ToInt16(row[7].ToString());
                                        }
                                        else
                                        {
                                            G3.RC40count += 1;
                                            G3.RC40time += Convert.ToInt16(row[7].ToString());
                                        }


                                    }
                                    else if (row[6].ToString().ToUpper().Contains("RB"))
                                    {
                                        G3.RBcount += 1;
                                        G3.RBtime += Convert.ToInt16(row[7].ToString());
                                    }
                                }
                               
                            }
                           

                            //int[] MyListSum = new int[MyListNd.Count];
                            //int[] MyListSum1 = new int[MyListNd.Count];
                            //int[] MyListSum2 = new int[MyListNd.Count];
                            //for (int i = 0; i < MyListNd.Count; i++)
                            //{
                            //    MyListSum[i] = 0;
                            //    MyListSum1[i] = 0;
                            //    MyListSum2[i] = 0;
                            //}

                            //string[] MyListName = new string[MyList.Count];
                            //int k = 0;
                            //foreach (DataRow row in dt.Rows)
                            //{
                            //    if (row[1].ToString() == "")
                            //    {
                            //        row[1] = "0";
                            //    }
                            //    k = MyListNd.IndexOf(row[0].ToString());
                            //    MyListSum[k] = MyListSum[k] + Convert.ToInt32(row[1].ToString().Replace(".",string.Empty).Replace(",000", string.Empty));
                            //    MyListName[k] = row[2].ToString();
                            //}
                            //foreach (DataRow row in dt1.Rows)
                            //{
                            //    if(row[1].ToString()=="")
                            //    {
                            //        row[1] = "0";
                            //    }
                            //    if (MyListNd.Contains(row[0].ToString()))
                            //    {
                            //        k = MyListNd.IndexOf(row[0].ToString());
                            //        MyListSum1[k] = MyListSum1[k] + Convert.ToInt32(row[1].ToString().Replace(".",string.Empty).Replace(",000", string.Empty));
                            //    }

                            //}

                            //k = 0;
                            //foreach (string p in MyListNd)
                            //{
                            //    Console.Write(p + " ");
                            //    Console.Write(MyListSum[k] + " ");
                            //    Console.Write(MyListSum1[k] + " ");
                            //    Console.Write(MyListSum2[k] + " ");
                            //    Console.WriteLine(MyListName[k]);
                            //    k++;
                            //}
                           
                            DataTable result = new DataTable();
                            result.Clear();
                            result.Columns.Add("Проект");
                            result.Columns.Add("Кількість чохлів").DataType = typeof(string);
                            result.Columns.Add("Загальний час").DataType=typeof(string);
                            result.Columns.Add("Час на одну штуку");
                            result.Columns.Add("Час на салон");
                            result.Columns.Add("Кількість салонів");
                            List<Saloon> Cars = new List<Saloon>();
                            G11.Coef = 7.5;
                            G3.Coef = 4.0;
                            Cars.Add(G11);
                            Cars.Add(G3);
                            double RCmiddle = 0;

                            foreach (Saloon car in Cars)
                            {
                                RCmiddle =(car.PartTime(car.RC40time, car.RC40count) + car.PartTime(car.RC100time, car.RC100count))/2;
                                car.RCtime = car.RC40time + car.RC100time;
                                car.RCcount = car.RC100count + car.RC40count;
                                DataRow row1 = result.NewRow();
                                row1["Проект"] =car.ProjectName;
                                row1["Кількість чохлів"] = "\n FB = " + car.FBcount
                                    + "\n" + " FC= " + car.FCcount
                                    + "\n" + " RB= " + car.RBcount
                                    + "\n" + " RC= " + car.RCcount + "\n";
                                row1["Загальний час"] = "\n FB time = " + car.FBtime
                                    + "\n" + " FC time= " + car.FCtime
                                    + "\n" + " RB time= " + car.RBtime
                                    + "\n" + " RC time= " + car.RCtime+ "\n";
                                row1["Час на одну штуку"] = "\n FB time for pcs= " +Math.Round( car.PartTime(car.FBtime,car.FBcount),3)
                                    + "\n" + " FC time for pcs= " +Math.Round( car.PartTime(car.FCtime, car.FCcount),3)
                                    + "\n" + " RB time for pcs= " +Math.Round( car.PartTime(car.RBtime, car.RBcount),3)
                                    + "\n" + " RC time for pcs= " +Math.Round( car.PartTime(car.RCtime, car.RCcount),3)+ "\n";
                                row1["Час на салон"] =Math.Round( car.TimeSaloon(),3);
                                row1["Кількість салонів"] =Math.Floor( car.GeneralCount()/car.Coef);

                                result.Rows.Add(row1);
                            }
                            
                            DataRow row2 = result.NewRow();
                            row2["Проект"] = "BMW Voga";
                            row2["Кількість чохлів"] = "\n FB = " + (G11.FBcount+G3.FBcount)
                                + "\n" + " FC= " + (G11.FCcount + G3.FCcount) + "\n";
                            row2["Загальний час"] = "\n FB time = " + (G11.FBtime+G3.FBtime)
                                + "\n" + " FC time= " + (G11.FCtime+G11.FCtime) + "\n";
                            row2["Час на одну штуку"] = "\n FB time for pcs= " + Math.Round(G11.PartTime(G11.FBtime + G3.FBtime, G11.FBcount + G3.FBcount), 3)
                                + "\n" + " FC time for pcs= " + Math.Round(G11.PartTime(G11.FCtime + G11.FCtime, G11.FCcount + G3.FCcount), 3) + "\n";
                            row2["Час на салон"] = Math.Round((G11.PartTime(G11.FBtime + G3.FBtime, G11.FBcount + G3.FBcount)*2+2* G11.PartTime(G11.FCtime + G11.FCtime, G11.FBcount + G3.FBcount))/0.65);
                            row2["Кількість салонів"] = Math.Floor((G11.FBcount + G3.FBcount+ G11.FCcount + G3.FCcount) /4.0);

                            result.Rows.Add(row2);
                           
                            DataRow row3 = result.NewRow();
                            row3["Проект"] = "BMW Higa";
                            row3["Кількість чохлів"] = "\n RB = " + G11.RBcount
                                + "\n" + " RC= " + (G11.RC40count + G11.RC100count) + "\n";
                            row3["Загальний час"] = "\n RB = " + G11.RBtime
                                + "\n" + " RC time= " + G11.RCtime + "\n";
                            row3["Час на одну штуку"] = "\n RB time for pcs= " + Math.Round(G11.PartTime(G11.RBtime, G11.RBcount), 3)
                                + "\n" + " RC time for pcs= " + Math.Round(G11.PartTime(G11.RC100time+G11.RC40time, G11.RC100count+G11.RC40count), 3) + "\n";
                            row3["Час на салон"] = Math.Round((G11.RC40time/G11.RC40count+2*G11.RBtime/G11.RBcount) / 0.35); ;
                            row3["Кількість салонів"] = Math.Floor((G11.RBcount+G11.RCcount) / 3.5);

                            result.Rows.Add(row3);
                            
                            //Populate DataGridView
                            dataGridView1.DataSource = result;
                            Cursor = Cursors.Arrow;
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
                        }
                    }
                }
            }
        }

        private
            void Form1_Load(object sender, EventArgs e)
        {
        }

        private
            void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            //{ //Here 2 cell is target value and 1 cell is Volume
            //    if (Convert.ToInt32(Myrow.Cells[5].Value) < 0) // Or your condition
            //    {
            //        Myrow.Cells[5].Style.BackColor = Color.Red;
            //    }
            //    else
            //    {
            //        //Myrow.DefaultCellStyle.BackColor = Color.Green;
            //    }
            //}
        }
        private
            void button1_Click(object sender, EventArgs e)

        {
            SaveFileDialog openDlg = new SaveFileDialog();
            openDlg.Filter = "Execl files (*.xls)|*.xls";

            string path = openDlg.FileName;
            if (openDlg.ShowDialog() == DialogResult.OK)
            {

                Excel.Application xlApp;

                Excel.Workbook xlWorkBook;

                Excel.Worksheet xlWorkSheet;

                object misValue = System.Reflection.Missing.Value;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                Int16 i, j;

                xlApp = new Excel.ApplicationClass();
                xlApp.DisplayAlerts = false;

                xlWorkBook = xlApp.Workbooks.Add(misValue);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                for (i = 0; i <= dataGridView1.RowCount - 2; i++)

                {

                    for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)

                    {

                        xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1[j, i ].Value.ToString();
                    }
                }

                try
                {
                    xlWorkBook.SaveAs(path.ToString(), Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Сталася помилка під час збереження " + ex.ToString());
                }
                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();

                releaseObject(xlWorkSheet);

                releaseObject(xlWorkBook);

                releaseObject(xlApp);
            }
        }

        private
            void releaseObject(object obj)

        {

            try

            {

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);

                obj = null;
            }

            catch (Exception ex)

            {

                obj = null;

                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }

            finally

            {

                GC.Collect();
            }
        }

        private
            void btnPrint_Click_1(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Продуктивність";
            //printer.SubTitle = string.Format("Дата {0}", DateTime.Now);

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;


            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.ColumnWidths.Add("Проект", 100);
            printer.ColumnWidths.Add("Кількість чохлів", 100);
            printer.ColumnWidths.Add("Загальний час", 100);
            printer.ColumnWidths.Add("Час на одну штуку", 100);
            printer.ColumnWidths.Add("Час на салон", 100);
            printer.Footer = "BADER";

            printer.FooterSpacing = 15;
            //printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.DataWidth;

            printer.PrintDataGridView(dataGridView1);
        }
    }
}


