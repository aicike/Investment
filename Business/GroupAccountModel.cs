﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace Business
{
    public class GroupAccountModel : BaseModel<GroupAccount>
    {
        /// <summary>
        /// 集团登陆
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Result Login(string userName, string password)
        {
            string pwd = DESEncrypt.Encrypt(password);
            var obj = List().Where(a => a.AccountNumber == userName && a.AccountPwd == pwd).FirstOrDefault();
            Result result = new Result();
            if (obj == null)
            {
                result.Error = "账号或密码错误。";
            }
            else
            {
                result.Entity = obj;
            }
            return result;
        }

        /// <summary>
        /// 查询登陆账号是否已存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>True:存在；false 不存在</returns>
        public bool GetUnameIsOnly(string AccountNumber)
        {
            var list = List().Where(a => a.AccountNumber == AccountNumber);
            if (list.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
