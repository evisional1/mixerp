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
    public class CustomFieldRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/delete/{customFieldId}", "DELETE", typeof(CustomFieldController), "Delete")]
        [InlineData("/api/config/custom-field/delete/{customFieldId}", "DELETE", typeof(CustomFieldController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/edit/{customFieldId}", "PUT", typeof(CustomFieldController), "Edit")]
        [InlineData("/api/config/custom-field/edit/{customFieldId}", "PUT", typeof(CustomFieldController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/count-where", "POST", typeof(CustomFieldController), "CountWhere")]
        [InlineData("/api/config/custom-field/count-where", "POST", typeof(CustomFieldController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/get-where/{pageNumber}", "POST", typeof(CustomFieldController), "GetWhere")]
        [InlineData("/api/config/custom-field/get-where/{pageNumber}", "POST", typeof(CustomFieldController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/add-or-edit", "POST", typeof(CustomFieldController), "AddOrEdit")]
        [InlineData("/api/config/custom-field/add-or-edit", "POST", typeof(CustomFieldController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/add/{customField}", "POST", typeof(CustomFieldController), "Add")]
        [InlineData("/api/config/custom-field/add/{customField}", "POST", typeof(CustomFieldController), "Add")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/bulk-import", "POST", typeof(CustomFieldController), "BulkImport")]
        [InlineData("/api/config/custom-field/bulk-import", "POST", typeof(CustomFieldController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/meta", "GET", typeof(CustomFieldController), "GetEntityView")]
        [InlineData("/api/config/custom-field/meta", "GET", typeof(CustomFieldController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/count", "GET", typeof(CustomFieldController), "Count")]
        [InlineData("/api/config/custom-field/count", "GET", typeof(CustomFieldController), "Count")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/all", "GET", typeof(CustomFieldController), "GetAll")]
        [InlineData("/api/config/custom-field/all", "GET", typeof(CustomFieldController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/export", "GET", typeof(CustomFieldController), "Export")]
        [InlineData("/api/config/custom-field/export", "GET", typeof(CustomFieldController), "Export")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/1", "GET", typeof(CustomFieldController), "Get")]
        [InlineData("/api/config/custom-field/1", "GET", typeof(CustomFieldController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/get?customFieldIds=1", "GET", typeof(CustomFieldController), "Get")]
        [InlineData("/api/config/custom-field/get?customFieldIds=1", "GET", typeof(CustomFieldController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field", "GET", typeof(CustomFieldController), "GetPaginatedResult")]
        [InlineData("/api/config/custom-field", "GET", typeof(CustomFieldController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/page/1", "GET", typeof(CustomFieldController), "GetPaginatedResult")]
        [InlineData("/api/config/custom-field/page/1", "GET", typeof(CustomFieldController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/count-filtered/{filterName}", "GET", typeof(CustomFieldController), "CountFiltered")]
        [InlineData("/api/config/custom-field/count-filtered/{filterName}", "GET", typeof(CustomFieldController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/get-filtered/{pageNumber}/{filterName}", "GET", typeof(CustomFieldController), "GetFiltered")]
        [InlineData("/api/config/custom-field/get-filtered/{pageNumber}/{filterName}", "GET", typeof(CustomFieldController), "GetFiltered")]
        [InlineData("/api/config/custom-field/first", "GET", typeof(CustomFieldController), "GetFirst")]
        [InlineData("/api/config/custom-field/previous/1", "GET", typeof(CustomFieldController), "GetPrevious")]
        [InlineData("/api/config/custom-field/next/1", "GET", typeof(CustomFieldController), "GetNext")]
        [InlineData("/api/config/custom-field/last", "GET", typeof(CustomFieldController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/config/custom-field/custom-fields", "GET", typeof(CustomFieldController), "GetCustomFields")]
        [InlineData("/api/config/custom-field/custom-fields", "GET", typeof(CustomFieldController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/custom-fields/{resourceId}", "GET", typeof(CustomFieldController), "GetCustomFields")]
        [InlineData("/api/config/custom-field/custom-fields/{resourceId}", "GET", typeof(CustomFieldController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/meta", "HEAD", typeof(CustomFieldController), "GetEntityView")]
        [InlineData("/api/config/custom-field/meta", "HEAD", typeof(CustomFieldController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/count", "HEAD", typeof(CustomFieldController), "Count")]
        [InlineData("/api/config/custom-field/count", "HEAD", typeof(CustomFieldController), "Count")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/all", "HEAD", typeof(CustomFieldController), "GetAll")]
        [InlineData("/api/config/custom-field/all", "HEAD", typeof(CustomFieldController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/export", "HEAD", typeof(CustomFieldController), "Export")]
        [InlineData("/api/config/custom-field/export", "HEAD", typeof(CustomFieldController), "Export")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/1", "HEAD", typeof(CustomFieldController), "Get")]
        [InlineData("/api/config/custom-field/1", "HEAD", typeof(CustomFieldController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/get?customFieldIds=1", "HEAD", typeof(CustomFieldController), "Get")]
        [InlineData("/api/config/custom-field/get?customFieldIds=1", "HEAD", typeof(CustomFieldController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field", "HEAD", typeof(CustomFieldController), "GetPaginatedResult")]
        [InlineData("/api/config/custom-field", "HEAD", typeof(CustomFieldController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/page/1", "HEAD", typeof(CustomFieldController), "GetPaginatedResult")]
        [InlineData("/api/config/custom-field/page/1", "HEAD", typeof(CustomFieldController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/count-filtered/{filterName}", "HEAD", typeof(CustomFieldController), "CountFiltered")]
        [InlineData("/api/config/custom-field/count-filtered/{filterName}", "HEAD", typeof(CustomFieldController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(CustomFieldController), "GetFiltered")]
        [InlineData("/api/config/custom-field/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(CustomFieldController), "GetFiltered")]
        [InlineData("/api/config/custom-field/first", "HEAD", typeof(CustomFieldController), "GetFirst")]
        [InlineData("/api/config/custom-field/previous/1", "HEAD", typeof(CustomFieldController), "GetPrevious")]
        [InlineData("/api/config/custom-field/next/1", "HEAD", typeof(CustomFieldController), "GetNext")]
        [InlineData("/api/config/custom-field/last", "HEAD", typeof(CustomFieldController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/config/custom-field/custom-fields", "HEAD", typeof(CustomFieldController), "GetCustomFields")]
        [InlineData("/api/config/custom-field/custom-fields", "HEAD", typeof(CustomFieldController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field/custom-fields/{resourceId}", "HEAD", typeof(CustomFieldController), "GetCustomFields")]
        [InlineData("/api/config/custom-field/custom-fields/{resourceId}", "HEAD", typeof(CustomFieldController), "GetCustomFields")]

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

        public CustomFieldRouteTests()
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