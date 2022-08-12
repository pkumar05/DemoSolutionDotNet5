using PK.BuildingBlocks.Infrastructure;
using System.Threading.Tasks;

namespace DS.Infrastructure.SQL.Data
{
    public class UnitOfWork : IUnitOfWork
    {


        private DADBContext _dbContext;

        public UnitOfWork(DADBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AffectedRows { get; private set; }

        public int Commit()
        {
            AffectedRows = _dbContext.SaveChanges();
            return AffectedRows;
        }

        public async Task<int> CommitAsync()
        {
            AffectedRows = await _dbContext.SaveChangesAsync();
            return AffectedRows;
        }

    }
}
