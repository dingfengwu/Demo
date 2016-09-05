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
    ///字段权限管理
    /// <summary>
    [Table("FieldPermission")]
    public partial class FieldPermission : IEntity<FieldPermission>
    {
        #region Model

        /// <summary>
        /// 主键
        /// </summary>	
        [Key]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 公司Id,对应SysCompany的Id
        /// </summary>	
        public Guid CompanyId { get; set; } = Guid.Empty;

        /// <summary>
        /// 模块Id,与CompanyModules的Id关联
        /// </summary>	
        public Guid ModuleId { get; set; } = Guid.Empty;

        /// <summary>
        /// 表Id,与CompanyTables的Id关联
        /// </summary>	
        public Guid TableId { get; set; } = Guid.Empty;

        /// <summary>
        /// 字段Id,与CompanyFields的Id关联
        /// </summary>	
        public Guid FieldId { get; set; } = Guid.Empty;

        /// <summary>
        /// 相关Id,对应Roles,Users,Positions中的Id
        /// </summary>	
        public Guid RelationId { get; set; } = Guid.Empty;

        /// <summary>
        /// 关联标识,0:用户,1:角色,2:职位
        /// </summary>	
        public int RelationType { get; set; } = 0;

        /// <summary>
        /// 权限控制 1:可查询,2:可显示，4:可编辑,8:禁止查询,16:禁止显示,32:禁止编辑,多个值时求和.
        /// </summary>	
        public int Properties { get; set; } = 0;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark { get; set; } = string.Empty;

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