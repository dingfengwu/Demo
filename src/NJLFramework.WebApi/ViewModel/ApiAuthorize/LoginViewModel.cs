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

namespace NJLFramework.WebApi.ViewModel.ApiAuthorize
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Username field is required.")]
        [MaxLength(10,ErrorMessage ="无效长度")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="用户名")]
        public string UserName { get; set; }
        
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
