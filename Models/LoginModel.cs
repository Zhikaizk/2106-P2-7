using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class LoginModel
    {
        public String id { get; set; }
        public String username { get; set; }
        public String password { get; set; }

        public String type { get; set; }

        public LoginModel(){}
        public LoginModel(String id,String username,String password, String type){
            this.id = id;
            this.username = username;
            this.password = password;
        
        }
        [Required(ErrorMessage = "Please enter user name.")] //test
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Name")]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(10)]
        public string Password { get; set; }

    }

    [Table("tblUser")]
    public class tblUser
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}