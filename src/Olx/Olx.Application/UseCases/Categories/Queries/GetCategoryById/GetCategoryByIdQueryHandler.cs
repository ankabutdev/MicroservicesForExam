using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Category not found!");
    }
}
