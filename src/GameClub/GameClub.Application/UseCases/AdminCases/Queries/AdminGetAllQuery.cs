using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Queries;

public class AdminGetAllQuery : IRequest<IEnumerable<Admin>>
{
}