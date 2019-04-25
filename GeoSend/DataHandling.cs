using System;
using System.Collections.Generic;
namespace GeoSend.Lan
{
    public class DataHandling
    {
        public object OnRecieve(DataTypes.DataPacket packet, int CurrentNodeSerial, List<DataTypes.Node> closestNodes)
        {
            if(packet.endNode.nodeSerial == CurrentNodeSerial) { return packet.dataObject; }
            foreach(var node in closestNodes)
            {
                if(node.forward == packet.endNode.forward)
                {
                    packet.nextIP = node.nodeIP;
                }
            }
            return packet;
        }
    }
}
