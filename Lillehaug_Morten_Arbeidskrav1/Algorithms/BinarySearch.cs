namespace Lillehaug_Morten_Arbeidskrav1.Algorithms;

public class BinarySearch
{
    public class SearchResult
    {
        public int Index { get; set; }
        public int Comparisons { get; set; }
    }

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