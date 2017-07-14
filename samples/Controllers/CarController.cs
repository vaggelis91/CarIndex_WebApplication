using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data.SqlClient;
using System.Net.Http.Formatting;
using System.Collections.Specialized;
using Newtonsoft.Json.Serialization;
using System.Text;
using System.Net.Mail;

namespace samples.Controllers
{
    public class CarController : ApiController
    {		

		// GET api/<controller>
		[HttpGet()]
        public void Get()
        {
		}

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}
        [HttpPost()]
        public List<Car> Post(FormDataCollection formData)
        {
			List<Car> carList = new List<Car>();			
			return carList = Methods.ExecuteQuery(Methods.BuidQuery(formData.Get("Brand"), formData.Get("Model"), formData.Get("Engine_Capacity"), 
																	formData.Get("Fuel_type"), formData.Get("Type"), formData.Get("Condition"), 
																	formData.Get("Price")));
        }

		[HttpPost()]
		public string SendEmail(FormDataCollection formData)
		{
			if (Methods.CreateEmail(formData.Get("Name"), formData.Get("Email"), formData.Get("commentsBox")))
			{
				return "Email sent successfully.";
			}
			else
			{
				return "Email was not sent.";
			}
		}


		// PUT api/<controller>/5
		public void Put(int id, [FromBody]string value)
        {    
                  
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        


    }
}