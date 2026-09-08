namespace Lillehaug_Morten_Arbeidskrav1;

public class Contact
{
    public string FirstName { get;private set;}
    public string LastName { get;private set;}
    public int Mobile { get;private set;}
    public string Birthday { get;private set;}
    public string Street { get;private set;}
    public string City { get;private set;}

    public Contact(string firstName, string lastName, int mobile, string birthday, string street, string city)
    {
        FirstName = firstName;
        LastName = lastName;
        Mobile = mobile;
        Birthday = birthday;
        Street = street;
        City = city;
    }
}

/*FirstName,LastName,Mobile,Birthday,Street,City*/