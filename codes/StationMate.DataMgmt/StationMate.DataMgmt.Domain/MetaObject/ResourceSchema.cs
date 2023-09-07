using System;
using StationMate.DataMgmt.MetaProperty;

namespace StationMate.DataMgmt.MetaObject
{
    /// <summary>
    /// 资源配置
    /// </summary>
    public abstract class ResourceSchemaBase : ObjectSchemaBase
    {
        /// <summary>
        /// 包含对外展示的名字以及对内使用的名字的构造
        /// </summary>
        /// <param name="displayName">对外展示的名字</param>
        /// <param name="entityName">对内使用的名字</param>
        /// <param name="resourceProperty">资源属性配置</param>
        public ResourceSchemaBase(DisplayName displayName, EntityName entityName, ResourcePropSchemaBase resourceProperty) :
            base(displayName, entityName)
        {
            if (resourceProperty is null || resourceProperty.Id == 0)
                throw new ArgumentNullException(nameof(resourceProperty));

            this.ResourceProperty = resourceProperty;
        }
        /// <summary>
        /// 资源属性配置
        /// </summary>
        public abstract ResourcePropSchemaBase ResourceProperty { get; protected set; }
        /// <summary>
        /// 设置资源属性配置
        /// </summary>
        /// <param name="resourceProperty">资源属性配置</param>
        public abstract void UpdateResourceProperty(ResourcePropSchemaBase resourceProperty);
    }

    /// <summary>
    /// 文件资源配置
    /// </summary>
    public sealed class FileSchema : ResourceSchemaBase
    {
        /// <summary>
        /// 包含对外展示的名字以及对内使用的名字的构造
        /// </summary>
        /// <param name="fileProperty">文件资源属性配置</param>
        /// <param name="displayName">对外展示的名字</param>
        /// <param name="entityName">对内使用的名字</param>
        public FileSchema(FilePropSchema fileProperty, DisplayName displayName, EntityName entityName) :
            base(displayName, entityName, fileProperty) { }

        /// <summary>
        /// 文件资源属性配置
        /// </summary>
        public override ResourcePropSchemaBase ResourceProperty { get; protected set; }

        /// <summary>
        /// 设置文件资源属性配置
        /// </summary>
        /// <param name="resourceProperty">文件资源属性配置</param>
        public override void UpdateResourceProperty(ResourcePropSchemaBase resourceProperty)
        {
            if (resourceProperty is not FilePropSchema)
                throw new ArgumentException($"{resourceProperty.GetType().FullName} is not {typeof(FilePropSchema)}");

            this.ResourceProperty = resourceProperty;
        }
    }

    /// <summary>
    /// 图像资源配置
    /// </summary>
    public sealed class ImageSchema : ResourceSchemaBase
    {
        /// <summary>
        /// 包含对外展示的名字以及对内使用的名字的构造
        /// </summary>
        /// <param name="imageProperty">图像资源属性配置</param>
        /// <param name="displayName">对外展示的名字</param>
        /// <param name="entityName">对内使用的名字</param>
        public ImageSchema(ImagePropSchema imageProperty, DisplayName displayName, EntityName entityName) :
            base(displayName, entityName, imageProperty) { }
        /// <summary>
        /// 图像资源属性配置
        /// </summary>
        public override ResourcePropSchemaBase ResourceProperty { get; protected set; }
        /// <summary>
        /// 设置图像资源属性配置
        /// </summary>
        /// <param name="resourceProperty">图像资源属性配置</param>
        public override void UpdateResourceProperty(ResourcePropSchemaBase resourceProperty)
        {
            if (resourceProperty is not ImagePropSchema)
                throw new ArgumentException($"{resourceProperty.GetType().FullName} is not {typeof(ImagePropSchema)}");

            this.ResourceProperty = resourceProperty;
        }
    }
}
