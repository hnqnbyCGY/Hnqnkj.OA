using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hnqnkj.OA.Model;
using System.Linq.Expressions;
using System.Data.SqlClient;


namespace Hnqnkj.OA.DAL
{
    interface ICommonRepository<TEntity>
        where TEntity:EntityBase
    {
        int GetCount(Expression<Func<TEntity, bool>> where = null);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderBy = null,string includeProperties = "");
        IEnumerable<TEntity> GetPageEntitys(Expression<Func<TEntity, bool>> where = null, int limit = 10, int offset = 0, string sort = "Id", OrderMode order = OrderMode.Asc);
        TEntity GetEntityById(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Update(TEntity entity, params string[] excludeFields);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where);
        int ExecuteSql(string sql, params SqlParameter[] param);
    }
}
