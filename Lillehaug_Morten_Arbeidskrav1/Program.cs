using Lillehaug_Morten_Arbeidskrav1;
using Lillehaug_Morten_Arbeidskrav1.Algorithms;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Arbeidskrav 1 ===");
        Console.WriteLine();

        Phonebook phonebook = new Phonebook();
        phonebook.Load("../../../Data/phonebook.csv");

        // --------------------------------
        // Question 1 - Linear Search
        // --------------------------------

        LinearSearch.LinearSearchResult results =
            LinearSearch.LinearSearchMethod(
                phonebook.Contacts,
                Phonebook.Field.FirstName,
                "Geir"
            );

        LinearSearch.LinearSearchResult results01 =
            LinearSearch.LinearSearchMethod(
                phonebook.Contacts,
                Phonebook.Field.FirstName,
                "geir"
            );

        LinearSearch.LinearSearchResult results1 =
            LinearSearch.LinearSearchMethod(
                phonebook.Contacts,
                Phonebook.Field.LastName,
                "bjerke"
            );

        LinearSearch.LinearSearchResult results2 =
            LinearSearch.LinearSearchMethod(
                phonebook.Contacts,
                Phonebook.Field.Mobile,
                "49572808"
            );

        LinearSearch.LinearSearchResult results3 =
            LinearSearch.LinearSearchMethod(
                phonebook.Contacts,
                Phonebook.Field.Mobile,
                "49572808242435534343"
            );

        Console.WriteLine("== FIRST NAME RESULT == ");
        foreach (Contact contact in results.Results)
        {
            Console.WriteLine(contact.FirstName);
        }

        Console.WriteLine($"Comparisons: {results.Comparisons}");

        Console.WriteLine("== FIRST NAME CASE INSENSITIVE RESULT == ");
        foreach (Contact contact in results01.Results)
        {
            Console.WriteLine(contact.FirstName);
        }

        Console.WriteLine($"Comparisons: {results01.Comparisons}");

        Console.WriteLine("== LAST NAME RESULT == ");
        foreach (Contact contact in results1.Results)
        {
            Console.WriteLine(contact.FirstName + " " + contact.LastName);
        }

        Console.WriteLine($"Comparisons: {results1.Comparisons}");

        Console.WriteLine("== MOBILE RESULT == ");
        foreach (Contact contact in results2.Results)
        {
            Console.WriteLine(
                contact.FirstName + " " +
                contact.LastName + " " +
                contact.Mobile
            );
        }

        Console.WriteLine($"Comparisons: {results2.Comparisons}");

        Console.WriteLine("== EMPTY RESULT == ");
        foreach (Contact contact in results3.Results)
        {
            Console.WriteLine(
                contact.FirstName + " " +
                contact.LastName + " " +
                contact.Mobile
            );
        }

        Console.WriteLine($"Comparisons: {results3.Comparisons}");

        // --------------------------------
        // Question 2 - Bubble Sort
        // --------------------------------

        Phonebook testPhonebook = new Phonebook();
        testPhonebook.Load("../../../Data/phonebook.csv");

        // As supplied
        Contact[] suppliedArray =
            (Contact[])testPhonebook.Contacts.Clone();

        Sorting.SortResult suppliedResult = Sorting.BubbleSort(
            suppliedArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine("Bubble sort - As supplied");
        Console.WriteLine($"Comparisons: {suppliedResult.Comparisons}");
        Console.WriteLine($"Swaps: {suppliedResult.Swaps}");

        // Already sorted
        Contact[] sortedArray =
            (Contact[])testPhonebook.Contacts.Clone();

        Sorting.BubbleSort(
            sortedArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Sorting.SortResult sortedResult = Sorting.BubbleSort(
            sortedArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine("Bubble sort - Already sorted");
        Console.WriteLine($"Comparisons: {sortedResult.Comparisons}");
        Console.WriteLine($"Swaps: {sortedResult.Swaps}");

        // Reverse sorted
        Contact[] reverseArray =
            (Contact[])testPhonebook.Contacts.Clone();

        Sorting.BubbleSort(
            reverseArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Descending
        );

        Sorting.SortResult reverseResult = Sorting.BubbleSort(
            reverseArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine("Bubble sort - Reverse sorted");
        Console.WriteLine($"Comparisons: {reverseResult.Comparisons}");
        Console.WriteLine($"Swaps: {reverseResult.Swaps}");

        // --------------------------------
        // Question 3 - Binary Search
        // --------------------------------
    }
}