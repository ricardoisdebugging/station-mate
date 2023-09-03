using System.ComponentModel;

namespace StationMate.DataMgmt.MetaProperty
{
    /// <summary>
    /// 元数据属性配置
    /// 随实体元数据配置持久化
    /// </summary>
    public abstract class PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public PropertyProtoBase(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            this.PropertyName = propertyName;
        }
        /// <summary>
        /// 索引号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 属性名字
        /// </summary>
        public string PropertyName { get; set; } = string.Empty;
        /// <summary>
        /// 属性类型
        /// </summary>
        public virtual Type PropertyType { get; protected set; } = typeof(object);
        /// <summary>
        /// 是否允许值可空
        /// 设置后不可更改
        /// </summary>
        public bool AllowNullable { get; private set; } = false;
    }

    /// <summary>
    /// 整型属性配置
    /// </summary>
    public sealed class IntegarProto : PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public IntegarProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 属性类型，默认为整数型
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(int);
    }

    /// <summary>
    /// 字符串属性配置
    /// </summary>
    public abstract class StringProtoBase : PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        protected StringProtoBase(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 属性类型，默认为字符串型
        /// </summary>
        new public Type PropertyType { get; protected set; } = typeof(string);
        /// <summary>
        /// 文本长度
        /// </summary>
        public abstract int TextLength { get; protected set; }
    }

    /// <summary>
    /// 短文本属性配置
    /// </summary>
    public class ShortTextProto : StringProtoBase 
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public ShortTextProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 文本长度
        /// </summary>
        public override int TextLength { get; protected set; } = 10;
    }

    /// <summary>
    /// 长文本属性配置
    /// </summary>
    public class LongTextProto : StringProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        private LongTextProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 包含属性名称与文本长度的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// /// <param name="textLength">文本长度</param>
        public LongTextProto(string propertyName, int textLength) : this(propertyName)
        {
            this.TextLength = textLength;
        }
        /// <summary>
        /// 文本长度
        /// </summary>
        public override int TextLength { get; protected set; }
    }


    /// <summary>
    /// 值对象属性配置
    /// </summary>
    public sealed class ValueObjectProto : PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public ValueObjectProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 属性类型，默认为对象型
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(object);
    }

    /// <summary>
    /// 布尔属性配置
    /// </summary>
    public sealed class BooleanProto : PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public BooleanProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 属性类型，默认为布尔型
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(bool);
    }

    /// <summary>
    /// 浮点属性配置
    /// </summary>
    public sealed class FloatProto : PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public FloatProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 属性类型，默认为浮点型
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(float);
    }

    /// <summary>
    /// 日期属性配置
    /// </summary>
    public sealed class DateTimeProto : PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public DateTimeProto(string propertyName) : base(propertyName)
        {
        }

        /// <summary>
        /// 包含属性名称与日期格式的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="dateFormat">日期格式</param>
        public DateTimeProto(string propertyName, DateFormat dateFormat) : this(propertyName)
        {
            this.DateFormat = dateFormat;
        }
        /// <summary>
        /// 属性类型，默认为日期型
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(DateTime);
        /// <summary>
        /// 日期格式，默认是24小时
        /// </summary>
        public DateFormat DateFormat { get; private set; } = DateFormat.Time12Hours;
    }

    /// <summary>
    /// 日期格式，都是UTC时间
    /// </summary>
    public enum DateFormat
    {
        Time24Hours = 1,
        Time12Hours = 2
    }

    /// <summary>
    /// 列表基础属性配置
    /// </summary>
    public abstract class OptionalProtoBase: PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        private OptionalProtoBase(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 包含属性名称与可供选择项列表的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="options">可供选择项列表</param>
        public OptionalProtoBase(string propertyName, HashSet<string> options) : this(propertyName)
        {
            AvailableOptions = options;
        }
        /// <summary>
        /// 可供选择项列表
        /// </summary>
        public HashSet<string> AvailableOptions { get; private set; }
    }

    /// <summary>
    /// 单选列表属性配置
    /// </summary>
    public sealed class OptionProto : OptionalProtoBase
    {
        /// <summary>
        /// 包含属性名称与可供选择项列表的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="options">可供选择项列表</param>
        public OptionProto(string propertyName, HashSet<string> options) : base(propertyName, options)
        {
        }
        /// <summary>
        /// 属性类型，默认为字符串型
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(string);
    }

    /// <summary>
    /// 多选列表属性配置
    /// </summary>
    public sealed class OptionsProto : OptionalProtoBase
    {
        /// <summary>
        /// 包含属性名称与可供选择项列表的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="options">可供选择项列表</param>
        public OptionsProto(string propertyName, HashSet<string> options) : base(propertyName, options)
        {
        }

        /// <summary>
        /// 属性类型，默认为字符串集合
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(HashSet<string>);
    }

    /// <summary>
    /// 字典基础属性配置
    /// </summary>
    public abstract class DictionalProtoBase : PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        private DictionalProtoBase(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 包含属性名称与可供选择项列表的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="pairs">可供选择项列表</param>
        public DictionalProtoBase(string propertyName, Dictionary<string, string> pairs) : this(propertyName)
        {
            AvailablPairs = pairs;
        }

        /// <summary>
        /// 可供选择项字典
        /// </summary>
        public Dictionary<string, string> AvailablPairs { get; private set; }
    }

    /// <summary>
    /// 单选字典属性配置
    /// </summary>
    public sealed class TupleProto : DictionalProtoBase
    {
        /// <summary>
        /// 包含属性名称与可供选择项列表的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="pairs">可供选择项列表</param>
        public TupleProto(string propertyName, Dictionary<string, string> pairs) : base(propertyName, pairs)
        {
        }
        /// <summary>
        /// 属性类型，默认为二元元组对
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(Tuple<string, string>);
    }

    /// <summary>
    /// 多选字典属性配置
    /// </summary>
    public sealed class DictionsProto : DictionalProtoBase
    {
        /// <summary>
        /// 包含属性名称与可供选择项列表的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        /// <param name="pairs">可供选择项列表</param>
        public DictionsProto(string propertyName, Dictionary<string, string> pairs) : base(propertyName, pairs)
        {
        }
        /// <summary>
        /// 属性类型，默认为字典
        /// </summary>
        public override Type PropertyType { get; protected set; } = typeof(Dictionary<string, string>);
    }

    /// <summary>
    /// 资源属性配置
    /// </summary>
    public abstract class ResourcePropProtoBase: PropertyProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        protected ResourcePropProtoBase(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 属性类型，统一为资源原型
        /// </summary>
        new public Type PropertyType { get; protected set; } = typeof(ResourcePropProtoBase);
        /// <summary>
        /// 资源类型
        /// </summary>
        public abstract ResouceType ResouceType { get; protected set; }
    }

    /// <summary>
    /// 资源类型
    /// </summary>
    public enum ResouceType
    {
        /// <summary>
        /// 图像类型，包括bmp/jpeg/png/gif
        /// </summary>
        Image = 1,
        /// <summary>
        /// 文件类型，包括txt/pdf/doc
        /// </summary>
        File = 2,
        /// <summary>
        /// 表格类型，包括csv/excel
        /// </summary>
        Table = 3,
        /// <summary>
        /// 音频，包括mp3/wav
        /// </summary>
        Audio = 4,
        /// <summary>
        /// 压缩文件，包括zip/7z/rar
        /// </summary>
        CompressedFile = 5,
        /// <summary>
        /// 视频，包括avi/mp4/mov/mpeg
        /// </summary>
        Video = 6,
        /// <summary>
        /// 网络主页，包括html/htm
        /// </summary>
        H5 = 7
    }

    /// <summary>
    /// 图像资源属性配置
    /// </summary>
    public class ImagePropProto : ResourcePropProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public ImagePropProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 资源类型
        /// </summary>
        public override ResouceType ResouceType { get; protected set; } = ResouceType.Image;
    }

    /// <summary>
    /// 文件资源属性配置
    /// </summary>
    public class FilePropProto : ResourcePropProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public FilePropProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 资源类型
        /// </summary>
        public override ResouceType ResouceType { get; protected set; } = ResouceType.File;
    }

    /// <summary>
    /// 表格资源属性配置
    /// </summary>
    public class TablePropProto : ResourcePropProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public TablePropProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 资源类型
        /// </summary>
        public override ResouceType ResouceType { get; protected set; } = ResouceType.Table;
    }

    /// <summary>
    /// 音频资源属性配置
    /// </summary>
    public class AudioPropProto : ResourcePropProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public AudioPropProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 资源类型
        /// </summary>
        public override ResouceType ResouceType { get; protected set; } = ResouceType.Audio;
    }

    /// <summary>
    /// 压缩文件资源属性配置
    /// </summary>
    public class CompressedFilePropProto : ResourcePropProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public CompressedFilePropProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 资源类型
        /// </summary>
        public override ResouceType ResouceType { get; protected set; } = ResouceType.CompressedFile;
    }

    /// <summary>
    /// 视频文件资源属性配置
    /// </summary>
    public class VideoPropProto : ResourcePropProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public VideoPropProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 资源类型
        /// </summary>
        public override ResouceType ResouceType { get; protected set; } = ResouceType.Video;
    }

    /// <summary>
    /// 网络文件资源属性配置
    /// </summary>
    public class H5PropProto : ResourcePropProtoBase
    {
        /// <summary>
        /// 包含属性名称的构造
        /// </summary>
        /// <param name="propertyName">属性名称</param>
        public H5PropProto(string propertyName) : base(propertyName)
        {
        }
        /// <summary>
        /// 资源类型
        /// </summary>
        public override ResouceType ResouceType { get; protected set; } = ResouceType.H5;
    }
}
