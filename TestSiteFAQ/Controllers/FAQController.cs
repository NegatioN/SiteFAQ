using TestSiteFAQ.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace TestSiteFAQ.Controllers
{
    public class FAQController : ApiController
    {
        public HttpResponseMessage Get()
        {
            FAQContext db = new FAQContext();

            

            List<FAQ> faqs = db.getAllFAQs();
            JavaScriptSerializer json = new JavaScriptSerializer();

            String JsonString = json.Serialize(faqs);

            Debug.WriteLine(JsonString);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };

        }

        public HttpResponseMessage Get(int id)
        {
            FAQContext db = new FAQContext();
            FAQ faq = db.getFAQ(id);

            JavaScriptSerializer json = new JavaScriptSerializer();

            String JsonString = json.Serialize(faq);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };


        }

        public HttpResponseMessage Post(PendingFAQ faq)
        {
            if (ModelState.IsValid)
            {
                FAQContext db = new FAQContext();
                Boolean OK = db.addPendingFAQ(faq);

                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = new StringContent("Kunne ikke sende spørsmål.")
            };
        }
    }
}
