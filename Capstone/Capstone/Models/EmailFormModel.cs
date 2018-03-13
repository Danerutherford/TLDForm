using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "User email"), EmailAddress]
        public string FromEmail { get; set; }

        public string Message { get; set; }
    }
}