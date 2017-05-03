using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data
{
     public class DemoRepository : IDemoRepository
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}
