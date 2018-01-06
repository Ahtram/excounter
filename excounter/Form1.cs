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
using System.Collections.Specialized;

namespace excounter
{
    public partial class Form1 : Form
    {
        //For print column Letter.
        static private string[] COLUMN_LETTER = new string[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"
        };

        public Form1()
        {
            InitializeComponent();
            LoadColumnToggleSettings();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            SaveColumnToggleSettings();
        }

        private void LoadColumnToggleSettings() {
            //Load column settings and present to the checkedList.
            StringCollection sc = Properties.Settings.Default.ToggleColumns;
            if (sc != null) {
                for (int i = 0; i < sc.Count; ++i) {
                    if (i < checkedListBoxColumns.Items.Count) {
                        checkedListBoxColumns.SetItemChecked(i, StringToBool(sc[i]));
                    }
                }
            }
        }

        private void SaveColumnToggleSettings() {
            //Form StringCollection from checkedList to save the setting.
            StringCollection sc = new StringCollection();
            for (int x = 0; x <= checkedListBoxColumns.Items.Count - 1; x++) {
                sc.Add(checkedListBoxColumns.GetItemChecked(x).ToString());
            }
            Properties.Settings.Default.ToggleColumns = sc;
            Properties.Settings.Default.Save();
        }

        private List<bool> ColumnToggles() {
            List<bool> columnToggles = new List<bool>();
            for (int x = 0; x <= checkedListBoxColumns.Items.Count - 1; x++) {
                columnToggles.Add(checkedListBoxColumns.GetItemChecked(x));
            }
            return columnToggles;
        }

        private void buttonSearchCalculate_Click(object sender, EventArgs e) {
            textBoxOutputs.Text = "";

            textBoxOutputs.Text += "==== Scan Result ====" + Environment.NewLine;

            //Toggle settings.
            List<bool> columnToggles = ColumnToggles();

            int totalCharacters= 0;

            //Get all xlsx.
            string[] files = Directory.GetFiles(".\\", "*.xlsx", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; ++i) {
                int totalCharactersInFile = 0;
                textBoxOutputs.Text += Environment.NewLine;
                textBoxOutputs.Text += "File[" + files[i] + "]:" + Environment.NewLine;

                try {
                    //Open the file.
                    using (FileStream file = File.Open(files[i], FileMode.Open, FileAccess.Read)) {
                        //Create excel reader.
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(file)) {
                            int[] characterCountForColumnFile = new int[26];
                            DataSet dataSet = reader.AsDataSet();
                            DataTableCollection dataTableCollection = dataSet.Tables;
                            for (int j = 0; j < dataTableCollection.Count; j++) {
                                DataTable table = dataTableCollection[j];
                                //A ~ Z = 26 columns.
                                int[] characterCountForColumnTab = new int[26];
                                textBoxOutputs.Text += "    Tab[" + j + "]: " + table.TableName + Environment.NewLine;
                                DataRow[] rows = table.Select();
                                for (int x = 0; x < rows.Length; ++x) {
                                    //string cell = rows[x].Field<string>(x);
                                    //if (x < characterCountForColumnTab.Length && columnToggles[x] == true) {
                                    //    characterCountForColumnTab[x] += cell.Length;
                                    //}
                                    Object[] cells = rows[x].ItemArray;
                                    for (int y = 0; y < cells.Length; ++y) {
                                        //Debug.Write(cells.Length);
                                        if (cells[y] != null) {
                                            string content = cells[y].ToString();
                                            //Add the character count of this cell.
                                            if (y < characterCountForColumnTab.Length && columnToggles[y] == true) {
                                                characterCountForColumnTab[y] += content.Length;
                                            }
                                        }
                                    }
                                }

                                //Print the column with characters.
                                int totalCharactersInTab = 0;
                                for (int x = 0; x < characterCountForColumnTab.Length; ++x) {
                                    if (characterCountForColumnTab[x] > 0) {
                                        textBoxOutputs.Text += "        Column[" + COLUMN_LETTER[x] + "] characters: " + characterCountForColumnTab[x] + Environment.NewLine;
                                        totalCharactersInTab += characterCountForColumnTab[x];
                                    }
                                }
                                textBoxOutputs.Text += "        Total characters in tab: " + totalCharactersInTab + Environment.NewLine;
                                totalCharactersInFile += totalCharactersInTab;
                            }
                        }
                    }
                } catch (Exception exception) {
                    textBoxOutputs.Text += "Unable to open file[" + files[i] + "]. Ignore it(" + exception.Message + ")";
                }                

                textBoxOutputs.Text += "Total characters in file: " + totalCharactersInFile + Environment.NewLine;
                totalCharacters += totalCharactersInFile;
            }

            textBoxOutputs.Text += Environment.NewLine;
            textBoxOutputs.Text += "Total characters: " + totalCharacters + Environment.NewLine;
            textBoxOutputs.Text += Environment.NewLine;

            textBoxOutputs.Text += "== " + files.Length + " files scanned ==" + Environment.NewLine;
        }

        private void textBoxOutputs_TextChanged(object sender, EventArgs e) {

        }

        static public bool StringToBool(string str) {
            if (string.Equals(str, "TRUE", System.StringComparison.CurrentCultureIgnoreCase)) {
                return true;
            } else {
                return false;
            }
        }
    }
}
