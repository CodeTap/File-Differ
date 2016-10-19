using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        private int NUM_OF_LINES_DICTIONARY = 4000000;

        private string m_strFileToCompare;
        private string m_strFileToCompareAgainst;
        private string m_strDirectoryOutputTo;
        private OpenFileDialog openFileDialog;
        private FolderBrowserDialog folderBrowserDialog1;

        StreamWriter logWriter;
        StreamWriter diffLeftWriter;
        StreamWriter diffRightWriter;

        public Form1()
        {
            InitializeComponent();
        }

        /*  Name: file1_Browse()
         *  Desc: Generates an open file dialog box and waits for user selection.
         *        once the file is selected it sets it to the text box's variable
         *        in the UI and sets it to fileToCompare
         *  
         * 
         */
        private void file1_Browse(object sender, EventArgs e)
        {
            int num = -1;

            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.m_strFileToCompare = openFileDialog.FileName;
                try
                {
                    this.textBox1.Text = this.m_strFileToCompare;
                }
                catch (IOException)
                {
                }
            }
        }


        private void file2_Browse(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = this.openFileDialog.FileName;
                this.m_strFileToCompareAgainst = fileName;
                try
                {
                    this.textBox2.Text = fileName;
                }
                catch (IOException)
                {
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.m_strDirectoryOutputTo = this.folderBrowserDialog1.SelectedPath;
                try
                {
                    this.textBox3.Text = this.m_strDirectoryOutputTo;
                }
                catch (IOException)
                {
                }
            }
        }

        private void StartDiff(object sender, EventArgs e)
        {
            string str;
           
            int num = 0;

            // Create a dictionary for our initial data set ~ 4000000 lines of a file
            // NOTE: This may need to be tweaked based on text file type. But for our
            //       initial usage of this application it works.
            Dictionary<int, Dictionary<string, int>> allDictionaries = new Dictionary<int, Dictionary<string, int>>();

            // Create our initial dictionary for Line Conetent and Line number
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            // Assign the loggers to their own files
            logWriter = new StreamWriter(this.m_strDirectoryOutputTo + "\\DifferLog.txt");
            diffLeftWriter = new StreamWriter(this.m_strDirectoryOutputTo + "\\DiffLeft.txt");
            diffRightWriter = new StreamWriter(this.m_strDirectoryOutputTo + "\\DiffRight.txt");

            // Here is where we do the file 1 to file 2 comparrison
            doDictionaryAdd(ref dictionary, ref allDictionaries, this.m_strFileToCompareAgainst);
            diffLeftWriter.WriteLine("Lines in {0} not in {1}\n", m_strFileToCompare, m_strFileToCompareAgainst);
            diffLeftWriter.WriteLine("\n");
            doCompare(ref dictionary, ref allDictionaries, ref diffLeftWriter, this.m_strFileToCompare);
          
            // We need to reinitialize our dictionary here, as well as clear our dictionary of dictionaries
            dictionary = new Dictionary<string, int>();
            allDictionaries.Clear();


            // Here is where we do the file 2 to file 1 comparrison
            doDictionaryAdd(ref dictionary, ref allDictionaries, this.m_strFileToCompare);
            diffRightWriter.WriteLine("Lines in {0} not in {1}\n", m_strFileToCompareAgainst, m_strFileToCompare);
            diffRightWriter.WriteLine("\n");
            doCompare(ref dictionary, ref allDictionaries, ref diffRightWriter, this.m_strFileToCompareAgainst);

            // Clear the dictionary one last time
            dictionary.Clear();
            allDictionaries.Clear();
             
            MessageBox.Show("Diff Has Ended");

            closeResources(logWriter, diffLeftWriter, diffRightWriter);
        }

        private void doDictionaryAdd(ref Dictionary<String,int> dictionary, ref Dictionary<int,Dictionary<String,int>> allDictionaries, String readFilePath)
        {
            StreamReader reader = new StreamReader(readFilePath);

            int num = 0;
            int dictionaryKey = 0;
            String str = "";

            while ((str = reader.ReadLine()) != null)
            {
                num++;

                try
                {
                    // If the line number divided our number of dictionaries is equal to our
                    // constant for number of lines before we clear our dictionary and start again 
                    if ((num / (dictionaryKey + 1)) == NUM_OF_LINES_DICTIONARY)
                    {
                        // Addd our current dictionary to the list of all dictionaries
                        allDictionaries.Add(dictionaryKey, dictionary);

                        // Assign our single use dictionary
                        dictionary = new Dictionary<string, int>();
                        dictionaryKey++;

                        // Log that we have gone over our limit of the constant and continue
                        logWriter.WriteLine("New Dictionary Created due to current line number being a multiple of {0}", NUM_OF_LINES_DICTIONARY);

                    }

                    dictionary.Add(str, 1);

                }
                catch (Exception ex)
                {
                    logWriter.WriteLine("Failed to add line {0}, string {1} (Exception Occurred: HelpLink = {2} , Message = {3}, Source = {4}, StackTrace = {5}, TargetSite = {6})", num, str, ex.HelpLink, ex.Message, ex.Source, ex.StackTrace, ex.TargetSite);
                }

            }

            // We need to add our final dictionary to our list of dictionaries since we didnt
            // add it within the loop
            allDictionaries.Add(dictionaryKey, dictionary);

            reader.Close();
        }

        private void doCompare(ref Dictionary<String, int> dictionary, ref Dictionary<int, Dictionary<String, int>> allDictionaries, ref StreamWriter writer, String fileToRead)
        {
            StreamReader reader2 = new StreamReader(fileToRead);
            int num = 0;
            String str = "";

            while ((str = reader2.ReadLine()) != null)
            {
                num++;

                var coll = allDictionaries.Values;
                bool tFound = false;
                foreach (var dic in coll)
                {
                    // if the dictionary does not contain the key it is not found we want to
                    // output this to our file for found in 1 but not the other with the line number
                    if (dic.ContainsKey(str))
                    {
                        tFound = true;
                        break;
                    }
                }

                if (tFound == false)
                {
                    string strOut;
                    strOut = str + " , " + num;
                    writer.WriteLine(strOut);
                }
            }

            reader2.Close();

            // Add some lines for some spacing
            writer.WriteLine("\n");
            writer.WriteLine("\n");

        }

        private void closeResources(StreamWriter writer1, StreamWriter writer2, StreamWriter writer3)
        {
            writer1.Close();
            writer2.Close();
            writer3.Close();
        }

    }// End of Form1

}
