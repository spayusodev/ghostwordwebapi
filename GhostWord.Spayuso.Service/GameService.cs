using System;
using GhostWord.Spayuso.Infraestructure;

namespace GhostWord.Spayuso.Service
{
    public class GameService : IGameService
    {
        private readonly IDataReader _dataReader;
        private readonly IDataFeed _dataFeed;
        private DataDictionary _gameDictionary { get; set; }
        private string _currentWord;

        public String CurrentWord
        {
            get { return this._currentWord; }
            set { this._currentWord = value; }
        }

        public GameService(IDataReader dataFeed)
        {
            this._dataReader = dataFeed;
            this._gameDictionary = this._dataReader.GetDataDictionary();
        }

        public bool StartGame()
        {
            if(this._gameDictionary != null)
            {
                return true;
            }
            return false;
        }

        public string AddLetter(string currentWord)
        {
            this.CurrentWord = currentWord;
            return SelectComputerGameMode();
        }

        
        public string SelectComputerGameMode()
        {
            SingleTree gameTree = this._gameDictionary.GetLastNode(this._currentWord);

            if(gameTree != null)
            {
                SingleTree winner = this.ComputerPlaysToWin(gameTree);

                if(winner != null)
                {
                    this.CurrentWord += winner.TreeNodeLetter;
                }
                else
                {
                    this.CurrentWord += this.ComputerPlaysToGetLongestWord(gameTree).TreeNodeLetter;
                }
            }
            return this.CurrentWord;
        }

        private SingleTree ComputerPlaysToWin(SingleTree nodeToPlay)
        {
            SingleTree winnerNode = null;

            foreach (var child in nodeToPlay.GetChilds().Values)
            {
                if (!child.NodeWithoutChilds())
                {
                    winnerNode = child;

                    foreach (var grandParent in child.GetChilds().Values)
                    {
                        if(!(ComputerPlaysToWin(grandParent) != null || grandParent.NodeWithoutChilds()))
                        {
                            winnerNode = null;
                            break;
                        }
                    }

                    if(winnerNode != null)
                    {
                        break;
                    }
                }
            }
            return winnerNode;
        }

        private SingleTree ComputerPlaysToGetLongestWord(SingleTree nodeToPlay)
        {
            SingleTree winnerNode = null;

            foreach(var child in nodeToPlay.GetChilds().Values)
            {
                if((winnerNode == null) || child.MaximumLength() > winnerNode.MaximumLength())
                {
                    winnerNode = child;
                }
            }
            return winnerNode;
        }

        


    }
}
