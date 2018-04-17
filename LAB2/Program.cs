using System;

namespace LAB2
{
    class Program
    {

        static void Main(string[] args)
        {
            string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            do
            {
                Console.Clear();
                Console.WriteLine("Программа Шифр Цезаря для зашифровки и расшифровки текста на РУССКОМ ЯЗЫКЕ.");
                Console.WriteLine("МЕНЮ.");
                Console.WriteLine("1.Зашифровка.");
                Console.WriteLine("2.Расшифровка.");
                Console.WriteLine("3.Выход.");
                int k;
                bool res = int.TryParse(Console.ReadLine(), out k);
                if (res == true && (k == 1 || k == 2 || k == 3))
                {
                    switch (k)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("Введите сообщение: ");
                            string original_message = Console.ReadLine();
                            Console.Write("Введите ключ: ");
                            int key;
                            res = int.TryParse(Console.ReadLine(), out key);
                            if (res == true && key >= 0)
                            {
                                Console.WriteLine("Зашифрованное сообщение: " + encryption(original_message, Alphabet, key));
                            }

                            else
                            {
                                Console.WriteLine("Данные введены некорректно.");
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.Write("Зашифрованноe сообщение: ");
                            string encrypted_message = Console.ReadLine();
                            decryption(encrypted_message, Alphabet);
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Ошибка!");
                            break;
                    }
                    Console.WriteLine("\n\nДля продолжения нажмите любую клавишу...");
                    Console.ReadLine();
                }
            } while (true);




        }
        static string encryption(string message, string alphabet, int key)
        {
            string result = "";
            int m = alphabet.Length;
            for (int i = 0; i < message.Length; i++)//перебор каждой буквы
            {
                if (alphabet.IndexOf(message[i]) > -1)//проверка символа в алфавите
                {
                    for (int j = 0; j < alphabet.Length; j++)//находим симол в алфавите
                    {
                        if (message[i] == alphabet[j])
                        {
                            int temp = (j + key) % m;
                            result = result + alphabet[temp];//добавление нового символа в строку
                        }
                    }
                }
                else
                    result = result + message[i];
            }
            return result;
        }

        static void decryption(string message, string alphabet)
        {
            string result;
            int m = alphabet.Length;
            int key = 0;
            Console.WriteLine();

            do
            {
                result = "";
                for (int i = 0; i < message.Length; i++)
                {
                    if (alphabet.IndexOf(message[i]) > -1)
                    {
                        for (int j = 0; j < alphabet.Length; j++)
                        {
                            if (message[i] == alphabet[j])
                            {
                                int temp = (j - key + m) % m;
                                result = result + alphabet[temp];
                            }
                        }
                    }
                    else
                        result = result + message[i];
                }
                Console.WriteLine("ROT{0}  {1}", key, result);
                key = key + 1;
            } while (key <= alphabet.Length);//пока не закончится перебор букв
        }
    }
}
