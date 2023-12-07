using NIkoh.Domain.Enums;
using System.Text.Json.Serialization;

namespace NIkoh.Domain.Dtos.Persons;

public class UpdatePersonDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string PassportSeriaNumber { get; set; }

    public long Age { get; set; }

    public string Address { get; set; }

    public string Healthy { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Gender Gender { get; set; }

}
