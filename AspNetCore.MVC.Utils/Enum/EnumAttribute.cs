using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AspNetCore.Mvc.Utils.Enum
{

    /// <summary>
    /// 枚举扩展函数
    /// 2018.6.17
    /// zev
    /// </summary>
    public static class EnumAttribute
    {
        #region  获得枚举字段的特性(Attribute)，该属性不允许多次定义。
        /// <summary>
        /// 获得枚举字段的特性(Attribute)，该属性不允许多次定义。
        /// </summary>
        public static string GetAttributeValue(System.Enum thisValue)
        {
            FieldInfo field = thisValue.GetType().GetField(thisValue.ToString());
            var attr = (Attribute.GetCustomAttribute(field, typeof(EnumAttributeDesc)) as EnumAttributeDesc);
            if (attr == null) return string.Empty;
            return (Attribute.GetCustomAttribute(field, typeof(EnumAttributeDesc)) as EnumAttributeDesc).Value;
        }
        #endregion

        #region 获得枚举字段的特性(Attribute)，该属性不允许多次定义。 
        /// <summary>
        /// 获得枚举字段的特性(Attribute)，该属性不允许多次定义。
        /// </summary>
        public static T GetAttribute<T>(this System.Enum thisValue) where T : class
        {
            FieldInfo field = thisValue.GetType().GetField(thisValue.ToString());
            var attr = (Attribute.GetCustomAttribute(field, typeof(T)) as T);
            return attr;
        }
        #endregion

        #region  获得枚举字段的名称。
        /// <summary>
        /// 获得枚举字段的名称。
        /// </summary>
        /// <returns></returns>
        public static string GetName(this System.Enum thisValue)
        {
            return System.Enum.GetName(thisValue.GetType(), thisValue);
        }
        #endregion

        #region  获得枚举字段的值。
        /// <summary>
        /// 获得枚举字段的值。
        /// </summary>
        /// <returns></returns>
        public static T GetValue<T>(this System.Enum thisValue)
        {
            return (T)System.Enum.Parse(thisValue.GetType(), thisValue.ToString());
        }
        #endregion

    }

    /// <summary>
    /// 字段或属性的中文解释属性
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EnumAttributeDesc : Attribute
    {
        /// <summary>
        /// 获得字段或属性的中文解释.
        /// </summary>
        /// <value>字段或属性的中文解释.</value>
        public string Value { get; private set; }
        /// <summary>
        /// 初始化创建一个 <see cref="EnumAttributeDesc"/> 类的实例, 用于指示字段或属性的解释说明.
        /// </summary>
        /// <param name="value">字段或属性的解释说明.</param>
        public EnumAttributeDesc(string value)
        {
            Value = value;
        }
    }

}
