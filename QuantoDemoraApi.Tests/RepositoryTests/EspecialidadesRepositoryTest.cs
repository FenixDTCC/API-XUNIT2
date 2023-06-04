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
    public class EspecialidadesRepositoryTest
    { 
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<IEspecialidadesRepository> _mockRepository;
        private EspecialidadesRepository _repository;


        public EspecialidadesRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<IEspecialidadesRepository>();
            _repository = new EspecialidadesRepository(_context);
        }

        [Fact]
        public async void GetAllAsync_RetornarListaEspecialidade()
        {
            // Arrange
            var tc = new List<Especialidade>
        {
            new Especialidade {IdEspecialidade = 1, DsEspecialidade= "Clinica Medica"},
            new Especialidade {IdEspecialidade = 2, DsEspecialidade = "Ortopedia e Traumatologia"},
            new Especialidade {IdEspecialidade = 3, DsEspecialidade = "Pediatria"}
        };
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

            //Act
            var result = await _repository.GetAllAsync();

            //Assert
            Assert.IsType<List<Especialidade>>(result);
        }

        [Fact]
        public async void GetByIdAsync_RetornarEspecialidadePeloIdInformado()
        {
            //Arrange
            using var context = new DataContext(_options);
            var repo = new EspecialidadesRepository(context);

            var tc = new Especialidade
            {
                IdEspecialidade = 1,
                DsEspecialidade = "Clinica Medica",
            };
            context.Especialidades.Add(tc);
            await context.SaveChangesAsync();

            //Act
            var result = await repo.GetByIdAsync(tc.IdEspecialidade);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(tc.IdEspecialidade, result.IdEspecialidade);
            Assert.Equal(tc.DsEspecialidade, result.DsEspecialidade);
        }
    }
}
