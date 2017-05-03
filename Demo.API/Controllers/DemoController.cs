using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Demo.Data;
using System.Web.Http.Cors;

namespace Demo.API.Controllers
{
    public class DemoController : ApiController
    {
        private readonly IDemoRepository _dempRepo;
        public DemoController(IDemoRepository repo)
        {
            _dempRepo = repo;
        }
        [HttpGet]
        [EnableCors(origins:"*", headers:"*",methods:"*")]
        public HttpResponseMessage Get()
        {
             return Request.CreateResponse(HttpStatusCode.OK, _dempRepo.Get());
        }
        
       
    }
}
