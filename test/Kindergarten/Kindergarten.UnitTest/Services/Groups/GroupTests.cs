using Kindergarten.Application.Abstractions;
using Kindergarten.Application.Mappers;
using Kindergarten.Application.UseCases.GroupCase.Commands;
using Kindergarten.Application.UseCases.GroupCase.Handlers.C;
using Kindergarten.Domain.Entities.Groups;

namespace Kindergarten.UnitTest.Services.Groups;

public class GroupTests
{
    private readonly IMapper _mapper;
    private Mock<IAppDbContext> _dbContextMock;

    public GroupTests()
    {
        _dbContextMock = new Mock<IAppDbContext>();
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingConfiguration>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public async Task ShouldReturnTrueWhenGroupCreateIsValid()
    {
        // Arrange
        var command = new CreateGroupCmd
        {
            Name = "name",
            AgeGroup = 1,
            Description = "description",
            EndDate = DateTime.Now,
            StartDate = DateTime.Now,
        };

        // Mock Add method
        _dbContextMock.Setup(x => x.Groups.AddAsync(It.IsAny<Group>(), CancellationToken.None));

        // Mock SaveChangesAsync method
        _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var handler = new CreateGroupCmdHandler(_dbContextMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }
}
