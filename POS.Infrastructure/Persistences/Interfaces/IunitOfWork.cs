using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infrastructure.Persistences.Interfaces
{
    public interface IunitOfWork : IDisposable
    {
        //Declaracion o matricula de nuestra interfaces a nivel de repositorio
        ICategoryRepository category { get; }

        void SafeChanges();
        Task SaveChangesAsync();
    }
}
