using System.Collections.Generic;
using System.Linq;
using PrestadorServico.Models;
using PrestadorServico.DataContexts;

namespace PrestadorServico.Repositories
{
    public class FornecedorRepository : IRepository<FornecedorModels, int>
    {
        public IEnumerable<FornecedorModels> Get()
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                return context.Fornecedores.ToList();
            }
        }

        public FornecedorModels Get(int id)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                return context.Fornecedores.Find(id);
            }
        }

        public void Add(FornecedorModels model)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                context.Fornecedores.Add(model);
                context.SaveChanges();
            }
        }

        public void Remove(FornecedorModels model)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                var obj = context.Fornecedores.Find(model.FornecedorId);
                context.Fornecedores.Remove(obj);
                context.SaveChanges();
            }
        }
    }
}