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
using System.Runtime.ConstrainedExecution;

namespace QuantoDemoraApi.Tests.RepositoryTests
{
    public class HospitaisRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<IHospitaisRepository> _mockRepository;
        private HospitaisRepository _repository;


        public HospitaisRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<IHospitaisRepository>();
            _repository = new HospitaisRepository(_context);
        }

        [Fact]
        public async void GetAllAsync_RetornarListaHospital()
        {
            // Arrange
            var tc = new List<Hospital>
            {
            new Hospital {IdHospital = 1, Cnpj = "84.946.165/0001-40", RazaoSocial = "Hospital e Maternidade A LTDA", NomeFantasia  = "Hospital A",
                IdLogradouro  = 33, Endereco  ="Dr. Edson de Melo", Numero ="357", Complemento =null,
                Bairro = "Vila Maria",Cidade = "Sao Paulo",Uf = "SP",Cep = "02122-080",Latitude =-23.511509793821133 ,
                Longitude =  -46.583786716042916,IdGoogleMaps = "ChIJfWg_7zRfzpQRfq0iAat2DYY"},
            new Hospital {IdHospital = 1, Cnpj = "84.946.165/0001-40", RazaoSocial = "Hospital e Maternidade A LTDA", NomeFantasia  = "Hospital A",
                IdLogradouro  = 33, Endereco  ="Dr. Edson de Melo", Numero ="357", Complemento =null,
                Bairro = "Vila Maria",Cidade = "Sao Paulo",Uf = "SP",Cep = "02122-080",Latitude =-23.511509793821133 ,
                Longitude =  -46.583786716042916,IdGoogleMaps = "ChIJfWg_7zRfzpQRfq0iAat2DYY"}
        };
            _mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(tc);

            //Act
            var result = await _repository.GetAllAsync();

            //Assert
            Assert.IsType<List<Hospital>>(result);
        }

        [Fact]
        public async void GetByIdAsync_RetornarAssociadoPeloIdInformado()
        {
            //Arrange
            using var context = new DataContext(_options);
            var repo = new HospitaisRepository(context);

            var tc = new Hospital
            {
                IdHospital = 1,
                Cnpj = "84.946.165/0001-40",
                RazaoSocial = "Hospital e Maternidade A LTDA",
                NomeFantasia = "Hospital A",
                IdLogradouro = 33,
                Endereco = "Dr. Edson de Melo",
                Numero = "357",
                Complemento = null,
                Bairro = "Vila Maria",
                Cidade = "Sao Paulo",
                Uf = "SP",
                Cep = "02122-080",
                Latitude = -23.511509793821133,
                Longitude = -46.583786716042916,
                IdGoogleMaps = "ChIJfWg_7zRfzpQRfq0iAat2DYY"
        };
            context.Hospitais.Add(tc);
            await context.SaveChangesAsync();

            //Act
            var result = await repo.GetByIdAsync(tc.IdHospital);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(tc.IdHospital, result.IdHospital);
            Assert.Equal(tc.Cnpj, result.Cnpj);
            Assert.Equal(tc.RazaoSocial, result.RazaoSocial);
            Assert.Equal(tc.NomeFantasia, result.NomeFantasia);
            Assert.Equal(tc.IdLogradouro, result.IdLogradouro);
            Assert.Equal(tc.Endereco, result.Endereco);
            Assert.Equal(tc.Numero, result.Numero);
            Assert.Equal(tc.Complemento, result.Complemento);
            Assert.Equal(tc.Bairro, result.Bairro);
            Assert.Equal(tc.Cidade, result.Cidade);
            Assert.Equal(tc.Uf, result.Uf);
            Assert.Equal(tc.Cep, result.Cep);
            Assert.Equal(tc.Latitude, result.Latitude);
            Assert.Equal(tc.Longitude, result.Longitude);
            Assert.Equal(tc.IdGoogleMaps, result.IdGoogleMaps);
        }
    }
}
