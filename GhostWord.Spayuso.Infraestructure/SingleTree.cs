using System;
using System.Collections.Generic;
using System.Linq;



namespace GhostWord.Spayuso.Infraestructure
{
    public class SingleTree : IDataFeed
    {
        private string _treeNode;
        private Dictionary<string, SingleTree> _dataDictionary = new Dictionary<string, SingleTree>();

        public string TreeNodeLetter
        {
            get { return this._treeNode; }
        }

        public SingleTree()
        { }
        
        public SingleTree(string newNode)
        {
            if(newNode.Length > 0 )
            {
                this._treeNode = newNode.GetLetterFromStringPosition(0);
            }
            
            if(newNode.Length > 1)
            {
                this._dataDictionary.Add(newNode.GetLetterFromStringPosition(1),
                    new SingleTree(newNode.Substring(1)));
            }
        }

        
        public void AddNewWordToStructure(string word)
        {
            if(string.Equals(word.GetLetterFromStringPosition(0), this._treeNode))
            {     
                if(!(this._dataDictionary.Count == 0))
                {
                    if(word.Length == 1)
                    {
                        this._dataDictionary.Clear();
                    }
                    else
                    {
                        SingleTree newNode = new SingleTree();

                        if (this._dataDictionary.ContainsKey(word.GetLetterFromStringPosition(1)))
                        {
                            newNode.AddNewWordToStructure(word.Substring(1));
                        }
                        else
                        {
                            this._dataDictionary.Add(word.GetLetterFromStringPosition(1), new SingleTree(word.Substring(1)));
                        }
                    }
                }
            }
        }

        public int  MaximumLength()
        {
            var maxLength = 0;
            var currentLength = 0;

            foreach(var node in this._dataDictionary.Values)
            {
                currentLength = node.MaximumLength();

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }
            }
            return maxLength + 1;
        }

        public bool NodeWithoutChilds()
        {
            using (var dictionaryEnum = this._dataDictionary.GetEnumerator())
            {
                return dictionaryEnum.MoveNext();
            }
        }

        public int NodeWithoutChildsCount()
        {
            return this._dataDictionary.Count(x => x.Value == null);
        }

        public int NodeWithoutChildsFromCurrentNode()
        {
            var nodesWithoutChild = 0;

            if(this.NodeWithoutChilds())
            {
                nodesWithoutChild = 1;
            }
            else
            {
                foreach(var node in this._dataDictionary.Values)
                {
                    nodesWithoutChild += this.NodeWithoutChildsFromCurrentNode();
                }
            }
            return nodesWithoutChild;
        }

        public Dictionary<string, SingleTree> GetChilds()
        {
            return this._dataDictionary;
        }

        public SingleTree GetChild(string node)
        {
            if(!this._dataDictionary.ContainsKey(node))
            {
                return null;
            }
            return this._dataDictionary[node];
        }

        public string GetAnteccesor()
        {
            return this._treeNode;
        }

        
    }
}
