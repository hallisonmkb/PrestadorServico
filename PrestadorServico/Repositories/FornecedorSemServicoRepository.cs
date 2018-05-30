using System;
using System.Collections.Generic;
using System.Linq;
using PrestadorServico.Models;
using PrestadorServico.DataContexts;

namespace PrestadorServico.Repositories
{
    public class FornecedorSemServicoRepository
    {
        public IEnumerable<FornecedorSemServicoModels> GetSemServico()
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                var subQuery = (from s in context.Servicos
                                join c in context.Clientes on s.ClienteId equals c.ClienteId
                                where s.Atendimento.Year.Equals(DateTime.Today.Year)
                                group s by new { s.ClienteId, c.Nome } into g
                                orderby g.Sum(x => x.Valor) descending
                                select new { g.Key, Orders = g }).Take(3);

                var query = from s in context.Servicos
                            join f in context.Fornecedores on s.FornecedorId equals f.FornecedorId
                            where s.Atendimento.Year.Equals(DateTime.Today.Year)
                            group s by new { s.FornecedorId, f.Nome, month = s.Atendimento.Month } into g
                            orderby g.Key.month, g.Key.Nome
                            select new FornecedorSemServicoModels
                            {
                                Mes = g.Key.month,
                                Nome = g.Key.Nome,
                                FornecedorId = g.Key.FornecedorId
                            };

                var fornecedorSemServicoList = new List<FornecedorSemServicoModels>();
                fornecedorSemServicoList.AddRange(query);

                return fornecedorSemServicoList;
            }
        }
    }
}