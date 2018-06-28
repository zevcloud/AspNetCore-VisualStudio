using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using AspNetCore.Mvc.Utils.Enum;
using System.Linq;
namespace System
{
    public static class EnumAttributeDescription
    {
        /// <summary>
        /// 根据枚举值，获取指定枚举类的成员描述
        /// </summary>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetDescriptionString(Type type, int value)
        {
            var values = (from System.Enum e in System.Enum.GetValues(type)
                          select new { id =Convert.ToInt32(e), name = e.GetDisplayName() }).ToList();
            try
            {
                return values.ToList().Find(c => c.id == value).name;
            }
            catch
            {
                return "NULL";
            }
        }
    }
}
