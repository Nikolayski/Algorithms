using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Test here

        }


        private static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var curr = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = curr;
                    }
                }
            }
        }

        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        var curr = arr[i];
                        arr[i] = arr[j];
                        arr[j] = curr;
                    }
                }
            }
        }

        private static void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        var curr = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = curr;
                    }
                }
            }
        }

        private static void QuickSort(int[] arr, int start, int end)
        {

            if (start < end)
            {
                int p = Partition(arr, start, end);
                QuickSort(arr, start, p - 1);
                QuickSort(arr, p + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];    //1, 5, 4, 11, 20, 8, 2, 98, 90, 16
            int i = start;
            int temp;
            for (int j = start; j < end; j++)
            {
                if (arr[j] <= pivot)
                {

                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                }
            }
            temp = arr[i];
            arr[i] = arr[end];
            arr[end] = temp;
            return i;
        }

        private static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            int middle = arr.Length / 2;
            int[] left = new int[arr.Length / 2];
            int[] right = arr.Length % 2 == 0 ? new int[arr.Length / 2] : new int[arr.Length / 2 + 1];

            Array.Copy(arr, 0, left, 0, middle);
            Array.Copy(arr, middle, right, 0, arr.Length - middle);

            left = MergeSort(left);
            right = MergeSort(right);
            var result = Merge(left.ToList(), right.ToList());
            return result.ToArray();
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right.First());
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            return result;
        }

        // MERGE SORT 2
        private static void Merge2(int[] input, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(input, left, leftArray, 0, middle - left + 1);
            Array.Copy(input, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    input[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    input[k] = leftArray[i];
                    i++;
                }
                else
                {
                    input[k] = rightArray[j];
                    j++;
                }
            }
        }

        private static void MergeSort2(int[] input, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort2(input, left, middle);
                MergeSort2(input, middle + 1, right);

                Merge2(input, left, middle, right);
            }
        }
        private static void CountSort(int[] arr, int maxNumber)    // only counting repeating numbers, but not sort array... Can be modified.
        {
            var result = new int[maxNumber + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                if (result[arr[i]] != 0)
                {
                    result[arr[i]]++;
                }
                else
                {
                    result[arr[i]] = 1;
                }
            }

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"{i} => {result[i]} times.");
            }
        }

        private static int BinarySearchLinear(int[] arr, int searchKey)
        {
            var min = 0;
            var max = arr.Length - 1;  //1 2 3 4 5

            while (min <= max)
            {
                var middle = (min + max) / 2;
                if (arr[middle] == searchKey)
                {
                    return middle;
                }
                else if (arr[middle] < searchKey)
                {
                    min = middle + 1;
                }
                else
                {
                    max = middle - 1;
                }
            }
            return -1;
        }

        private static int BinarySearchRecursevely(int[] arr, int min, int max, int key)
        {
            if (min > max)
            {
                return -1;
            }

            var middle = (min + max) / 2;
            if (arr[middle] == key)
            {
                return middle;
            }
            else if (arr[middle] < key)
            {
                return BinarySearchRecursevely(arr, middle + 1, max, key);
            }
            else
            {
                return BinarySearchRecursevely(arr, 0, middle - 1, key);
            }
        }

    }


}






