using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.Clear();
                Console.WriteLine("Игра БЫКИ И КОРОВЫ. ЗАДАЧА: отгадать задуманное 4-х значное число.");
                Console.WriteLine("МЕНЮ.");
                Console.WriteLine("1.Новая игра.");
                Console.WriteLine("2.Выход.");
                int n = 0;
                bool result1 = int.TryParse(Console.ReadLine(), out n);
                if (result1 == true && (n == 1 || n == 2))
                {
                    switch (n)
                    {
                        case 1:
                            string chisla = "0123456789";
                            string otv = "";
                            string popi = "";
                            int i;
                            int b;
                            int ch = 0;
                            int kol = 0;
                            //Компьютер загадывает число.
                            Random r = new Random();
                            for (i = 0; i <= 3; i++)
                            {
                                do
                                {
                                    ch = r.Next(0, 10);
                                } while (chisla[ch] == 'a');//чтобы не было повторяющихся чисел 
                                otv = otv + chisla[ch];
                                chisla = chisla.Remove(ch, 1).Insert(ch, 'a'.ToString());
                            }
                            Console.Write("Правильный ответ:"); Console.Write(otv);//вывод правильного ответа
                            Console.WriteLine();
                            chisla = "0123456789";
                            do
                            {
                                b = 0;// быки
                                int k = 0;//коровы
                                popi = Console.ReadLine();
                                if (popi.Length != 4)//количество введенных символов
                                {
                                    Console.WriteLine("Неверный ввод");
                                }
                                else if (proverka(popi) != 0)
                                {
                                    Console.WriteLine("Неверный ввод");
                                }
                                else if (symb(popi) != 0)
                                {
                                    Console.WriteLine("Неверный ввод");
                                }
                                else
                                {
                                    k = cow(popi, otv);
                                    b = bull(popi, otv);
                                    Console.WriteLine("{0} бык(а) и {1} корова(ы)", b, k);
                                    Console.WriteLine();
                                    kol++;
                                }
                            } while (b != 4);
                            Console.WriteLine("Победа!");
                            Console.WriteLine("Количество сделанных ходов:{0}", kol);

                            break;
                        case 2:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Данные введены некорректно.");
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        static int proverka(string popi)//нет ли одинаковых среди введеных
        {
            int rav = 0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (i != j)
                    {
                        if (popi[i] == popi[j])
                        {
                            rav++;
                        }

                    }
                }
            };
            return rav;
        }
        static int cow(string popi, string otv)//проверка количества коров
        {
            int k = 0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (j != i)
                    {
                        if (popi[i] == otv[j])
                        {
                            k++;
                        }
                    }
                }
            }
            return k;
        }
        static int bull(string popi, string otv)//проверка  количество быков
        {
            int b = 0;
            for (int i = 0; i <= 3; i++)
            {
                if (popi[i] == otv[i])
                {
                    b++;
                }
            }
            return b;
        }
        static int symb(string popi)//проверка на цифры
        {
            int sym = 0;
            for (int i = 0; i <= 3; i++)
            {
                if (!Char.IsNumber(popi[i]))
                {
                    sym++;
                }
            }
            return sym;
        }
    }
}
