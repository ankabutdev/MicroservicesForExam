using Kindergarten.Application.Abstractions;
using Kindergarten.Application.Mappers;
using Kindergarten.Application.UseCases.TeacherCase.Commands;
using Kindergarten.Application.UseCases.TeacherCase.Handlers.C;
using Kindergarten.Domain.Entities.Teachers;

namespace Kindergarten.UnitTest.Services.Teachers;

public class TeacherTests
{
    private readonly IMapper _mapper;
    private Mock<IAppDbContext> _dbContextMock;

    public TeacherTests()
    {
        _dbContextMock = new Mock<IAppDbContext>();
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingConfiguration>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public async Task ShouldReturnTrueWhenTeacherCreateIsValid()
    {
        // Arrange
        var command = new CreateTeacherCmd
        {
            Address = "address",
            Email = "email",
            FullName = "name",
            PhoneNumber = "1234567890",
        };

        // Mock Add method
        _dbContextMock.Setup(x => x.Teachers.AddAsync(It.IsAny<Teacher>(), CancellationToken.None));

        // Mock SaveChangesAsync method
        _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var handler = new CreateTeacherCmdHandler(_dbContextMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }
}
