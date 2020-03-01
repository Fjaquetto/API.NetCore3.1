using APIEstudoAngular.Business.Interfaces;
using APIEstudoAngular.Business.Models;
using APIEstudoAngular.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace APIEstudoAngular.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DevIoDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DevIoDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

        public async Task<bool> UsuariosExists(Guid id)
        {
            return await _db.Usuarios.AnyAsync(e => e.Id == id);
        }
    }
}
