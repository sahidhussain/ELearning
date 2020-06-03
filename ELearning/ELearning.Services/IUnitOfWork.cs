using ELearning.Entities;
using ELearning.Services.Generic;
using ELearning.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Services
{
    public interface IUnitOfWork
    {
        IGenericAsyncRepository<Titles> TitleServices { get; }
        Task<bool> SaveAsync();
    }
}
