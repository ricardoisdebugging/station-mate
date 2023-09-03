namespace StationMate.DataMgmt.MetaRelationship
{
    /// <summary>
    /// 实体配置关系
    /// </summary>
    public enum RelationshipType
    {
        /// <summary>
        /// 一对一
        /// </summary>
        OneToOne = 1,
        /// <summary>
        /// 多对一
        /// </summary>
        ManyToOne = 2,
        /// <summary>
        /// 多对多
        /// </summary>
        ManyToMany = 3,
        /// <summary>
        /// 一对多
        /// </summary>
        OneToMany = 4
    }
}
