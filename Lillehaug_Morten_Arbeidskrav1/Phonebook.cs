namespace Lillehaug_Morten_Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts = new Contact[200];
    
    public enum Field { FirstName, LastName, Mobile }
    public enum SortOrder { Ascending, Descending }
}