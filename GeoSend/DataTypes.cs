using System;
using System.Net;
namespace GeoSend.Lan
{
    public class DataTypes
    {
        public struct Node
        {
            public bool forward;
            public IPAddress nodeIP;
            public string nodeName;
            public int nodeSerial;
        }
        public struct DataPacket
        {
            public Node endNode;
            public IPAddress nextIP;
            public object dataObject;
        }
    }
}
