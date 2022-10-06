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
            for (int i = 0; i < mas1.GetLength(0); i++)
            {
                for (int j = 0; j < mas2.GetLength(1); j++)
                {
                    int _i = i;
                    int _j = j;
                    Task task = new Task(() =>
                    {
                        for (int k = 0; k < mas2.GetLength(0); k++)
                        {
                           
                            ish[_i, _j] += mas1[_i, k] * mas2[k, _j];
                        }
                    });

                    task.Start();
                }
            }
            Thread.Sleep(500);                     
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
