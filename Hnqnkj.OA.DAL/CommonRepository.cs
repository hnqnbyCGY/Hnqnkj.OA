using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hnqnkj.OA.Model;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Dynamic;


namespace Hnqnkj.OA.DAL
{
    public enum OrderMode
    {
        Asc,
        Desc
    }

    public class CommonRepository<TEntity> : ICommonRepository<TEntity>
         where TEntity : EntityBase
    {        
        internal OADBContext context;
        internal DbSet<TEntity> dbSet;
        public CommonRepository(OADBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        /// <summary>
        /// return rows
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<TEntity, bool>> where = null)
        {
            if (where == null)
                return dbSet.Count();
            else
                return dbSet.Count(where);
        }
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }
        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            if(context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            if(where != null)
            {
                query = query.Where(where);
            }
            foreach (var includeProperty in includeProperties.Split(
                new char[] { ','},StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }          
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="where"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="sort"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetPageEntitys(Expression<Func<TEntity, bool>> where = null, int limit = 10, int offset = 0, string sort = "Id", OrderMode order = OrderMode.Asc)
        {
            IEnumerable<TEntity> query = null;
            if (where == null)
            {
                query = this.dbSet;
            }
            else
            {
                query = this.dbSet.Where(where);
            }
            if (order == OrderMode.Asc)
            {
                sort = sort + " asc";
            }
            else
            {
                sort = sort + " desc";
            }
            query = query.OrderBy(sort);
            return query.Skip(offset).Take(limit).ToList();
        }
        /// <summary>
        /// 根据ID查实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetEntityById(object id)
        {
            return dbSet.Find(id);//根据主键查找实体
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity,params string[] excludeFields)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            foreach (var item in excludeFields)
            {
                context.Entry(entity).Property(item).IsModified = false;
            }            
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> query = null;
            if (where == null)
            {
                query = this.dbSet;
            }
            else
            {
                query = this.dbSet.Where(where);
            }
            return query;
        }
        public int ExecuteSql(string sql, params SqlParameter[] param)
        {
            return context.Database.ExecuteSqlCommand(sql, param);
        }
    }
}
