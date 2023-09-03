using StationMate.DataMgmt.MetaProperty;

namespace StationMate.DataMgmt.MetaObject
{
    /// <summary>
    /// 元数据对象实例
    /// </summary>
    public abstract class ObjectImpl
    {
        /// <summary>
        /// 包含元数据对象实例名以及实体配置的构造
        /// </summary>
        /// <param name="instanceName">元数据对象实例名</param>
        /// <param name="objectConf">元数据对象配置</param>
        public ObjectImpl(string instanceName, ObjectProtoBase objectConf)
        {
            if (string.IsNullOrEmpty(instanceName))
                throw new ArgumentNullException(nameof(instanceName));

            if (objectConf is null || objectConf.Id == 0)
                throw new ArgumentNullException(nameof(objectConf));

            this.InstanceName = instanceName;
            this.ObjectConf = objectConf;
            this.ObjectConfId = objectConf.Id;
        }
        /// <summary>
        /// 索引号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 元数据对象配置的索引号
        /// </summary>
        public int ObjectConfId { get; set; }
        /// <summary>
        /// 元数据对象配置
        /// </summary>
        public ObjectProtoBase ObjectConf { get; set; }
        /// <summary>
        /// 元数据对象实例名
        /// 可按任意格式设置，不可修改
        /// </summary>
        public string InstanceName { get; set; }
        /// <summary>
        /// 元数据属性实例列表
        /// </summary>
        public List<PropertyImplBase> Properties { get; private set; }
        /// <summary>
        /// 添加元数据属性实例列表
        /// </summary>
        /// <param name="properties">元数据属性实例列表</param>
        public void AddProperties(List<PropertyImplBase> properties)
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
        /// <param name="property">元数据属性实例</param>
        public void AddProperty(PropertyImplBase property)
        {
            if (property is null)
                throw new ArgumentNullException(nameof(property));

            this.Properties.Add(property);
        }
    }
}
