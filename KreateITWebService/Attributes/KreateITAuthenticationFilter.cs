using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using KreateIT.Business;

namespace KreateITWebService.Attributes
{
    public class KreateITAuthenticationFilter : BasicAuthenticationFilter
    {
        public KreateITAuthenticationFilter()
        { }

        public KreateITAuthenticationFilter(bool active)
            : base(active)            
        { }


        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            return UserBLL.AuthoriseAdminUser(username, password);
        }
    }
}