using System;
using System.Collections.Generic;
using System.Text;

namespace AuthService.Config
{
    static class Config
    {
        static public string dbHost { get; } = "192.168.0.14";
        static public int dbPort { get; } = 5432;
        static public string dbUser { get; } = "user";
        static public string dbPassword { get; } = "1234";
        static public string dbTable { get; } = "database";
    }
}
