using System;

class Program
{
    // This method combines two sorted parts of the array.
    static void Merge(int[] arr, int left, int middle, int right)
    {
        int leftSize = middle - left + 1;
        int rightSize = right - middle;

        int[] leftArray = new int[leftSize];
        int[] rightArray = new int[rightSize];

        // Copy the numbers into two temporary arrays.
        for (int i = 0; i < leftSize; i++)
        {
            leftArray[i] = arr[left + i];
        }

        for (int j = 0; j < rightSize; j++)
        {
            rightArray[j] = arr[middle + 1 + j];
        }

        int leftIndex = 0;
        int rightIndex = 0;
        int arrayIndex = left;

        // Compare the numbers in both temporary arrays.
        while (leftIndex < leftSize && rightIndex < rightSize)
        {
            if (leftArray[leftIndex] <= rightArray[rightIndex])
            {
                arr[arrayIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else
            {
                arr[arrayIndex] = rightArray[rightIndex];
                rightIndex++;
            }

            arrayIndex++;
        }

        // Copy any numbers that are left over.
        while (leftIndex < leftSize)
        {
            arr[arrayIndex] = leftArray[leftIndex];
            leftIndex++;
            arrayIndex++;
        }

        while (rightIndex < rightSize)
        {
            arr[arrayIndex] = rightArray[rightIndex];
            rightIndex++;
            arrayIndex++;
        }
    }

    // This method divides the array into smaller parts.
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;

            MergeSort(arr, left, middle);
            MergeSort(arr, middle + 1, right);

            Merge(arr, left, middle, right);
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Merge Sort Program");
        Console.Write("Enter whole numbers separated by spaces: ");

        string input = Console.ReadLine() ?? "";
        string[] numberStrings = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[numberStrings.Length];

        // Change each string entered by the user into an integer.
        for (int i = 0; i < numberStrings.Length; i++)
        {
            numbers[i] = int.Parse(numberStrings[i]);
        }

        Console.Write("Unsorted array: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();

        MergeSort(numbers, 0, numbers.Length - 1);

        Console.Write("Sorted array: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }

        Console.WriteLine();
    }
}

