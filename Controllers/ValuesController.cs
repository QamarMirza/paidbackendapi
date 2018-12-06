using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using paidbackendapi.Services;
using pictures;

namespace paidbackendapi.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class ValuesController : Controller
    {

        // GET api/values
        [HttpGet]
        public Data Get()
        {
            string filter = "";
            string sort = "";

            if (Request.QueryString.Value.ToString().Length > 1)
            {
                var queryDictionary = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(Request.QueryString.Value);
                foreach (var kvp in queryDictionary)
                {
                    if (kvp.Key.ToString().Equals("filter"))
                    {
                        filter = kvp.Value.ToString().ToLower();
                    }
                    if (kvp.Key.ToString().Equals("sort"))
                    {
                        sort = kvp.Value.ToString().ToLower();
                    }
                }


            }
            ValueService valueService = new ValueService();
            return valueService.GetValues(filter, sort);
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
