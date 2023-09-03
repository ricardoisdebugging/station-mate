using StationMate.DataMgmt.MetaRelationship;

namespace StationMate.DataMgmt.MetaObject
{
    /// <summary>
    /// 实体配置
    /// </summary>
    public sealed class EntityProto : ObjectProtoBase
    {
        /// <summary>
        /// 包含对外展示的名字以及对内使用的名字的构造
        /// </summary>
        /// <param name="displayName">对外展示的名字</param>
        /// <param name="protoName">对内使用的名字</param>
        public EntityProto(DisplayName displayName, ProtoName protoName) :
            base(displayName, protoName) { }
        /// <summary>
        /// 元数据关联配置列表
        /// </summary>
        public List<RelationshipProto> Relationships { get; private set; }
        /// <summary>
        /// 添加元数据关联配置列表
        /// </summary>
        /// <param name="relationships">元数据关联配置列表</param>
        public void AddRelationships(List<RelationshipProto> relationships)
        {
            if (relationships is null || relationships.Count == 0)
                throw new ArgumentNullException(nameof(relationships));

            if (Relationships.Count == 0)
                Relationships = relationships;
            else if (Relationships.Count > 0)
                Relationships.Concat(relationships);
        }
        /// <summary>
        /// 添加元数据关联配置
        /// </summary>
        /// <param name="relationship">元数据关联配置</param>
        public void AddRelationship(RelationshipProto relationship)
        {
            if (relationship is null)
                throw new ArgumentNullException(nameof(relationship));

            this.Relationships.Add(relationship);
        }
    }
}
