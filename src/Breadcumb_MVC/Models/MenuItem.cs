using System.Collections.Generic;

namespace Breadcumbs_MVC.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int? ParentMenuId { get; set; }
        public IList<MenuItem> ChildrenMenus { get; set; }
    }

}
