using System;

namespace CodeForLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            string chisla = "0123456789";
            string otv = "";
            string popi = "";
            int i;
            int b;
            int ch = 0;
            //Компьютер загадывает число.
            Random r = new Random();
            for (i = 0; i <= 3; i++)
            {
                do
                {
                    ch = r.Next(0, 10);
                } while (chisla[ch] == 'a');
                otv = otv + chisla[ch];
                chisla = chisla.Remove(ch, 1).Insert(ch, 'a'.ToString());
            }
            Console.Write("Правильный ответ:"); Console.Write(otv);
            Console.WriteLine();
            chisla = "0123456789";
            do
            {
                b = 0;
                int k = 0;
                popi = Console.ReadLine();
                if (popi.Length != 4)
                {
                    Console.WriteLine("Неверный ввод");
                }
                else if (proverka(popi)!=0)
                {
                    Console.WriteLine("Неверный ввод");
                }
                else if (symb(popi)!=0)
                {
                    Console.WriteLine("Неверный ввод");
                }
                else
                {
                    k = cow(popi, otv);
                    b = bull(popi, otv);
                    Console.Write(k); Console.Write(" Коров "); Console.Write(b); Console.Write(" Быков ");
                    Console.WriteLine();
                }
            } while (b!=4);
            Console.WriteLine("Победа");
            Console.ReadKey();
        }
        static int proverka(string popi)
        {
            int rav=0;
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j<=3; j++)
                {
                    if(i!=j)
                    {
                        if(popi[i] == popi[j])
                        {
                            rav++;
                        }

                    }
                }
            };
            return rav;
        }
        static int cow(string popi, string otv)
        {
            int k = 0;
            for (int i=0; i<=3; i++)
            {
                for (int j=0; j<=3; j++)
                {
                    if(j!=i)
                    {
                        if (popi[i]==otv[j])
                        {
                            k++;
                        }
                    }
                }
            }
            return k;
        }
        static int bull(string popi, string otv)
        {
            int b = 0;
            for(int i=0; i<=3; i++)
            {
                if (popi[i] == otv[i])
                {
                    b++;
                }
            }
            return b;
        }
        static int symb(string popi)
        {
            int sym=0;
            for(int i=0; i<=3;i++)
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