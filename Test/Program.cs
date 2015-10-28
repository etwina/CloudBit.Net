using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            LittleBits.CloudBit cloud = new LittleBits.CloudBit("00e04c223422","fff7a4f43446d73baf5e85b3032ec9963e2be8dcb55848f7dc745873978b92de");
            cloud.SetOutput(90);
        }
    }
}
