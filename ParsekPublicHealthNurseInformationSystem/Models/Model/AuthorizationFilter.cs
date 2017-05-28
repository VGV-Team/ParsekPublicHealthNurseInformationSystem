using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ParsekPublicHealthNurseInformationSystem.Models
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public new void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                // Don't check for authorization as AllowAnonymous filter is applied to the action or controller
                return;
            }

            if (Allowed == null)
            {
                return;
            }

            User user = (User)HttpContext.Current.Session["user"];
            if (user != null)
            {
                string userRole = user.Role.Title;

                // Check if roles match.
                foreach (var role in Allowed)
                {
                    if (userRole == role)
                    {
                        return;
                    }
                }

                if (user.Employee != null)
                {
                    string userJobTitle = user.Employee.JobTitle.Title;

                    // Check if job title match.
                    foreach (var jobTitle in Allowed)
                    {
                        if (userJobTitle == jobTitle)
                        {
                            return;
                        }
                    }
                }
            }

            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary{
                    { "controller", "Home" },
                    { "action", "Index" }
                });
        }

        
        private string[] Allowed { get; set; }

        public AuthorizationFilter(params string[] rolesRequired)
        {
            Allowed = rolesRequired;
        }

    }
}