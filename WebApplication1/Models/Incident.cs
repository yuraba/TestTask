using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace WebApplication1.Models;

public class Incident
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public string IncidentName { get; set; }
    public string Description { get; set; }
    public ICollection<Account> Accounts { get; set; }
    
}