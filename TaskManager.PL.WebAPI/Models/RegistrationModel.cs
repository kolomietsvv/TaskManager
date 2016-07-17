using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.PL.WebAPI.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public string Token { get; set; }

        public RegistrationModel()
        {
            
        }
    }
}