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
    ///系统模块权限表
    /// <summary>
    [Table("SysModuleRight")]
    public partial class SysModuleRight : IEntity<SysModuleRight>
    {
        #region Model

        /// <summary>
        /// 联合主键,模块Id,对应SysModules的Id
        /// </summary>	
        [Key]
        public Guid ModuleId { get; set; } = Guid.Empty;

        /// <summary>
        /// 联合主键,权限项Id,对应SysRights的Id
        /// </summary>	
        [Key]
        public Guid RightId { get; set; } = Guid.Empty;

        /// <summary>
        /// 是否启用，0：不启用，1：启用,不启用，则当删除CompanyModuleRight中相关的记录
        /// </summary>	
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark { get; set; } = string.Empty;


        #endregion Model
    }
}