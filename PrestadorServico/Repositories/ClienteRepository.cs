using System.Collections.Generic;
using System.Linq;
using PrestadorServico.Models;
using PrestadorServico.DataContexts;

namespace PrestadorServico.Repositories
{
    public class ClienteRepository : IRepository<ClienteModels, int>
    {
        public IEnumerable<ClienteModels> Get()
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                return context.Clientes.ToList();
            }
        }

        public ClienteModels Get(int id)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                return context.Clientes.Find(id);
            }
        }

        public void Add(ClienteModels model)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                context.Clientes.Add(model);
                context.SaveChanges();
            }
        }

        public void Remove(ClienteModels model)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                var obj = context.Clientes.Find(model.ClienteId);
                context.Clientes.Remove(obj);
                context.SaveChanges();
            }
        }
    }
}