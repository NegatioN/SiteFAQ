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
        public DbSet<Question> pendingFaqs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }

        public List<FAQ> getAllFAQs()
        {
            return Faqs.Where(a => a.Heading != null).ToList();
        }

        public List<Question> getAllQuestions()
        {
            return pendingFaqs.ToList();
        }

        public FAQ getFAQ(int id)
        {
            return Faqs.Where(a => a.FAQId == id).SingleOrDefault();
        }

        public Boolean addQuestion(Question faq){
            bool result = pendingFaqs.Add(faq) != null;
            SaveChanges();

            return result;

        }

        public Boolean addFAQ(FAQ faq)
        {
            bool result = Faqs.Add(faq) != null;
            SaveChanges();
            return result;
        }
        
    }
}