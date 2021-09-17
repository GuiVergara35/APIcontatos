using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ContactListAPI.Domain.Entities.Base;
using ContactListAPI.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ContactListAPI.Data.Repositories.Base
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : BaseEntity
        where TId : struct
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }

        public TEntity ObterPor(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Listar(includeProperties).FirstOrDefault(where);
        }

        public TEntity ObterPorId(TId id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Listar(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntity>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntity> ListarOrdenadosPor<TKey>(Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return ascendente ? Listar(includeProperties).OrderBy(ordem) : Listar(includeProperties).OrderByDescending(ordem);
        }

        public TEntity Adicionar(TEntity entidade)
        {
            var entity = _context.Add<TEntity>(entidade);
            return entity.Entity;
        }

        public TEntity Editar(TEntity entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        public void Remover(TEntity entidade)
        {
            _context.Set<TEntity>().Remove(entidade);
        }

        public void Remover(IEnumerable<TEntity> entidades)
        {
            _context.Set<TEntity>().RemoveRange(entidades);
        }
        public void AdicionarLista(IEnumerable<TEntity> entidades)
        {
            _context.AddRange(entidades);
        }

        public bool Existe(Func<TEntity, bool> where)
        {
            return _context.Set<TEntity>().Any(where);
        }

        private IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
