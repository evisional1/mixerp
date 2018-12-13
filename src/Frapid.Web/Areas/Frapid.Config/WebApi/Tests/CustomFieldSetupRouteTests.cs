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
    public class CustomFieldSetupRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/delete/{customFieldSetupId}", "DELETE", typeof(CustomFieldSetupController), "Delete")]
        [InlineData("/api/config/custom-field-setup/delete/{customFieldSetupId}", "DELETE", typeof(CustomFieldSetupController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/edit/{customFieldSetupId}", "PUT", typeof(CustomFieldSetupController), "Edit")]
        [InlineData("/api/config/custom-field-setup/edit/{customFieldSetupId}", "PUT", typeof(CustomFieldSetupController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/count-where", "POST", typeof(CustomFieldSetupController), "CountWhere")]
        [InlineData("/api/config/custom-field-setup/count-where", "POST", typeof(CustomFieldSetupController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/get-where/{pageNumber}", "POST", typeof(CustomFieldSetupController), "GetWhere")]
        [InlineData("/api/config/custom-field-setup/get-where/{pageNumber}", "POST", typeof(CustomFieldSetupController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/add-or-edit", "POST", typeof(CustomFieldSetupController), "AddOrEdit")]
        [InlineData("/api/config/custom-field-setup/add-or-edit", "POST", typeof(CustomFieldSetupController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/add/{customFieldSetup}", "POST", typeof(CustomFieldSetupController), "Add")]
        [InlineData("/api/config/custom-field-setup/add/{customFieldSetup}", "POST", typeof(CustomFieldSetupController), "Add")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/bulk-import", "POST", typeof(CustomFieldSetupController), "BulkImport")]
        [InlineData("/api/config/custom-field-setup/bulk-import", "POST", typeof(CustomFieldSetupController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/meta", "GET", typeof(CustomFieldSetupController), "GetEntityView")]
        [InlineData("/api/config/custom-field-setup/meta", "GET", typeof(CustomFieldSetupController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/count", "GET", typeof(CustomFieldSetupController), "Count")]
        [InlineData("/api/config/custom-field-setup/count", "GET", typeof(CustomFieldSetupController), "Count")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/all", "GET", typeof(CustomFieldSetupController), "GetAll")]
        [InlineData("/api/config/custom-field-setup/all", "GET", typeof(CustomFieldSetupController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/export", "GET", typeof(CustomFieldSetupController), "Export")]
        [InlineData("/api/config/custom-field-setup/export", "GET", typeof(CustomFieldSetupController), "Export")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/1", "GET", typeof(CustomFieldSetupController), "Get")]
        [InlineData("/api/config/custom-field-setup/1", "GET", typeof(CustomFieldSetupController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/get?customFieldSetupIds=1", "GET", typeof(CustomFieldSetupController), "Get")]
        [InlineData("/api/config/custom-field-setup/get?customFieldSetupIds=1", "GET", typeof(CustomFieldSetupController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup", "GET", typeof(CustomFieldSetupController), "GetPaginatedResult")]
        [InlineData("/api/config/custom-field-setup", "GET", typeof(CustomFieldSetupController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/page/1", "GET", typeof(CustomFieldSetupController), "GetPaginatedResult")]
        [InlineData("/api/config/custom-field-setup/page/1", "GET", typeof(CustomFieldSetupController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/count-filtered/{filterName}", "GET", typeof(CustomFieldSetupController), "CountFiltered")]
        [InlineData("/api/config/custom-field-setup/count-filtered/{filterName}", "GET", typeof(CustomFieldSetupController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/get-filtered/{pageNumber}/{filterName}", "GET", typeof(CustomFieldSetupController), "GetFiltered")]
        [InlineData("/api/config/custom-field-setup/get-filtered/{pageNumber}/{filterName}", "GET", typeof(CustomFieldSetupController), "GetFiltered")]
        [InlineData("/api/config/custom-field-setup/first", "GET", typeof(CustomFieldSetupController), "GetFirst")]
        [InlineData("/api/config/custom-field-setup/previous/1", "GET", typeof(CustomFieldSetupController), "GetPrevious")]
        [InlineData("/api/config/custom-field-setup/next/1", "GET", typeof(CustomFieldSetupController), "GetNext")]
        [InlineData("/api/config/custom-field-setup/last", "GET", typeof(CustomFieldSetupController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/custom-fields", "GET", typeof(CustomFieldSetupController), "GetCustomFields")]
        [InlineData("/api/config/custom-field-setup/custom-fields", "GET", typeof(CustomFieldSetupController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/custom-fields/{resourceId}", "GET", typeof(CustomFieldSetupController), "GetCustomFields")]
        [InlineData("/api/config/custom-field-setup/custom-fields/{resourceId}", "GET", typeof(CustomFieldSetupController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/meta", "HEAD", typeof(CustomFieldSetupController), "GetEntityView")]
        [InlineData("/api/config/custom-field-setup/meta", "HEAD", typeof(CustomFieldSetupController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/count", "HEAD", typeof(CustomFieldSetupController), "Count")]
        [InlineData("/api/config/custom-field-setup/count", "HEAD", typeof(CustomFieldSetupController), "Count")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/all", "HEAD", typeof(CustomFieldSetupController), "GetAll")]
        [InlineData("/api/config/custom-field-setup/all", "HEAD", typeof(CustomFieldSetupController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/export", "HEAD", typeof(CustomFieldSetupController), "Export")]
        [InlineData("/api/config/custom-field-setup/export", "HEAD", typeof(CustomFieldSetupController), "Export")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/1", "HEAD", typeof(CustomFieldSetupController), "Get")]
        [InlineData("/api/config/custom-field-setup/1", "HEAD", typeof(CustomFieldSetupController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/get?customFieldSetupIds=1", "HEAD", typeof(CustomFieldSetupController), "Get")]
        [InlineData("/api/config/custom-field-setup/get?customFieldSetupIds=1", "HEAD", typeof(CustomFieldSetupController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup", "HEAD", typeof(CustomFieldSetupController), "GetPaginatedResult")]
        [InlineData("/api/config/custom-field-setup", "HEAD", typeof(CustomFieldSetupController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/page/1", "HEAD", typeof(CustomFieldSetupController), "GetPaginatedResult")]
        [InlineData("/api/config/custom-field-setup/page/1", "HEAD", typeof(CustomFieldSetupController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/count-filtered/{filterName}", "HEAD", typeof(CustomFieldSetupController), "CountFiltered")]
        [InlineData("/api/config/custom-field-setup/count-filtered/{filterName}", "HEAD", typeof(CustomFieldSetupController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(CustomFieldSetupController), "GetFiltered")]
        [InlineData("/api/config/custom-field-setup/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(CustomFieldSetupController), "GetFiltered")]
        [InlineData("/api/config/custom-field-setup/first", "HEAD", typeof(CustomFieldSetupController), "GetFirst")]
        [InlineData("/api/config/custom-field-setup/previous/1", "HEAD", typeof(CustomFieldSetupController), "GetPrevious")]
        [InlineData("/api/config/custom-field-setup/next/1", "HEAD", typeof(CustomFieldSetupController), "GetNext")]
        [InlineData("/api/config/custom-field-setup/last", "HEAD", typeof(CustomFieldSetupController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/custom-fields", "HEAD", typeof(CustomFieldSetupController), "GetCustomFields")]
        [InlineData("/api/config/custom-field-setup/custom-fields", "HEAD", typeof(CustomFieldSetupController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/custom-field-setup/custom-fields/{resourceId}", "HEAD", typeof(CustomFieldSetupController), "GetCustomFields")]
        [InlineData("/api/config/custom-field-setup/custom-fields/{resourceId}", "HEAD", typeof(CustomFieldSetupController), "GetCustomFields")]

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

        public CustomFieldSetupRouteTests()
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