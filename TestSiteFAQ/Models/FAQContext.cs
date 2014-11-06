using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TestSiteFAQ.Models
{
    public class FAQContext : DbContext
    {

        public DbSet<FAQ> Faqs { get; set; }
        public DbSet<PendingFAQ> pendingFaqs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }

        public List<FAQ> getAllFAQs()
        {
            return Faqs.ToList();
        }

        public FAQ getFAQ(int id)
        {
            return Faqs.Where(a => a.FAQId == id).SingleOrDefault();
        }

        public Boolean addPendingFAQ(PendingFAQ faq){
            return pendingFaqs.Add(faq) != null;

        }

        public void addFAQ(FAQ faq)
        {
            Faqs.Add(faq);
        }
        
    }
}