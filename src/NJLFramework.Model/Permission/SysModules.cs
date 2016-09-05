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
    ///系统模块管理表
    /// <summary>
    [Table("SysModules")]
    public partial class SysModules : IEntity<SysModules>
    {
        #region Model

        /// <summary>
        /// 主键
        /// </summary>	
        [Key]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 模块key
        /// </summary>	
        public string ModuleKey { get; set; } = string.Empty;

        /// <summary>
        /// 模块名
        /// </summary>	
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 菜单Id,与SysMenus的Id关联
        /// </summary>	
        public Guid MenuId { get; set; } = Guid.Empty;

        /// <summary>
        /// 是否启用此模块，0:不启用，1：启用,如果不启用，则应当删除CompanyModules对应的记录
        /// </summary>	
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// 是否进行权限验证，0:不验证，1：验证
        /// </summary>	
        public bool Authorize { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark { get; set; } = string.Empty;


        #endregion Model
    }
}