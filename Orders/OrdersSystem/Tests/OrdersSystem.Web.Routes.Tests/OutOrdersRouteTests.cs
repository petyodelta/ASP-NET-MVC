﻿namespace OrdersSystem.Web.Routes.Tests
{
    using System.Web.Routing;

    using MvcRouteTester;
    using NUnit.Framework;
    using OrdersSystem.Web.Controllers;
    
    [TestFixture]
    public class OutOrdersRouteTests
    {
        [Test]
        public void OutOrdersTestRouteIndex()
        {
            var routeCollection = new RouteCollection();
            const string url = "/OutOrders/Index";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url).To<OutOrdersController>(c => c.Index());
        }

        [Test]
        public void OutOrdersTestRouteDetails()
        {
            var routeCollection = new RouteCollection();
            const string url = "/OutOrders/Details/1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url).To<OutOrdersController>(c => c.Details(1));
        }

        [Test]
        public void OutOrdersTestRouteCreate()
        {
            var routeCollection = new RouteCollection();
            const string url = "/OutOrders/Create";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url).To<OutOrdersController>(c => c.Create());
        }

        [Test]
        public void OutOrdersTestRouteEdit()
        {
            var routeCollection = new RouteCollection();
            const string url = "/OutOrders/Edit/1";
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(url).To<OutOrdersController>(c => c.Edit(1));
        }
    }
}
