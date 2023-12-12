using AutoMapper;
using MediatR;
using Olx.Application.Abstractions;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public GetCategoryByIdQueryHandler(IMapper mapper,
        IAppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
