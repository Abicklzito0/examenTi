using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TalperExamen.Server
{
    public class ClaseBase
    {
        public static string getConexion()
        {
            var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();
            string conn = configuration["OtraBase"];
            string jjis = CryptoFNS.Function.Decrypt(conn);
           
           string mico = CryptoFNS.Function.Encrypt(@"Server=LT-LMM391P\SQLEXPRESS11; Database = talperExamen; User Id = sa; Password = IIPe65?01;");

            //  string mico = CryptoFNS.Function.Encrypt(@"workstation id=TalperExamen.mssql.somee.com;packet size=4096;user id=Abicklzito0_SQLLogin_1;pwd=kx4adechqf;data source=TalperExamen.mssql.somee.com;persist security info=False;initial catalog=TalperExamen");
            return CryptoFNS.Function.Decrypt(conn);
        }
    }
}

