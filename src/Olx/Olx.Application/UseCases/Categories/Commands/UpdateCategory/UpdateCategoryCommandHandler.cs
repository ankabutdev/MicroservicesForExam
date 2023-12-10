using AutoMapper;
using MediatR;
using Olx.Application.Abstractions;

namespace Olx.Application.UseCases.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public UpdateCategoryCommandHandler(IMapper mapper, IAppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
