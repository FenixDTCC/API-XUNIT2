using Microsoft.EntityFrameworkCore;
using Moq;
using QuantoDemoraApi.Data;
using QuantoDemoraApi.Models;
using QuantoDemoraApi.Repository;
using QuantoDemoraApi.Repository.Interfaces;

namespace QuantoDemoraApi.Tests.RepositoryTests
{
    public class LogradourosRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<ILogradourosRepository> _mockRepository;
        private LogradourosRepository _repository;


        public LogradourosRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<ILogradourosRepository>();
            _repository = new LogradourosRepository(_context);
        }

        [Fact]
        public async void GetAllAsync_RetornarListaLogradouro()
        {
            // Arrange
            var tc = new List<Logradouro>
        {
            new Logradouro {IdLogradouro = 1, DsLogradouro = "Rua 15"},
            new Logradouro {IdLogradouro = 2, DsLogradouro = "Avenida Jurema"},
            new Logradouro {IdLogradouro = 3, DsLogradouro = "Parque Ibirapuera"}
        };
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

            //Act
            var result = await _repository.GetAllAsync();

            //Assert
            Assert.IsType<List<Logradouro>>(result);
        }

        [Fact]
        public async void GetByIdAsync_RetornarLogradouroPeloIdInformado()
        {
            //Arrange
            using var context = new DataContext(_options);
            var repo = new LogradourosRepository(context);

            var tc = new Logradouro
            {
                IdLogradouro = 1,
                DsLogradouro = "rua 15"
            };
            context.Logradouros.Add(tc);
            await context.SaveChangesAsync();

            //Act
            var result = await repo.GetByIdAsync(tc.IdLogradouro);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(tc.IdLogradouro, result.IdLogradouro);
            Assert.Equal(tc.DsLogradouro, result.DsLogradouro);
        }
    }
}
