namespace Lillehaug_Morten_Arbeidskrav1.Algorithms;

public class Sorting
{
    public class SortResult
    {
        public int Comparisons { get; set; }
        public int Swaps { get; set; }
    }
    
    /// <summary>
    /// Compares two Contact objects using the selected field and sort order.
    /// Time complexity: O(1).
    /// Space complexity: O(1).
    /// </summary>
    /// <param name="a">The first Contact.</param>
    /// <param name="b">The second Contact.</param>
    /// <param name="field">The Contact field to compare.</param>
    /// <param name="order">The desired sort order.</param>
    /// <returns>A negative value, zero, or a positive value based on the comparison.</returns>
    
    
    public static int Compare(
        Contact a,
        Contact b,
        Phonebook.Field field,
        Phonebook.SortOrder order)
    {
        int result;
        switch (field)
        {
            case Phonebook.Field.FirstName:
                result = string.Compare(a.FirstName, b.FirstName, StringComparison.OrdinalIgnoreCase);
                break;
            case Phonebook.Field.LastName:
                result = string.Compare(a.LastName, b.LastName, StringComparison.OrdinalIgnoreCase);
                break;
            case Phonebook.Field.Mobile:
                result = a.Mobile.CompareTo(b.Mobile);
                break;
            default:
                throw new ArgumentException("Invalid field.");
        }
        if (order == Phonebook.SortOrder.Descending)
        {
            result = -result;
        }
        return result;
    }
    
    /// <summary>
    /// Sorts an array in-place using the Bubble Sort algorithm.
    /// Time complexity: O(n²) worst case and O(n) best case.
    /// Space complexity: O(1).
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to sort.</param>
    /// <param name="comparison">The comparison function used to determine element order.</param>
    /// <returns>The number of comparisons and swaps performed.</returns>
    
    public static SortResult BubbleSort<T>(
        T[] arr,
        Comparison<T> comparison)
    {
        int comparisons = 0;
        int swaps = 0;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                comparisons++;
                if (comparison(arr[j], arr[j + 1]) > 0)
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    swaps++;
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }

        return new SortResult
        {
            Comparisons = comparisons,
            Swaps = swaps
        };
    }
    
    /// <summary>
    /// Creates a comparison function for Contact objects using the selected field and sort order.
    /// Time complexity: O(1).
    /// Space complexity: O(1).
    /// </summary>
    /// <param name="field">The Contact field to compare.</param>
    /// <param name="order">The desired sort order.</param>
    /// <returns>A comparison function for Contact objects.</returns>
    
    public static Comparison<Contact> GetContactComparison(
        Phonebook.Field field,
        Phonebook.SortOrder order)
    {
        return (a, b) => Compare(a, b, field, order);
    }
 }
    



        
    
