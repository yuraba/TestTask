using WebApplication1.Models.DTO;

namespace WebApplication1.Models.Repository;

public interface IContactRepository
{
    Task<IEnumerable<ContactDto>> GetContacts();
    Task<ContactDto> GetContactsById(int contactId);
    Task<Contact> CreateUpdateContact(Contact  contact);
    Task<bool> DeleteContact(int contactId);
}