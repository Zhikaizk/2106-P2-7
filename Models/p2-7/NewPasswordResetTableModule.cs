using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace Project.Models
{

        [MySqlCollation("latin1_spanish_ci")]

        public class NewPasswordResetTableModule
        {
            [MySqlCharset("latin1")]
            public string newResetPassword { get; set; }
            public string confirmResetPassword { get; set; }
            public int newPasswordResetID { get; set; }
            public string householdEmail { get; set; }

        }
    
}