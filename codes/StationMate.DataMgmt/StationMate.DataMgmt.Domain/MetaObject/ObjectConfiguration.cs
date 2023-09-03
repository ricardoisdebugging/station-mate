﻿using StationMate.DataMgmt.MetaProperty;

namespace StationMate.DataMgmt.MetaObject
{
    /// <summary>
    /// 元数据对象配置
    /// </summary>
    public abstract class ObjectProtoBase
    {
        /// <summary>
        /// 包含对外展示的名字以及对内使用的名字的构造
        /// </summary>hao
        /// <param name="displayName">对外展示的名字</param>
        /// <param name="protoName">对内使用的名字</param>
        public ObjectProtoBase(DisplayName displayName, ProtoName protoName)
        {
            if (displayName is null || string.IsNullOrEmpty(displayName.Value))
                throw new ArgumentNullException(nameof(displayName));
            if (protoName is null || string.IsNullOrEmpty(protoName.Value))
                throw new ArgumentNullException(nameof(protoName));

            this.ProtoName = protoName;
            this.DisplayName = displayName;
        }
        /// <summary>
        /// 索引号
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// 对外展示的名字，用户可以自行指定，
        /// 只要不和用户定义的其它实体名字重复即可
        /// 可按任意格式设置，不可修改
        /// </summary>
        public DisplayName DisplayName { get; protected set; }
        /// <summary>
        /// 对内使用的名字
        /// Pascal风格命名，特殊符使用与C#命名规范一致
        /// 不可修改
        /// </summary>
        public ProtoName ProtoName { get; protected set; }
        /// <summary>
        /// 元数据属性配置列表
        /// </summary>
        public List<PropertyProtoBase> Properties { get; private set; }
        /// <summary>
        /// 添加元数据属性配置列表
        /// </summary>
        /// <param name="properties">元数据属性配置列表</param>
        public void AddProperties(List<PropertyProtoBase> properties)
        {
            if (properties is null || properties.Count == 0)
                throw new ArgumentNullException(nameof(properties));

            if (Properties.Count == 0)
                Properties = properties;
            else if (Properties.Count > 0)
                Properties.Concat(properties);
        }
        /// <summary>
        /// 添加元数据属性配置
        /// </summary>
        /// <param name="property">元数据属性配置</param>
        public void AddProperty(PropertyProtoBase property)
        {
            if (property is null) 
                throw new ArgumentNullException(nameof(property));

            this.Properties.Add(property);
        }
    }

    /// <summary>
    /// 对外展示的名字，用户可以自行指定，
    /// 只要不和用户定义的其它实体名字重复即可
    /// 可按任意格式设置，不可修改
    /// </summary>
    public sealed class DisplayName
    {
        public DisplayName()
        {
            //TODO: validation rule
        }
        public string Value { get; set; }
    }

    /// <summary>
    /// 对内使用的名字，默认基于DisplayName转化
    /// 不可修改
    /// Pascal风格命名，特殊符使用与C#命名规范一致
    /// </summary>
    public sealed class ProtoName
    {
        public ProtoName()
        {
            //TODO: validation rule
        }
        public string Value { get; set; }
    }
}
