using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Laba3new.UoW.Repositories;
using Laba3new.Models;

namespace Laba3new.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book, int> BookRepository { get; }
        IRepository<Sage, int> SageRepository { get; }
        IRepository<BookOrder, int> BookOrderRepository { get; }

        Task<bool> SaveAsync();
    }
}