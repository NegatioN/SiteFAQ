using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSiteFAQ.Models
{
    public class PendingFAQ
    {

        public int PendingFAQId { get; set; }

        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            ErrorMessage = "Skriv inn en gyldig e-mail")]
        public String Email { get; set; }

        public String Description { get; set; }
    }
}