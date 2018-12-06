using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using paidbackendapi.Controllers;
using pictures;

namespace paidbackendapi.Services
{
    public class ValueService
    {
        List<PictureTemplates> mockData = new List<PictureTemplates>();
        List<String> Names = new List<string>();
        readonly string path = Path.Combine(Environment.CurrentDirectory, @"Data/mockData.json");

        public Data GetValues(string filter, string sort)
        {

            var jsonArray = System.IO.File.ReadAllText(path);
            mockData = JsonConvert.DeserializeObject<List<PictureTemplates>>(jsonArray);

            foreach (var post in mockData)
            {
                if (!Names.Contains(post.user.name))
                {
                    Names.Add(post.user.name);
                }
            }

            List<PictureTemplates> returnList = new List<PictureTemplates>();
            if (filter.Length > 0)
            {
                foreach (var item in mockData)
                {
                    if (item.user.name.ToLower().Equals(filter))
                    {
                        returnList.Add(item);
                    }
                }
            }

            if (!returnList.Any())
            {
                returnList = mockData;
            }
            return new Data { Names= Names, Content= returnList };
        }
    }
}
