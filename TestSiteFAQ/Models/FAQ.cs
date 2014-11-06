using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSiteFAQ.Models
{
    public class FAQ
    {
        public static String[] Categories = {"Payment", "Site", "About us"};

        public String Heading { get; set; }
        public String Description { get; set; }
        public int FAQId { get; set; }
        public String Category { get; set; }

    }
}