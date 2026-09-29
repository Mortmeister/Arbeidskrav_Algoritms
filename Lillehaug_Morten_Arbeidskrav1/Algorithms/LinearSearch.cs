namespace Lillehaug_Morten_Arbeidskrav1.Algorithms;

public class LinearSearch
{
    public class LinearSearchResult<T>
    {
        public T[] Results { get; set; }
        public int Comparisons { get; set; }
    }

    /// <summary>
    /// Searches an array sequentially for all elements matching the target condition.
    /// Time complexity: O(n).
    /// Space complexity: O(n) in the worst case.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to search.</param>
    /// <param name="matches">A function that determines whether an element matches.</param>
    /// <returns>All matching elements and the number of comparisons performed.</returns>
    public static LinearSearchResult<T> LinearSearchMethod<T>(
        T[] arr,
        Func<T, bool> matches)
    {
        List<T> results = new List<T>();
        int comparisons = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            comparisons++;
            if (matches(arr[i]))
            {
                results.Add(arr[i]);
            }
        }

        return new LinearSearchResult<T>
        {
            Results = results.ToArray(),
            Comparisons = comparisons
        };
    }
}