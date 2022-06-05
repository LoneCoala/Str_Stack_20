using System;
using System.Collections.Generic;
using System.IO;

namespace Str_Stack_20
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\tjuri\source\repos\Str_Stack_20\Str_Stack_20\TextFile1.txt"; // путь файла
            StreamReader sr = File.OpenText(path); 
            Queue<int> div5 = new Queue<int> { }; // создаем очереди под каждый вид чисел
            Queue<int> oddNot5 = new Queue<int> { }; //
            Queue<int> EvenNot5 = new Queue<int> { }; //
            string s;
            while ((s = sr.ReadLine()) != null) // пока файл не закончится
            {
                string parsToInt = "";
                for (int i = 0; i < s.Length; i++) // пока строка не закончится
                {
                    int num;
                    if ((i+1) < s.Length)
                    {
                        if ((s[i+1] != ' ') || s[i+1] != '\n') // пока можем записываем число
                        {
                            parsToInt += s[i];
                        }
                        if ((s[i + 1] == ' ') || s[i + 1] == '\n') // если встречаем пробел или переход на новую строку записываем число
                        {
                            if (int.TryParse(parsToInt, out num)) // преобразуем в число и записываем в соответсвующую очередь
                            {
                                if (num % 5 == 0)
                                {
                                    div5.Enqueue(num);
                                }
                                if ((num % 5 != 0) && (num % 2 == 0))
                                {
                                    EvenNot5.Enqueue(num);
                                }
                                if ((num % 5 != 0) && (num % 2 != 0))
                                {
                                    oddNot5.Enqueue(num);
                                }
                            }
                            parsToInt = "";
                        }
                    }

                }
            }

            while (div5.Count > 0) // вывод чисел из очередей
            {
                Console.Write(div5.Dequeue() + " ");
            }
            Console.WriteLine();
            while (oddNot5.Count > 0)
            {
                Console.Write(oddNot5.Dequeue() + " ");
            }
            Console.WriteLine();
            while (EvenNot5.Count > 0)
            {
                Console.Write(EvenNot5.Dequeue() + " ");
            }
        }
    }
}
