using System.Collections.Generic;
using System.Linq;
using PrestadorServico.Models;
using PrestadorServico.DataContexts;

namespace PrestadorServico.Repositories
{
    public class ServicoRepository : IRepository<ServicoModels, int>
    {
        public IEnumerable<ServicoModels> Get()
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                return context.Servicos.ToList();
            }
        }

        public IEnumerable<ServicoModels> GetByFornecedor(int fornecedorId)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                var servicoList = context.Servicos.Where(t => t.FornecedorId == fornecedorId).Select(t => t).OrderByDescending(t => t.ServicoId).Take(10).ToList();

                foreach (var servico in servicoList)
                {
                    servico.Cliente = new ClienteRepository().Get(servico.ClienteId);
                }

                return servicoList;
            }
        }

        public IEnumerable<ServicoModels> GetByReport(int fornecedorId, int clienteId, string estado, string cidade, string bairro, int? tipo, decimal valorMinimo, decimal valorMaximo)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                var servicoList = (from s in context.Servicos 
                            join c in context.Clientes on s.ClienteId equals c.ClienteId 
                            where s.FornecedorId.Equals(fornecedorId)
                                && (clienteId.Equals(0) || s.ClienteId.Equals(clienteId))
                                && (estado.Equals(string.Empty) || c.Estado.Equals(estado))
                                && (cidade.Equals(string.Empty) || c.Cidade.Equals(cidade))
                                && (bairro.Equals(string.Empty) || c.Bairro.Equals(bairro))
                                && (tipo == null || (int)s.Tipo == tipo)
                                && (valorMinimo.Equals(0) || s.Valor >= valorMinimo)
                                && (valorMaximo.Equals(0) || s.Valor <= valorMaximo)
                            orderby s.ServicoId descending
                            select s).ToList();


                foreach (var servico in servicoList)
                {
                    servico.Cliente = new ClienteRepository().Get(servico.ClienteId);
                }

                return servicoList;
            }
        }

        public ServicoModels Get(int id)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                return context.Servicos.Find(id);
            }
        }

        public void Add(ServicoModels model)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                context.Servicos.Add(model);
                context.SaveChanges();
            }
        }

        public void Remove(ServicoModels model)
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                var obj = context.Servicos.Find(model.ServicoId);
                context.Servicos.Remove(obj);
                context.SaveChanges();
            }
        }
    }
}