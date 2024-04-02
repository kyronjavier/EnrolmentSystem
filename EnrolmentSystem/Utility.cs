using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrolmentSystem
{
    public class Utility
    {
        /// <summary>
        /// Performs a sequential search through the array to find the target element.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the array</typeparam>
        /// <param name="array">The array to be searched</param>
        /// <param name="target">The target element to search for</param>
        /// <returns>The index of the target element if found, otherwise -1</returns>
        public static int LinearSearchArray<T>(T[] array, T target) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(target))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Performs a binary search through the sorted array to find the target element.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the array</typeparam>
        /// <param name="array">The sorted array to be searched</param>
        /// <param name="target">The target element to search for</param>
        /// <returns>The index of the target element if found, otherwise -1</returns>
        public static int BinarySearchArray<T>(T[] array, T target) where T : IComparable<T>
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (right + left) / 2;

                if (array[mid].Equals(target))
                    return mid;

                if (array[mid].CompareTo(target) < 0)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }

        /// <summary>
        /// Sorts any C# object of Type <T> in ascending order using bubble sort.
        /// </summary>
        /// <typeparam name="T">Type of the objects to be sorted</typeparam>
        /// <param name="array">The array to be sorted</param>
        public static void BubbleSortAscending<T>(T[] array, Func<T, T, int> comparer) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer(array[j], array[j + 1]) > 0)
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
        public static void BubbleSortDescending<T>(T[] array, Func<T, T, int> comparer) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer(array[j], array[j + 1]) < 0)
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
