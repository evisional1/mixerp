// ReSharper disable All
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Xunit;

namespace Frapid.Config.Api.Tests
{
    public class DefaultEntityAccessRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/delete/{defaultEntityAccessId}", "DELETE", typeof(DefaultEntityAccessController), "Delete")]
        [InlineData("/api/config/default-entity-access/delete/{defaultEntityAccessId}", "DELETE", typeof(DefaultEntityAccessController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/edit/{defaultEntityAccessId}", "PUT", typeof(DefaultEntityAccessController), "Edit")]
        [InlineData("/api/config/default-entity-access/edit/{defaultEntityAccessId}", "PUT", typeof(DefaultEntityAccessController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/count-where", "POST", typeof(DefaultEntityAccessController), "CountWhere")]
        [InlineData("/api/config/default-entity-access/count-where", "POST", typeof(DefaultEntityAccessController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/get-where/{pageNumber}", "POST", typeof(DefaultEntityAccessController), "GetWhere")]
        [InlineData("/api/config/default-entity-access/get-where/{pageNumber}", "POST", typeof(DefaultEntityAccessController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/add-or-edit", "POST", typeof(DefaultEntityAccessController), "AddOrEdit")]
        [InlineData("/api/config/default-entity-access/add-or-edit", "POST", typeof(DefaultEntityAccessController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/add/{defaultEntityAccess}", "POST", typeof(DefaultEntityAccessController), "Add")]
        [InlineData("/api/config/default-entity-access/add/{defaultEntityAccess}", "POST", typeof(DefaultEntityAccessController), "Add")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/bulk-import", "POST", typeof(DefaultEntityAccessController), "BulkImport")]
        [InlineData("/api/config/default-entity-access/bulk-import", "POST", typeof(DefaultEntityAccessController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/meta", "GET", typeof(DefaultEntityAccessController), "GetEntityView")]
        [InlineData("/api/config/default-entity-access/meta", "GET", typeof(DefaultEntityAccessController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/count", "GET", typeof(DefaultEntityAccessController), "Count")]
        [InlineData("/api/config/default-entity-access/count", "GET", typeof(DefaultEntityAccessController), "Count")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/all", "GET", typeof(DefaultEntityAccessController), "GetAll")]
        [InlineData("/api/config/default-entity-access/all", "GET", typeof(DefaultEntityAccessController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/export", "GET", typeof(DefaultEntityAccessController), "Export")]
        [InlineData("/api/config/default-entity-access/export", "GET", typeof(DefaultEntityAccessController), "Export")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/1", "GET", typeof(DefaultEntityAccessController), "Get")]
        [InlineData("/api/config/default-entity-access/1", "GET", typeof(DefaultEntityAccessController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/get?defaultEntityAccessIds=1", "GET", typeof(DefaultEntityAccessController), "Get")]
        [InlineData("/api/config/default-entity-access/get?defaultEntityAccessIds=1", "GET", typeof(DefaultEntityAccessController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access", "GET", typeof(DefaultEntityAccessController), "GetPaginatedResult")]
        [InlineData("/api/config/default-entity-access", "GET", typeof(DefaultEntityAccessController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/page/1", "GET", typeof(DefaultEntityAccessController), "GetPaginatedResult")]
        [InlineData("/api/config/default-entity-access/page/1", "GET", typeof(DefaultEntityAccessController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/count-filtered/{filterName}", "GET", typeof(DefaultEntityAccessController), "CountFiltered")]
        [InlineData("/api/config/default-entity-access/count-filtered/{filterName}", "GET", typeof(DefaultEntityAccessController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/get-filtered/{pageNumber}/{filterName}", "GET", typeof(DefaultEntityAccessController), "GetFiltered")]
        [InlineData("/api/config/default-entity-access/get-filtered/{pageNumber}/{filterName}", "GET", typeof(DefaultEntityAccessController), "GetFiltered")]
        [InlineData("/api/config/default-entity-access/first", "GET", typeof(DefaultEntityAccessController), "GetFirst")]
        [InlineData("/api/config/default-entity-access/previous/1", "GET", typeof(DefaultEntityAccessController), "GetPrevious")]
        [InlineData("/api/config/default-entity-access/next/1", "GET", typeof(DefaultEntityAccessController), "GetNext")]
        [InlineData("/api/config/default-entity-access/last", "GET", typeof(DefaultEntityAccessController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/custom-fields", "GET", typeof(DefaultEntityAccessController), "GetCustomFields")]
        [InlineData("/api/config/default-entity-access/custom-fields", "GET", typeof(DefaultEntityAccessController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/custom-fields/{resourceId}", "GET", typeof(DefaultEntityAccessController), "GetCustomFields")]
        [InlineData("/api/config/default-entity-access/custom-fields/{resourceId}", "GET", typeof(DefaultEntityAccessController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/meta", "HEAD", typeof(DefaultEntityAccessController), "GetEntityView")]
        [InlineData("/api/config/default-entity-access/meta", "HEAD", typeof(DefaultEntityAccessController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/count", "HEAD", typeof(DefaultEntityAccessController), "Count")]
        [InlineData("/api/config/default-entity-access/count", "HEAD", typeof(DefaultEntityAccessController), "Count")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/all", "HEAD", typeof(DefaultEntityAccessController), "GetAll")]
        [InlineData("/api/config/default-entity-access/all", "HEAD", typeof(DefaultEntityAccessController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/export", "HEAD", typeof(DefaultEntityAccessController), "Export")]
        [InlineData("/api/config/default-entity-access/export", "HEAD", typeof(DefaultEntityAccessController), "Export")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/1", "HEAD", typeof(DefaultEntityAccessController), "Get")]
        [InlineData("/api/config/default-entity-access/1", "HEAD", typeof(DefaultEntityAccessController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/get?defaultEntityAccessIds=1", "HEAD", typeof(DefaultEntityAccessController), "Get")]
        [InlineData("/api/config/default-entity-access/get?defaultEntityAccessIds=1", "HEAD", typeof(DefaultEntityAccessController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access", "HEAD", typeof(DefaultEntityAccessController), "GetPaginatedResult")]
        [InlineData("/api/config/default-entity-access", "HEAD", typeof(DefaultEntityAccessController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/page/1", "HEAD", typeof(DefaultEntityAccessController), "GetPaginatedResult")]
        [InlineData("/api/config/default-entity-access/page/1", "HEAD", typeof(DefaultEntityAccessController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/count-filtered/{filterName}", "HEAD", typeof(DefaultEntityAccessController), "CountFiltered")]
        [InlineData("/api/config/default-entity-access/count-filtered/{filterName}", "HEAD", typeof(DefaultEntityAccessController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(DefaultEntityAccessController), "GetFiltered")]
        [InlineData("/api/config/default-entity-access/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(DefaultEntityAccessController), "GetFiltered")]
        [InlineData("/api/config/default-entity-access/first", "HEAD", typeof(DefaultEntityAccessController), "GetFirst")]
        [InlineData("/api/config/default-entity-access/previous/1", "HEAD", typeof(DefaultEntityAccessController), "GetPrevious")]
        [InlineData("/api/config/default-entity-access/next/1", "HEAD", typeof(DefaultEntityAccessController), "GetNext")]
        [InlineData("/api/config/default-entity-access/last", "HEAD", typeof(DefaultEntityAccessController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/custom-fields", "HEAD", typeof(DefaultEntityAccessController), "GetCustomFields")]
        [InlineData("/api/config/default-entity-access/custom-fields", "HEAD", typeof(DefaultEntityAccessController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/default-entity-access/custom-fields/{resourceId}", "HEAD", typeof(DefaultEntityAccessController), "GetCustomFields")]
        [InlineData("/api/config/default-entity-access/custom-fields/{resourceId}", "HEAD", typeof(DefaultEntityAccessController), "GetCustomFields")]

        [Conditional("Debug")]
        public void TestRoute(string url, string verb, Type type, string actionName)
        {
            //Arrange
            url = url.Replace("{apiVersionNumber}", this.ApiVersionNumber);
            url = Host + url;

            //Act
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(verb), url);

            IHttpControllerSelector controller = this.GetControllerSelector();
            IHttpActionSelector action = this.GetActionSelector();

            IHttpRouteData route = this.Config.Routes.GetRouteData(request);
            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = route;
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = this.Config;

            HttpControllerDescriptor controllerDescriptor = controller.SelectController(request);

            HttpControllerContext context = new HttpControllerContext(this.Config, route, request)
            {
                ControllerDescriptor = controllerDescriptor
            };

            var actionDescriptor = action.SelectAction(context);

            //Assert
            Assert.NotNull(controllerDescriptor);
            Assert.NotNull(actionDescriptor);
            Assert.Equal(type, controllerDescriptor.ControllerType);
            Assert.Equal(actionName, actionDescriptor.ActionName);
        }

        #region Fixture
        private readonly HttpConfiguration Config;
        private readonly string Host;
        private readonly string ApiVersionNumber;

        public DefaultEntityAccessRouteTests()
        {
            this.Host = ConfigurationManager.AppSettings["HostPrefix"];
            this.ApiVersionNumber = ConfigurationManager.AppSettings["ApiVersionNumber"];
            this.Config = GetConfig();
        }

        private HttpConfiguration GetConfig()
        {
            if (MemoryCache.Default["Config"] == null)
            {
                HttpConfiguration config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute("VersionedApi", "api/" + this.ApiVersionNumber + "/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
                config.Routes.MapHttpRoute("DefaultApi", "api/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });

                config.EnsureInitialized();
                MemoryCache.Default["Config"] = config;
                return config;
            }

            return MemoryCache.Default["Config"] as HttpConfiguration;
        }

        private IHttpControllerSelector GetControllerSelector()
        {
            if (MemoryCache.Default["ControllerSelector"] == null)
            {
                IHttpControllerSelector selector = this.Config.Services.GetHttpControllerSelector();
                return selector;
            }

            return MemoryCache.Default["ControllerSelector"] as IHttpControllerSelector;
        }

        private IHttpActionSelector GetActionSelector()
        {
            if (MemoryCache.Default["ActionSelector"] == null)
            {
                IHttpActionSelector selector = this.Config.Services.GetActionSelector();
                return selector;
            }

            return MemoryCache.Default["ActionSelector"] as IHttpActionSelector;
        }
        #endregion
    }
}