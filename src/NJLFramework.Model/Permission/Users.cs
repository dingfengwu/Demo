﻿/*----------------------------------------------------------------
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
    ///用户表
    /// <summary>
    [Table("Users")]
    public partial class Users : IdentityUser<Guid>, IEntity<Users>
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
        public Guid? CompanyId { get; set; } = Guid.Empty;

        /// <summary>
        /// 登陆失败次数
        /// </summary>	
        public override int AccessFailedCount { get; set; } = 0;

        /// <summary>
        /// 是否启用登陆失败锁定,0:不启用，1:启用
        /// </summary>	
        public override bool LockoutEnabled { get; set; } = false;

        /// <summary>
        /// 锁定时长
        /// </summary>	
        public override DateTimeOffset? LockoutEnd { get; set; } = new DateTimeOffset();

        /// <summary>
        /// 登陆邮件地址
        /// </summary>	
        public override string Email { get; set; } = string.Empty;

        /// <summary>
        /// 序列化过的登陆邮件地址
        /// </summary>	
        public override string NormalizedEmail { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用邮件地址验证,0:不启用,1:启用
        /// </summary>	
        public override bool EmailConfirmed { get; set; } = false;

        /// <summary>
        /// 登陆手机号码
        /// </summary>	
        public override string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用手机号码验证,0:不启用，1：启用
        /// </summary>	
        public override bool PhoneNumberConfirmed { get; set; } = false;

        /// <summary>
        /// 用户名
        /// </summary>	
        public override string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 序列化过的用户名
        /// </summary>	
        public override string NormalizedUserName { get; set; } = string.Empty;

        /// <summary>
        /// 密码的hash码
        /// </summary>	
        public override string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// 安全戳
        /// </summary>	
        public override string SecurityStamp { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用二因素验证,0:不启用，1;:启用
        /// </summary>	
        public override bool TwoFactorEnabled { get; set; } = false;

        /// <summary>
        /// 用户密钥
        /// </summary>	
        public string UserSecret { get; set; } = string.Empty;

        /// <summary>
        /// token
        /// </summary>	
        public string UserToken { get; set; } = string.Empty;

        /// <summary>
        /// 是否系统用户
        /// </summary>	
        public bool IsSysUser { get; set; } = false;

        /// <summary>
        /// 员工Id,对应Employees的Id
        /// </summary>	
        public Guid EmployeeId { get; set; } = Guid.Empty;

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