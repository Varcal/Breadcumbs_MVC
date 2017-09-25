using System.Collections.Generic;
using System.Linq;

namespace Breadcumbs_MVC.Models
{
    public class BreadcumbItem
    {
        public string Title { get; private set; }
        public string Area { get; set; }
        public string Controller { get; private set; }
        public string Action { get; private set; }
        public bool IsLink { get; private set; }
        public int Ordered { get; set; }

        public BreadcumbItem(string title, string area, string controller, string action, bool isLink)
        {
            Title = title;
            Area = area;
            Controller = controller;
            Action = action;
            IsLink = isLink;
        }

        public static IList<BreadcumbItem> CreateBreadCumb(IList<MenuItem> menus, string area, string controller, string action)
        {
            var breadcumbs = new List<BreadcumbItem>();

            if (area == null)
            {
                area = string.Empty;
            }

            var menu = CreateBreadcumbItem(menus, area, controller, action);

            while (menu != null)
            {
                breadcumbs.Add(new BreadcumbItem(menu.Title,menu.Area, menu.Controller, menu.Action, menu.ParentMenuId != null));


                menu = menu.ParentMenuId == null ? null : ReturnParentMenu(menus, menu.ParentMenuId.Value);
            }
            breadcumbs.Reverse();

            return breadcumbs;
        }


        private static MenuItem CreateBreadcumbItem(IList<MenuItem> menus, string area, string controller, string action)
        {
            foreach (var menu in menus)
            {
                var menuitem = menus.FirstOrDefault(x => x.Area == area && x.Controller == controller && x.Action == action);

                if (menuitem != null)
                {
                    return menuitem;
                }

                if (menu.ChildrenMenus != null)
                {
                    var m = CreateBreadcumbItem(menu.ChildrenMenus, area, controller, action);

                    return m;
                }
            }


            return null;
        }

        private static MenuItem ReturnParentMenu(IList<MenuItem> menus, int parentId)
        {
            foreach (var menu in menus)
            {
                var menuitem = menus.FirstOrDefault(x => x.Id == parentId);

                if (menuitem != null)
                {
                    return menuitem;
                }

                if (menu.ChildrenMenus != null)
                {
                    var m = ReturnParentMenu(menu.ChildrenMenus, parentId);

                    return m;
                }
            }

            return null;
        }
    }
}
