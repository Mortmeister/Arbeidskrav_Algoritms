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
        


        LinearSearch.LinearSearchResult results = LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            Phonebook.Field.FirstName,
            "Geir"
        );

        LinearSearch.LinearSearchResult results01 = LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            Phonebook.Field.FirstName,
            "geir"
        );

        LinearSearch.LinearSearchResult results1 = LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            Phonebook.Field.LastName,
            "bjerke"
        );

        LinearSearch.LinearSearchResult results2 = LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            Phonebook.Field.Mobile,
            "49572808"
        );

        LinearSearch.LinearSearchResult results3 = LinearSearch.LinearSearchMethod(
            phonebook.Contacts,
            Phonebook.Field.Mobile,
            "49572808242435534343"
        );
        
        Console.WriteLine("== FIRST NAME RESULT == ");
        foreach (Contact contact in results.Results)
        {
            Console.WriteLine(contact.FirstName);
        }
        Console.WriteLine(results.Comparisons);
        
        Console.WriteLine("== FIRST NAME CASE INSENSITIVE RESULT == ");
        foreach (Contact contact in results01.Results)
        {
            Console.WriteLine(contact.FirstName);
        }
        Console.WriteLine(results01.Comparisons);
        
        Console.WriteLine("== LAST NAME RESULT == ");
        foreach (Contact contact in results1.Results)
        {
            Console.WriteLine(contact.FirstName + " " + contact.LastName);
        }
        Console.WriteLine(results01.Comparisons);
        
        Console.WriteLine("== MOBILE RESULT == ");
        foreach (Contact contact in results2.Results)
        {
            Console.WriteLine(contact.FirstName + " " + contact.LastName + " " + contact.Mobile);
        }
        Console.WriteLine(results2.Comparisons);
        
        Console.WriteLine("== Empty result == ");
        foreach (Contact contact in results3.Results)
        {
            Console.WriteLine(contact.FirstName + " " + contact.LastName + " " + contact.Mobile);
            
        }
        Console.WriteLine(results3.Comparisons);
        
 
        Console.WriteLine("SORT TEST");
        Sorting.SortResult sortResult = Sorting.BubbleSort(
            phonebook.Contacts,
            Phonebook.Field.FirstName,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine($"Comparisons: {sortResult.Comparisons}");
        Console.WriteLine($"Swaps: {sortResult.Swaps}");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(phonebook.Contacts[i].FirstName);
        }
 
        Console.WriteLine("SORT TEST");
        Sorting.SortResult sortResult2 = Sorting.BubbleSort(
            phonebook.Contacts,
            Phonebook.Field.Mobile,
            Phonebook.SortOrder.Ascending
        );

        Console.WriteLine($"Comparisons: {sortResult2.Comparisons}");
        Console.WriteLine($"Swaps: {sortResult2.Swaps}");

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(phonebook.Contacts[i].Mobile);
        }

 
        // --------------------------------
        // Question 1 - Linear Search
        // --------------------------------
        // Question 2 - Sorting
        // --------------------------------
        // Question 3 - Binary Search
        // --------------------------------
    }

}