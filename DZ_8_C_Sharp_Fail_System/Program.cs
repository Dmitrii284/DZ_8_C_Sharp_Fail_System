
using System.IO;
using static System.Console;
using System.Text.RegularExpressions;
using System;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

///*
// Программа «Анализатор кода»
//Прочитать текстC#-программы(выбрать самостоятельно)
//и все слова public в объявлении полей классов заменить
//на слово private. В исходном коде в каждом слове длиннее
//двух символов все строчные символы заменить прописными.
//Также в коде программы удалить все «лишние»
//пробелы и табуляции, оставив только необходимые для
//разделения операторов. Записать символы каждой строки
//программы в другой файл в обратном порядке. 
// */
//namespace DZ_8_C_Sharp_Fail_System
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello, World!");
//            DirectoryInfo dir = new DirectoryInfo("CodeAnalyzer.txt");
//            WriteLine($"Full path to the directory:\n{ dir.FullName }");

//            // 1) Прочитать текст
//            string filePath = @"C:\\Users\\Дмитрий\\source\\repos\\DZ_8_C_Sharp_Fail_System\\DZ_8_C_Sharp_Fail_System\\CodeAnalyzer.txt";
//            FileStream fileStream = new FileStream(filePath, FileMode.Open);

//            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
//            {
//                WriteLine($"Чтение файла: {dir}\n {sr.ReadToEnd()}");                
//            }

//            // 2) Заменить слова public на private
//            using(FileStream fs = new FileStream(filePath, FileMode.Open,FileAccess.ReadWrite, FileShare.Read))
//            {

//                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
//                {
//                    string  writeText = ReadLine();
//                    sw.WriteLine(writeText);
//                    foreach (var item in writeText)
//                    {
//                        writeText = writeText.Replace("public", "private");
//                        sw.WriteLine(item); 
//                    }                  

//                }



//            }


//            // 3) Применить регулярное выражение для замены строчных символов на прописные
//        }
//    }
//}

//using System;
//using System.IO;
//using System.Text.RegularExpressions;

namespace SimpleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\\Users\\Дмитрий\\source\\repos\\DZ_8_C_Sharp_Fail_System\\DZ_8_C_Sharp_Fail_System\\CodeAnalyzer.txt";
            string newFilePath = @"C:\\Users\\Дмитрий\\source\\repos\\DZ_8_C_Sharp_Fail_System\\DZ_8_C_Sharp_Fail_System\\NewCodeAnalyzer.txt";

            // 1) Прочитать текст
            string text = File.ReadAllText(filePath);
            DirectoryInfo dir = new DirectoryInfo("CodeAnalyzer.txt");
            WriteLine($"Full path to the directory:\n{dir.FullName}");            

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                WriteLine($"\n\nЧтение исходного файла: {dir}\n {sr.ReadToEnd()}");
            }
            // 2) Заменить слова public на private
            text = text.Replace("public", "private");            
            WriteLine($"\n\nЗаменить слова public на private:\n{text}");
            
            // 3) Применить регулярное выражение для замены строчных символов на прописные
            text = Regex.Replace(text, @"\b\w{3,}\b", match => match.Value.ToUpper());
            WriteLine($"\n\nПрименить регулярное выражение для замены строчных символов на прописные:\n{text}");

            // 4) Удалить все пробелы и табуляции
            text = Regex.Replace(text, @"\s+", "");
            WriteLine($"\n\nУдалить все пробелы и табуляции:\n{text}");

            // 5) Записать символы каждой строки в другой файл в обратном порядке
            using (StreamWriter writer = new StreamWriter(newFilePath))
            {
                string[] lines = text.Split('\n');
                foreach (string line in lines)
                {
                    char[] charArray = line.ToCharArray();
                    Array.Reverse(charArray);
                    writer.WriteLine(new string(charArray));
                }
                
            }
            DirectoryInfo newDir = new DirectoryInfo("NewCodeAnalyzer.txt");
            WriteLine($"\n\nFull path to the directory:\n{newDir.FullName}");
            using (StreamReader sr = new StreamReader(newFilePath, Encoding.UTF8))
            {
                WriteLine($"\n\nЗаписать символы каждой строки в другой файл в обратном порядке: {newDir}\n {sr.ReadToEnd()}");
            }

            Console.WriteLine("Text processing complete. Check the new file for the results.");
        }
    }
}