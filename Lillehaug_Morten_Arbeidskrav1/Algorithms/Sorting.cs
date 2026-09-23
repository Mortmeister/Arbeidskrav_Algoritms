namespace Lillehaug_Morten_Arbeidskrav1.Algorithms;

public class Sorting
{
    public class SortResult
    {
        public int Comparisons { get; set; }
        public int Swaps { get; set; }
    }
    
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
    
    public static SortResult BubbleSort(
     Contact[] arr,
     Phonebook.Field field,
     Phonebook.SortOrder order)
 {
     
     
     int comparisons = 0;
     int swaps = 0;
     
    
             for (int i = 0; i < arr.Length - 1; i++)
             {
                 bool swapped = false;
                 for (int j = 0; j < arr.Length - 1 - i; j++)
                 {
                     comparisons++;
                     if (Compare(arr[j], arr[j + 1], field, order) > 0)
                     {
                         (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                         swaps++;
                         swapped = true;
                     }
                 }
                 if (!swapped) break;  
             }
             return new SortResult()
             {
                 Comparisons = comparisons,
                 Swaps = swaps
             };
     }
 }
    



        
    
