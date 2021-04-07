using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace Project.Models
{

        [MySqlCollation("latin1_spanish_ci")]

        public class PasswordResetTableModule
        {
            [MySqlCharset("latin1")]
            public string householdEmail { get; set; }
            public int passwordResetID { get; set; }
        }
    
}