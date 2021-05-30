using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Repository
{
    public interface IproductRepository
    {
        Task<IEnumerable<products>> Get();
        Task<products> Get(int id);
        Task<products> Create(products product);
        Task Update(products product);
        Task Delete(int id);

    }
}
