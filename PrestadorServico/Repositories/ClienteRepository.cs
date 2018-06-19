using System.Collections.Generic;
using System.Linq;
using PrestadorServico.Models;
using PrestadorServico.DataContexts;

namespace PrestadorServico.Repositories
{
    public class ClienteRepository :
        GenericRepository<PrestadorServicoContext, ClienteModels>
    {
        public override ClienteModels Get(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ClienteId == id);
            return query;
        }
    }
}