using AspNetCore.Mvc.Context.Config;
using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Mvc.Entities;
using AspNetCore.Mvc.Context.IDb;


namespace AspNetCore.Mvc.Context
{
    /// <summary>
    /// 导航底层
    /// </summary>
    public class NavigationDb : SqlSugarBaseRepository<NavigationModel>, INavigationDb
    {
        #region   编辑状态下，根据别名判断和ID是否已存在
        /// <summary>
        /// 编辑状态下，根据别名判断和ID是否已存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool GetExtisByName(string name, int navId)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var rows = conn.Queryable<NavigationModel>().Where(t => t.NavIdent == name && t.NavId != navId).Any();
                return rows;
            }
        }
        #endregion

        #region  获取所有导航数据
        /// <summary>
        /// 获取所有导航数据
        /// </summary>
        /// <returns></returns>
        public List<NavigationModel> GetNavigationAllList()
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<NavigationModel>().OrderBy(t => t.NavSort, SqlSugar.OrderByType.Desc).OrderBy(t => t.NavInsertTime).ToList();
                return query;
            }
        }
        #endregion

        #region 先获取父级导航,然后获取子级数据,规定后台只有2级
        /// <summary>
        /// 先获取父级导航,然后获取子级数据,规定后台只有2级
        /// </summary>
        /// <returns></returns>
        public List<NavigationModel> GetNavList()
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var parent_0 = conn.Queryable<NavigationModel>().Where(t => t.NavParentId == 0).OrderBy(t => t.NavSort, SqlSugar.OrderByType.Desc).OrderBy(t => t.NavInsertTime).ToList();
                foreach (var item in parent_0)
                {
                    item.ActionList = conn.Queryable<NavigationModel>().Where(t => t.NavParentId == item.NavId).OrderBy(t => t.NavSort, SqlSugar.OrderByType.Desc).OrderBy(t => t.NavInsertTime).ToList();
                }
                return parent_0;
            }
        }
        #endregion

        #region 获取导航实体
        /// <summary>
        /// 获取导航实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NavigationModel GetModel(int id)
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<NavigationModel>().Where(t => t.NavId == id).First();
                return query;
            }
        }
        #endregion

        #region 获取到所有的父级导航
        /// <summary>
        /// 获取到所有的父级导航
        /// </summary>
        /// <returns></returns>
        public List<NavigationModel> GetNavUpperLevel()
        {
            using (var conn = SqlSugarConnection.GetSqlSugarClient())
            {
                var query = conn.Queryable<NavigationModel>().Where(t => t.NavParentId == 0).ToList();
                return query;
            }
        }
        #endregion
    }
}
