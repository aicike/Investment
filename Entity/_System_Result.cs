﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Result
    {
        public Result() { }
        public Result(string error)
        {
            this.Error = error;
        }

        private bool hasError = false;
        public bool HasError
        {
            get { return hasError; }
            set { hasError = value; }
        }

        private string error = null;
        public string Error
        {
            get { return error; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    HasError = true; error = value.Replace("\r\n", "");
                }
            }
        }

        public string EntityType { get; set; }

        public object Entity { get; set; }
    }
}
