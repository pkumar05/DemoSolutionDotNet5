using DS.Domain.Entities;
using DS.Domain.Interfaces;
using DS.Infrastructure.SQL.Data;
using Microsoft.Extensions.Configuration;
using PK.BuildingBlocks.Repository;

namespace DS.Infrastructure.SQL.Repositories
{
    public class DepartmentsRequestRepository : RepositoryEF<Departments>, IDepartmentsRequestRepos
    {
        private readonly DADBContext _dbContext;
        public IConfiguration _configuration;

        public DepartmentsRequestRepository(DADBContext dBContext, IConfiguration configuration) : base(dBContext)
        {
            _dbContext = dBContext;
            _configuration = configuration;

        }
    }
}
