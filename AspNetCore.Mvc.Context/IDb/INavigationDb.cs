using AspNetCore.Mvc.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc.Context.IDb
{
    public interface INavigationDb
    {
        /// <summary>
        /// 编辑状态下，根据别名判断和ID是否已存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="navId"></param>
        /// <returns></returns>
        bool GetExtisByName(string name, int navId);


        /// <summary>
        /// 获取所有导航数据
        /// </summary>
        /// <returns></returns>
        List<NavigationModel> GetNavigationAllList();

        /// <summary>
        /// 先获取父级导航,然后获取子级数据,规定后台只有2级
        /// </summary>
        /// <returns></returns>
        List<NavigationModel> GetNavList();

        /// <summary>
        /// 获取到所有的父级导航
        /// </summary>
        /// <returns></returns>
        List<NavigationModel> GetNavUpperLevel();

        /// <summary>
        /// 获取导航实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        NavigationModel GetModel(int id);
    }
}
