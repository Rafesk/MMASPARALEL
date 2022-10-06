using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace MASYMN
{
    internal class Program
    {
        public int YMAS(int size, int[,] mas1, int[,] mas2, int i, int j)
        {
            int chs = 0;
            for (int k = 0; k < size; k++)
            {
                chs += mas1[i, k] * mas2[k, j];
            }
            return chs;
        }
        

        static void Main(string[] args)
        {
            var rand = new Random();
            Console.WriteLine("Введите размер первого массива: ");
            int size1_mas1 = Convert.ToInt32(Console.ReadLine());
            //int size2_mas1 = Convert.ToInt32(Console.ReadLine());
            int[,] mas1 = new int[size1_mas1,size1_mas1];
            for (int i = 0; i < size1_mas1; i++)
            {
                for (int j = 0; j < size1_mas1; j++)
                {
                    mas1[i, j] = rand.Next(1, 10);
                }
            }
            Console.WriteLine("Введите размер второго массива: ");
            int size1_mas2 = Convert.ToInt32(Console.ReadLine());
            //int size2_mas2 = Convert.ToInt32(Console.ReadLine());
            int[,] mas2 = new int[size1_mas2,size1_mas2];
            for (int i = 0; i < size1_mas2; i++)
            {
                for (int j = 0; j < size1_mas2; j++)
                {
                    mas2[i, j] = rand.Next(1, 10);
                }
            }



            int[,] ish = new int[size1_mas1,size1_mas2];
            for (int i = 0; i < ish.GetLength(0); i++)
            {
                for (int j = 0; j < ish.GetLength(1); j++)
                {
                    Thread t1 = new Thread(() =>
                    {
                        for (int k = 0; k < size1_mas1; k++)
                        {
                            ish[i, j] += mas1[i, k] * mas2[k, j];
                        }
                    });
                    t1.Start();
                   
                }
            }
            for (int i = 0; i < ish.GetLength(0); i++)
            {
                for (int j = 0; j < ish.GetLength(1); j++)
                {
                    Console.Write(ish[i,j]+ " ");
                }
                Console.WriteLine();
            }
        }
    }
}
