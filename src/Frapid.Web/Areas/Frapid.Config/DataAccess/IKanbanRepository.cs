// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Frapid.Config.DataAccess
{
    public interface IKanbanRepository
    {
        /// <summary>
        /// Counts the number of Kanban in IKanbanRepository.
        /// </summary>
        /// <returns>Returns the count of IKanbanRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of Kanban. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Kanban.</returns>
        IEnumerable<Frapid.Config.Entities.Kanban> GetAll();

        /// <summary>
        /// Returns all instances of Kanban to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of Kanban.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the Kanban against kanbanId. 
        /// </summary>
        /// <param name="kanbanId">The column "kanban_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of Kanban.</returns>
        Frapid.Config.Entities.Kanban Get(long kanbanId);

        /// <summary>
        /// Gets the first record of Kanban.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Kanban.</returns>
        Frapid.Config.Entities.Kanban GetFirst();

        /// <summary>
        /// Gets the previous record of Kanban sorted by kanbanId. 
        /// </summary>
        /// <param name="kanbanId">The column "kanban_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Kanban.</returns>
        Frapid.Config.Entities.Kanban GetPrevious(long kanbanId);

        /// <summary>
        /// Gets the next record of Kanban sorted by kanbanId. 
        /// </summary>
        /// <param name="kanbanId">The column "kanban_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of Kanban.</returns>
        Frapid.Config.Entities.Kanban GetNext(long kanbanId);

        /// <summary>
        /// Gets the last record of Kanban.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of Kanban.</returns>
        Frapid.Config.Entities.Kanban GetLast();

        /// <summary>
        /// Returns multiple instances of the Kanban against kanbanIds. 
        /// </summary>
        /// <param name="kanbanIds">Array of column "kanban_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of Kanban.</returns>
        IEnumerable<Frapid.Config.Entities.Kanban> Get(long[] kanbanIds);

        /// <summary>
        /// Custom fields are user defined form elements for IKanbanRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for Kanban.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding Kanban.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for Kanban.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of Kanban class to IKanbanRepository.
        /// </summary>
        /// <param name="kanban">The instance of Kanban class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic kanban, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of Kanban class to IKanbanRepository.
        /// </summary>
        /// <param name="kanban">The instance of Kanban class to insert.</param>
        object Add(dynamic kanban);

        /// <summary>
        /// Inserts or updates multiple instances of Kanban class to IKanbanRepository.;
        /// </summary>
        /// <param name="kanbans">List of Kanban class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> kanbans);


        /// <summary>
        /// Updates IKanbanRepository with an instance of Kanban class against the primary key value.
        /// </summary>
        /// <param name="kanban">The instance of Kanban class to update.</param>
        /// <param name="kanbanId">The value of the column "kanban_id" which will be updated.</param>
        void Update(dynamic kanban, long kanbanId);

        /// <summary>
        /// Deletes Kanban from  IKanbanRepository against the primary key value.
        /// </summary>
        /// <param name="kanbanId">The value of the column "kanban_id" which will be deleted.</param>
        void Delete(long kanbanId);

        /// <summary>
        /// Produces a paginated result of 10 Kanban classes.
        /// </summary>
        /// <returns>Returns the first page of collection of Kanban class.</returns>
        IEnumerable<Frapid.Config.Entities.Kanban> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 Kanban classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of Kanban class.</returns>
        IEnumerable<Frapid.Config.Entities.Kanban> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IKanbanRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of Kanban class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against IKanbanRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of Kanban class.</returns>
        IEnumerable<Frapid.Config.Entities.Kanban> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IKanbanRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of Kanban class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of IKanbanRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of Kanban class.</returns>
        IEnumerable<Frapid.Config.Entities.Kanban> GetFiltered(long pageNumber, string filterName);



    }
}