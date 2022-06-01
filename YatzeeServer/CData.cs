using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace YatzeeServer
{
    class CData  //is automatically a descendent of object
    {
        public NetworkStream ConnStream;
        public Socket TheSocket;
        public bool Connected;
        public int which;
        public int gameID;
    }
}
