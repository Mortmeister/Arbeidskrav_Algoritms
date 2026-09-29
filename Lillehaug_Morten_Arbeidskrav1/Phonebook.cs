namespace Lillehaug_Morten_Arbeidskrav1;

public class Phonebook
{
    private Contact[] _contacts = new Contact[200];
    public Contact[] Contacts => _contacts;
    public enum Field { FirstName, LastName, Mobile }
    public enum SortOrder { Ascending, Descending }

    public void Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(
                $"The Phonebook file was not found: {filePath}",
                filePath
            );
        }

        string[] lines = File.ReadAllLines(filePath);
        
        if (lines.Length - 1 > _contacts.Length)
        {
            throw new FormatException(
                $"The CSV contains more than {_contacts.Length} contacts."
            );
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(",");
            
            if (parts.Length != 6)
            {
                throw new FormatException(
                    $"Invalid data on line {i + 1}: expected 6 fields."
                );
            }

            if (!int.TryParse(parts[2], out int mobile))
            {
                throw new FormatException(
                    $"Invalid mobile number on line {i + 1}."
                );
            }

            Contact contact = new Contact(
                parts[0],
                parts[1],
                mobile,
                parts[3],
                parts[4],
                parts[5]
            );
            _contacts[i - 1] = contact;
        }
    }
}

// For each contact, i want to assign their vallues to the _conact object. Contact [] is an array. 