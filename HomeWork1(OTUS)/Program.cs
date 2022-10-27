using System;
using System.Text;

namespace HomeWork1_OTUS_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = InputTableDimension();        

            string textTable = InputTextTable(n);
           
            bool isExit = false;

            string texMenu =
                "Введите номер типа строки: \n" +
                "\t 1 - строка с текстом\n" +
                "\t 2 - шахматный порядок\n" +
                "\t 3 - пересечение\n" +
                "\t любое другое число - выход";
            Console.WriteLine(texMenu);


            
            //не совсем понял в каком формате должен быть вывод через switch, но если что, могу и переделать как надо
            while (!isExit)
            {
                bool isGoodChoise;                
                isGoodChoise = int.TryParse(Console.ReadLine(), out int choise);
                if (isGoodChoise)
                {
                    switch (choise)
                    {
                        case 1:
                            PrintBorder(textTable, n);
                            PrintLineText(textTable, n);
                            PrintBorder(textTable, n);
                            break;

                        case 2:
                            PrintBorder(textTable, n);
                            PrintLineChess(textTable, n);
                            PrintBorder(textTable, n);
                            break;

                        case 3:
                            PrintBorder(textTable, n);
                            PrintLineCross(textTable, n);
                            PrintBorder(textTable, n);
                            break;

                            
                        case int a when a < 1 || a > 3:
                            isExit = true;
                            Console.WriteLine("Вы вышли из приложения");
                            break;

                        default:
                            isExit = true;
                            Console.WriteLine("Какая-то ошибка");
                            break;
                    }
                }

            }                           

            Console.ReadLine();
        }


        // Задаем размерность таблицы
        static int InputTableDimension()
        {
            bool isGoodValue;
            int tableDimension;

            //Пример использования do...while
            do
            {
                Console.Write("Введите размерность таблицы (1 .. 6): \t");
                isGoodValue = int.TryParse(Console.ReadLine(), out tableDimension);


                if  (tableDimension <= 0 || tableDimension > 6)
                {
                    Console.WriteLine("Некорректное значение, повторите ввод \n");
                    isGoodValue = false;
                }                 
                
            } while (!isGoodValue);            
            
            return tableDimension;
        }


        //Задаем текст для таблицы
        static string InputTextTable(int n)
        {
            string text;
            bool isOver40;
            do
            {
                Console.Write("Введите произвольный текст:\t");
                text = Console.ReadLine();
                // Плюсуем количество символов в тексте и отступы * 2 чтобы избежать переполнения 40 символов
                isOver40 = text.Length + 2 * n > 40;
                if (isOver40)                
                    Console.WriteLine("Недопустимая ширина таблицы!");                
            } while (string.IsNullOrWhiteSpace(text) || isOver40);
            return text;
        }


        //1 строка
        static void PrintLineText(string text, int n)
        {
            int lengthTable = text.Length + 2 * n;
            int heightTable = 2 * n + 1;           

            for (int i = 0; i < heightTable-2; i++) 
            {
                for (int j = 0; j < lengthTable; j++)
                {
                    if (i == n - 1 && j == n)
                    {
                        Console.Write(text);
                        j += text.Length;
                    }
                    
                    //    Пример использования тернарного оператора
                    string character = j == 0 || j == lengthTable - 1 ? "+" : " ";
                    Console.Write(character);
                }
                Console.WriteLine();                
            }
            
        }

        //2 строка
        static void PrintLineChess(string text, int n)
        {
            int lengthTable = text.Length + 2 * n;
            int heightTable = 2 * n + 1;

            for (int i = 0; i < heightTable - 2; i++)
            {
                for (int j = 0; j < lengthTable; j++)
                {              
                    if (i % 2 == 0 && j % 2 == 0)
                        Console.Write("+");
                    else if (i % 2 != 0 && j % 2 != 0)                    
                        Console.Write("+");                     
                    else 
                        Console.Write(" ");                    
                }
                Console.WriteLine();
            }
            

        }

        //3 строка
        static void PrintLineCross(string text, int n)
        {
            int lengthTable = text.Length + 2 * n;
            int heightTable = 2 * n + text.Length;

            for (int i = 0; i < heightTable; i++)
            {
                for (int j = 0; j < lengthTable; j++)
                {
                    if (j == i || j == lengthTable - i - 1)
                        Console.Write("+");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }           

        }       

        //Построение горизонтальной рамки
        static void PrintBorder(String text, int n)
        {
            int lengthTable = text.Length + 2 * n;            

            StringBuilder border = new StringBuilder();

            for (int j = 0; j < lengthTable; j++)
                border.Append("+");
            Console.WriteLine(border);
        }
    }
}
