using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public class Account
{
    [Key]
    public int AccountId { get; set; }
    public string AccountName { get; set; }
    [JsonIgnore]
    public Incident? Incident { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}