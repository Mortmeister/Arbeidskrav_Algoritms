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

        // 0 should be the first === Geir, second is Kristin
        Console.WriteLine(phonebook.Contacts[0].FirstName);
        Console.WriteLine(phonebook.Contacts[1].FirstName);
        
        
        // Testing console loggin the whole csv file:
        for (int i = 0; i < phonebook.Contacts.Length; i++)
        {
            Console.WriteLine(phonebook.Contacts[i].FirstName);
        }
        

        /*int result = LinearSearch.LinearSearchMethod(filePath, "Geir");*/
        
        /*foreach (string line in lines)

        {

            Console.WriteLine(line);

        }*/
        
        
        

        /*foreach (string part in parts)
        {
            Console.WriteLine(part);
        }*/

        
        
        /*Console.WriteLine(contactTest.FirstName);
        Console.WriteLine(contactTest.LastName);
        Console.WriteLine(contactTest.Mobile);
        Console.WriteLine(contactTest.Birthday);
        Console.WriteLine(contactTest.Street);
        Console.WriteLine(contactTest.City);#1#*/

        

        // --------------------------------
        // Question 1 - Linear Search
        // --------------------------------
        // Question 2 - Sorting
        // --------------------------------
        // Question 3 - Binary Search
        // --------------------------------


    }

}