using System.Collections.Generic;

namespace PrestadorServico.Repositories
{
    public interface IRepository<TEnt, in TPk> where TEnt : class
    {
        IEnumerable<TEnt> Get();
        TEnt Get(TPk id);
        void Add(TEnt entity);
        void Remove(TEnt entity);
    }

    public interface IGenericRepository<TEnt> where TEnt : class
    {
        IEnumerable<TEnt> GetAll();
        void Add(TEnt entity);
        void Remove(TEnt entity);
    }
}