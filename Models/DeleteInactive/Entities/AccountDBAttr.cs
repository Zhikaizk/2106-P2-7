using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace Project.Models.DeleteInactive
{
    [MySqlCollation("latin1_spanish_ci")]
    public class AccountDBAttr
    {
        [MySqlCharset("latin1")]
        public int idAccount { get; set; }
        public string email { get; set; }
    }
}
