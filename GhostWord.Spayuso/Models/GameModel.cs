using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GhostWord.Spayuso.Api.Models
{
    public enum GameStatus
    {
        YouWin,
        YouLoose,
        ContinueGame,
    }
    public class GameModel
    {
        public string CurrentWord { get; set; }
        public GameStatus GameStatus { get; set; }

        public GameModel(string currentWord, GameStatus gameStatus)
        {
            this.CurrentWord = currentWord;
            this.GameStatus = gameStatus;
        }
    }
}
