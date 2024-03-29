using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pract6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Random rnd = new Random();
                byte[] data = new byte[10];
                Console.WriteLine("Сохраняем числа в файл \"F.txt\":");
                for (int i = 0; i < data.Length; i++)
                {
                    data[i]=(byte)rnd.Next(256);
                    Console.WriteLine(data[i]);
                }


                FileStream fileStream=new FileStream("F.txt",FileMode.Create,FileAccess.ReadWrite);
                fileStream.Write(data, 0, data.Length);



                Console.WriteLine("Чётные чмсла из файла \"F.txt\":");
                fileStream.Seek(0, SeekOrigin.Begin);
                byte[] fdata = new byte[10];
                for (int i = 0; i < data.Length; i++)
                    fdata[i]=(byte)fileStream.ReadByte();

                for(int i = 0;i < fdata.Length; i++)
                    if (fdata[i] % 2==0)
                        Console.WriteLine(fdata[i]);
            }
            catch(Exception ex)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ResetColor();
            }
        }
    }
}
