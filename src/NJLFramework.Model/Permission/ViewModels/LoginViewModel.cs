/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：LoginViewModel.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-03-14 11:49:45
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NJLFramework.Model.Permission.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "LOGIN_USERNAME_REQUIRED")]
        [MaxLength(10,ErrorMessage ="LOGIN_USERNAME_TOO_LONG")]
        [DataType(DataType.Text)]
        [Display(Name ="LOGIN_USERNAME_LABEL")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "LOGIN_PASSWORD_REQUIRED")]
        [StringLength(16,MinimumLength =6,ErrorMessage = "LOGIN_PASSWORD_LENGTH_INVALID")]
        [DataType(DataType.Password)]
        [Display(Name = "LOGIN_PASSWORD_LABEL")]
        public string Password { get; set; }
    }
}
