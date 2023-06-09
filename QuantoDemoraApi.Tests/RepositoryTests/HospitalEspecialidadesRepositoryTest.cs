using Microsoft.EntityFrameworkCore;
using Moq;
using QuantoDemoraApi.Data;
using QuantoDemoraApi.Repository.Interfaces;
using QuantoDemoraApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantoDemoraApi.Models;

namespace QuantoDemoraApi.Tests.RepositoryTests
{
    public class HospitalEspecialidadesRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<IHospitalEspecialidadesRepository> _mockRepository;
        private HospitalEspecialidadesRepository _repository;
        //private int hospitalId =1;

        public HospitalEspecialidadesRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<IHospitalEspecialidadesRepository>();
            _repository = new HospitalEspecialidadesRepository(_context);
        }

        /* [Fact]
         public async void GetAllAsync_RetornarListaHospitalEspecialidade()
         {
             // Arrange
             var tc = new List<Hospital>
             { 
             new Hospital { IdHospital = 2, HospitalEspecialidades = Especialidade.IdEspecialidade },
             new Hospital { IdHospital = 3, IdEspecialidade = 1 }
             };
             _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

             //Act
             var result = await _repository.GetAllAsync();

             //Assert
             Assert.IsType<List<Hospital>>(result);
         }*/
        [Fact]
        public async void GetByIdAsync_RetornarLogradouroPeloIdInformado()
        {
            //Arrange
            using var context = new DataContext(_options);
            var repo = new HospitalEspecialidadesRepository(context);

            var tc = new HospitalEspecialidade
            {
                IdEspecialidade = 1,
                IdHospital = 1
            };
            context.HospitalEspecialidades.Add(tc);
            await context.SaveChangesAsync();

            //Act
            var result = await repo.GetByIdAsync(tc.IdHospital);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(tc.IdHospital, result.IdHospital);
           // Assert.Equal(tc.IdEspecialidade, result.IdEspecialidade);
        }
    }
}
