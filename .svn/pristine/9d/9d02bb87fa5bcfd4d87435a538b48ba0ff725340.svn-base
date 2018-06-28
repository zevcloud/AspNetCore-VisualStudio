using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;
namespace AspNetCore.Mvc.Context.Config
{


    /// <summary>
    /// 创建实现底层一些公用的方法
    /// </summary>
    public class SqlSugarFactory<T> : SimpleClient<T> where T : class, new()
    {
        public SqlSugarFactory(SqlSugarClient context) : base(context)
        {

        }

        public T GetModel(dynamic[] ids)
        {
            return Context.Queryable<T>().In(ids).First(); ;
        }

        /// <summary>
        /// 获取总数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllList()
        {
            return Context.Queryable<T>().ToList(); ;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetInsert(T model)
        {
            return Context.Insertable<T>(model).ExecuteCommand();
        }

        /// <summary>
        /// 根据实体修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetModify(T model)
        {
            return Context.Updateable<T>(model).ExecuteCommand();
        }

        /// <summary>
        /// 根据实体进行删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetDelete(T model)
        {
            return Context.Deleteable<T>(model).ExecuteCommand();
        }

        /// <summary>
        /// 根据ID删除数据
        /// </summary>
        /// <returns></returns>
        public int GetDeleteById(int id)
        {
            return Context.Deleteable<T>().In(id).ExecuteCommand();
        }

        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <returns></returns>
        public T GetModel(int id)
        {
            return Context.Queryable<T>().In(id).First();
        }
    }

}
