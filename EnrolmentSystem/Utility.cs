using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    internal class Utility
    {
        /// <summary>
        /// Sorts any C# object of Type <T> in ascending order using bubble sort.
        /// </summary>
        /// <typeparam name="T">Type of the objects to be sorted</typeparam>
        /// <param name="array">The array to be sorted</param>
        public static void BubbleSortAscending<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        // Swap array[j] and array[j+1]
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Sorts any C# object of Type <T> in descending order using bubble sort.
        /// </summary>
        /// <typeparam name="T">Type of the objects to be sorted</typeparam>
        /// <param name="array">The array to be sorted</param>
        public static void BubbleSortDescending<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) < 0)
                    {
                        // Swap array[j] and array[j+1]
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
