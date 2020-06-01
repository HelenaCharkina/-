using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
      
      
        static void Main(string[] args)
        {
            string data = ""; // переменная для записи данных файлы .cpp
            string header = ""; // переменная для хранения директив
            Console.WriteLine("Введите путь к файлу .cpp");
            string path = Console.ReadLine(); // путь к файлу .cpp
            using (StreamReader sr = new StreamReader(path)) // считываем полностью файл и сразу удаляем все комментарии
            {
                while (true)
                {
                    var str = sr.ReadLine();
                    if (str == null) break;

                    string patternSingleComment = @"^(\s*)//(\w*)"; // комментарии типа "//"
                    string patternMultiComment = @"^(\s*)/\*(\s*)(\w*)(\s*)\*/"; // комментарии типа "/* */"

                    string patternStartMultiComment = @"(\s*)/\*(\w*)"; // для многострочных комментариев (начало комментария)
                    string patternEndMultiComment = @"(\s*)(\w*)(\s*)\*/"; // для многострочных комментариев (конец комментария)
 
                    if (Regex.IsMatch(str, patternSingleComment) || Regex.IsMatch(str, patternMultiComment))
                    {
                    }
                    else if (Regex.IsMatch(str, patternStartMultiComment))
                    {
                        while (true)
                        {
                            var commentStr = sr.ReadLine();
                            if (Regex.IsMatch(commentStr, patternEndMultiComment)) break;
                        }
                    }
                    else
                    {
                        if (str.Contains("#"))
                        {
                            header += str + "\n";
                        } else
                        {
                            data += str + "\n";
                        }
                        
                    }
                }

            }
           
            // Переименование переменных
           string tmpSymbol = "\"";
            Regex rxForGeneric = new Regex(@"\s*\w*(\s*|\w)<\w*>\s\w*(\s*)(;|\(|=|{)"); // регулярное выражение для типов с дженериками
            Regex rxForVariable = new Regex(@"\s*\w+\s+\w+\s*((=|\(|{)\s*[\w'.\-+*/_\(\)\s" + tmpSymbol + "]*;|;)"); // регулярное выражение для других типов
            
            List<string> variables = new List<string>();
            foreach (var i in rxForVariable.Matches(data))
            {
                if (!i.ToString().Contains("return") && !i.ToString().Contains("namespace"))
                {
                    string variable = i.ToString().Split(" ")[1];
                    variable = Upgrader.Upgrade(variable);
                    variables.Add(variable);
                }
            }
            foreach (var i in rxForGeneric.Matches(data))
            {
                string variable = i.ToString().Split(" ")[2];
                variable = Upgrader.Upgrade(variable);
                variables.Add(variable);
            }

            string result = data;
            foreach (var i in variables)
            {
                string hash = i[0].ToString();
                using (MD5 md5Hash = MD5.Create())
                {
                    hash += HashGenerator.GetMd5Hash(md5Hash, i);
                }
                Regex variableRegex = new Regex(@"\b"+i+@"\b");
                result = variableRegex.Replace(result, hash);
            }
           
            result = Minificator.Minify(result);
            result = header + result;
            Console.WriteLine(result);
        }

       
    }
}
