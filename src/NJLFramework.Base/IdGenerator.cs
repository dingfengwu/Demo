/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：IdGenerater.cs
// 文件功能描述：
// 描述内容
//
// 创建人  ：Administrator
// 创建日期：2016-04-12 19:35:37
//----------------------------------------------------------------*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NJLFramework.Base
{
    /// <summary>
    /// 实体Id生成器
    /// </summary>
    public class IdGenerator
    {
        static object _lock = new object();
        static IdGenerator _instance;
        /// <summary>
        /// 生成唯一Id
        /// </summary>
        /// <returns></returns>
        public Guid GetId()
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();

            DateTime baseDate = new DateTime(1900, 1, 1);
            DateTime now = DateTime.Now;

            // Get the days and milliseconds which will be used to build    
            //the byte string    
            TimeSpan days = new TimeSpan(now.Ticks - baseDate.Ticks);
            TimeSpan msecs = now.TimeOfDay;

            // Convert to a byte array        
            // Note that SQL Server is accurate to 1/300th of a    
            // millisecond so we divide by 3.333333    
            byte[] daysArray = BitConverter.GetBytes(days.Days);
            byte[] msecsArray = BitConverter.GetBytes((long)
              (msecs.TotalMilliseconds / 3.333333));

            // Reverse the bytes to match SQL Servers ordering    
            Array.Reverse(daysArray);
            Array.Reverse(msecsArray);

            // Copy the bytes into the guid    
            Array.Copy(daysArray, daysArray.Length - 2, guidArray,
              guidArray.Length - 6, 2);
            Array.Copy(msecsArray, msecsArray.Length - 4, guidArray,
              guidArray.Length - 4, 4);

            return new Guid(guidArray);
        }

        public static IdGenerator Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new IdGenerator();
                    }
                }
                return _instance;
            }
        }
    }
}
