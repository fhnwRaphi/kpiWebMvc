using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Testwebsite.Controllers
{
    public class CommandsController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Command()
        {
            List<string> commandlist = new List<string>();
            commandlist.Add("Hallo");
            commandlist.Add("Welt");
            return commandlist;
        }
        [HttpGet]
        public IQueryable<string> Query()
        {
            List<string> commandlist = new List<string>();
            commandlist.Add("Hallo");
            commandlist.Add("Welt");
            return (IQueryable<string>)commandlist;
        }
    }
}
