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

           
            try
            {
                 using (StreamReader reader = new StreamReader(file))
                                while(!reader.EndOfStream)
                                    coll.Add(reader.ReadLine());
            }
            catch (FileNotFoundException) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The file \"{file}\" cannot be found or does not exist!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Main();
            }
            catch (UnauthorizedAccessException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Access to \"{file}\" denied. Please try again.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Main();
            }
            catch (NotSupportedException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The format \"{file}\" is not supported. Please try again.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Main();
            }
            
            Console.Write("Prefered name of the .spindermaan file [filif.spindermaan]:" );
            var oname = Console.ReadLine();
            string name = "";

            if (oname == "" || string.IsNullOrEmpty(oname))
                name = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}" + @"\filif.spindermaan.txt";
            else
                name = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}" + @"\" + oname + ".spindermaan.txt";

           

            Parser.Run(coll, name);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The file was spindified successfuly! \nPath to file: {name}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
