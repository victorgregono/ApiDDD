using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDDD.Data.SqlQuerys
{
    public class promocaoScript
    {
        public static string PromocoesScript
           => @"SELECT top(100) * 
                FROM Promocao 
                    order by DATAHORA desc";
    }
}
