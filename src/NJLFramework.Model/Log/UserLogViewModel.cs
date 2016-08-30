using NJLFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.Model
{
    public class OperateLogViewModel<TModel>
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 源值
        /// </summary>
        public object SourceValue { get; set; }

        /// <summary>
        /// 改变后的值 
        /// </summary>
        public object ChangedValue { get; set; }

    }
}
