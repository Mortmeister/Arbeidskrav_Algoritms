namespace Lillehaug_Morten_Arbeidskrav1.Algorithms;

/// <summary>
/// Provides a generic Merge Sort implementation that sorts an array in place
/// using a temporary buffer during the merge operation.
/// </summary>
public class MergeSort
{
    /// <summary>
    /// Stores the number of comparisons and moves performed during sorting.
    /// </summary>
    public class SortResult
    {
        /// <summary>
        /// Gets or sets the number of element comparisons performed.
        /// </summary>
        public int Comparisons { get; set; }
        /// <summary>
        /// Gets or sets the number of element moves performed.
        /// </summary>
        public int Moves { get; set; }
    }
    /// <summary>
    /// Sorts the specified array using the Merge Sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to sort.</param>
    /// <param name="comparison">
    /// A comparison function that determines the ordering of two elements.
    /// </param>
    /// <returns>
    /// A <see cref="SortResult"/> containing the number of comparisons and moves
    /// performed during the sort.
    /// </returns>
    /// <remarks>
    /// Merge Sort has O(n log n) time complexity in the best, average, and worst
    /// cases. The algorithm uses O(n) additional space for the temporary buffer.
    /// </remarks>Method<T>
    public static SortResult MergeSortMethod<T>(
        T[] arr,
        Comparison<T> comparison)
    {
        int comparisons = 0;
        int moves = 0;

        if (arr.Length <= 1)
        {
            return new SortResult
            {
                Comparisons = comparisons,
                Moves = moves
            };
        }

        T[] temp = new T[arr.Length];

        MergeSortRecursive(
            arr,
            temp,
            0,
            arr.Length - 1,
            comparison,
            ref comparisons,
            ref moves
        );

        return new SortResult
        {
            Comparisons = comparisons,
            Moves = moves
        };
    }

    private static void MergeSortRecursive<T>(
        T[] arr,
        T[] temp,
        int left,
        int right,
        Comparison<T> comparison,
        ref int comparisons,
        ref int moves)
    {
        if (left >= right)
        {
            return;
        }

        int middle = (left + right) / 2;

        MergeSortRecursive(
            arr,
            temp,
            left,
            middle,
            comparison,
            ref comparisons,
            ref moves
        );

        MergeSortRecursive(
            arr,
            temp,
            middle + 1,
            right,
            comparison,
            ref comparisons,
            ref moves
        );

        Merge(
            arr,
            temp,
            left,
            middle,
            right,
            comparison,
            ref comparisons,
            ref moves
        );
    }

    private static void Merge<T>(
        T[] arr,
        T[] temp,
        int left,
        int middle,
        int right,
        Comparison<T> comparison,
        ref int comparisons,
        ref int moves)
    {
        int i = left;
        int j = middle + 1;
        int k = left;

        while (i <= middle && j <= right)
        {
            comparisons++;

            if (comparison(arr[i], arr[j]) <= 0)
            {
                temp[k] = arr[i];
                i++;
            }
            else
            {
                temp[k] = arr[j];
                j++;
            }

            k++;
            moves++;
        }

        while (i <= middle)
        {
            temp[k] = arr[i];
            i++;
            k++;
            moves++;
        }

        while (j <= right)
        {
            temp[k] = arr[j];
            j++;
            k++;
            moves++;
        }

        for (int index = left; index <= right; index++)
        {
            arr[index] = temp[index];
            moves++;
        }
    }
}