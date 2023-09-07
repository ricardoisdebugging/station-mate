using System;
using StationMate.DataMgmt.MetaProperty;

namespace StationMate.DataMgmt.MetaObject
{
    /// <summary>
    /// 资源实例
    /// </summary>
    public abstract class ResourceInstanceBase: ObjectInstance
    {
        /// <summary>
        /// 包含元数据对象实例名以及资源配置的构造
        /// </summary>
        /// <param name="instanceName">元数据对象实例名</param>
        /// <param name="resourceConf">实体配置</param>
        /// <param name="resourceProperty">资源属性实例</param>
        public ResourceInstanceBase(string instanceName, ResourceSchemaBase resourceConf, ResourcePropInstanceBase resourceProperty) : 
            base(instanceName, resourceConf) 
        {
            if (resourceProperty is null)
                throw new ArgumentNullException(nameof(resourceProperty));

            this.ResourceProperty = resourceProperty;
        }
        /// <summary>
        /// 资源属性实例
        /// </summary>
        public abstract ResourcePropInstanceBase ResourceProperty { get; protected set; }
        /// <summary>
        /// 设置资源属性实例
        /// </summary>
        /// <param name="resourceProperty">资源属性实例</param>
        public abstract void UpdateResourceProperty(ResourcePropInstanceBase resourceProperty);
    }

    /// <summary>
    /// 文件资源实例
    /// </summary>
    public sealed class FileInstance : ResourceInstanceBase
    {
        /// <summary>
        /// 包含元数据对象实例名以及资源配置的构造
        /// </summary>
        /// <param name="instanceName">元数据对象实例名</param>
        /// <param name="fileConf">文件资源配置</param>
        /// <param name="fileProperty">文件资源属性实例</param>
        public FileInstance(string instanceName, FileSchema fileConf, FilePropInstance fileProperty) : 
            base(instanceName, fileConf, fileProperty) { }
        /// <summary>
        /// 文件资源属性实例
        /// </summary>
        public override ResourcePropInstanceBase ResourceProperty { get; protected set; }
        /// <summary>
        /// 设置文件资源属性实例
        /// </summary>
        /// <param name="resourceProperty">文件资源属性实例</param>
        public override void UpdateResourceProperty(ResourcePropInstanceBase resourceProperty)
        {
            if (resourceProperty is not FilePropInstance)
                throw new ArgumentException($"{resourceProperty.GetType().FullName} is not {typeof(FilePropInstance)}");

            this.ResourceProperty = resourceProperty;
        }
    }

    /// <summary>
    /// 图像资源实例
    /// </summary>
    public sealed class ImageInstance : ResourceInstanceBase
    {
        /// <summary>
        /// 包含元数据对象实例名以及资源配置的构造
        /// </summary>
        /// <param name="instanceName">元数据对象实例名</param>
        /// <param name="imageConf">图像资源配置</param>
        /// <param name="imageProperty">图像资源属性实例</param>
        public ImageInstance(string instanceName, ImageSchema imageConf, ImagePropInstance imageProperty) : 
            base(instanceName, imageConf, imageProperty) { }
        /// <summary>
        /// 图像资源属性实例
        /// </summary>
        public override ResourcePropInstanceBase ResourceProperty { get; protected set; }
        /// <summary>
        /// 设置图像资源属性实例
        /// </summary>
        /// <param name="resourceProperty">图像资源属性实例</param>
        public override void UpdateResourceProperty(ResourcePropInstanceBase resourceProperty)
        {
            if (resourceProperty is not ImagePropInstance)
                throw new ArgumentException($"{resourceProperty.GetType().FullName} is not {typeof(ImagePropInstance)}");

            this.ResourceProperty = resourceProperty;
        }
    }
}
