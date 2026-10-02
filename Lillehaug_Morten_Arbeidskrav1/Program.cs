using Lillehaug_Morten_Arbeidskrav1;
using Lillehaug_Morten_Arbeidskrav1.Algorithms;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Arbeidskrav 1 ===");
        Console.WriteLine();

        Phonebook phonebook = new Phonebook();

        try
        {
            phonebook.Load("Data/phonebook.csv");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Could not load phonebook: {e.Message}");
            return;
        }

        RunLinearSearchTests(phonebook);
        RunBubbleSortTests();
        RunMergeSortTest();
        RunBinarySearchTests();
        RunLinearSearchComparisonTests(phonebook);
        RunMergeSortMeasurements();
        RunEdgeCaseTests();
    }

    // --------------------------------
    // Question 1 - Linear Search
    // --------------------------------

    /// <summary>
    /// Runs the linear search tests for Question 1.
    /// </summary>
    static void RunLinearSearchTests(Phonebook phonebook)
{
    Console.WriteLine("Question 1 - Linear search");
    Console.WriteLine();

    // Best case: value in the first record
    string bestCaseTarget = phonebook.Contacts[0].LastName;

    LinearSearch.LinearSearchResult<Contact> bestCase =
        LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            contact => string.Equals(
                contact.LastName,
                bestCaseTarget,
                StringComparison.OrdinalIgnoreCase
            )
        );

    Console.WriteLine("Test 1 - Best case - LastName: Bjerke");
    Console.WriteLine($"Target: {bestCaseTarget}");
    Console.WriteLine($"Matches: {bestCase.Results.Length}");
    Console.WriteLine($"Comparisons: {bestCase.Comparisons}");
    Console.WriteLine();

    // Worst case: value in the last record
    string worstCaseTarget =
        phonebook.Contacts[phonebook.Contacts.Length - 1].LastName;

    LinearSearch.LinearSearchResult<Contact> worstCase =
        LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            contact => string.Equals(
                contact.LastName,
                worstCaseTarget,
                StringComparison.OrdinalIgnoreCase
            )
        );

    Console.WriteLine("Test 2 - Worst case - LastName: Hansen");
    Console.WriteLine($"Target: {worstCaseTarget}");
    Console.WriteLine($"Matches: {worstCase.Results.Length}");
    Console.WriteLine($"Comparisons: {worstCase.Comparisons}");
    Console.WriteLine();

    // Absent surname
    string absentSurname = "NonExistent";

    LinearSearch.LinearSearchResult<Contact> absentSurnameResult =
        LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            contact => string.Equals(
                contact.LastName,
                absentSurname,
                StringComparison.OrdinalIgnoreCase
            )
        );

    Console.WriteLine("Test 3 - Absent surname");
    Console.WriteLine($"Target: {absentSurname}");
    Console.WriteLine($"Matches: {absentSurnameResult.Results.Length}");
    Console.WriteLine($"Comparisons: {absentSurnameResult.Comparisons}");
    Console.WriteLine();

    // Absent mobile number
    string absentMobile = "00000000";

    LinearSearch.LinearSearchResult<Contact> absentMobileResult =
        LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            contact => contact.Mobile.ToString() == absentMobile
        );

    Console.WriteLine("Test 4 - Absent mobile");
    Console.WriteLine($"Target: {absentMobile}");
    Console.WriteLine($"Matches: {absentMobileResult.Results.Length}");
    Console.WriteLine($"Comparisons: {absentMobileResult.Comparisons}");
    Console.WriteLine();
}
    
    static void RunLinearSearchComparisonTests(Phonebook phonebook)
    {
        Console.WriteLine("LINEAR SEARCH FOR COMPARING WITH BINARY SEARCH");
        Console.WriteLine();

        var mobileResult = LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            c => c.Mobile == 96657088
        );

        Console.WriteLine("Mobile 96657088");
        Console.WriteLine($"Matches: {mobileResult.Results.Length}");
        Console.WriteLine($"Comparisons: {mobileResult.Comparisons}");
        Console.WriteLine();

        var lastNameResult = LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            c => string.Equals(
                c.LastName,
                "Amundsen",
                StringComparison.OrdinalIgnoreCase)
        );

        Console.WriteLine("LastName Amundsen");
        Console.WriteLine($"Matches: {lastNameResult.Results.Length}");
        Console.WriteLine($"Comparisons: {lastNameResult.Comparisons}");
        Console.WriteLine();

        var firstNameResult = LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            c => string.Equals(
                c.FirstName,
                "Guro",
                StringComparison.OrdinalIgnoreCase)
        );

        Console.WriteLine("FirstName Guro");
        Console.WriteLine($"Matches: {firstNameResult.Results.Length}");
        Console.WriteLine($"Comparisons: {firstNameResult.Comparisons}");
        Console.WriteLine();
    }

    // --------------------------------
    // Question 2 - Bubble Sort
    // --------------------------------

    /// <summary>
    /// Runs Bubble Sort on the supplied, sorted and reverse-sorted data.
    /// </summary>
    static void RunBubbleSortTests()
    {
        Console.WriteLine("QUESTION 2 - BUBBLE SORT");
        Console.WriteLine();

        Phonebook phonebook = new Phonebook();
        phonebook.Load("Data/phonebook.csv");

        Comparison<Contact> ascendingFirstName =
            Sorting.GetContactComparison(
                Phonebook.Field.FirstName,
                Phonebook.SortOrder.Ascending
            );

        Comparison<Contact> descendingFirstName =
            Sorting.GetContactComparison(
                Phonebook.Field.FirstName,
                Phonebook.SortOrder.Descending
            );

        // As supplied
        Contact[] suppliedArray =
            (Contact[])phonebook.Contacts.Clone();

        Sorting.SortResult suppliedResult =
            Sorting.BubbleSort(
                suppliedArray,
                ascendingFirstName
            );

        Console.WriteLine("Bubble Sort - As supplied");
        Console.WriteLine($"Comparisons: {suppliedResult.Comparisons}");
        Console.WriteLine($"Swaps: {suppliedResult.Swaps}");
        Console.WriteLine();

        // Already sorted
        Contact[] sortedArray =
            (Contact[])suppliedArray.Clone();

        Sorting.SortResult sortedResult =
            Sorting.BubbleSort(
                sortedArray,
                ascendingFirstName
            );

        Console.WriteLine("Bubble Sort - Already sorted");
        Console.WriteLine($"Comparisons: {sortedResult.Comparisons}");
        Console.WriteLine($"Swaps: {sortedResult.Swaps}");
        Console.WriteLine();

        // Reverse sorted
        Contact[] reverseArray =
            (Contact[])phonebook.Contacts.Clone();

        Sorting.BubbleSort(
            reverseArray,
            descendingFirstName
        );

        Sorting.SortResult reverseResult =
            Sorting.BubbleSort(
                reverseArray,
                ascendingFirstName
            );

        Console.WriteLine("Bubble Sort - Reverse sorted");
        Console.WriteLine($"Comparisons: {reverseResult.Comparisons}");
        Console.WriteLine($"Swaps: {reverseResult.Swaps}");
        Console.WriteLine();
    }

    // --------------------------------
    // Question 2 - Merge Sort example
    // --------------------------------

    /// <summary>
    /// Runs a  Merge Sort test using mobile numbers.
    /// </summary>
    static void RunMergeSortTest()
    {
        Console.WriteLine("MERGE SORT TEST");
        Console.WriteLine();

        Phonebook phonebook = new Phonebook();
        phonebook.Load("Data/phonebook.csv");

        Comparison<Contact> mobileAscending =
            Sorting.GetContactComparison(
                Phonebook.Field.Mobile,
                Phonebook.SortOrder.Ascending
            );

        MergeSort.SortResult result =
            MergeSort.MergeSortMethod(
                phonebook.Contacts,
                mobileAscending
            );

        Console.WriteLine($"Comparisons: {result.Comparisons}");
        Console.WriteLine($"Moves: {result.Moves}");

        Console.WriteLine("First 10 mobile numbers:");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(phonebook.Contacts[i].Mobile);
        }

        Console.WriteLine();
    }

    // --------------------------------
    // Question 3 - Binary Search
    // --------------------------------

    /// <summary>
    /// Runs the eight Binary Search test cases required for Question 3.
    /// </summary>
    static void RunBinarySearchTests()
{
    Console.WriteLine("QUESTION 3 - BINARY SEARCH");
    Console.WriteLine();

    Phonebook phonebook = new Phonebook();
    phonebook.Load("Data/phonebook.csv");

    // ---------------------------------------------------------
    // Test 1: Mobile - existing number
    // ---------------------------------------------------------

    Contact[] mobileArray =
        (Contact[])phonebook.Contacts.Clone();

    Sorting.BubbleSort(
        mobileArray,
        Sorting.GetContactComparison(
            Phonebook.Field.Mobile,
            Phonebook.SortOrder.Ascending
        )
    );

    BinarySearch.SearchResult test1 =
        BinarySearch.BinarySearchMethod(
            mobileArray,
            contact => contact.Mobile.CompareTo(96657088)
        );

    Console.WriteLine("Test 1 - Mobile 96657088");
    Console.WriteLine($"Expected: index of 96657088");
    Console.WriteLine($"Result: Index={test1.Index}, Comparisons={test1.Comparisons}");
    Console.WriteLine();


    // ---------------------------------------------------------
    // Test 2: Mobile - below smallest
    // ---------------------------------------------------------

    BinarySearch.SearchResult test2 =
        BinarySearch.BinarySearchMethod(
            mobileArray,
            contact => contact.Mobile.CompareTo(00000000)
        );

    Console.WriteLine("Test 2 - Mobile 00000000");
    Console.WriteLine($"Expected: -1");
    Console.WriteLine($"Result: Index={test2.Index}, Comparisons={test2.Comparisons}");
    Console.WriteLine();


    // ---------------------------------------------------------
    // Test 3: Mobile - above largest
    // ---------------------------------------------------------

    BinarySearch.SearchResult test3 =
        BinarySearch.BinarySearchMethod(
            mobileArray,
            contact => contact.Mobile.CompareTo(99999999)
        );

    Console.WriteLine("Test 3 - Mobile 99999999");
    Console.WriteLine($"Expected: -1");
    Console.WriteLine($"Result: Index={test3.Index}, Comparisons={test3.Comparisons}");
    Console.WriteLine();


    // ---------------------------------------------------------
    // Test 4: LastName 
    // ---------------------------------------------------------

    Contact[] lastNameArray =
        (Contact[])phonebook.Contacts.Clone();

    Sorting.BubbleSort(
        lastNameArray,
        Sorting.GetContactComparison(
            Phonebook.Field.LastName,
            Phonebook.SortOrder.Ascending
        )
    );

    BinarySearch.SearchResult test4 =
        BinarySearch.BinarySearchMethod(
            lastNameArray,
            contact => string.Compare(
                contact.LastName,
                "Amundsen",
                StringComparison.OrdinalIgnoreCase
            )
        );

    Console.WriteLine("Test 4 - LastName Amundsen");
    Console.WriteLine($"Result: Index={test4.Index}, Comparisons={test4.Comparisons}");

    if (test4.Index > 0)
    {
        Console.WriteLine(
            $"Entry before result: " +
            $"{lastNameArray[test4.Index - 1].FirstName} " +
            $"{lastNameArray[test4.Index - 1].LastName}"
        );

        Console.WriteLine(
            $"Value before result: " +
            $"{lastNameArray[test4.Index - 1].LastName}"
        );

        Console.WriteLine(
            $"Returned value: " +
            $"{lastNameArray[test4.Index].LastName}"
        );
    }

    Console.WriteLine();


    // ---------------------------------------------------------
    // Test 5: LastName - absent
    // ---------------------------------------------------------

    BinarySearch.SearchResult test5 =
        BinarySearch.BinarySearchMethod(
            lastNameArray,
            contact => string.Compare(
                contact.LastName,
                "Alfredosen",
                StringComparison.OrdinalIgnoreCase
            )
        );

    Console.WriteLine("Test 5 - LastName Alfredosen");
    Console.WriteLine($"Expected: -1");
    Console.WriteLine($"Result: Index={test5.Index}, Comparisons={test5.Comparisons}");
    Console.WriteLine();


    // ---------------------------------------------------------
    // Test 6: FirstName - duplicate value
    // ---------------------------------------------------------

    Contact[] firstNameArray =
        (Contact[])phonebook.Contacts.Clone();

    Sorting.BubbleSort(
        firstNameArray,
        Sorting.GetContactComparison(
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        )
    );

    BinarySearch.SearchResult test6 =
        BinarySearch.BinarySearchMethod(
            firstNameArray,
            contact => string.Compare(
                contact.FirstName,
                "Guro",
                StringComparison.OrdinalIgnoreCase
            )
        );

    Console.WriteLine("Test 6 - FirstName Guro");
    Console.WriteLine($"Result: Index={test6.Index}, Comparisons={test6.Comparisons}");

    if (test6.Index > 0)
    {
        Console.WriteLine(
            $"Entry before result: " +
            $"{firstNameArray[test6.Index - 1].FirstName} " +
            $"{firstNameArray[test6.Index - 1].LastName}"
        );

        Console.WriteLine(
            $"Value before result: " +
            $"{firstNameArray[test6.Index - 1].FirstName}"
        );

        Console.WriteLine(
            $"Returned value: " +
            $"{firstNameArray[test6.Index].FirstName}"
        );
    }

    Console.WriteLine();


    // ---------------------------------------------------------
    // Test 7: Empty array
    // ---------------------------------------------------------

    Contact[] emptyArray = new Contact[0];

    BinarySearch.SearchResult test7 =
        BinarySearch.BinarySearchMethod(
            emptyArray,
            contact => string.Compare(
                contact.FirstName,
                "Anything",
                StringComparison.OrdinalIgnoreCase
            )
        );

    Console.WriteLine("Test 7 - Empty array");
    Console.WriteLine($"Expected: -1");
    Console.WriteLine($"Result: Index={test7.Index}, Comparisons={test7.Comparisons}");
    Console.WriteLine();


    // ---------------------------------------------------------
    // Test 8: Single element
    // ---------------------------------------------------------

    Contact[] singleArray =
    {
        new Contact(
            "Test",
            "Person",
            12345678,
            "01.01.2000",
            "Test",
            "Oslo"
        )
    };

    BinarySearch.SearchResult test8 =
        BinarySearch.BinarySearchMethod(
            singleArray,
            contact => string.Compare(
                contact.FirstName,
                "Test",
                StringComparison.OrdinalIgnoreCase
            )
        );

    Console.WriteLine("Test 8 - Single element");
    Console.WriteLine($"Expected: 0");
    Console.WriteLine($"Result: Index={test8.Index}, Comparisons={test8.Comparisons}");
    Console.WriteLine();
}

    // --------------------------------
    // Question 2 - Merge Sort measurements
    // --------------------------------

    /// <summary>
    /// Measures Merge Sort on supplied, sorted and reverse-sorted data.
    /// </summary>
    static void RunMergeSortMeasurements()
    {
        Console.WriteLine("MERGE SORT MEASUREMENTS");
        Console.WriteLine();

        Phonebook phonebook = new Phonebook();
        phonebook.Load("Data/phonebook.csv");

        Comparison<Contact> ascendingFirstName =
            Sorting.GetContactComparison(
                Phonebook.Field.FirstName,
                Phonebook.SortOrder.Ascending
            );

        Comparison<Contact> descendingFirstName =
            Sorting.GetContactComparison(
                Phonebook.Field.FirstName,
                Phonebook.SortOrder.Descending
            );

        // As supplied
        Contact[] suppliedArray =
            (Contact[])phonebook.Contacts.Clone();

        MergeSort.SortResult suppliedResult =
            MergeSort.MergeSortMethod(
                suppliedArray,
                ascendingFirstName
            );

        Console.WriteLine("Merge Sort - As supplied");
        Console.WriteLine($"Comparisons: {suppliedResult.Comparisons}");
        Console.WriteLine($"Moves: {suppliedResult.Moves}");
        Console.WriteLine();

        // Already sorted
        Contact[] sortedArray =
            (Contact[])suppliedArray.Clone();

        MergeSort.SortResult sortedResult =
            MergeSort.MergeSortMethod(
                sortedArray,
                ascendingFirstName
            );

        Console.WriteLine("Merge Sort - Already sorted");
        Console.WriteLine($"Comparisons: {sortedResult.Comparisons}");
        Console.WriteLine($"Moves: {sortedResult.Moves}");
        Console.WriteLine();

        // Reverse sorted
        Contact[] reverseArray =
            (Contact[])phonebook.Contacts.Clone();

        MergeSort.MergeSortMethod(
            reverseArray,
            descendingFirstName
        );

        MergeSort.SortResult reverseResult =
            MergeSort.MergeSortMethod(
                reverseArray,
                ascendingFirstName
            );

        Console.WriteLine("Merge Sort - Reverse sorted");
        Console.WriteLine($"Comparisons: {reverseResult.Comparisons}");
        Console.WriteLine($"Moves: {reverseResult.Moves}");
        Console.WriteLine();
    }

    // --------------------------------
    // Edge cases
    // --------------------------------

    /// <summary>
    /// Tests empty and single-element arrays.
    /// </summary>
    static void RunEdgeCaseTests()
    {
        Console.WriteLine("EDGE CASE TESTS");
        Console.WriteLine();

        Comparison<Contact> ascendingFirstName =
            Sorting.GetContactComparison(
                Phonebook.Field.FirstName,
                Phonebook.SortOrder.Ascending
            );

        // Empty array
        Contact[] emptyArray = new Contact[0];

        Sorting.SortResult emptyBubble =
            Sorting.BubbleSort(
                emptyArray,
                ascendingFirstName
            );

        MergeSort.SortResult emptyMerge =
            MergeSort.MergeSortMethod(
                emptyArray,
                ascendingFirstName
            );

        Console.WriteLine(
            $"Empty Bubble Sort: " +
            $"Comparisons={emptyBubble.Comparisons}, " +
            $"Swaps={emptyBubble.Swaps}"
        );

        Console.WriteLine(
            $"Empty Merge Sort: " +
            $"Comparisons={emptyMerge.Comparisons}, " +
            $"Moves={emptyMerge.Moves}"
        );

        // Single-element array
        Contact[] singleArray =
        {
            new Contact(
                "Test",
                "Person",
                12345678,
                "01.01.2000",
                "Test Street",
                "Oslo"
            )
        };

        MergeSort.SortResult singleMerge =
            MergeSort.MergeSortMethod(
                singleArray,
                ascendingFirstName
            );

        Sorting.SortResult singleBubble =
            Sorting.BubbleSort(
                singleArray,
                ascendingFirstName
            );

        Console.WriteLine(
            $"Single Bubble Sort: " +
            $"Comparisons={singleBubble.Comparisons}, " +
            $"Swaps={singleBubble.Swaps}"
        );

        Console.WriteLine(
            $"Single Merge Sort: " +
            $"Comparisons={singleMerge.Comparisons}, " +
            $"Moves={singleMerge.Moves}"
        );

        Console.WriteLine();
    }


}