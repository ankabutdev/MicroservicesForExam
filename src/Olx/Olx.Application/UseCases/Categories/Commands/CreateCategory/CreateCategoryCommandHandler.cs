using AutoMapper;
using MediatR;
using Olx.Application.Abstractions;

namespace Olx.Application.UseCases.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public CreateCategoryCommandHandler(IMapper mapper, IAppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
