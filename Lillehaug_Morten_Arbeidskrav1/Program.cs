using Lillehaug_Morten_Arbeidskrav1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Arbeidskrav 1 ===");
        Console.WriteLine();
        string filePath = "../../../Data/phonebook.csv";
        

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)

        {

            Console.WriteLine(line);

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