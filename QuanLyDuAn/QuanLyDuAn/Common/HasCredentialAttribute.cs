using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyDuAn.Common
{
    public class HasCredentialAttribute : AuthorizeAttribute
    {
        public string RoleID { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserLogin)HttpContext.Current.Session[CommonConstants.USER_SESSION];
            List<string> privilegeLevels = this.GetCredentialByLoggedInUser(session.UserID);

            if (privilegeLevels.Contains(this.RoleID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
<<<<<<< HEAD
=======
            string Message = "Bạn không có quyền thực hiện thao tác này";

            var values = new RouteValueDictionary(new
            {
                action = "Login",
                controller = "Account",
                exceptiontext = Message
            });
            filterContext.Result = new RedirectToRouteResult(values);
>>>>>>> 9962297f98ab595dc513f659f041d29a6399123b
        }
        private List<string> GetCredentialByLoggedInUser(string username)
        {
            var credentials = (List<string>)HttpContext.Current.Session[CommonConstants.SESSION_CREDENTIAL];
            return credentials;
        }
    }
}