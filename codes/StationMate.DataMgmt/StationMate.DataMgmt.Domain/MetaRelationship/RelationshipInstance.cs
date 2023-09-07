namespace StationMate.DataMgmt.MetaRelationship
{
    /// <summary>
    /// 元数据关联实例
    /// </summary>
    public class RelationshipInstance
    {
        /// <summary>
        /// 索引号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 源实体实例索引
        /// </summary>
        public int SourceEntityId { get; set; }
        /// <summary>
        /// 目标实体实例索引
        /// </summary>
        public int TargetEntityId { get; set; }
        /// <summary>
        /// 关联关系
        /// 源实体 -> 目标实体
        /// </summary>
        public RelationshipType Relationship { get; set; }
    }
}
