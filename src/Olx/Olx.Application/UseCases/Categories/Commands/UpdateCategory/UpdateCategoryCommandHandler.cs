using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var categories = await _context.Categories
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (categories is null)
                throw new ArgumentNullException(nameof(categories));

            _mapper.Map(request, categories);

            _context.Categories.Update(categories);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
