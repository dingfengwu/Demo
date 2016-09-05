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
    ///员工表
    /// <summary>
    [Table("Employees")]
    public partial class Employees : IEntity<Employees>
    {
        #region Model

        /// <summary>
        /// 主键Id
        /// </summary>	
        [Key]
        public Guid Id { get; set; } = Guid.Empty;

        /// <summary>
        /// 公司Id,对应SysCompany的Id
        /// </summary>	
        public Guid CompanyId { get; set; } = Guid.Empty;

        /// <summary>
        /// 出生日期
        /// </summary>	
        public DateTime? Birthday { get; set; } = DateTime.Parse("1900-01-01");

        /// <summary>
        /// 工号
        /// </summary>	
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 部门Id,对应Departments的Id
        /// </summary>	
        public Guid DepartmentId { get; set; } = Guid.Empty;

        /// <summary>
        /// 性别
        /// </summary>	
        public int? Gender { get; set; } = 0;

        /// <summary>
        /// 是否离职
        /// </summary>	
        public int? IsDimission { get; set; } = 0;

        /// <summary>
        /// 入职日期
        /// </summary>	
        public DateTime? JoinDate { get; set; } = DateTime.Parse("1900-01-01");

        /// <summary>
        /// 离职日期
        /// </summary>	
        public DateTime? LeaveDate { get; set; } = DateTime.Parse("1900-01-01");

        /// <summary>
        /// 手机号码
        /// </summary>	
        public string MobilePhone { get; set; } = string.Empty;

        /// <summary>
        /// 姓名
        /// </summary>	
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 办公电话
        /// </summary>	
        public string OfficePhone { get; set; } = string.Empty;

        /// <summary>
        /// 其他联系方式
        /// </summary>	
        public string OtherLink { get; set; } = string.Empty;

        /// <summary>
        /// 照片
        /// </summary>	
        public string Photo { get; set; } = string.Empty;

        /// <summary>
        /// 员工拼音简写
        /// </summary>	
        public string PinYin { get; set; } = string.Empty;

        /// <summary>
        /// 职务Id,对应Positions的Id
        /// </summary>	
        public Guid PositionId { get; set; } = Guid.Empty;

        /// <summary>
        /// 员工QQ
        /// </summary>	
        public string QQ { get; set; } = string.Empty;

        /// <summary>
        /// 员工微信
        /// </summary>	
        public string Weixin { get; set; } = string.Empty;

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