namespace Lillehaug_Morten_Arbeidskrav1.Algorithms;
/// <summary>
/// Provides a generic Binary Search implementation for searching sorted arrays.
/// </summary>
public class BinarySearch
{
    /// <summary>
    /// Stores the result of a binary search, including the found index
    /// and the number of comparisons performed.
    /// </summary>
    public class SearchResult
    {
        /// <summary>
        /// Gets or sets the index of the first matching element.
        /// Returns -1 if the target is not found.
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// Gets or sets the number of comparisons performed during the search.
        /// </summary>
        public int Comparisons { get; set; }
    }
    /// <summary>
    /// Searches a sorted array using the Binary Search algorithm.
    /// If multiple elements match the target, the index of the first occurrence
    /// is returned.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">
    /// The array to search. The array must be sorted in ascending order
    /// according to the same comparison used by <paramref name="compare"/>.
    /// </param>
    /// <param name="compare">
    /// A function that compares an element with the search target.
    /// It should return 0 when the element matches the target, a value less
    /// than 0 when the element is smaller than the target, and a value greater
    /// than 0 when the element is greater than the target.
    /// </param>
    /// <returns>
    /// A <see cref="SearchResult"/> containing the index of the first matching
    /// element, or -1 if the target is not found, together with the number of
    /// comparisons performed.
    /// </returns>
    /// <remarks>
    /// Binary Search has O(log n) time complexity in the average and worst cases
    /// and O(1) best-case time complexity. It uses O(1) additional space.
    /// </remarks>
    public static SearchResult BinarySearchMethod<T>(
        T[] arr,
        Func<T, int> compare)
    {
        int left = 0;
        int right = arr.Length - 1;
        int comparisons = 0;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;
            comparisons++;
            int result = compare(arr[middle]);
            if (result == 0)
            {
                int firstIndex = middle;
                right = middle - 1;
                while (left <= right)
                {
                    int newMiddle = left + (right - left) / 2;
                    comparisons++;
                    int newResult = compare(arr[newMiddle]);
                    if (newResult == 0)
                    {
                        firstIndex = newMiddle;
                        right = newMiddle - 1;
                    }
                    else if (newResult < 0)
                    {
                        left = newMiddle + 1;
                    }
                    else
                    {
                        right = newMiddle - 1;
                    }
                }
                return new SearchResult
                {
                    Index = firstIndex,
                    Comparisons = comparisons
                };
            }
            if (result < 0)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }
        return new SearchResult
        {
            Index = -1,
            Comparisons = comparisons
        };
    }
}