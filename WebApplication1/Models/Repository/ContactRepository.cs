using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContext;
using WebApplication1.Models.DTO;

namespace WebApplication1.Models.Repository;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _db;
    private IMapper _mapper;


    public ContactRepository(AppDbContext db,IMapper mapper)
    {
        _mapper=mapper;
        _db = db;
    }
    
    public async Task<IEnumerable<ContactDto>> GetContacts()
    {
        List<Contact> contactList = await _db.Contacts.ToListAsync();
        return _mapper.Map<List<ContactDto>>(contactList);
    }

    public async Task<ContactDto> GetContactsById(int contactId)
    {
        Contact contact = await _db.Contacts.Where(x => x.ContacdId == contactId).FirstOrDefaultAsync();
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<Contact> CreateUpdateContact(Contact contact)
    {
        //Contact contact = _mapper.Map<ContactDto, Contact>(contactDto);
        if (contact.ContacdId>0)
        {
            _db.Contacts.Update(contact);
            await _db.SaveChangesAsync();
        }
        else
        {
            _db.Contacts.Add(contact);
            await _db.SaveChangesAsync();
        }

       
        return contact;
    }

    public async Task<bool> DeleteContact(int contactId)
    {
        try
        {
            Contact contact = await _db.Contacts.FirstOrDefaultAsync(u => u.ContacdId == contactId);
            if (contact==null)
            {
                return false;
            }

            _db.
                Contacts.Remove(contact);
            await _db.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}