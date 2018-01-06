using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ExcelDataReader;

namespace excounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            //Todo: Do something here.
            Debug.WriteLine("==== File List ====");
            string[] files = Directory.GetFiles("./", "*.xlsx", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; ++i) {
                Debug.WriteLine("File: " + files[i]);
                //Open the file.
                using (FileStream file = File.Open(files[i], FileMode.Open, FileAccess.Read)) {
                    //Create excel reader.
                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(file)) {
                        DataSet dataSet = reader.AsDataSet();
                        DataTableCollection dataTableCollection = dataSet.Tables;
                        for (int j = 0; j < dataTableCollection.Count; j++) {
                            Debug.WriteLine("Tab[" + j + "]: " + dataTableCollection[j].TableName);
                        }
                    }
                }
            }
            Debug.WriteLine("===================");
        }
    }
}
