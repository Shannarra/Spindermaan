using System;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace Spinderman3
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            StringCollection coll = new StringCollection();

            using (StreamReader reader = new StreamReader(@"..\..\test.txt"))
                while(!reader.EndOfStream)
                    coll.Add(reader.ReadLine());

           Parser.Run(coll);
        }
    }
}
