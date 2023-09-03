using System.Text.Json;

namespace StationMate.DataMgmt.MetaProperty
{
    /// <summary>
    /// 元数据属性实例
    /// 随实体实例化数据持久化
    /// </summary>
    public abstract class PropertyImplBase
    {
        /// <summary>
        /// 包含元数据属性配置的构造
        /// </summary>
        /// <param name="propertyConf">元数据属性配置</param>
        public PropertyImplBase(PropertyProtoBase propertyConf)
        {
            if (propertyConf is null || propertyConf.Id == 0)
                throw new ArgumentNullException(nameof(propertyConf));

            this.PropertyConf = propertyConf;
            this.PropertyConfId = propertyConf.Id;
        }
        /// <summary>
        /// 基础属性配置索引号
        /// </summary>
        public int PropertyConfId { get; set; }
        /// <summary>
        /// 基础属性配置
        /// </summary>
        public PropertyProtoBase PropertyConf { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public abstract object? PropertyValue { get; set; }
        /// <summary>
        /// 检查输入的属性值是否为空
        /// </summary>
        /// <param name="value">PropertyValue的输入值</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected void CheckNullable(object? value)
        {
            if (!this.PropertyConf.AllowNullable && value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }
    }

    /// <summary>
    /// 整型属性实例
    /// </summary>
    public sealed class IntegarImpl : PropertyImplBase
    {
        private int? _propertyValue;
        /// <summary>
        /// 包含整型属性配置的构造
        /// </summary>
        /// <param name="propertyConf">整型属性配置</param>
        public IntegarImpl(IntegarProto propertyConf): base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成整数型
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if (!int.TryParse(value?.ToString(), out int isIntegar))
                    throw new ArgumentException();

                _propertyValue = int.Parse(value?.ToString());
            }
        }
    }

    /// <summary>
    /// 字符串属性实例
    /// </summary>
    public abstract class StringImplBase : PropertyImplBase
    {
        /// <summary>
        /// 包含字符串属性配置的构造
        /// </summary>
        /// <param name="propertyConf">字符串属性配置</param>
        public StringImplBase(StringProtoBase propertyConf) : base(propertyConf) { }

        private string? _propertyValue;
        /// <summary>
        /// 属性值，转化成字符串型
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if (value.ToString().Length > (PropertyConf as StringProtoBase).TextLength)
                    throw new ArgumentException();

