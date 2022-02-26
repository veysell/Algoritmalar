using System;

namespace Sorted_Algorithms
{
    class Program
    {
        public const int lenght = 100000;
        static int[] NonSorted = new int[lenght];
        static void Main(string[] args)
        {
            Random rnd = new Random();
            #region Sequential Sort
            for (int i = 0; i < lenght; i++)
            {
                NonSorted[i] = rnd.Next(i, lenght);
            }
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (NonSorted[i] < NonSorted[j])
                    {
                        int temp = NonSorted[j];
                        NonSorted[j] = NonSorted[i];
                        NonSorted[i] = temp;
                    }

                }
            }
            foreach (var item in NonSorted)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
