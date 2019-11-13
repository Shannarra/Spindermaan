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

            Console.Write("File to read: ");
            var file = Console.ReadLine();

            Console.Write("Prefered name of the .spindermaan file [filif.spindermaan]:" );
            var oname = Console.ReadLine();
            string name = "";

            if (oname == "" || string.IsNullOrEmpty(oname))
                name = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}" + @"\filif.spindermaan";
            else
                name = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}" + @"\" + oname + ".spindermaan";

            using (StreamReader reader = new StreamReader(file))
                while(!reader.EndOfStream)
                    coll.Add(reader.ReadLine());

            Parser.Run(coll, name);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The file was spindified successfuly! \nPath to file: {name}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
