using Lillehaug_Morten_Arbeidskrav1;
using Lillehaug_Morten_Arbeidskrav1.Algorithms;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=Arbeidskrav 1 ===");
        Console.WriteLine();

        Phonebook phonebook = new Phonebook();
        phonebook.Load("Data/phonebook.csv");

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

        Console.WriteLine("First name RESULT ");
        foreach (Contact contact in results.Results)
        {
            Console.WriteLine(contact.FirstName);
        }

        Console.WriteLine($"Comparisons: {results.Comparisons}");

        Console.WriteLine("First name CASE INSENSITIVE RESULT ");
        foreach (Contact contact in results01.Results)
        {
            Console.WriteLine(contact.FirstName);
        }

        Console.WriteLine($"Comparisons: {results01.Comparisons}");

        Console.WriteLine("LAST NAME RESULT ");
        foreach (Contact contact in results1.Results)
        {
            Console.WriteLine(contact.FirstName + " " + contact.LastName);
        }

        Console.WriteLine($"Comparisons: {results1.Comparisons}");

        Console.WriteLine("MOBILE RESULT ");
        foreach (Contact contact in results2.Results)
        {
            Console.WriteLine(
                contact.FirstName + " " +
                contact.LastName + " " +
                contact.Mobile
            );
        }

        Console.WriteLine($"Comparisons: {results2.Comparisons}");

        Console.WriteLine("EMPTY RESULT ");
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
        testPhonebook.Load("Data/phonebook.csv");

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
        
        Console.WriteLine("MERGE SORT TEST");

        Phonebook mergePhonebook = new Phonebook();
        mergePhonebook.Load("Data/phonebook.csv");

        MergeSort.SortResult mergeResult = MergeSort.MergeSortMethod(
            mergePhonebook.Contacts,
            Phonebook.Field.Mobile,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine($"Comparisons: {mergeResult.Comparisons}");
        Console.WriteLine($"Moves: {mergeResult.Moves}");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(mergePhonebook.Contacts[i].Mobile);
        }
        
        Console.WriteLine();
        Console.WriteLine("BINARY SEARCH TEST");

        Phonebook binaryPhonebook = new Phonebook();
        binaryPhonebook.Load("Data/phonebook.csv");


        Sorting.BubbleSort(
            binaryPhonebook.Contacts,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        BinarySearch.SearchResult binaryResult = BinarySearch.BinarySearchMethod(
            binaryPhonebook.Contacts,
            Phonebook.Field.FirstName,
            "Geir"
        );

        Console.WriteLine($"Index: {binaryResult.Index}");
        Console.WriteLine($"Comparisons: {binaryResult.Comparisons}");

        if (binaryResult.Index >= 0)
        {
            Console.WriteLine(
                $"Found: {binaryPhonebook.Contacts[binaryResult.Index].FirstName} " +
                $"{binaryPhonebook.Contacts[binaryResult.Index].LastName}"
            );
        }
        Console.WriteLine();

        BinarySearch.SearchResult test2 = BinarySearch.BinarySearchMethod(
            binaryPhonebook.Contacts,
            Phonebook.Field.FirstName,
            "geir"
        );

        Console.WriteLine($"Test 2 - FirstName geir: Index={test2.Index}, Comparisons={test2.Comparisons}");

        BinarySearch.SearchResult test3 = BinarySearch.BinarySearchMethod(
            binaryPhonebook.Contacts,
            Phonebook.Field.FirstName,
            "NotARealName"
        );

        Console.WriteLine($"Test 3 - FirstName absent: Index={test3.Index}, Comparisons={test3.Comparisons}");
        
        Contact[] lastNameArray = (Contact[])binaryPhonebook.Contacts.Clone();

        Sorting.BubbleSort(
            lastNameArray,
            Phonebook.Field.LastName,
            Phonebook.SortOrder.Ascending
        );

        BinarySearch.SearchResult test4 = BinarySearch.BinarySearchMethod(
            lastNameArray,
            Phonebook.Field.LastName,
            "Bjerke"
        );

        Console.WriteLine(
            $"Test 4 - LastName Bjerke: Index={test4.Index}, Comparisons={test4.Comparisons}"
        );


        Contact[] mobileArray = (Contact[])binaryPhonebook.Contacts.Clone();

        Sorting.BubbleSort(
            mobileArray,
            Phonebook.Field.Mobile,
            Phonebook.SortOrder.Ascending
        );

        BinarySearch.SearchResult test5 = BinarySearch.BinarySearchMethod(
            mobileArray,
            Phonebook.Field.Mobile,
            "49572808"
        );

        Console.WriteLine(
            $"Test 5 - Mobile 49572808: Index={test5.Index}, Comparisons={test5.Comparisons}"
        );


        BinarySearch.SearchResult test6 = BinarySearch.BinarySearchMethod(
            mobileArray,
            Phonebook.Field.Mobile,
            "99999999"
        );

        Console.WriteLine(
            $"Test 6 - Mobile absent: Index={test6.Index}, Comparisons={test6.Comparisons}"
        );
        
        BinarySearch.SearchResult test7 = BinarySearch.BinarySearchMethod(
            binaryPhonebook.Contacts,
            Phonebook.Field.FirstName,
            "Amalie"
        );

        Console.WriteLine(
            $"Test 7 - FirstName Amalie: Index={test7.Index}, Comparisons={test7.Comparisons}"
        );

        if (test7.Index >= 0)
        {
            Console.WriteLine(
                $"Found: {binaryPhonebook.Contacts[test7.Index].FirstName} " +
                $"{binaryPhonebook.Contacts[test7.Index].LastName}"
            );
        }

        if (test7.Index >= 0)
        {
            Console.WriteLine(
                $"Found: {binaryPhonebook.Contacts[test7.Index].FirstName} " +
                $"{binaryPhonebook.Contacts[test7.Index].LastName}"
            );
        }
        BinarySearch.SearchResult test8 = BinarySearch.BinarySearchMethod(
            lastNameArray,
            Phonebook.Field.LastName,
            "Hansen"
        );

        Console.WriteLine(
            $"Test 8 - LastName Hansen: Index={test8.Index}, Comparisons={test8.Comparisons}"
        );
        
        Console.WriteLine();
        Console.WriteLine("MERGE SORT MEASUREMENTS");

        Phonebook mergeTestPhonebook = new Phonebook();
        mergeTestPhonebook.Load("Data/phonebook.csv");

// As supplied
        Contact[] mergeSupplied = (Contact[])mergeTestPhonebook.Contacts.Clone();

        MergeSort.SortResult mergeSuppliedResult = MergeSort.MergeSortMethod(
            mergeSupplied,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine("MERGE SORT - AS SUPPLIED");
        Console.WriteLine($"Comparisons: {mergeSuppliedResult.Comparisons}");
        Console.WriteLine($"Moves: {mergeSuppliedResult.Moves}");


// Already sorted
        Contact[] mergeSorted = (Contact[])mergeTestPhonebook.Contacts.Clone();

        MergeSort.MergeSortMethod(
            mergeSorted,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        MergeSort.SortResult mergeSortedResult = MergeSort.MergeSortMethod(
            mergeSorted,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine("MERGE SORT - ALREADY SORTED");
        Console.WriteLine($"Comparisons: {mergeSortedResult.Comparisons}");
        Console.WriteLine($"Moves: {mergeSortedResult.Moves}");


// Reverse sorted
        Contact[] mergeReverse = (Contact[])mergeTestPhonebook.Contacts.Clone();

        MergeSort.MergeSortMethod(
            mergeReverse,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Descending
        );

        MergeSort.SortResult mergeReverseResult = MergeSort.MergeSortMethod(
            mergeReverse,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine("MERGE SORT - REVERSE SORTED");
        Console.WriteLine($"Comparisons: {mergeReverseResult.Comparisons}");
        Console.WriteLine($"Moves: {mergeReverseResult.Moves}");
        
        Console.WriteLine();
        Console.WriteLine("EDGE CASE TESTS");

        Contact[] emptyArray = new Contact[0];

        Sorting.SortResult emptyBubble = Sorting.BubbleSort(
            emptyArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        MergeSort.SortResult emptyMerge = MergeSort.MergeSortMethod(
            emptyArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine(
            $"Empty Bubble Sort: Comparisons={emptyBubble.Comparisons}, Swaps={emptyBubble.Swaps}"
        );

        Console.WriteLine(
            $"Empty Merge Sort: Comparisons={emptyMerge.Comparisons}, Moves={emptyMerge.Moves}"
        );


        Contact[] singleArray =
        {
            new Contact("Test", "Person", 12345678, "01.01.2000", "Test Street", "Oslo")
        };

        Sorting.SortResult singleBubble = Sorting.BubbleSort(
            singleArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        MergeSort.SortResult singleMerge = MergeSort.MergeSortMethod(
            singleArray,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine(
            $"Single Bubble Sort: Comparisons={singleBubble.Comparisons}, Swaps={singleBubble.Swaps}"
        );

        Console.WriteLine(
            $"Single Merge Sort: Comparisons={singleMerge.Comparisons}, Moves={singleMerge.Moves}"
        );
        // --------------------------------
        // Question 3 - Binary Search
        // --------------------------------
    }
}