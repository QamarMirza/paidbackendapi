using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pictures;

namespace paidbackendapi.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class ValuesController : Controller
    {
        List<PictureTemplates> mockData = new List<PictureTemplates>();
        List<String> Names = new List<string>();
        readonly string path = Path.Combine(Environment.CurrentDirectory, @"Data/mockData.json");

        // GET api/values
        [HttpGet]
        public Data Get()
        {
            string filter = "";
            string sort = "";

            var jsonArray = System.IO.File.ReadAllText(path);
            mockData = JsonConvert.DeserializeObject<List<PictureTemplates>>(jsonArray);

            foreach (var post in mockData)
            {
                if (!Names.Contains(post.user.name))
                {
                    Names.Add(post.user.name);
                }
            }

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

            List<PictureTemplates> returnList = new List<PictureTemplates>();
            if (filter.Length > 0)
            {
                foreach (var item in mockData)
                {
                    if (item.user.name.ToLower().Equals(filter)){
                        returnList.Add(item);
                    }
                }
            }

            if (!returnList.Any())
            {
                returnList = mockData;
            }

            return new Data
            {
                Names = Names,
                Content = returnList
            };
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
