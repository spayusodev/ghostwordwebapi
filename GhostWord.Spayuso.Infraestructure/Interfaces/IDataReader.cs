using System;
using System.Collections.Generic;
using System.Text;

namespace GhostWord.Spayuso.Infraestructure
{
    public interface IDataReader
    {
        DataDictionary GetDataDictionary(string fileName);
        DataDictionary GetDataDictionary();
    }
}
