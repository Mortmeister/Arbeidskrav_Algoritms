namespace Lillehaug_Morten_Arbeidskrav1.Algorithms;

public class MergeSort
{
    public class SortResult
    {
        public int Comparisons { get; set; }
        public int Moves { get; set; }
    }
    
    public static SortResult MergeSortMethod(
        Contact[] arr,
        Phonebook.Field field,
        Phonebook.SortOrder order)
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

        Contact[] temp = new Contact[arr.Length];

        MergeSortRecursive(
            arr,
            temp,
            0,
            arr.Length - 1,
            field,
            order,
            ref comparisons,
            ref moves
        );

        return new SortResult
        {
            Comparisons = comparisons,
            Moves = moves
        };
    }
    private static void MergeSortRecursive(
        Contact[] arr,
        Contact[] temp,
        int left,
        int right,
        Phonebook.Field field,
        Phonebook.SortOrder order,
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
            field,
            order,
            ref comparisons,
            ref moves
        );

        MergeSortRecursive(
            arr,
            temp,
            middle + 1,
            right,
            field,
            order,
            ref comparisons,
            ref moves
        );

        Merge(
            arr,
            temp,
            left,
            middle,
            right,
            field,
            order,
            ref comparisons,
            ref moves
        );
    }
    private static void Merge(
        Contact[] arr,
        Contact[] temp,
        int left,
        int middle,
        int right,
        Phonebook.Field field,
        Phonebook.SortOrder order,
        ref int comparisons,
        ref int moves)
    {
        int i = left;
        int j = middle + 1;
        int k = left;

        while (i <= middle && j <= right)
        {
            comparisons++;

            if (Sorting.Compare(arr[i], arr[j], field, order) <= 0)
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