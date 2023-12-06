using MediatR;

namespace Kindergarten.Application.UseCases.ParentCase.Commands;

public class CreateParentCmd : IRequest<bool>
{
    public string MotherFullName { get; set; }

    public string FatherFullName { get; set; }

    public string PassportSeriaNumber { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }
}
