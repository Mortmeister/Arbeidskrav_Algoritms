namespace Lillehaug_Morten_Arbeidskrav1.Algorithms;

public class LinearSearch
{
    public class LinearSearchResult
    {
        public Contact[] Results { get; set; }
        public int Comparisons { get; set; }
    }
    
    /* I should be able to search through the ENUM : firstName, lastName, Mobile*/
    
    public static LinearSearchResult LinearSearchMethod(Contact[] arr, Phonebook.Field field, string target)
    {
        string value;
        List<Contact> results = new List<Contact>();
        int comparisons = 0;
        
        switch (field)
        {
         case Phonebook.Field.FirstName:
             for (int i = 0; i < arr.Length; i++)
             {
                 Contact contact = arr[i];
                 value = contact.FirstName;
                 
                 if (value.ToLower() == target.ToLower())
                 {
                     results.Add(contact);
                 }
                 comparisons++;
             }
             break;
         case Phonebook.Field.LastName:
             for (int i = 0; i < arr.Length; i++)
             {
                 Contact contact = arr[i];
                 value = contact.LastName;
                 
                 
                 if (value.ToLower() == target.ToLower())
                 {
                     
                     results.Add(contact);
                 }
                 comparisons++;
             } 
             break;
         case Phonebook.Field.Mobile:
            for (int i = 0; i < arr.Length; i++)
            {
                 Contact contact = arr[i];
                 value = contact.Mobile.ToString();
                 
                 
                 if (value == target)
                 {
                     results.Add(contact);
                 }
                 comparisons++;
            } 
            break;
         default:
             throw new ArgumentException("Please select a valid field"); 
        }
        Contact[] resultArray = results.ToArray();
        
        
        return new LinearSearchResult
        {
            Results = resultArray, 
            Comparisons = comparisons
        };
    }
}