using Microsoft.EntityFrameworkCore;
using Moq;
using QuantoDemoraApi.Data;
using QuantoDemoraApi.Models;
using QuantoDemoraApi.Repository;
using QuantoDemoraApi.Repository.Interfaces;


namespace QuantoDemoraApi.Tests.RepositoryTests
{
    public class ContatosRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<IContatosRepository> _mockRepository;
        private ContatosRepository _repository;


        public ContatosRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<IContatosRepository>();
            _repository = new ContatosRepository(_context);
        }

        [Fact]
        public async void GetAllAsync_RetornarListaContatos()
        {
            // Arrange
            var tc = new List<Contato>
        {
            new Contato {IdHospital = 1, IdContato = 1, IdTipoContato = 1, DsContato = "(11) 3758-5202", InfoContato = null},
            new Contato {IdHospital = 1, IdContato = 1, IdTipoContato = 1, DsContato = "atendimento@hospitala.com.br", InfoContato = null},
            new Contato {IdHospital = 1, IdContato = 1, IdTipoContato = 1, DsContato = "(11) 3784-9463", InfoContato = null}
        };
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

            //Act
            var result = await _repository.GetAllAsync();

            //Assert
            Assert.IsType<List<Contato>>(result);
        }

        /*[Fact]
        public async void GetByIdAsync_RetornarContatoPeloIdInformado()
        {
            //Arrange
            using var context = new DataContext(_options);
            var repo = new ContatosRepository(context);

            var tc = new List<Contato<Hospital>>
            {
            new Hospital {IdHospital = 1, Cnpj = 1, RazaoSocial = 1, DsContato = "(11) 3758-5202", InfoContato = null},
           
            };
            context.Contatos.Add(tc);
            await context.SaveChangesAsync();

            //Act
            var result = await repo.GetByIdAsync( tc.IdHospital);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(tc.IdHospital, result.IdHospital);
            Assert.Equal(tc.IdContato, result.IdContato);
            Assert.Equal(tc.IdTipoContato, result.IdTipoContato);
            Assert.Equal(tc.DsContato, result.DsContato);
            Assert.Equal(tc.InfoContato, result.InfoContato);
        }*/
    }
}
