using System;
using System.Collections.Generic;
using System.Linq;
using PrestadorServico.Models;
using PrestadorServico.DataContexts;

namespace PrestadorServico.Repositories
{
    public class ClienteMaisGastouRepository
    {
        public IEnumerable<ClienteMaisGastouModels> GetMaisGastou()
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
                            join q in subQuery on s.ClienteId equals q.Key.ClienteId into j
                            join c in context.Clientes on s.ClienteId equals c.ClienteId
                            where s.Atendimento.Year.Equals(DateTime.Today.Year)
                            group s by new { s.ClienteId, c.Nome, month = s.Atendimento.Month } into g
                            orderby g.Key.month, g.Key.Nome
                            select new ClienteMaisGastouModels
                            {
                                Mes = g.Key.month,
                                Nome = g.Key.Nome,
                                Valor = g.Sum(x => x.Valor)
                            };

                var clienteMaisGostouList = new List<ClienteMaisGastouModels>();
                clienteMaisGostouList.AddRange(query);

                return clienteMaisGostouList;
            }
        }
    }
}