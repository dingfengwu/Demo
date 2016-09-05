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
    ///公司表
    /// <summary>
    [Table("SysCompany")]
    public partial class SysCompany : IEntity<SysCompany>
    {
        #region Model

        /// <summary>
        /// 主键
        /// </summary>	
        [Key]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 公司名
        /// </summary>	
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 授权码
        /// </summary>	
        public string License { get; set; } = string.Empty;

        /// <summary>
        /// 电话
        /// </summary>	
        public string Tel { get; set; } = string.Empty;

        /// <summary>
        /// 传真
        /// </summary>	
        public string Fax { get; set; } = string.Empty;

        /// <summary>
        /// 公司地址
        /// </summary>	
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// 域名
        /// </summary>	
        public string Domain { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>	
        public string Remark { get; set; } = string.Empty;


        #endregion Model
    }
}