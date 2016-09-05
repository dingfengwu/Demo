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
    ///角色表
    /// <summary>
    [Table("Roles")]
    public partial class Roles : IdentityRole<Guid>, IEntity<Roles>
    {
        #region Model

        /// <summary>
        /// 主键Id
        /// </summary>	
        [Key]
        public override Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 公司Id,对应SysCompany的Id
        /// </summary>	
        public Guid CompanyId { get; set; } = Guid.Empty;

        /// <summary>
        /// 角色名称
        /// </summary>	
        public override string Name { get; set; } = string.Empty;

        /// <summary>
        /// 序列化过的角色名
        /// </summary>	
        public override string NormalizedName { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用,0:不启用，1：启用
        /// </summary>	
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// 是否系统角色,0:不是,1:是
        /// </summary>	
        public bool IsSysRole { get; set; } = false;

        /// <summary>
        /// 并发时间戳
        /// </summary>
        public override string ConcurrencyStamp { get; set; } = string.Empty;

        /// <summary>
        /// 创建用户Id,对应Users的Id
        /// </summary>	
        public Guid CreateUserId { get; set; } = Guid.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime CreateTime { get; set; } = DateTime.Parse("1900-01-01");

        /// <summary>
        /// 修改用户Id,对应Users的Id
        /// </summary>	
        public Guid? UpdateUserId { get; set; } = Guid.Empty;

        /// <summary>
        /// 修改时间
        /// </summary>	
        public DateTime? UpdateTime { get; set; } = DateTime.Parse("1900-01-01");

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark { get; set; } = string.Empty;
        
        #endregion Model
    }
}