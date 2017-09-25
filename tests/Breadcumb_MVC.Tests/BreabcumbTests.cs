using System.Collections.Generic;
using Breadcumbs_MVC;
using Breadcumbs_MVC.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Breadcumb_MVC.Tests
{
    [TestClass]
    public class BreabcumbTests
    {
        [TestMethod]
        public void Should_Be_Create_Breadcumb_Without_Area()
        {
            var menus = MenuItemsService.GetMenusTest();

            var list = BreadcumbItem.CreateBreadCumb(menus,"", "Nivel3", "Menu2");
         
            list.Count.Should().Be(4); 
        }

        [TestMethod]
        public void Should_Be_Create_Breadcumb_With_Area()
        {
            var menus = MenuItemsService.GetMenusWithAreaTest();

            var list = BreadcumbItem.CreateBreadCumb(menus, "Admin", "Nivel3", "Menu2");
          
            list.Count.Should().Be(4);          
        }
    }  
}
