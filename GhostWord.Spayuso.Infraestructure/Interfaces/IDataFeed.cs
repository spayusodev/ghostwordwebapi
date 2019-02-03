using System;
using System.Collections.Generic;
using System.Text;

namespace GhostWord.Spayuso.Infraestructure
{
    public interface IDataFeed 
    {
        void AddNewWordToStructure(string word);
        int MaximumLength();
    }
}
