﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCleanArch.Application.Common.Constants
{
    public static class Constants
    {
        public static string BaseUrl = "";
        public static string DateFormat = "yyyy-MM-dd";
        public static string LongDateFormat = "yyyy-MM-dd hh:mm tt";
        public static string FiscalYearClaimName = "FY";
        public static string ConnectionString = "";

        public static class EmailSetup
        {
            public static string FromEmail { get; set; } = "";
            public static string FromName { get; set; } = "";
            public static string SMTP_USERNAME { get; set; } = "";
            public static string SMTP_PASSWORD { get; set; } = "";
            public static string SMTP_PORT { get; set; } = "";
            public static string SMTP_HOST { get; set; } = "";
            public static string FB_Key { get; set; } = "";
        }

        public static class JwtToken
        {
            public static string Issuer = "";
            public static string Audience = "";
            public static string SigningKey = "";
            public static int TokenTimeoutMinutes = 60;
        }
    }
}
