using System.Collections.Generic;
using Breadcumbs_MVC.Models;

namespace Breadcumbs_MVC
{
    public class MenuItemsService
    {
        public static IList<MenuItem> GetMenusTest()
        {
            var menus = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 1,
                    Title = "Menu Superior",
                    ChildrenMenus = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Id = 2,
                            ParentMenuId = 1,
                            Title = "Menu 1 nivel 1",
                            Area = "",
                            Controller = "",
                            Action = "",
                            ChildrenMenus = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Id = 3,
                                    ParentMenuId = 2,
                                    Title = "Menu 1 nivel 2",
                                    Area = "",
                                    Controller = "Nivel1",
                                    Action = "Menu1",
                                },
                                new MenuItem
                                {
                                    Id = 4,
                                    ParentMenuId = 2,
                                    Title = "Menu 2 nivel 2",
                                    Area = "",
                                    Controller = "Nivel2",
                                    Action = "Menu2",
                                },
                                new MenuItem
                                {
                                    Id = 5,
                                    ParentMenuId = 2,
                                    Title = "Menu 3 nivel 2",
                                    Area = "",
                                    Controller = "Nivel2",
                                    Action = "Menu3",
                                    ChildrenMenus = new List<MenuItem>
                                    {
                                        new MenuItem
                                        {
                                            Id = 3,
                                            ParentMenuId = 5,
                                            Title = "Menu 1 nivel 3",
                                            Area = "",
                                            Controller = "Nivel3",
                                            Action = "Menu1",
                                        },
                                        new MenuItem
                                        {
                                            Id = 4,
                                            ParentMenuId = 5,
                                            Title = "Menu 2 nivel 3",
                                            Area = "",
                                            Controller = "Nivel3",
                                            Action = "Menu2",
                                        },
                                        new MenuItem
                                        {
                                            Id = 5,
                                            ParentMenuId = 5,
                                            Title = "Menu 3 nivel 3",
                                            Area = "",
                                            Controller = "Teste",
                                            Action = "Novo"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return menus;
        }

        public static IList<MenuItem> GetMenusWithAreaTest()
        {
            var menus = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 1,
                    Title = "Menu Superior",
                    ChildrenMenus = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Id = 2,
                            ParentMenuId = 1,
                            Title = "Menu 1 nivel 1",
                            Area = "Admin",
                            Controller = "",
                            Action = "",
                            ChildrenMenus = new List<MenuItem>
                            {
                                new MenuItem
                                {
                                    Id = 3,
                                    ParentMenuId = 2,
                                    Title = "Menu 1 nivel 2",
                                    Area = "Admin",
                                    Controller = "Nivel1",
                                    Action = "Menu1",
                                },
                                new MenuItem
                                {
                                    Id = 4,
                                    ParentMenuId = 2,
                                    Title = "Menu 2 nivel 2",
                                    Area = "Admin",
                                    Controller = "Nivel2",
                                    Action = "Menu2",
                                },
                                new MenuItem
                                {
                                    Id = 5,
                                    ParentMenuId = 2,
                                    Title = "Menu 3 nivel 2",
                                    Area = "Admin",
                                    Controller = "Nivel2",
                                    Action = "Menu3",
                                    ChildrenMenus = new List<MenuItem>
                                    {
                                        new MenuItem
                                        {
                                            Id = 3,
                                            ParentMenuId = 5,
                                            Title = "Menu 1 nivel 3",
                                            Area = "Admin",
                                            Controller = "Nivel3",
                                            Action = "Menu1",
                                        },
                                        new MenuItem
                                        {
                                            Id = 4,
                                            ParentMenuId = 5,
                                            Title = "Menu 2 nivel 3",
                                            Area = "Admin",
                                            Controller = "Nivel3",
                                            Action = "Menu2",
                                        },
                                        new MenuItem
                                        {
                                            Id = 5,
                                            ParentMenuId = 5,
                                            Title = "Menu 3 nivel 3",
                                            Area = "Admin",
                                            Controller = "Teste",
                                            Action = "Novo"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            return menus;
        }
    }
}