using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace ExceptionHandling
{
    public class ApiException : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext filterContext)
        {
            //ILog Logger;

            if (filterContext.Exception == null)
            {
                return;
            }
            if (filterContext.Exception.GetType() == typeof (ISTException))
            {
                //if it's our customized exception we can perform our logics before logging
                  //Can use the logger
            }
            else
            {
                //General exception
            }

        }
    }
}
