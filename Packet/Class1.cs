using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packet
{
    [Serializable]
    public class Packet
    {
    }

    [Serializable]
    public class Message : Packet
    {
        public string message;
    }

    [Serializable]
    public class Question : Packet
    {
        public string Operator;
        public int Operand1;
        public int Operand2;
    }
}
