/*----------------------------------------------------------------
// Copyright (C) 2016 kehu1688.com
// 版权所有。
//
// 文件功能描述：
// 实体类
// 此文件是代码生成器生成的代码，最好不要在此上面做修改，可以建立分部类作修改.
//
// 创建人  ：WZJ
// 创建日期：2016-09-23
//----------------------------------------------------------------*/

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NJLFramework.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NJLFramework.Model.Permission
{
    /// <summary>
    ///系统模块与表的关系表
    /// <summary>
    [Table("SysModuleTable")]
    public partial class SysModuleTable : IEntity<SysModuleTable>
    {
        #region Model

        /// <summary>
        /// 联合主键,模块Id,对应SysModules的Id
        /// </summary>	
        [Key]
        public Guid ModuleId { get; set; } = Guid.Empty;

        /// <summary>
        /// 联合主键,表Id,对应SysTables的Id
        /// </summary>	
        [Key]
        public string TableId { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark { get; set; } = string.Empty;


        #endregion Model
    }
}