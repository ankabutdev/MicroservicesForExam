using MediatR;

namespace Kindergarten.Application.UseCases.ParentCase.Commands;

public class UpdateParentCmd : IRequest<bool>
{
    public long Id { get; set; }

    public string MotherFullName { get; set; }

    public string FatherFullName { get; set; }

    public string PassportSeriaNumber { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }
}
