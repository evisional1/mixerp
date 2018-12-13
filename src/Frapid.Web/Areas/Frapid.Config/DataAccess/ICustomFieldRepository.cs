// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;

namespace Frapid.Config.DataAccess
{
    public interface ICustomFieldRepository
    {
        /// <summary>
        /// Counts the number of CustomField in ICustomFieldRepository.
        /// </summary>
        /// <returns>Returns the count of ICustomFieldRepository.</returns>
        long Count();

        /// <summary>
        /// Returns all instances of CustomField. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of CustomField.</returns>
        IEnumerable<Frapid.Config.Entities.CustomField> GetAll();

        /// <summary>
        /// Returns all instances of CustomField to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of CustomField.</returns>
        IEnumerable<dynamic> Export();

        /// <summary>
        /// Returns a single instance of the CustomField against customFieldId. 
        /// </summary>
        /// <param name="customFieldId">The column "custom_field_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of CustomField.</returns>
        Frapid.Config.Entities.CustomField Get(long customFieldId);

        /// <summary>
        /// Gets the first record of CustomField.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of CustomField.</returns>
        Frapid.Config.Entities.CustomField GetFirst();

        /// <summary>
        /// Gets the previous record of CustomField sorted by customFieldId. 
        /// </summary>
        /// <param name="customFieldId">The column "custom_field_id" parameter used to find the previous record.</param>
        /// <returns>Returns a non-live, non-mapped instance of CustomField.</returns>
        Frapid.Config.Entities.CustomField GetPrevious(long customFieldId);

        /// <summary>
        /// Gets the next record of CustomField sorted by customFieldId. 
        /// </summary>
        /// <param name="customFieldId">The column "custom_field_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of CustomField.</returns>
        Frapid.Config.Entities.CustomField GetNext(long customFieldId);

        /// <summary>
        /// Gets the last record of CustomField.
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of CustomField.</returns>
        Frapid.Config.Entities.CustomField GetLast();

        /// <summary>
        /// Returns multiple instances of the CustomField against customFieldIds. 
        /// </summary>
        /// <param name="customFieldIds">Array of column "custom_field_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of CustomField.</returns>
        IEnumerable<Frapid.Config.Entities.CustomField> Get(long[] customFieldIds);

        /// <summary>
        /// Custom fields are user defined form elements for ICustomFieldRepository.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for CustomField.</returns>
        IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId);

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding CustomField.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for CustomField.</returns>
        IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields();

        /// <summary>
        /// Inserts the instance of CustomField class to ICustomFieldRepository.
        /// </summary>
        /// <param name="customField">The instance of CustomField class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        object AddOrEdit(dynamic customField, List<Frapid.DataAccess.Models.CustomField> customFields);

        /// <summary>
        /// Inserts the instance of CustomField class to ICustomFieldRepository.
        /// </summary>
        /// <param name="customField">The instance of CustomField class to insert.</param>
        object Add(dynamic customField);

        /// <summary>
        /// Inserts or updates multiple instances of CustomField class to ICustomFieldRepository.;
        /// </summary>
        /// <param name="customFields">List of CustomField class to import.</param>
        /// <returns>Returns list of inserted object ids.</returns>
        List<object> BulkImport(List<ExpandoObject> customFields);


        /// <summary>
        /// Updates ICustomFieldRepository with an instance of CustomField class against the primary key value.
        /// </summary>
        /// <param name="customField">The instance of CustomField class to update.</param>
        /// <param name="customFieldId">The value of the column "custom_field_id" which will be updated.</param>
        void Update(dynamic customField, long customFieldId);

        /// <summary>
        /// Deletes CustomField from  ICustomFieldRepository against the primary key value.
        /// </summary>
        /// <param name="customFieldId">The value of the column "custom_field_id" which will be deleted.</param>
        void Delete(long customFieldId);

        /// <summary>
        /// Produces a paginated result of 10 CustomField classes.
        /// </summary>
        /// <returns>Returns the first page of collection of CustomField class.</returns>
        IEnumerable<Frapid.Config.Entities.CustomField> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 CustomField classes.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of CustomField class.</returns>
        IEnumerable<Frapid.Config.Entities.CustomField> GetPaginatedResult(long pageNumber);

        List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on ICustomFieldRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of CustomField class using the filter.</returns>
        long CountWhere(List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered pagination against ICustomFieldRepository producing result of 10 items.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of CustomField class.</returns>
        IEnumerable<Frapid.Config.Entities.CustomField> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters);

        /// <summary>
        /// Performs a filtered count on ICustomFieldRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of CustomField class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Gets a filtered result of ICustomFieldRepository producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of CustomField class.</returns>
        IEnumerable<Frapid.Config.Entities.CustomField> GetFiltered(long pageNumber, string filterName);



    }
}