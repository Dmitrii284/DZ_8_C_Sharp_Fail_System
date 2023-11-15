
using System.IO;
using static System.Console;
using System.Text.RegularExpressions;
using System;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

/*
 Программа «Анализатор кода»
Прочитать текстC#-программы(выбрать самостоятельно)
и все слова public в объявлении полей классов заменить
на слово private. В исходном коде в каждом слове длиннее
двух символов все строчные символы заменить прописными.
Также в коде программы удалить все «лишние»
пробелы и табуляции, оставив только необходимые для
разделения операторов. Записать символы каждой строки
программы в другой файл в обратном порядке. 
 */
namespace DZ_8_C_Sharp_Fail_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DirectoryInfo dir = new DirectoryInfo("CodeAnalyzer.txt");
            WriteLine($"Full path to the directory:\n{ dir.FullName }");

            // 1) Прочитать текст
            string filePath = @"C:\\Users\\Дмитрий\\source\\repos\\DZ_8_C_Sharp_Fail_System\\DZ_8_C_Sharp_Fail_System\\CodeAnalyzer.txt";
            FileStream fileStream = new FileStream(filePath, FileMode.Open);
           
            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                WriteLine($"Чтение файла: {dir}\n {sr.ReadToEnd()}");                
            }

            // 2) Заменить слова public на private
            using(FileStream fs = new FileStream(filePath, FileMode.Open,FileAccess.ReadWrite, FileShare.Read))
            {

                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    string  writeText = ReadLine();
                    sw.WriteLine(writeText);
                    foreach (var item in writeText)
                    {
                        writeText = writeText.Replace("public", "private");
                        sw.WriteLine(item); 
                    }                  
                   
                }

               

            }
            

            // 3) Применить регулярное выражение для замены строчных символов на прописные
        }
    }
}