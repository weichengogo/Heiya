using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsuing
{
    class Program
    {
        static void Main(string[] args)
        {
            GetRequest("http://localhost:56980/api/Demo");
            Console.ReadKey();
        }

        async static void GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        Console.WriteLine(mycontent);
                    }
                }
        }
        }
    }
}
