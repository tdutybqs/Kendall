using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kendall
{
    public class Program
    {
        public static void Main()
        {
            int n = 10;
            //Изначальные массивы
            int[] first = new int[] { 10, 9, 1, 2, 7, 3, 6, 4, 5, 8 };
            int[] second = new int[] { 1, 2, 3, 10, 9, 8, 4, 5, 7, 6 };

            //Копии массивов
            int[] first_sort = new int[10];
            for (int i = 0; i< n; i++)
            {
                first_sort[i] = first[i];
            }
            int[] second_sort = new int[10];

            //Отсортированный первый массив
            Array.Sort(first_sort);

            for (int i = 0; i< n; i++)
            {
                second_sort[i] = second[Array.IndexOf(first, first_sort[i])];
            }

            //Массивы для рангов
            int[] first_rank = new int[n];
            int[] second_rank = new int[n];

            //Нахождение рангов
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (second[i] == second_sort[j])
                    {
                        second_rank[i] = second_sort[i];
                    }
                }
            }

            //Массив для Q
            int[] P = new int[n];

            //Счётчик
            int count = 0;

            //Нахождение Q
            for (int i = 0; i< n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (second_rank[i] < second_rank[j])
                    {
                        count++;
                    }
                }
                P[i] = count;
                count = 0;
            }

            //Расчёт корреляции
            double cor = -1 + 4.0 * P.Sum() / (n * (n - 1));
            Console.WriteLine(Math.Round(cor,3));

            Console.ReadKey();
        }
    }
}
