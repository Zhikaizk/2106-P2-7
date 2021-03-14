using MySql.Data.EntityFrameworkCore.DataAnnotations;



namespace Project.Database
{

        [MySqlCollation("latin1_spanish_ci")]

        public class PasswordResetTableModule
        {
            [MySqlCharset("latin1")]
            public string householdEmail { get; set; }
            public string newPassword { get; set; }
            public string confirmResetPassword { get; set; }
            public int passwordResetID { get; set; }
        }
    
}