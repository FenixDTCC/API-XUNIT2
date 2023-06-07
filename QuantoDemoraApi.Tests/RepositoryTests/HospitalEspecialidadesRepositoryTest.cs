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

namespace QuantoDemoraApi.Tests.RepositoryTests
{
    public class HospitalEspecialidadesRepositoryTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;
        private readonly Mock<IHospitalEspecialidadesRepository> _mockRepository;
        private HospitalEspecialidadesRepository _repository;


        public HospitalEspecialidadesRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "DB-TCC-QUANTODEMORA")
                .Options;

            _context = new DataContext(_options);
            _mockRepository = new Mock<IHospitalEspecialidadesRepository>();
            _repository = new HospitalEspecialidadesRepository(_context);
        }


    }
}
