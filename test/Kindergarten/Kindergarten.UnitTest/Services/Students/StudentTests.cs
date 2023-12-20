using Kindergarten.Application.Abstractions;
using Kindergarten.Application.Mappers;
using Kindergarten.Application.UseCases.StudentCase.Commands;
using Kindergarten.Application.UseCases.StudentCase.Handlers.C;
using Kindergarten.Domain.Entities.Students;
using Kindergarten.Domain.Enums;

namespace Kindergarten.UnitTest.Services.Students;

public class StudentTests
{
    private readonly IMapper _mapper;
    private Mock<IAppDbContext> _dbContextMock;

    public StudentTests()
    {
        _dbContextMock = new Mock<IAppDbContext>();
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingConfiguration>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public async Task ShouldReturnTrueWhenStudentCreateIsValid()
    {
        // Arrange
        var command = new CreateStudentCmd
        {
            Address = "address",
            RegisteredAt = DateTime.UtcNow,
            DateOfBirth = DateTime.UtcNow,
            FullName = string.Empty,
            Gender = Gender.Other,
            GroupId = 1,
            ParentId = 1
        };

        // Mock Add method
        _dbContextMock.Setup(x => x.Students.AddAsync(It.IsAny<Student>(), CancellationToken.None));

        // Mock SaveChangesAsync method
        _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var handler = new CreateStudentCmdHandler(_dbContextMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }
}
