using MySql.Data.EntityFrameworkCore.DataAnnotations;
namespace EFCoreSample
{
        [MySqlCollation("latin1_spanish_ci")]
        public class FeedbackTableModule
        {
            [MySqlCharset("latin1")]
            public string FeedbackContent { get; set; }
            public string HouseholdEmail { get; set; }
            public string FeedbackStatus { get; set; }
            public string FeedbackType { get; set; }
            public int FeedbackId { get; set; }
        }
    }


