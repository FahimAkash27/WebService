using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LibaryUser
{
    class GetFromWebservice : IGetFromWebservice
    {
        public string GetMethod(string url, string value)
        {
            url = url + "/" + value;

            
            var request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response = request.GetResponse())
            {
                using (var streamItem = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(streamItem))
                    {
                        var result = reader.ReadToEnd();

                        return result.ToString();

                        //Console.WriteLine(result);

                        //dynamic item = JsonConvert.DeserializeObject(result);
                        ////Console.WriteLine($"item 1: {item[0]}");
                        ////Console.WriteLine($"item 2: {item[1]}");

                        //return item[0];
                    }
                }
            }

        }
    }
}
