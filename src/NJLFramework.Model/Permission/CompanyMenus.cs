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
    ///公司菜单表
    /// <summary>
    [Table("CompanyMenus")]
    public partial class CompanyMenus : IEntity<CompanyMenus>
    {
        #region Model

        /// <summary>
        /// 联合主键,公司Id,对应SysCompany的Id
        /// </summary>	
        [Key]
        public Guid CompanyId { get; set; } = Guid.Empty;

        /// <summary>
        /// 联合主键,菜单Id,对应SysMenus的Id
        /// </summary>	
        [Key]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 菜单key值
        /// </summary>	
        public string MenuKey { get; set; } = string.Empty;

        /// <summary>
        /// 菜单名称
        /// </summary>	
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 父级菜单Id
        /// </summary>	
        public Guid ParentMenuId { get; set; } = Guid.Empty;

        /// <summary>
        /// 菜单是否启用，0：不启用，1：启用,不启用，则当删除CompanyMenus中相关的记录
        /// </summary>	
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark { get; set; } = string.Empty;


        #endregion Model
    }
}