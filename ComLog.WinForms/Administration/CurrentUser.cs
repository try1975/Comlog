﻿using System;

namespace ComLog.WinForms.Administration
{
    public static class CurrentUser
    {
        public static string Login { get; set; }

        public static string Password { get; set; }

        public static string[] Roles { get; set; }

        public static bool MaySeeBalance { get { return Array.Exists(MaySeeBalanceArray, z => z.Equals(Login)); }}

        private static readonly string[] MaySeeBalanceArray = {"ag", "or",  "tli", "yadmin", "vorobyev"};
    }
}