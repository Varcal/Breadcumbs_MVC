using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Breadcumbs_MVC.Models;

namespace Breadcumbs_MVC
{
    public static class HtmlExtensions
    {
        static string _area;
        static string _controller;
        static string _action;

        public static IHtmlString BuildBreadcrumbNavigation(this HtmlHelper helper, [Optional]bool mostrar)
        {
            _area = helper.ViewContext.RouteData.Values["area"]?.ToString();
            _controller = helper.ViewContext.RouteData.Values["controller"]?.ToString();
            _action = helper.ViewContext.RouteData.Values["action"]?.ToString();            


            if (ShowInHomeAndAccountController(mostrar))
            {
                return helper.Raw(string.Empty);
            }

            var menus = MenuItemsService.GetMenusTest();

            var breadcumbList = BreadcumbItem.CreateBreadCumb(menus, _area, _controller, _action);

            var breadcrumb = new StringBuilder();

            breadcrumb.Append(Constants.OpenBreadCrumb);

            CreateBreadcumbItem(helper, breadcrumb, new BreadcumbItem(Constants.TitleInitialPage, _area, Constants.HomeController, Constants.ActionIndex, Constants.IsLink));

            foreach (var breadcumbItem in breadcumbList)
            {
                CreateBreadcumbItem(helper, breadcrumb, breadcumbItem);
            }

            string html = breadcrumb.Append(Constants.CloseBreadCrumb).ToString();

            return helper.Raw(html);
        }


        private static bool ShowInHomeAndAccountController(bool mostrar)
        {
            return mostrar && (IsHomeController() || IsAccountController());
        }

        private static bool IsAccountController()
        {
            return _controller == Constants.AccountController;
        }

        private static bool IsHomeController()
        {
            return _controller == Constants.HomeController;
        }

        private static void CreateBreadcumbItem(HtmlHelper helper, StringBuilder breadcrumb, BreadcumbItem item)
        {
            breadcrumb.Append(Constants.OpenLi);

            if (!item.IsLink || (string.IsNullOrWhiteSpace(item.Controller) && string.IsNullOrWhiteSpace(item.Action)))
            {
                breadcrumb.Append(item.Title);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(item.Area))
                {
                    breadcrumb.Append(helper.ActionLink(item.Title, item.Action, item.Controller));
                }
                else
                {
                    breadcrumb.Append(helper.ActionLink(item.Title, item.Action, item.Controller, new {area = item.Area}));
                }
            }

            breadcrumb.Append(Constants.CloseLi);
        }
    }
}