using StationMate.DataMgmt.MetaProperty;

namespace StationMate.DataMgmt.MetaObject
{
    /// <summary>
    /// 资源配置
    /// </summary>
    public abstract class ResourceProtoBase : ObjectProtoBase
    {
        /// <summary>
        /// 包含对外展示的名字以及对内使用的名字的构造
        /// </summary>
        /// <param name="displayName">对外展示的名字</param>
        /// <param name="protoName">对内使用的名字</param>
        /// <param name="resourceProperty">资源属性配置</param>
        public ResourceProtoBase(DisplayName displayName, ProtoName protoName, ResourcePropProtoBase resourceProperty) :
            base(displayName, protoName)
        {
            if (resourceProperty is null || resourceProperty.Id == 0)
                throw new ArgumentNullException(nameof(resourceProperty));

            this.ResourceProperty = resourceProperty;
        }
        /// <summary>
        /// 资源属性配置
        /// </summary>
        public abstract ResourcePropProtoBase ResourceProperty { get; protected set; }
        /// <summary>
        /// 设置资源属性配置
        /// </summary>
        /// <param name="resourceProperty">资源属性配置</param>
        public abstract void UpdateResourceProperty(ResourcePropProtoBase resourceProperty);
    }

    /// <summary>
    /// 文件资源配置
    /// </summary>
    public sealed class FileProto : ResourceProtoBase
    {
        /// <summary>
        /// 包含对外展示的名字以及对内使用的名字的构造
        /// </summary>
        /// <param name="fileProperty">文件资源属性配置</param>
        /// <param name="displayName">对外展示的名字</param>
        /// <param name="protoName">对内使用的名字</param>
        public FileProto(FilePropProto fileProperty, DisplayName displayName, ProtoName protoName) :
            base(displayName, protoName, fileProperty) { }

        /// <summary>
        /// 文件资源属性配置
        /// </summary>
        public override ResourcePropProtoBase ResourceProperty { get; protected set; }

        /// <summary>
        /// 设置文件资源属性配置
        /// </summary>
        /// <param name="resourceProperty">文件资源属性配置</param>
        public override void UpdateResourceProperty(ResourcePropProtoBase resourceProperty)
        {
            if (resourceProperty is not FilePropProto)
                throw new ArgumentException($"{resourceProperty.GetType().FullName} is not {typeof(FilePropProto)}");

            this.ResourceProperty = resourceProperty;
        }
    }

    /// <summary>
    /// 图像资源配置
    /// </summary>
    public sealed class ImageProto : ResourceProtoBase
    {
        /// <summary>
        /// 包含对外展示的名字以及对内使用的名字的构造
        /// </summary>
        /// <param name="imageProperty">图像资源属性配置</param>
        /// <param name="displayName">对外展示的名字</param>
        /// <param name="protoName">对内使用的名字</param>
        public ImageProto(ImagePropProto imageProperty, DisplayName displayName, ProtoName protoName) :
            base(displayName, protoName, imageProperty) { }
        /// <summary>
        /// 图像资源属性配置
        /// </summary>
        public override ResourcePropProtoBase ResourceProperty { get; protected set; }
        /// <summary>
        /// 设置图像资源属性配置
        /// </summary>
        /// <param name="resourceProperty">图像资源属性配置</param>
        public override void UpdateResourceProperty(ResourcePropProtoBase resourceProperty)
        {
            if (resourceProperty is not ImagePropProto)
                throw new ArgumentException($"{resourceProperty.GetType().FullName} is not {typeof(ImagePropProto)}");

            this.ResourceProperty = resourceProperty;
        }
    }
}
