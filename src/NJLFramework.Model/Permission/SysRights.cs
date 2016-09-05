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
    ///系统权限项表
    /// <summary>
    [Table("SysRights")]
    public partial class SysRights : IEntity<SysRights>
    {
        #region Model

        /// <summary>
        /// 主键
        /// </summary>	
        [Key]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 权限key值
        /// </summary>	
        public string RightKey { get; set; } = string.Empty;

        /// <summary>
        /// 权限名称
        /// </summary>	
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 当拥有RightKey的权限时，ParallelRight所指向的权限也就拥有了。
        /// </summary>	
        public string ParallelRight { get; set; } = string.Empty;

        /// <summary>
        /// 是否启用，0：不启用，1：启用,不启用，则当删除CompanyRights中相关的记录
        /// </summary>	
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// 权限项顺序
        /// </summary>	
        public int Order { get; set; } = 0;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark { get; set; } = string.Empty;


        #endregion Model
    }
}