using Kindergarten.Application.Abstractions;
using Kindergarten.Application.Mappers;
using Kindergarten.Application.UseCases.ParentCase.Commands;
using Kindergarten.Application.UseCases.ParentCase.Handlers.C;
using Kindergarten.Domain.Entities.Parents;

namespace Kindergarten.UnitTest.Services.Parents;

public class ParentTests
{
    private readonly IMapper _mapper;
    private Mock<IAppDbContext> _dbContextMock;

    public ParentTests()
    {
        _dbContextMock = new Mock<IAppDbContext>();
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingConfiguration>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public async Task ShouldReturnTrueWhenParentCreateIsValid()
    {
        // Arrange
        var command = new CreateParentCmd
        {
            Address = "address",
            Email = "email",
            FatherFullName = "FatherFullName",
            MotherFullName = "motherFullName",
            PassportSeriaNumber = "123456789",
            PhoneNumber = "1234567890"
        };

        // Mock Add method
        _dbContextMock.Setup(x => x.Parents.AddAsync(It.IsAny<Parent>(), CancellationToken.None));

        // Mock SaveChangesAsync method
        _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var handler = new CreateParentCmdHandler(_dbContextMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }
}
