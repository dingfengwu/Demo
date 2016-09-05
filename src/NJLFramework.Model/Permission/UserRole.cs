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
    ///用户角色表
    /// <summary>
    [Table("UserRole")]
    public partial class UserRole : IEntity<UserRole>
    {
        #region Model

        /// <summary>
        /// 联合主键
        /// </summary>	
        [Key]
        public Guid RoleId { get; set; } = Guid.Empty;

        /// <summary>
        /// 联合主键
        /// </summary>	
        [Key]
        public Guid UserId { get; set; } = Guid.Empty;

        /// <summary>
        /// 创建用户Id,对应Users的Id
        /// </summary>	
        public Guid CreateUserId { get; set; } = Guid.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime CreateTime { get; set; } = DateTime.Parse("1900-01-01");


        #endregion Model
    }
}