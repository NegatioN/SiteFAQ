using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSiteFAQ.Models
{
    public class FAQ
    {
        public static String[] Categories = {"Betaling", "Siden", "Om oss", "Handel"};

        public String Heading { get; set; }
        public String Description { get; set; }
        public int FAQId { get; set; }
        public String Category { get; set; }

    }
}