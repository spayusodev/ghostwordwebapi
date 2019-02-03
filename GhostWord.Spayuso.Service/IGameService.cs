using System;
using System.Collections.Generic;
using System.Text;
using GhostWord.Spayuso.Infraestructure;

namespace GhostWord.Spayuso.Service
{
    public interface IGameService
    {
        bool StartGame();
        string AddLetter(string newLetter);
    }
}
