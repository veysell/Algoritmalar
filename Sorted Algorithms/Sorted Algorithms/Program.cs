using System;
using System.Diagnostics;

namespace Sorted_Algorithms
{

    class Program
    {
        public const int lenght = 100000;
        static int[] NonSorted = new int[lenght];

        static int[] SequentialSort(int[] array)
        {

            int lenght = array.Length;
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (array[i] < array[j])
                    {
                        int temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
            return array;
        }

        static int[] BubbleSort(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        #region Heap Sort
        public class HeapSort
        {
            public void sort(int[] arr)
            {
                int n = arr.Length;


                for (int i = n / 2 - 1; i >= 0; i--)
                    maxHeap(arr, n, i);


                for (int i = n - 1; i > 0; i--)
                {

                    int temp = arr[0];
                    arr[0] = arr[i];
                    arr[i] = temp;


                    maxHeap(arr, i, 0);
                }
            }

            void maxHeap(int[] arr, int n, int i)
            {
                int MaxNode = i;
                int LeftNode = 2 * i + 1;
                int rightNode = 2 * i + 2;


                if (LeftNode < n && arr[LeftNode] > arr[MaxNode])
                    MaxNode = LeftNode;


                if (rightNode < n && arr[rightNode] > arr[MaxNode])
                    MaxNode = rightNode;


                if (MaxNode != i)
                {
                    int swap = arr[i];
                    arr[i] = arr[MaxNode];
                    arr[MaxNode] = swap;

                    maxHeap(arr, n, MaxNode);
                }
            }

        }
        #endregion 


        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Random rnd = new Random();
            #region Dizi Elemanlarla Dolduruldu
            for (int i = 0; i < lenght; i++)
            {
                NonSorted[i] = rnd.Next(i, lenght);
            }
            #endregion

            /*
            sw.Start();
            SequentialSort(NonSorted);
            sw.Stop();
            */

            sw.Start();
            BubbleSort(NonSorted);
            sw.Stop();

            /*
            sw.Start();
            HeapSort ob = new HeapSort();
            ob.sort(NonSorted);
            sw.Stop();
            */
            #region Sıralanmış Dizi ve Süre Ekrana Yazdırıldı
            foreach (var item in NonSorted)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("ne kadar sürdü: " + sw.Elapsed);
            #endregion

        }
    }
}
