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
    ///部门表
    /// <summary>
    [Table("Departments")]
    public partial class Departments : IEntity<Departments>
    {
        #region Model

        /// <summary>
        /// 主键
        /// </summary>	
        [Key]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 公司Id
        /// </summary>	
        public Guid CompanyId { get; set; } = Guid.Empty;

        /// <summary>
        /// 部门名称
        /// </summary>	
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 父级部门
        /// </summary>	
        public Guid? ParentId { get; set; } = Guid.Empty;

        /// <summary>
        /// 部门类型,0:公司;1:部门;2:小组
        /// </summary>	
        public int DepartmentType { get; set; } = 0;

        /// <summary>
        /// 并发时间戳
        /// </summary>	
        public string ConcurrencyStamp { get; set; } = string.Empty;

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