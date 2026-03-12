using PersonalProfileSystem.Mvc.Data;
using PersonalProfileSystem.Mvc.Models;

public class RegisterService
{
    private readonly PersonalProfileSystemContext _context;

    public RegisterService(PersonalProfileSystemContext context)
    {
        _context = context;
    }

    public PersonInfo RegisterUser(PersonInfo person)
    {
        person.CreatedDate = DateTime.Now;
        person.IsDeleted = false;

        _context.PersonInfos.Add(person);
        _context.SaveChanges(); // generates UserId
        return person;
    }

    public void AddContact(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
    }
}