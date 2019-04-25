using System;
using System.Net;
using System.Collections.Generic;
namespace GeoSend.Lan
{
    public class LANMap
    {
        public List<DataTypes.Node> ReturnNodes(List<DataTypes.Node>nodeList, string currentNodeName)
        {
            var returnData = new List<DataTypes.Node>();
            var nodeInProgress = new DataTypes.Node();
            var names = new string[2048];
            int count=0, forward=0, backward=0;
            string forwardNode, backwardNode;
            foreach (var nodeToSearch in nodeList)
            {
                names[count] = nodeToSearch.nodeName;
                count++;
            }
            count = 0;
            
            foreach(string check in names)
            {
                if (check.Equals(currentNodeName)){
                    forward = count + 1;
                    backward = count - 1;
                }
                count++;
            }
            forwardNode = names[forward];
            backwardNode = names[backward];
            foreach(var nodeToSearch in nodeList)
            {
                if (nodeToSearch.nodeName.Equals(forwardNode))
                {
                    nodeInProgress = nodeToSearch;
                    nodeInProgress.forward = true;
                    returnData.Add(nodeInProgress);
                }
                else if (nodeToSearch.nodeName.Equals(backwardNode))
                {
                    nodeInProgress = nodeToSearch;
                    nodeInProgress.forward = false;
                    returnData.Add(nodeInProgress);
                }
            }
            return returnData;
        }
        public List<DataTypes.Node> ReturnNodes(List<DataTypes.Node> nodeList, int currentNodeSerial)
        {
            var returnData = new List<DataTypes.Node>();
            var nodeInProgress = new DataTypes.Node();
            foreach (var nodeToSearch in nodeList)
            {
                int nodeCheck = nodeToSearch.nodeSerial - currentNodeSerial;
                if (nodeCheck == -1)
                {
                    nodeInProgress = nodeToSearch;
                    nodeInProgress.forward = true;
                    returnData.Add(nodeInProgress);
                }
                else if (nodeCheck == 1)
                {
                    nodeInProgress = nodeToSearch;
                    nodeInProgress.forward = false;
                    returnData.Add(nodeInProgress);
                }
            }
            return returnData;
        }
    }
}