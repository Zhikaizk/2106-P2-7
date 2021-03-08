using MySql.Data.EntityFrameworkCore.DataAnnotations;
namespace EFCoreSample
{
        [MySqlCollation("latin1_spanish_ci")]
        public class FeedbackTableModule
        {
            [MySqlCharset("latin1")]
            public string feedbackContent { get; set; }
            public string householdEmail { get; set; }
            public string feedbackStatus { get; set; }
            public string feedbackType { get; set; }
            public int feedbackId { get; set; }
        }
    }


