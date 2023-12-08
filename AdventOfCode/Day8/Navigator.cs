using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal class Navigator
    {
        private IEnumerable<string> _lines;
        private List<Node> _nodes;

        public Navigator(IEnumerable<string> lines)
        {
            _lines = lines;
            _nodes = new List<Node>();
        }

        public void ProcessData()
        {
            foreach (string line in _lines)
            {
                _nodes.Add(new Node
                {
                    Id = line.Substring(0, 3),
                    LeftNodeId = line.Substring(7,3),
                    RightNodeId = line.Substring(12,3)
                });
            }
        }

        public int navigateNodes(string instructions)
        {
            var steps = 0;
            var navigationPointer = 0;
            var currentNode = _nodes.First(x => x.Id == "AAA");

            //might need to repeat the steps instructions
            while (currentNode.Id != "ZZZ")
            {
                switch (instructions[navigationPointer])
                { 
                    case 'R':
                        currentNode = _nodes.First(x => x.Id == currentNode.RightNodeId);
                        break;
                    case 'L':
                        currentNode = _nodes.First(x => x.Id == currentNode.LeftNodeId);
                        break;
                }
                steps++;
                if (instructions.Length - 1 > navigationPointer)
                {
                    navigationPointer++;
                }
                else
                {
                    navigationPointer = 0;
                }
            }

            return steps;
        }
    }

    internal class Node
    {
        public string Id;
        public string LeftNodeId;
        public string RightNodeId;
    }
}
