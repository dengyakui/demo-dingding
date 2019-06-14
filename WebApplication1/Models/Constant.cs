using System;

namespace WebApplication1.Models
{
    public class Constant
    {
        /**
         * 开发者后台->企业自建应用->选择您创建的E应用->查看->AppKey
         */
        public const String APP_KEY = "dingzmpbosimpev5pra6";
        /**
         * 开发者后台->企业自建应用->选择您创建的E应用->查看->AppSecret
         */
        public const String APP_SECRET = "bwfem_7QM62NzTg6IcuFRyN3EWUWi-wQu8JWGqkt3JAcCdFQ9n8mHHjbyx4bBrot";
    }


    public class GetAccessTokenResponse
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string access_token { get; set; }
    }


    public class GetUserIdResponse
    {
        public string userid { get; set; }
        public int sys_level { get; set; }
        public string errmsg { get; set; }
        public bool is_sys { get; set; }
        public string deviceId { get; set; }
        public int errcode { get; set; }
    }


    public class UserDetail
    {
        public int errcode { get; set; }
        public string unionid { get; set; }
        public string remark { get; set; }
        public string userid { get; set; }
        public string isLeaderInDepts { get; set; }
        public bool isBoss { get; set; }
        public long hiredDate { get; set; }
        public bool isSenior { get; set; }
        public string tel { get; set; }
        public int[] department { get; set; }
        public string workPlace { get; set; }
        public string email { get; set; }
        public string orderInDepts { get; set; }
        public string mobile { get; set; }
        public string errmsg { get; set; }
        public bool active { get; set; }
        public string avatar { get; set; }
        public bool isAdmin { get; set; }
        public bool isHide { get; set; }
        public string jobnumber { get; set; }
        public string name { get; set; }
        public Extattr extattr { get; set; }
        public string stateCode { get; set; }
        public string position { get; set; }
        public Role[] roles { get; set; }
    }

    public class Extattr
    {
    }

    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public string groupName { get; set; }
    }



}