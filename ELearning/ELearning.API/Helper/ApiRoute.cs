using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.API.Helper
{
    public static class ApiRoute
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string BaseUrl = Root + "/" + Version;
        public static class Title
        {
            public const string Create = BaseUrl + "/title/create";
            public const string GetAll = BaseUrl + "/title/list";
            public const string Get = BaseUrl + "/title/{titleId}/detail";
            public const string Bulk = BaseUrl + "/title/bulk";
            public const string Update = BaseUrl + "/title/{titleId}/update";
        }

        public static class Account
        {
            public const string Register = BaseUrl + "/account/register";
            public const string Login = BaseUrl + "/account/login";
        }

    }
}
