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

            if (db.Faqs.ToList().Count() == 0)
                Seed(db);
        }
        protected override void Seed(FAQContext context)
        {
            Debug.WriteLine("db-Init start");
            var faqs = new List<FAQ>{
                new FAQ{Heading = "Toretang?", Category=FAQ.Categories[0], Description= "Tore tang er en gammel mann"},
                new FAQ{Heading = "Torsk", Category=FAQ.Categories[1], Description = "Lang tekst som forklarer torsk"}
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