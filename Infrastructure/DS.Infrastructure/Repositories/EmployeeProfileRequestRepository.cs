using DS.Domain.Entities;
using DS.Domain.Interfaces;
using DS.Infrastructure.SQL.Data;
using Microsoft.Extensions.Configuration;
using PK.BuildingBlocks.Repository;

namespace DS.Infrastructure.SQL.Repositories
{
    public class EmployeeProfileRequestRepository : RepositoryEF<EmployeeProfile>, IEmployeeProfileRequestRepos
    {
        private readonly DADBContext _dbContext;
        public IConfiguration _configuration;

        public EmployeeProfileRequestRepository(DADBContext dBContext, IConfiguration configuration) : base(dBContext)
        {
            _dbContext = dBContext;
            _configuration = configuration;

        }
    }
}
