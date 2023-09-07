using System;
using System.Collections.Generic;
using System.Linq;
using StationMate.DataMgmt.MetaRelationship;

namespace StationMate.DataMgmt.MetaObject
{
    /// <summary>
    /// 实体实例
    /// </summary>
    public sealed class EntityInstance: ObjectInstance
    {
        /// <summary>
        /// 包含元数据对象实例名以及实体配置的构造
        /// </summary>
        /// <param name="instanceName">元数据对象实例名</param>
        /// <param name="entityConf">实体配置</param>
        public EntityInstance(string instanceName, EntitySchema entityConf): base(instanceName, entityConf) { }
        /// <summary>
        /// 元数据关联实例列表
        /// </summary>
        public List<RelationshipInstance> Relationships { get; private set; }
        /// <summary>
        /// 添加元数据关联实例列表
        /// </summary>
        /// <param name="relationships">元数据关联实例列表</param>
        public void AddRelationships(List<RelationshipInstance> relationships)
        {
            if (relationships is null || relationships.Count == 0)
                throw new ArgumentNullException(nameof(relationships));

            if (Relationships.Count == 0)
                Relationships = relationships;
            else if (Relationships.Count > 0)
                Relationships.Concat(relationships);
        }
        /// <summary>
        /// 添加元数据关联实例
        /// </summary>
        /// <param name="relationship">元数据关联实例</param>
        public void AddRelationship(RelationshipInstance relationship)
        {
            if (relationship is null)
                throw new ArgumentNullException(nameof(relationship));

            this.Relationships.Add(relationship);
        }
    }
}
