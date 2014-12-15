using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public static class SystemConst
    {

        public class Session
        {
            private Session() { }

            public const string LoginUser = "LoginUser";
        }

        public class Business
        {
            private Business() { }

            public const string FilePath = "/File/{0}";
            public const string FileTempPath = "/File/Temp";

            public const string key = "abcdefgh";
            public const string iv = "12345678";

        }
    }

}
