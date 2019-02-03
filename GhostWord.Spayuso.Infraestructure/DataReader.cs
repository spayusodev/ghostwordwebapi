using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GhostWord.Spayuso.Infraestructure
{
    public class DataReader : IDataReader
    {
        private DataDictionary _dataDictionary;

        public DataDictionary DataDictionary
        {
            get { return this._dataDictionary; }
            set { this._dataDictionary = value; }
        }

        public DataReader()
        {
            this.DataDictionary = new DataDictionary();
        }

        public DataDictionary GetDataDictionary(string filePath)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
                

            string line;

            while((line = file.ReadLine()) != null)
            {
                this.DataDictionary.AddNewWordToStructure(line);
            }

            file.Close();

            return this.DataDictionary;
        }

        public DataDictionary GetDataDictionary()
        {
            System.IO.StreamReader file = new System.IO.StreamReader(GetPathToFile("gosthGameDict.txt"));
            string line;

            while((line = file.ReadLine()) != null)
            {
                this.DataDictionary.AddNewWordToStructure(line);
            }

            file.Close();

            return this.DataDictionary;
        }

        private static string GetPathToFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException();
            }

            return (Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/" + fileName);
        }
    }
}
