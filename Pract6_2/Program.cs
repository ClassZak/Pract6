using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pract6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.WriteLine("печатаем символы в файл\"F.txt\":");

            try
            {
                FileStream fileStream = new FileStream("F.txt",FileMode.Create,FileAccess.Write);
                for (int i = 0; i < 10; i++)
                {
                    char ch = ((rand.Next(2)) == 0) ? ((char)rand.Next('A', 'Z' + 1)) : ((char)rand.Next('a', 'z' + 1));
                    Console.Write(ch);
                    fileStream.WriteByte(System.Text.Encoding.UTF8.GetBytes($"{ch}")[0]);
                }
                Console.WriteLine();
                fileStream.Close();
            }
            catch(Exception ex) {Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(ex.Message);Console.ResetColor(); }

            byte upCaseCount = 0;
            Console.WriteLine("Количество больших латинских букв:");
            try
            {
                FileStream fileStream = new FileStream("F.txt", FileMode.Open, FileAccess.Read);
                for (int i = 0; i < 10; i++)
                {
                    char curr = (char)fileStream.ReadByte();
                    if(curr>='A' && curr<='Z')
                        upCaseCount++;
                }
                fileStream.Close();
            }
            catch (Exception ex) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(ex.Message); Console.ResetColor(); }
            Console.WriteLine(upCaseCount);

        }
    }
}
