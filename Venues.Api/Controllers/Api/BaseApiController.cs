using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Venues.Api.Models.Database;

namespace Venues.Api.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        public ApplicationContext DbContext { get; private set; }

        public BaseApiController()
        {
            DbContext = new ApplicationContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
