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
    public class AtendimentosRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<IAtendimentosRepository> _mockRepository;
        private AtendimentosRepository _repository;


        public AtendimentosRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<IAtendimentosRepository>();
            _repository = new AtendimentosRepository(_context);
        }

       /* [Fact]
        public async void GetAllAsync_RetornarListaAtendimento()
        {
            // Arrange
            var tc = new List<Atendimento>
        {
            new Atendimento {IdAtendimento = 1, IdHospital = 1, IdEspecialidade= 1, IdentificacaoAtendimento = 1, IdAssociado = 1, TempoAtendimento = 12, SenhaAtendimento=2},
            new Atendimento {IdAssociado = 1, NomeAssociado = "Roberto", SobrenomeAssociado = "Matas", Cpf = "255.255.255-25", DddCelular = "11", Email ="matas@gmail.com", NroCelular="99292929", Sexo='M'},
            new Atendimento {IdAssociado = 1, NomeAssociado = "Carlos", SobrenomeAssociado = "Dantas", Cpf = "255.255.255-25", DddCelular = "11", Email ="dantas@gmail.com", NroCelular="99292929", Sexo='M'}
        };
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

            //Act
            var result = await _repository.GetAllAsync();

            //Assert
            Assert.IsType<List<Atendimento>>(result);
        }*/
    }
}
