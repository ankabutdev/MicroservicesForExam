using Kindergarten.Application.Abstractions;
using Kindergarten.Application.Mappers;
using Kindergarten.Application.UseCases.AdminCase.Handlers.C;
using Kindergarten.Application.UseCases.AdminCases.Commands;
using Kindergarten.Domain.Entities.Admins;

namespace Kindergarten.UnitTest.Services.Admins;

public class AdminTests
{
    private readonly IMapper _mapper;
    private Mock<IAppDbContext> _dbContextMock;

    public AdminTests()
    {
        _dbContextMock = new Mock<IAppDbContext>();
        var config = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingConfiguration>();
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public async Task ShouldReturnTrueWhenAdminCreateIsValid()
    {
        // Arrange
        var command = new CreateAdminCommand
        {
            Email = "email",
            Name = "name",
            Password = "password"
        };

        // Mock Add method
        _dbContextMock.Setup(x => x.Admins.AddAsync(It.IsAny<Admin>(), CancellationToken.None));

        // Mock SaveChangesAsync method
        _dbContextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var handler = new CreateAdminComandHandler(_dbContextMock.Object, _mapper);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result);
    }

    //[Fact]
    //public async ValueTask ShouldReturnTrueWhenAdminUpdateIsValid()
    //{
    //    // Arrange
    //    var command = new UpdateAdminCommand
    //    {
    //        Id = 1,
    //        Name = "name",
    //        Email = "email",
    //        Password = "password"
    //    };

    //    var dbContextMock = new Mock<IAppDbContext>();
    //    var mapperMock = new Mock<IMapper>();

    //    var handler = new UpdateAdminCommandHandler(dbContextMock.Object, mapperMock.Object);

    //    mapperMock.Setup(x => x
    //    .Map<Admin>(command))
    //    .Returns(new Admin());

    //    // Act
    //    var result = await handler.Handle(command, CancellationToken.None);

    //    // Assert 
    //    Assert.True(result);

    //    mapperMock.Verify(x => x.Map<Admin>(command), Times.Once);

    //    dbContextMock.Verify(x => x.Admins.Update(It.IsAny<Admin>()), Times.Once);

    //    dbContextMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    //}

    //[Fact]
    //public async ValueTask ShouldReturnTrueWhenAdminDeleteIsValid()
    //{
    //    var dbContextMock = new Mock<IAppDbContext>();

    //    var command = new DeleteAdminCommand
    //    {
    //        Id = 1
    //    };

    //    var handler = new AdminDeleteCommandHandler(dbContextMock.Object);

    //    var result = await handler.Handle(command, CancellationToken.None);

    //    Assert.True(result);

    //    dbContextMock
    //        .Verify(x => x
    //        .Admins
    //        .FirstOrDefault(x => x
    //        .Id == command.Id), Times.Once);

    //    dbContextMock
    //        .Verify(x => x
    //        .SaveChangesAsync(It
    //        .IsAny<CancellationToken>()), Times.Once);
    //}
}