                _propertyValue = value?.ToString() ?? string.Empty;
            }
        }
    }

    /// <summary>
    /// 短文本属性实例
    /// </summary>
    public class ShortTextImpl : StringImplBase 
    {
        /// <summary>
        /// 包含短文本属性配置的构造
        /// </summary>
        /// <param name="propertyConf">短文本属性配置</param>
        public ShortTextImpl(ShortTextProto propertyConf) : base(propertyConf) { }
    }

    /// <summary>
    /// 长文本属性实例
    /// </summary>
    public class LongTextImpl : StringImplBase 
    {
        /// <summary>
        /// 包含长文本属性配置的构造
        /// </summary>
        /// <param name="propertyConf">长文本属性配置</param>
        public LongTextImpl(LongTextProto propertyConf) : base(propertyConf) { }
}

    /// <summary>
    /// 值对象属性实例
    /// </summary>
    public sealed class ValueObjectImpl : PropertyImplBase
    {
        private dynamic? _propertyValue;
        /// <summary>
        /// 包含值对象性配置的构造
        /// </summary>
        /// <param name="propertyConf">值对象属性配置</param>
        public ValueObjectImpl(ValueObjectProto propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成动态类型
        /// </summary>
        public override object? PropertyValue
        {
            get => JsonSerializer.Serialize(_propertyValue);
            set
            {
                this.CheckNullable(value);

                _propertyValue = value is not null ? JsonSerializer.Deserialize<dynamic>(value.ToString()): null;
            }
        }
    }

    /// <summary>
    /// 布尔属性实例
    /// </summary>
    public sealed class BooleanImpl : PropertyImplBase
    {
        private bool? _propertyValue;
        /// <summary>
        /// 包含布尔属性配置的构造
        /// </summary>
        /// <param name="propertyConf">布尔属性配置</param>
        public BooleanImpl(BooleanProto propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成布尔型
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if (!bool.TryParse(value?.ToString(), out bool isBool))
                    throw new ArgumentException();

                _propertyValue = bool.Parse(value?.ToString());
            }
        }
    }

    /// <summary>
    /// 浮点属性实例
    /// </summary>
    public sealed class FloatImpl : PropertyImplBase
    {
        private float? _propertyValue;
        /// <summary>
        /// 包含浮点属性配置的构造
        /// </summary>
        /// <param name="propertyConf">浮点属性配置</param>
        public FloatImpl(FloatProto propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成浮点型
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if (!float.TryParse(value?.ToString(), out float isFloat))
                    throw new ArgumentException();

                _propertyValue = float.Parse(value?.ToString());
            }
        }
    }

    /// <summary>
    /// 日期属性实例
    /// </summary>
    public sealed class DateTimeImpl : PropertyImplBase
    {
        private DateTime? _propertyValue;
        /// <summary>
        /// 包含日期属性配置的构造
        /// </summary>
        /// <param name="propertyConf">日期属性配置</param>
        public DateTimeImpl(DateTimeProto propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成日期型
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if (!DateTime.TryParse(value?.ToString(), out DateTime isDateTime))
                    throw new ArgumentException();

                _propertyValue = DateTime.Parse(value?.ToString());
            }
        }
    }

    /// <summary>
    /// 单选列表属性实例
    /// </summary>
    public sealed class OptionImpl : PropertyImplBase
    {
        private string _propertyValue;
        /// <summary>
        /// 包含单选列表属性配置的构造
        /// </summary>
        /// <param name="propertyConf">单选列表属性配置</param>
        public OptionImpl(OptionProto propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成字符串型
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if ((PropertyConf as OptionsProto).AvailableOptions.Count == 0)
                    throw new InvalidOperationException();
                if (!(PropertyConf as OptionsProto).AvailableOptions.Contains(value?.ToString()))
                    throw new ArgumentException();

                _propertyValue = value?.ToString();
            }
        }
    }

    /// <summary>
    /// 多选列表属性实例
    /// </summary>
    public sealed class OptionsImpl : PropertyImplBase
    {
        private HashSet<string> _propertyValue;
        /// <summary>
        /// 包含多选列表属性配置的构造
        /// </summary>
        /// <param name="propertyConf">多选列表属性配置</param>
        public OptionsImpl(OptionsProto propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成哈希列表
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if ((PropertyConf as OptionsProto).AvailableOptions.Count == 0)
                    throw new InvalidDataException();

                if (value is not HashSet<string> ||
                    !(value as HashSet<string>).All(x => (PropertyConf as OptionsProto).AvailableOptions.Contains(x)))
                    throw new ArgumentException();

                _propertyValue = value as HashSet<string>;
            }
        }
    }

    /// <summary>
    /// 单选字典属性实例
    /// </summary>
    public sealed class TupleImpl : PropertyImplBase
    {
        private Tuple<string, string> _propertyValue;
        /// <summary>
        /// 包含单选字典属性配置的构造
        /// </summary>
        /// <param name="propertyConf">单选字典属性配置</param>
        public TupleImpl(TupleProto propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成二元元组
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if ((PropertyConf as TupleProto).AvailablPairs.Count == 0)
                    throw new InvalidOperationException();

                if (value is not Tuple<string, string> || 
                    !(PropertyConf as TupleProto).AvailablPairs.ContainsKey((value as Tuple<string, string>).Item1))
                throw new ArgumentException();

                _propertyValue = value as Tuple<string, string>;
            }
        }
    }

    /// <summary>
    /// 多选字典属性实例
    /// </summary>
    public sealed class DictionsImpl : PropertyImplBase
    {
        private Dictionary<string, string> _propertyValue;
        /// <summary>
        /// 包含多选字典属性配置的构造
        /// </summary>
        /// <param name="propertyConf">多选字典属性配置</param>
        public DictionsImpl(DictionsProto propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化成字典
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if ((PropertyConf as DictionsProto).AvailablPairs.Count == 0)
                    throw new InvalidDataException();

                if (value is not Dictionary<string, string> ||
                    !(value as Dictionary<string, string>).All(x => (PropertyConf as DictionsProto).AvailablPairs.ContainsKey(x.Key)))
                    throw new ArgumentException();

                _propertyValue = value as Dictionary<string, string>;
            }
        }
    }

    /// <summary>
    /// 资源属性实例
    /// </summary>
    public abstract class ResourcePropImplBase : PropertyImplBase
    {
        /// <summary>
        /// 资源字节流
        /// </summary>
        private byte[] _propertyValue;
        /// <summary>
        /// 包含资源属性配置的构造
        /// </summary>
        /// <param name="propertyConf">资源属性配置</param>
        public ResourcePropImplBase(ResourcePropProtoBase propertyConf) : base(propertyConf) { }
        /// <summary>
        /// 属性值，转化字节流
        /// </summary>
        public override object? PropertyValue
        {
            get => _propertyValue;
            set
            {
                this.CheckNullable(value);

                if (value is byte[])
                    throw new ArgumentException();

                _propertyValue = value as byte[];
            }
        }
        /// <summary>
        /// 资源全称，携带后缀名
        /// </summary>
        public string ResourceFullName { get; protected set; }
    }

    /// <summary>
    /// 图像资源属性实例
    /// </summary>
    public sealed class ImagePropImpl : ResourcePropImplBase
    {
        /// <summary>
        /// 包含图像资源属性配置的构造
        /// </summary>
        /// <param name="propertyConf">图像资源属性配置</param>
        public ImagePropImpl(ImagePropProto propertyConf) : base(propertyConf) { }
    }

    /// <summary>
    /// 文件资源属性实例
    /// </summary>
    public sealed class FilePropImpl : ResourcePropImplBase
    {
        /// <summary>
        /// 包含文件资源属性配置的构造
        /// </summary>
        /// <param name="propertyConf">文件资源属性配置</param>
        public FilePropImpl(FilePropProto propertyConf) : base(propertyConf) { }
    }
}
