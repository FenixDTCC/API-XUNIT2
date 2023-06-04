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
    public class IdentificacaoAtendimentosRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<IIdentificacaoAtendimentosRepository> _mockRepository;
        private IdentificacaoAtendimentosRepository _repository;


        public IdentificacaoAtendimentosRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<IIdentificacaoAtendimentosRepository>();
            _repository = new IdentificacaoAtendimentosRepository(_context);
        }

        [Fact]
        public async void GetAllAsync_RetornarListaIndentificacaoAtendimento()
        {
            // Arrange
            var tc = new List<IdentificacaoAtendimento>
        {
            new IdentificacaoAtendimento {IdIdentificacaoAtendimento = 1, DsIdentificacaoAtendimento = "Azul", DfIdentificacaoAtendimento = "Nao Urgente, sem risco imediato de agravo a saude. Atendimento em ate 240 min."},
            new IdentificacaoAtendimento {IdIdentificacaoAtendimento = 1, DsIdentificacaoAtendimento = "Verde", DfIdentificacaoAtendimento = "Pouco Urgente, baixo risco de agravo imediato a saude. Atendimento em ate 120 min."},
            new IdentificacaoAtendimento {IdIdentificacaoAtendimento = 1, DsIdentificacaoAtendimento = "Amarelo", DfIdentificacaoAtendimento = "Urgente, condicoes que podem se agravar sem atendimento. Atendimento em ate 60 min."}
        };
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

            //Act
            var result = await _repository.GetAllAsync();

            //Assert
            Assert.IsType<List<IdentificacaoAtendimento>>(result);
        }

        [Fact]
        public async void GetByIdAsync_RetornarEspecialidadePeloIdInformado()
        {
            //Arrange
            using var context = new DataContext(_options);
            var repo = new IdentificacaoAtendimentosRepository(context);

            var tc = new IdentificacaoAtendimento
            {
                IdIdentificacaoAtendimento = 1,
                DsIdentificacaoAtendimento = "Azul",
                DfIdentificacaoAtendimento = "Nao Urgente, sem risco imediato de agravo a saude. Atendimento em ate 240 min."
            };
            context.IdentificacaoAtendimentos.Add(tc);
            await context.SaveChangesAsync();

            //Act
            var result = await repo.GetByIdAsync(tc.IdIdentificacaoAtendimento);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(tc.IdIdentificacaoAtendimento, result.IdIdentificacaoAtendimento);
            Assert.Equal(tc.DsIdentificacaoAtendimento, result.DsIdentificacaoAtendimento);
            Assert.Equal(tc.DfIdentificacaoAtendimento, result.DfIdentificacaoAtendimento);
        }
    }
}
