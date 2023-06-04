using Microsoft.EntityFrameworkCore;
using Moq;
using QuantoDemoraApi.Data;
using QuantoDemoraApi.Models;
using QuantoDemoraApi.Repository.Interfaces;
using QuantoDemoraApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantoDemoraApi.Tests.RepositoryTests
{
    public class AssociadosRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<IAssociadosRepository> _mockRepository;
        private AssociadosRepository _repository;


        public AssociadosRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<IAssociadosRepository>();
            _repository = new AssociadosRepository(_context);
        }

        [Fact]
        public async void GetAllAsync_RetornarListaAssociado()
        {
            // Arrange
            var tc = new List<Associado>
        {
            new Associado {IdAssociado = 1, NomeAssociado = "Carlos", SobrenomeAssociado = "Dantas", Cpf = "255.255.255-25", DddCelular = "11", Email ="dantas@gmail.com", NroCelular="99292929", Sexo='M'},
            new Associado {IdAssociado = 1, NomeAssociado = "Roberto", SobrenomeAssociado = "Matas", Cpf = "255.255.255-25", DddCelular = "11", Email ="matas@gmail.com", NroCelular="99292929", Sexo='M'},
            new Associado {IdAssociado = 1, NomeAssociado = "Carlos", SobrenomeAssociado = "Dantas", Cpf = "255.255.255-25", DddCelular = "11", Email ="dantas@gmail.com", NroCelular="99292929", Sexo='M'}
        };
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

            //Act
            var result = await _repository.GetAllAsync();

            //Assert
            Assert.IsType<List<Associado>>(result);
        }

        [Fact]
        public async void GetByIdAsync_RetornarAssociadoPeloIdInformado()
        {
            //Arrange
            using var context = new DataContext(_options);
            var repo = new AssociadosRepository(context);

            var tc = new Associado
            {
                IdAssociado = 1,
                NomeAssociado = "Carlos",
                SobrenomeAssociado = "Dantas",
                Cpf = "255.255.255-25",
                DddCelular = "11",
                Email = "dantas@gmail.com",
                NroCelular = "99292929",
                Sexo = 'M'
            };
            context.Associados.Add(tc);
            await context.SaveChangesAsync();

            //Act
            var result = await repo.GetByIdAsync(tc.IdAssociado);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(tc.IdAssociado, result.IdAssociado);
            Assert.Equal(tc.NomeAssociado, result.NomeAssociado);
            Assert.Equal(tc.SobrenomeAssociado, result.SobrenomeAssociado);
            Assert.Equal(tc.Cpf, result.Cpf);
            Assert.Equal(tc.DddCelular, result.DddCelular);
            Assert.Equal(tc.Email, result.Email);
            Assert.Equal(tc.NroCelular, result.NroCelular);
            Assert.Equal(tc.Sexo, result.Sexo);
        }
    }
}
