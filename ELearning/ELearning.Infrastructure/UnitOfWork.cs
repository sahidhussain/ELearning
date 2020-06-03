using ELearning.Entities;
using ELearning.Infrastructure.DbContext;
using ELearning.Infrastructure.Generic;
using ELearning.Services;
using ELearning.Services.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext dbContext;
        private IGenericAsyncRepository<Titles> titleRepository;
        public UnitOfWork(AppDbContext DBContext)
        {
            dbContext = DBContext;
        }
        public IGenericAsyncRepository<Titles> TitleServices
        {
            get { return titleRepository ?? (titleRepository = new GenericRepository<Titles>(dbContext)); }
        }
        public async Task<bool> SaveAsync()
        {
            return await dbContext.SaveChangesAsync() > 0 ? true : false;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
