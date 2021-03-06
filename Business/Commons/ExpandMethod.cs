﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace System
{
    public static partial class ExpandMethod
    {
        /// <summary>
        /// 字符串转成整型数组
        /// </summary>
        public static int[] ConvertToIntArray(this string[] value)
        {
            if (value == null)
            {
                return null;
            }
            int[] array = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                array[i] = Convert.ToInt32(value[i]);
            }
            return array;
        }

        /// <summary>
        /// 集合拼接成字符串
        /// </summary>
        public static string ConvertToString<T>(this IList<T> list, string split)
        {
            if (list != null)
            {
                StringBuilder str = new StringBuilder();
                foreach (var item in list)
                {
                    str.AppendFormat("{0}{1}", item, split);
                }
                string value = str.ToString();
                if (value.Length > 0)
                {
                    value = value.Remove(value.Length - split.Length);
                }
                return value;
            }
            return "";
        }

        public static int[] ConvertToIntArray(this string value, char split)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                string[] str_array = value.Split(new char[] { split }, StringSplitOptions.RemoveEmptyEntries);
                int[] array = new int[str_array.Length];
                for (int i = 0; i < str_array.Length; i++)
                {
                    array[i] = int.Parse(str_array[i]);
                }
                return array;
            }
            return null;
        }

        /// <summary>
        /// 获取字符窜后缀名
        /// </summary>
        /// <param name="path"></param>
        /// <returns>.xxx</returns>
        public static string GetFileSuffix(this string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return "";
            }
            else
            {
                return path.Substring(path.LastIndexOf('.')).ToLower();
            }
        }

        /// <summary>
        /// false 发生没有权限异常
        /// </summary>
        /// <param name="value"></param>
        public static void NotAuthorizedPage(this bool value, string message = null)
        {
            if (!value)
            {
                if (message != null)
                {
                    throw new ApplicationException(message);
                }
                else
                {
                    throw new ApplicationException("无权操作。");
                }
            }
        }
    }
}