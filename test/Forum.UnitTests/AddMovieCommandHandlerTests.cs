using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using Forum.Application.Common.DataAccess.Entities;
using Forum.Application.Common.DataAccess.Repositories;
using Forum.Application.Common.DataAccess.UoW;
using Forum.Application.Core.Movies.Commands.AddMovie;
using NSubstitute;
using Forum.Application.Common.Mappings.Movies;
using Forum.Application.Common.Contracts.Responses;
using ErrorOr;


namespace Forum.UnitTests;

public class AddMovieCommandHandlerTests
{
    private readonly IFixture _fixture;
    private readonly IUnitOfWork _mockUnitOfWork;
    private readonly IMovieRepository _mockMovieRepository;
    private readonly AddMovieCommandHandler _sut; // system under test
    private readonly AddMovieCommandFixture _addMovieCommandFixture;
    public AddMovieCommandHandlerTests()
    {
        _fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        _mockUnitOfWork = Substitute.For<IUnitOfWork>();
        _mockMovieRepository = Substitute.For<IMovieRepository>();
        _mockUnitOfWork.GetRepository<IMovieRepository>().Returns(_mockMovieRepository);
        _sut = new AddMovieCommandHandler(_mockUnitOfWork);
        _addMovieCommandFixture = new();
    }
    [Fact]
    public async Task Handle_WhenCalledWithValidCommand_ShouldReturnSuccessResult()
    {
        // Arrange
        AddMovieCommand command = _addMovieCommandFixture.Create();
        MovieEntity repositoryEntity = command.ToRepositoryEntity();
        MovieResponse expected = repositoryEntity.ToResponse();
        _mockMovieRepository.InsertAsync(Arg.Any<MovieEntity>(), Arg.Any<CancellationToken>()).Returns(Result.Created);
        _mockMovieRepository.GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(repositoryEntity);

        // Act
        ErrorOr<MovieResponse> result = await _sut.Handle(command, CancellationToken.None);
        MovieResponse actual = result.Value;

        // Assert
        Assert.False(result.IsError);
        Assert.IsType<MovieResponse>(result.Value);
        Assert.NotNull(actual);
        Assert.Equal(expected, actual);
        await _mockMovieRepository.Received(1).InsertAsync(Arg.Any<MovieEntity>(), Arg.Any<CancellationToken>());
        await _mockMovieRepository.Received(1).GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>());
        await _mockUnitOfWork.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
