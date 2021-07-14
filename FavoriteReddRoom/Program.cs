using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoriteReddRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] pname = Process.GetProcessesByName("scpsl");
            if (pname.Length > 0)
            {
                SLRunning();
            }
            else
            {
                Console.WriteLine("SCP:SL is not running, continuing.");
            }

            //Finds the favorite paths and sets them as a variable/string.
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SCP Secret Laboratory/favorites.txt");

            //Favorites.txt check
            if (File.Exists(fileName))
            {
                Console.WriteLine($"The favorites file is there, continuing.");
            }
            else
            {
                Console.WriteLine($"The favorites file is not there. Making the file and continuing.");
                File.Create(fileName).Close();
            }

            //Reads all the text
            string text = File.ReadAllText(fileName);

            //Checks to see if the line is actually there in configs.
            if (text.Contains("172.93.100.104:7783"))
            {
                AlreadyFavorited();
            }
            else
            {
                string DoesNotContain = "The server is not already favorited, continuing.";
                Console.WriteLine(DoesNotContain);
                string WriteLine = "\n172.93.100.104:7783\n172.93.100.104:7784\n172.93.100.104:7785";
                System.IO.File.AppendAllText(fileName, WriteLine);
                Favorited();
            }
        }

        //Used for writing the line and ending the program.
        static void Favorited()
        {
            Console.WriteLine("All the new servers are now favorited! Press any key to close the program.");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
        static void AlreadyFavorited()
        {
            Console.WriteLine("The servers are already favorited! Press any key to close the program.");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
        static void SLRunning()
        {
            Console.WriteLine("SCP:SL is currently running, close it before running the program! Hit any key to close.");
            Console.ReadKey();
            Process.GetCurrentProcess().Kill();
        }
    }
}
