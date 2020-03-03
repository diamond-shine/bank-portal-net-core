using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public abstract class ConnectionInfo
    {
        protected string centennialExternal = "User Id=COMP214_M19_002_8;Password=kamila;Data Source=199.212.26.208:1521/SQLD";
        protected string centennialLocal = "User Id=COMP214_M19_002_8;Password=kamila;Data Source=oracle1.centennialcollege.ca:1521/SQLD";
        protected string localServer = "User Id=Daniel;Password=kamikaze;" + "Data Source=localhost:1521/xe";
    }
}
