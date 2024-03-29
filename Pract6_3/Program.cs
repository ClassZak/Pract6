using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pract6_3
{
    internal class Program
    {
        const string FILE_NAME = "Text.txt";
        static void Main(string[] args)
        {
            try
            {
                string longestString=string.Empty;
                FileStream fileStream = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fileStream);

                string line;
                while(!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if(line.Length> longestString.Length)
                        longestString = line;
                }

                Console.WriteLine($"Самая длинная строка в файле {FILE_NAME}\n"+longestString);
            }
            catch(FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не найден файл \"Text.txt\"");
                Console.ResetColor();
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
