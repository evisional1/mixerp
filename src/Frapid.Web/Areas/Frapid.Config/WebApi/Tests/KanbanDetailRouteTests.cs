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
    public class KanbanDetailRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/delete/{kanbanDetailId}", "DELETE", typeof(KanbanDetailController), "Delete")]
        [InlineData("/api/config/kanban-detail/delete/{kanbanDetailId}", "DELETE", typeof(KanbanDetailController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/edit/{kanbanDetailId}", "PUT", typeof(KanbanDetailController), "Edit")]
        [InlineData("/api/config/kanban-detail/edit/{kanbanDetailId}", "PUT", typeof(KanbanDetailController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/count-where", "POST", typeof(KanbanDetailController), "CountWhere")]
        [InlineData("/api/config/kanban-detail/count-where", "POST", typeof(KanbanDetailController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/get-where/{pageNumber}", "POST", typeof(KanbanDetailController), "GetWhere")]
        [InlineData("/api/config/kanban-detail/get-where/{pageNumber}", "POST", typeof(KanbanDetailController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/add-or-edit", "POST", typeof(KanbanDetailController), "AddOrEdit")]
        [InlineData("/api/config/kanban-detail/add-or-edit", "POST", typeof(KanbanDetailController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/add/{kanbanDetail}", "POST", typeof(KanbanDetailController), "Add")]
        [InlineData("/api/config/kanban-detail/add/{kanbanDetail}", "POST", typeof(KanbanDetailController), "Add")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/bulk-import", "POST", typeof(KanbanDetailController), "BulkImport")]
        [InlineData("/api/config/kanban-detail/bulk-import", "POST", typeof(KanbanDetailController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/meta", "GET", typeof(KanbanDetailController), "GetEntityView")]
        [InlineData("/api/config/kanban-detail/meta", "GET", typeof(KanbanDetailController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/count", "GET", typeof(KanbanDetailController), "Count")]
        [InlineData("/api/config/kanban-detail/count", "GET", typeof(KanbanDetailController), "Count")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/all", "GET", typeof(KanbanDetailController), "GetAll")]
        [InlineData("/api/config/kanban-detail/all", "GET", typeof(KanbanDetailController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/export", "GET", typeof(KanbanDetailController), "Export")]
        [InlineData("/api/config/kanban-detail/export", "GET", typeof(KanbanDetailController), "Export")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/1", "GET", typeof(KanbanDetailController), "Get")]
        [InlineData("/api/config/kanban-detail/1", "GET", typeof(KanbanDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/get?kanbanDetailIds=1", "GET", typeof(KanbanDetailController), "Get")]
        [InlineData("/api/config/kanban-detail/get?kanbanDetailIds=1", "GET", typeof(KanbanDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail", "GET", typeof(KanbanDetailController), "GetPaginatedResult")]
        [InlineData("/api/config/kanban-detail", "GET", typeof(KanbanDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/page/1", "GET", typeof(KanbanDetailController), "GetPaginatedResult")]
        [InlineData("/api/config/kanban-detail/page/1", "GET", typeof(KanbanDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/count-filtered/{filterName}", "GET", typeof(KanbanDetailController), "CountFiltered")]
        [InlineData("/api/config/kanban-detail/count-filtered/{filterName}", "GET", typeof(KanbanDetailController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/get-filtered/{pageNumber}/{filterName}", "GET", typeof(KanbanDetailController), "GetFiltered")]
        [InlineData("/api/config/kanban-detail/get-filtered/{pageNumber}/{filterName}", "GET", typeof(KanbanDetailController), "GetFiltered")]
        [InlineData("/api/config/kanban-detail/first", "GET", typeof(KanbanDetailController), "GetFirst")]
        [InlineData("/api/config/kanban-detail/previous/1", "GET", typeof(KanbanDetailController), "GetPrevious")]
        [InlineData("/api/config/kanban-detail/next/1", "GET", typeof(KanbanDetailController), "GetNext")]
        [InlineData("/api/config/kanban-detail/last", "GET", typeof(KanbanDetailController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/custom-fields", "GET", typeof(KanbanDetailController), "GetCustomFields")]
        [InlineData("/api/config/kanban-detail/custom-fields", "GET", typeof(KanbanDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/custom-fields/{resourceId}", "GET", typeof(KanbanDetailController), "GetCustomFields")]
        [InlineData("/api/config/kanban-detail/custom-fields/{resourceId}", "GET", typeof(KanbanDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/meta", "HEAD", typeof(KanbanDetailController), "GetEntityView")]
        [InlineData("/api/config/kanban-detail/meta", "HEAD", typeof(KanbanDetailController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/count", "HEAD", typeof(KanbanDetailController), "Count")]
        [InlineData("/api/config/kanban-detail/count", "HEAD", typeof(KanbanDetailController), "Count")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/all", "HEAD", typeof(KanbanDetailController), "GetAll")]
        [InlineData("/api/config/kanban-detail/all", "HEAD", typeof(KanbanDetailController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/export", "HEAD", typeof(KanbanDetailController), "Export")]
        [InlineData("/api/config/kanban-detail/export", "HEAD", typeof(KanbanDetailController), "Export")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/1", "HEAD", typeof(KanbanDetailController), "Get")]
        [InlineData("/api/config/kanban-detail/1", "HEAD", typeof(KanbanDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/get?kanbanDetailIds=1", "HEAD", typeof(KanbanDetailController), "Get")]
        [InlineData("/api/config/kanban-detail/get?kanbanDetailIds=1", "HEAD", typeof(KanbanDetailController), "Get")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail", "HEAD", typeof(KanbanDetailController), "GetPaginatedResult")]
        [InlineData("/api/config/kanban-detail", "HEAD", typeof(KanbanDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/page/1", "HEAD", typeof(KanbanDetailController), "GetPaginatedResult")]
        [InlineData("/api/config/kanban-detail/page/1", "HEAD", typeof(KanbanDetailController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/count-filtered/{filterName}", "HEAD", typeof(KanbanDetailController), "CountFiltered")]
        [InlineData("/api/config/kanban-detail/count-filtered/{filterName}", "HEAD", typeof(KanbanDetailController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(KanbanDetailController), "GetFiltered")]
        [InlineData("/api/config/kanban-detail/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(KanbanDetailController), "GetFiltered")]
        [InlineData("/api/config/kanban-detail/first", "HEAD", typeof(KanbanDetailController), "GetFirst")]
        [InlineData("/api/config/kanban-detail/previous/1", "HEAD", typeof(KanbanDetailController), "GetPrevious")]
        [InlineData("/api/config/kanban-detail/next/1", "HEAD", typeof(KanbanDetailController), "GetNext")]
        [InlineData("/api/config/kanban-detail/last", "HEAD", typeof(KanbanDetailController), "GetLast")]

        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/custom-fields", "HEAD", typeof(KanbanDetailController), "GetCustomFields")]
        [InlineData("/api/config/kanban-detail/custom-fields", "HEAD", typeof(KanbanDetailController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/config/kanban-detail/custom-fields/{resourceId}", "HEAD", typeof(KanbanDetailController), "GetCustomFields")]
        [InlineData("/api/config/kanban-detail/custom-fields/{resourceId}", "HEAD", typeof(KanbanDetailController), "GetCustomFields")]

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

        public KanbanDetailRouteTests()
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