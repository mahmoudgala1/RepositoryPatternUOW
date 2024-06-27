using RepositoryPatternUOW.Core.Interfaces;
using RepositoryPatternUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternUOW.Core
{
    public interface IUnitOfWork: IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        IBooksRepository Books { get; }

        int Complete();
    }
}
