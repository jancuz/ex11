using System;
using MyLibrary;

namespace ex11
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = AskData.ReadIntNumber("Введите число k (не менее 2): ", 2, int.MaxValue);
            int[] codingCard = new int[k];      // массив перестановки чисел
            int[] decodingCard = new int[k];    // декодирующая карта

            // ввод перестановки чисел
            for (int i = 0; i < k; i++)
                codingCard[i] = AskData.ReadIntNumber("Введите новую позицию элемента:", 1, k) - 1;

            // формирование декодирующей карты
            for (int i = 0; i < k; i++)
                decodingCard[codingCard[i]] = i;

            Console.WriteLine("Введите слово:");
            string word = Console.ReadLine();   // слово, введенное пользователем
            string codingWord = "";             // закодированное слово
            string decodingWord = "";           // декодированное слово

            if (word.Length % k > 0)
                word = word.PadRight(word.Length + (k % word.Length)); // заполнение слова недостающими пробелами

            int block = word.Length / k;        // кол-во блоков

            for (int i = 0; i < block; i++)     // просмотр каждого блока
            {
                for (int j = 0; j < k; j++)     // просмотр каждого элемента блока
                {
                    codingWord += word[codingCard[j]];    // шифрование по заданной последовательности
                    decodingWord += word[decodingCard[j]];// дешифрование по заданной последовательности
                }
                word = word.Remove(0, k);       // удаление расшифрованного блока
            }

            Console.WriteLine("Зашифрованное слово от заданного: {0}", codingWord);
            Console.WriteLine("Дешифрованное слово от заданного: {0}", decodingWord);

            Console.WriteLine("\nНажмите Enter для завершения работы с программой");
            Console.ReadLine();
        }
    }
}
