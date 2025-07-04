﻿namespace MyProject.Web.Utility
{
    public static class CConst
    {
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public static string AccessToken = "JWTToken";
        public static string RefreshToken = "RefreshToken";

        public const string Admin = "admin";
        public const string Customer = "customer";
        public enum ContentType
        {
            Json,
            MultipartFormData,
        }
    }
}
