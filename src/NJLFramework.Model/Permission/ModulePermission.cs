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
    ///模块授权
    /// <summary>
    [Table("ModulePermission")]
    public partial class ModulePermission : IEntity<ModulePermission>
    {
        #region Model

        /// <summary>
        /// 主键Id
        /// </summary>	
        [Key]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 公司Id,与SysCompany的Id关联
        /// </summary>	
        public Guid CompanyId { get; set; } = Guid.Empty;

        /// <summary>
        /// 模块Id,对应CompanyModule的Id
        /// </summary>	
        public Guid ModuleId { get; set; } = Guid.Empty;

        /// <summary>
        /// 相关Id,对应Roles,Users,Positions中的Id
        /// </summary>	
        public Guid RelationId { get; set; } = Guid.Empty;

        /// <summary>
        /// 相关标识,0:用户,1:角色,2:职位
        /// </summary>	
        public int RelationType { get; set; } = 0;

        /// <summary>
        /// Properties
        /// </summary>	
        public int Properties { get; set; } = 0;

        /// <summary>
        /// 创建用户Id，对应Users表的Id
        /// </summary>	
        public Guid CreateUserId { get; set; } = Guid.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime CreateTime { get; set; } = DateTime.Parse("1900-01-01");


        #endregion Model
    }
}