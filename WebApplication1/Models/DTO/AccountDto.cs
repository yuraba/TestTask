using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models.DTO;

public class AccountDto
{
    
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }
    public string AccountName { get; set; }
    [JsonIgnore]
    public Incident? Incident { get; set; }
    
    public ICollection<Contact> Contacts { get; set; }
}