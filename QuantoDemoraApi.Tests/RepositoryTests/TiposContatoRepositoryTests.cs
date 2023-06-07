using Microsoft.EntityFrameworkCore;
using Moq;
using QuantoDemoraApi.Data;
using QuantoDemoraApi.Models;
using QuantoDemoraApi.Repository;
using QuantoDemoraApi.Repository.Interfaces;

namespace QuantoDemoraApi.Tests.RepositoryTests;

public class TiposContatoRepositoryTests
{
    private readonly DbContextOptions<DataContext> _options;
    private readonly DataContext _context;
    private readonly Mock<ITiposContatoRepository> _mockRepository;
    private TiposContatoRepository _repository;

    public TiposContatoRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
            .Options;

        _context = new DataContext(_options);
        _mockRepository = new Mock<ITiposContatoRepository>();
        _repository = new TiposContatoRepository(_context);
    }

    [Fact]
    public async void GetAllAsync_RetornarListaTiposContato()
    {
        // Arrange
        var tc = new List<TipoContato>
        {
            new TipoContato {IdTipoContato = 1, DsTipoContato = "Telefone"},
            new TipoContato {IdTipoContato = 2, DsTipoContato = "E-mail"},
            new TipoContato {IdTipoContato = 3, DsTipoContato = "WhatsApp"}
        };
        _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

        //Act
        var result = await _repository.GetAllAsync();

        //Assert
        Assert.IsType<List<TipoContato>>(result);
    }

    [Fact]
    public async void GetByIdAsync_RetornarTipoContatoPeloIdInformado()
    {
        //Arrange
        using var context = new DataContext(_options);
        var repo = new TiposContatoRepository(context);

        var tc = new TipoContato
        {
            IdTipoContato = 1,
            DsTipoContato = "Telefone"
        };
        context.TiposContato.Add(tc);
        await context.SaveChangesAsync();

        //Act
        var result = await repo.GetByIdAsync(tc.IdTipoContato);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(tc.IdTipoContato, result.IdTipoContato);
        Assert.Equal(tc.DsTipoContato, result.DsTipoContato);
    }
}