using System;

namespace ClassUpdateLog
{
    /// <summary>
    /// 字段修改记录特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class PropertyChangeTrackingAttribute : Attribute
    {
        /// <summary>
        /// 指定 PropertyChangeTrackingAttribute 属性的默认值
        /// </summary>
        public static readonly PropertyChangeTrackingAttribute Default = new PropertyChangeTrackingAttribute();

        /// <summary>
        /// 构造一个新的 PropertyChangeTrackingAttribute 特性实例
        /// </summary>
        public PropertyChangeTrackingAttribute()
        { }

        /// <summary>
        /// 构造一个新的 PropertyChangeTrackingAttribute 特性实例
        /// </summary>
        /// <param name="ignore">是否忽略该字段的数据变化</param>
        public PropertyChangeTrackingAttribute(bool ignore = false)
        {
            IgnoreValue = ignore;
        }

        /// <summary>
        /// 构造一个新的 PropertyChangeTrackingAttribute 特性实例
        /// </summary>
        /// <param name="displayName">属性对应页面显示名称</param>
        public PropertyChangeTrackingAttribute(string displayName)
            : this(false)
        {
            DisplayNameValue = displayName;
        }

        /// <summary>
        /// 构造一个新的 PropertyChangeTrackingAttribute 特性实例
        /// </summary>
        /// <param name="displayName">属性对应页面显示名称</param>
        /// <param name="ignore">是否忽略该字段的数据变化</param>
        public PropertyChangeTrackingAttribute(string displayName, bool ignore)
            : this(ignore)
        {
            DisplayNameValue = displayName;
        }

        /// <summary>
        /// 获取特性中的属性对应页面上显示名称参数信息
        /// </summary>
        public virtual string DisplayName => DisplayNameValue;

        /// <summary>
        /// 获取特性中的是否忽略该字段的数据变化参数信息
        /// </summary>
        public virtual bool Ignore => IgnoreValue;

        /// <summary>
        /// 修改属性对应页面显示名称参数值
        /// </summary>
        protected string DisplayNameValue { get; set; }

        /// <summary>
        /// 修改是否忽略该字段的数据变化
        /// </summary>
        protected bool IgnoreValue { get; set; }
    }
}