using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;

namespace Olx.Application.UseCases.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public DeleteCategoryCommandHandler(IMapper mapper, IAppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var categories = await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (categories == null)
            return false;

        _context.Categories.Remove(categories);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
