using System;
using System.Collections.Generic;
using System.Text;

namespace GhostWord.Spayuso.Infraestructure
{
    public class DataDictionary : IDataFeed
    {
        private readonly Dictionary<string, SingleTree> _dataDictionary = new Dictionary<string, SingleTree>();
        

        public void AddNewWordToStructure(string word)
        {
            SingleTree newNode = null;
            if (word.Length >= 4)
            {
                if (this._dataDictionary.ContainsKey(word.GetLetterFromStringPosition(0)))
                {
                    newNode = this._dataDictionary[word.GetLetterFromStringPosition(0)];
                }


                if (newNode == null)
                {
                    this._dataDictionary[word.GetLetterFromStringPosition(0)] = new SingleTree(word);
                }
                else
                {
                    newNode.AddNewWordToStructure(word);
                }
            }
        }

        /// <summary>
        /// Only for test purposes
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            int count = 0;
            foreach(var node in this._dataDictionary.Values)
            {
                count += node.NodeWithoutChildsCount();
            }
            return count;
        }
                
        public int MaximumLength()
        {
            int maxLength = 0;
            
            foreach(var node in this._dataDictionary.Values)
            {
                if(node.MaximumLength() > maxLength)
                {
                    maxLength = node.MaximumLength();
                }
            }
            return maxLength;
        }

        public SingleTree GetLastNode(string wordToFindLastNode)
        {
            SingleTree node;
            if(this._dataDictionary.ContainsKey(wordToFindLastNode.GetLetterFromStringPosition(0)))
            {
                node = this._dataDictionary[wordToFindLastNode.GetLetterFromStringPosition(0)];
                
                for(int count = 0; count < wordToFindLastNode.Length; count++)
                {

                    node = node.GetChild(wordToFindLastNode.GetLetterFromStringPosition(count));

                    if (node == null)
                    {
                        break;
                    }
                }
                return node;
            }
            return null;
        }
    }
}
