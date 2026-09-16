namespace Lillehaug_Morten_Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts = new Contact[200];
    public Contact[] Contacts => _contacts;
    
    public enum Field { FirstName, LastName, Mobile }
    public enum SortOrder { Ascending, Descending }

    public void Load(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);

        for (int i=1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(",");
            Contact contact = new Contact(parts[0],parts[1],int.Parse(parts[2]),(parts[3]),parts[4],parts[5]);

            _contacts[i-1] = contact;
        }
    }

    
}

// For each contact, i want to assign their vallues to the _conact object. Contact [] is an array. 