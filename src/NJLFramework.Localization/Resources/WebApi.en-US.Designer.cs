﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NJLFramework.Localization.Resources {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///    强类型资源类，用于查找本地化字符串，等等。
    /// </summary>
    // 此类已由 StronglyTypedResourceBuilder 自动生成
    // 通过 ResGen 或 Visual Studio 之类的工具提供的类。
    // 若要添加或删除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (使用 /str 选项)，或重新生成 VS 项目。
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class WebApi_en_US {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        internal WebApi_en_US() {
        }
        
        /// <summary>
        ///    返回此类使用的缓存 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NJLFramework.Localization.Resources.WebApi-en-US", typeof(WebApi_en_US).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///    重写所有项的当前线程的 CurrentUICulture 属性
        ///    使用此强类型资源类进行资源查找。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///    查找与 您没有此操作的权限 类似的本地化字符串。
        /// </summary>
        public static string ERROR_NOT_PERMISSION {
            get {
                return ResourceManager.GetString("ERROR_NOT_PERMISSION", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 指定的用户不存在 类似的本地化字符串。
        /// </summary>
        public static string ERROR_USER_NO_FOUND {
            get {
                return ResourceManager.GetString("ERROR_USER_NO_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 指定的用户密码不正确 类似的本地化字符串。
        /// </summary>
        public static string ERROR_USER_PASSWORD_NOT_FOUND {
            get {
                return ResourceManager.GetString("ERROR_USER_PASSWORD_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 Login 类似的本地化字符串。
        /// </summary>
        public static string LOGIN_HEADER {
            get {
                return ResourceManager.GetString("LOGIN_HEADER", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 请传入正确格式的数据 类似的本地化字符串。
        /// </summary>
        public static string MODEL_NOT_NULL {
            get {
                return ResourceManager.GetString("MODEL_NOT_NULL", resourceCulture);
            }
        }
        
        /// <summary>
        ///    查找与 用户名： 类似的本地化字符串。
        /// </summary>
        public static string VIEWMODEL_LOGINVIEWMODEL_USERNAME {
            get {
                return ResourceManager.GetString("VIEWMODEL_LOGINVIEWMODEL_USERNAME", resourceCulture);
            }
        }
    }
}
