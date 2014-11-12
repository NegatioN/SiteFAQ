using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace TestSiteFAQ.Models
{
    public class FAQInitializer : DropCreateDatabaseIfModelChanges<FAQContext>
    {
        public FAQInitializer()
        {
            FAQContext db = new FAQContext();

            try
            {
                if (db.Faqs.ToList().Count() == 0)
                    Seed(db);
            }
            catch (Exception e)
            {
                Seed(db);
            }
        }
        protected override void Seed(FAQContext context)
        {
            Debug.WriteLine("db-Init start");
            var faqs = new List<FAQ>{
                new FAQ{Heading = "Toretang?", Category=FAQ.Categories[0], Description= "Tore tang er en gammel mann"},
                new FAQ{Heading = "Torsk", Category=FAQ.Categories[1], Description = "Lang tekst som forklarer torsk"},
                new FAQ{Heading = "Lorem Ipsum", Category=FAQ.Categories[2], Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."}
            };
            foreach(var faq in faqs){
                context.addFAQ(faq);
                Debug.WriteLine(faq.Heading + " added.");
            }
            context.SaveChanges();
            Debug.WriteLine("Db-init complete");
        }
    }
}