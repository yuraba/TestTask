using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApplication1.Models.DTO;

public class IncidentDto
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [JsonIgnore]
    public string IncidentName { get; set; }
    public string Description { get; set; }
    public ICollection<Account>? Accounts { get; set; }
    
}