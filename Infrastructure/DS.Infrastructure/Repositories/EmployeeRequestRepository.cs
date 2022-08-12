using DS.Domain.Entities;
using DS.Domain.Interfaces;
using DS.Infrastructure.SQL.Data;
using Microsoft.Extensions.Configuration;
using PK.BuildingBlocks.Repository;

namespace DS.Infrastructure.SQL.Repositories
{
    public class EmployeeRequestRepository : RepositoryEF<Employee>, IEmployeeRequestRepos
    {
        private readonly DADBContext _dbContext;
        public IConfiguration _configuration;

        public EmployeeRequestRepository(DADBContext dBContext, IConfiguration configuration) : base(dBContext)
        {
            _dbContext = dBContext;
            _configuration = configuration;

        }
    }
}
