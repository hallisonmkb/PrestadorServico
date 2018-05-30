using System.Collections.Generic;
using System.Linq;
using PrestadorServico.Models;
using PrestadorServico.DataContexts;

namespace PrestadorServico.Repositories
{
    public class FornecedorMediaValorRepository
    {
        public IEnumerable<FornecedorMediaValorModels> GetMediaValorByTipo()
        {
            using (PrestadorServicoContext context = new PrestadorServicoContext())
            {
                var query = from s in context.Servicos
                            join f in context.Fornecedores on s.FornecedorId equals f.FornecedorId
                            group s by new { s.FornecedorId, f.Nome, s.Tipo } into g
                            orderby g.Key.Nome, g.Key.Tipo
                            select new FornecedorMediaValorModels
                            {
                                Tipo = g.Key.Tipo,
                                Nome = g.Key.Nome,
                                ValorMedia = g.Average(x => x.Valor)
                            };
                
                var fornecedorMediaValorList = new List<FornecedorMediaValorModels>();
                fornecedorMediaValorList.AddRange(query);

                return fornecedorMediaValorList;
            }
        }
    }
}