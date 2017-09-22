using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Breadcumbs_MVC
{
    public static class HtmlExtensions
    {
        static string _controller;
        static string _action;

        public static IHtmlString BuildBreadcrumbNavigation(this HtmlHelper helper, [Optional]bool mostrar)
        {          
            _controller = helper.ViewContext.RouteData.Values["controller"].ToString();
            _action = helper.ViewContext.RouteData.Values["action"].ToString();

            
            if (ShowInHomeAndAccountController(mostrar))
            {
                return helper.Raw(string.Empty);
            }

            var breadcrumb = new StringBuilder();

            breadcrumb.Append(Constants.OpenBreadCrumb);

            if (IsHomeController() && !IsActionIndex())
            {
                CreateInitialPageLink(helper, breadcrumb);
            }

            if (!IsHomeController())
            {
                CreateInitialPageLink(helper, breadcrumb);

                //Fazer o select do menu para pegar o titulo do menu principal
                var menu = "Menu Superior";

                CreateCurrrentMenuText(breadcrumb, menu);

                if (IsActionIndex())
                {
                    CreateCurrentControllerText(breadcrumb);
                }                
            }

            if (!IsActionIndex())
            {
                if (!IsHomeController())
                {
                    CreateCurrentControllerLink(helper, breadcrumb);
                }

                CreateCurrentActionText(breadcrumb); //text
                //CreateCurrentActionLink(helper, breadcrumb); //link
            }

            string html = breadcrumb.Append(Constants.CloseBreadCrumb).ToString();

            return helper.Raw(html);
        }

        private static void CreateCurrentActionText(StringBuilder breadcrumb)
        {
            breadcrumb.Append(Constants.OpenLi);
            breadcrumb.Append(_action.Titleize()); // like a text
            breadcrumb.Append(Constants.CloseLi);
        }

        private static void CreateCurrentActionLink(HtmlHelper helper, StringBuilder breadcrumb)
        {
            breadcrumb.Append(Constants.OpenLi);
            breadcrumb.Append(helper.ActionLink(_action.Titleize(), _action, _controller)); 
            breadcrumb.Append(Constants.CloseLi);
        }
     
        private static void CreateCurrentControllerLink(HtmlHelper helper, StringBuilder breadcrumb)
        {
            breadcrumb.Append(Constants.OpenLi);
            breadcrumb.Append(helper.ActionLink(_controller.Titleize(), Constants.ActionIndex, _controller));
            breadcrumb.Append(Constants.CloseLi);
        }

        private static void CreateCurrentControllerText(StringBuilder breadcrumb)
        {
            breadcrumb.Append(Constants.OpenLi);
            breadcrumb.Append(_controller.Titleize());
            breadcrumb.Append(Constants.CloseLi);
        }

        private static void CreateCurrrentMenuText(StringBuilder breadcrumb, string menu)
        {
            breadcrumb.Append(Constants.OpenLi);
            breadcrumb.Append(menu);
            breadcrumb.Append(Constants.CloseLi);
        }

        private static void CreateInitialPageLink(HtmlHelper helper, StringBuilder breadcrumb)
        {
            breadcrumb.Append(Constants.OpenLi);
            breadcrumb.Append(helper.ActionLink(Constants.TitleInitialPage, Constants.ActionIndex, Constants.HomeController));
            breadcrumb.Append(Constants.CloseLi);
        }

        private static bool ShowInHomeAndAccountController(bool mostrar)
        {
            return mostrar && (IsHomeController() || IsAccountController());
        }

        private static bool IsAccountController()
        {
            return _controller == Constants.AccountController;
        }

        private static bool IsActionIndex()
        {
            return _action == Constants.ActionIndex;
        }

        private static bool IsHomeController()
        {
            return _controller == Constants.HomeController;
        }
    }

    public static class StringExtensions
    {
        public static string Titleize(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text).ToSentenceCase();
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
        }
    }
}