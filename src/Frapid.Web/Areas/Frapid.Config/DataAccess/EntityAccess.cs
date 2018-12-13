// ReSharper disable All
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using Frapid.Configuration;
using Frapid.DataAccess;
using Frapid.DataAccess.Models;
using Frapid.DbPolicy;
using Frapid.Framework.Extensions;
using Npgsql;
using Frapid.NPoco;
using Serilog;

namespace Frapid.Config.DataAccess
{
    /// <summary>
    /// Provides simplified data access features to perform SCRUD operation on the database table "config.entity_access".
    /// </summary>
    public class EntityAccess : DbAccess, IEntityAccessRepository
    {
        /// <summary>
        /// The schema of this table. Returns literal "config".
        /// </summary>
        public override string _ObjectNamespace => "config";

        /// <summary>
        /// The schema unqualified name of this table. Returns literal "entity_access".
        /// </summary>
        public override string _ObjectName => "entity_access";

        /// <summary>
        /// Login id of application user accessing this table.
        /// </summary>
        public long _LoginId { get; set; }

        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }

        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Performs SQL count on the table "config.entity_access".
        /// </summary>
        /// <returns>Returns the number of rows of the table "config.entity_access".</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long Count()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"EntityAccess\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT COUNT(*) FROM config.entity_access;";
            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "config.entity_access" to return all instances of the "EntityAccess" class. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "EntityAccess" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.Config.Entities.EntityAccess> GetAll()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ExportData, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the export entity \"EntityAccess\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access ORDER BY entity_access_id;";
            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "config.entity_access" to return all instances of the "EntityAccess" class to export. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "EntityAccess" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<dynamic> Export()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ExportData, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the export entity \"EntityAccess\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access ORDER BY entity_access_id;";
            return Factory.Get<dynamic>(this._Catalog, sql);
        }

        /// <summary>
        /// Executes a select query on the table "config.entity_access" with a where filter on the column "entity_access_id" to return a single instance of the "EntityAccess" class. 
        /// </summary>
        /// <param name="entityAccessId">The column "entity_access_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped instance of "EntityAccess" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Frapid.Config.Entities.EntityAccess Get(int entityAccessId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get entity \"EntityAccess\" filtered by \"EntityAccessId\" with value {EntityAccessId} was denied to the user with Login ID {_LoginId}", entityAccessId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access WHERE entity_access_id=@0;";
            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql, entityAccessId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the first record of the table "config.entity_access". 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of "EntityAccess" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Frapid.Config.Entities.EntityAccess GetFirst()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get the first record of entity \"EntityAccess\" was denied to the user with Login ID {_LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access ORDER BY entity_access_id LIMIT 1;";
            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql).FirstOrDefault();
        }

        /// <summary>
        /// Gets the previous record of the table "config.entity_access" sorted by entityAccessId.
        /// </summary>
        /// <param name="entityAccessId">The column "entity_access_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of "EntityAccess" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Frapid.Config.Entities.EntityAccess GetPrevious(int entityAccessId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get the previous entity of \"EntityAccess\" by \"EntityAccessId\" with value {EntityAccessId} was denied to the user with Login ID {_LoginId}", entityAccessId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access WHERE entity_access_id < @0 ORDER BY entity_access_id DESC LIMIT 1;";
            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql, entityAccessId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the next record of the table "config.entity_access" sorted by entityAccessId.
        /// </summary>
        /// <param name="entityAccessId">The column "entity_access_id" parameter used to find the next record.</param>
        /// <returns>Returns a non-live, non-mapped instance of "EntityAccess" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Frapid.Config.Entities.EntityAccess GetNext(int entityAccessId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get the next entity of \"EntityAccess\" by \"EntityAccessId\" with value {EntityAccessId} was denied to the user with Login ID {_LoginId}", entityAccessId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access WHERE entity_access_id > @0 ORDER BY entity_access_id LIMIT 1;";
            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql, entityAccessId).FirstOrDefault();
        }


        /// <summary>
        /// Gets the last record of the table "config.entity_access". 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instance of "EntityAccess" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public Frapid.Config.Entities.EntityAccess GetLast()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the get the last record of entity \"EntityAccess\" was denied to the user with Login ID {_LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access ORDER BY entity_access_id DESC LIMIT 1;";
            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql).FirstOrDefault();
        }

        /// <summary>
        /// Executes a select query on the table "config.entity_access" with a where filter on the column "entity_access_id" to return a multiple instances of the "EntityAccess" class. 
        /// </summary>
        /// <param name="entityAccessIds">Array of column "entity_access_id" parameter used on where filter.</param>
        /// <returns>Returns a non-live, non-mapped collection of "EntityAccess" class mapped to the database row.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.Config.Entities.EntityAccess> Get(int[] entityAccessIds)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to entity \"EntityAccess\" was denied to the user with Login ID {LoginId}. entityAccessIds: {entityAccessIds}.", this._LoginId, entityAccessIds);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access WHERE entity_access_id IN (@0);";

            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql, entityAccessIds);
        }

        /// <summary>
        /// Custom fields are user defined form elements for config.entity_access.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection for the table config.entity_access</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.DataAccess.Models.CustomField> GetCustomFields(string resourceId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get custom fields for entity \"EntityAccess\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            string sql;
            if (string.IsNullOrWhiteSpace(resourceId))
            {
                sql = "SELECT * FROM config.custom_field_definition_view WHERE table_name='config.entity_access' ORDER BY field_order;";
                return Factory.Get<Frapid.DataAccess.Models.CustomField>(this._Catalog, sql);
            }

            sql = "SELECT * from config.get_custom_field_definition('config.entity_access'::text, @0::text) ORDER BY field_order;";
            return Factory.Get<Frapid.DataAccess.Models.CustomField>(this._Catalog, sql, resourceId);
        }

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding the row collection of config.entity_access.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for the table config.entity_access</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.DataAccess.Models.DisplayField> GetDisplayFields()
        {
            List<Frapid.DataAccess.Models.DisplayField> displayFields = new List<Frapid.DataAccess.Models.DisplayField>();

            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return displayFields;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to get display field for entity \"EntityAccess\" was denied to the user with Login ID {LoginId}", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT entity_access_id AS key, entity_name as value FROM config.entity_access;";
            using (NpgsqlCommand command = new NpgsqlCommand(sql))
            {
                using (DataTable table = DbOperation.GetDataTable(this._Catalog, command))
                {
                    if (table?.Rows == null || table.Rows.Count == 0)
                    {
                        return displayFields;
                    }

                    foreach (DataRow row in table.Rows)
                    {
                        if (row != null)
                        {
                            DisplayField displayField = new DisplayField
                            {
                                Key = row["key"].ToString(),
                                Value = row["value"].ToString()
                            };

                            displayFields.Add(displayField);
                        }
                    }
                }
            }

            return displayFields;
        }

        /// <summary>
        /// Inserts or updates the instance of EntityAccess class on the database table "config.entity_access".
        /// </summary>
        /// <param name="entityAccess">The instance of "EntityAccess" class to insert or update.</param>
        /// <param name="customFields">The custom field collection.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object AddOrEdit(dynamic entityAccess, List<Frapid.DataAccess.Models.CustomField> customFields)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            entityAccess.audit_user_id = this._UserId;
            entityAccess.audit_ts = System.DateTime.UtcNow;

            object primaryKeyValue = entityAccess.entity_access_id;

            if (Cast.To<int>(primaryKeyValue) > 0)
            {
                this.Update(entityAccess, Cast.To<int>(primaryKeyValue));
            }
            else
            {
                primaryKeyValue = this.Add(entityAccess);
            }

            string sql = "DELETE FROM config.custom_fields WHERE custom_field_setup_id IN(" +
                         "SELECT custom_field_setup_id " +
                         "FROM config.custom_field_setup " +
                         "WHERE form_name=config.get_custom_field_form_name('config.entity_access')" +
                         ");";

            Factory.NonQuery(this._Catalog, sql);

            if (customFields == null)
            {
                return primaryKeyValue;
            }

            foreach (var field in customFields)
            {
                sql = "INSERT INTO config.custom_fields(custom_field_setup_id, resource_id, value) " +
                      "SELECT config.get_custom_field_setup_id_by_table_name('config.entity_access', @0::character varying(100)), " +
                      "@1, @2;";

                Factory.NonQuery(this._Catalog, sql, field.FieldName, primaryKeyValue, field.Value);
            }

            return primaryKeyValue;
        }

        /// <summary>
        /// Inserts the instance of EntityAccess class on the database table "config.entity_access".
        /// </summary>
        /// <param name="entityAccess">The instance of "EntityAccess" class to insert.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public object Add(dynamic entityAccess)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Create, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to add entity \"EntityAccess\" was denied to the user with Login ID {LoginId}. {EntityAccess}", this._LoginId, entityAccess);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            return Factory.Insert(this._Catalog, entityAccess, "config.entity_access", "entity_access_id");
        }

        /// <summary>
        /// Inserts or updates multiple instances of EntityAccess class on the database table "config.entity_access";
        /// </summary>
        /// <param name="entityAccesses">List of "EntityAccess" class to import.</param>
        /// <returns></returns>
        public List<object> BulkImport(List<ExpandoObject> entityAccesses)
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.ImportData, this._LoginId, this._Catalog, false);
                }

                if (!this.HasAccess)
                {
                    Log.Information("Access to import entity \"EntityAccess\" was denied to the user with Login ID {LoginId}. {entityAccesses}", this._LoginId, entityAccesses);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            var result = new List<object>();
            int line = 0;
            try
            {
                using (Database db = new Database(ConnectionString.GetConnectionString(this._Catalog), Factory.ProviderName))
                {
                    using (ITransaction transaction = db.GetTransaction())
                    {
                        foreach (dynamic entityAccess in entityAccesses)
                        {
                            line++;

                            entityAccess.audit_user_id = this._UserId;
                            entityAccess.audit_ts = System.DateTime.UtcNow;

                            object primaryKeyValue = entityAccess.entity_access_id;

                            if (Cast.To<int>(primaryKeyValue) > 0)
                            {
                                result.Add(entityAccess.entity_access_id);
                                db.Update("config.entity_access", "entity_access_id", entityAccess, entityAccess.entity_access_id);
                            }
                            else
                            {
                                result.Add(db.Insert("config.entity_access", "entity_access_id", entityAccess));
                            }
                        }

                        transaction.Complete();
                    }

                    return result;
                }
            }
            catch (NpgsqlException ex)
            {
                string errorMessage = $"Error on line {line} ";

                if (ex.Code.StartsWith("P"))
                {
                    errorMessage += Factory.GetDbErrorResource(ex);

                    throw new DataAccessException(errorMessage, ex);
                }

                errorMessage += ex.Message;
                throw new DataAccessException(errorMessage, ex);
            }
            catch (System.Exception ex)
            {
                string errorMessage = $"Error on line {line} ";
                throw new DataAccessException(errorMessage, ex);
            }
        }

        /// <summary>
        /// Updates the row of the table "config.entity_access" with an instance of "EntityAccess" class against the primary key value.
        /// </summary>
        /// <param name="entityAccess">The instance of "EntityAccess" class to update.</param>
        /// <param name="entityAccessId">The value of the column "entity_access_id" which will be updated.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Update(dynamic entityAccess, int entityAccessId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Edit, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to edit entity \"EntityAccess\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}. {EntityAccess}", entityAccessId, this._LoginId, entityAccess);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Factory.Update(this._Catalog, entityAccess, entityAccessId, "config.entity_access", "entity_access_id");
        }

        /// <summary>
        /// Deletes the row of the table "config.entity_access" against the primary key value.
        /// </summary>
        /// <param name="entityAccessId">The value of the column "entity_access_id" which will be deleted.</param>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public void Delete(int entityAccessId)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Delete, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to delete entity \"EntityAccess\" with Primary Key {PrimaryKey} was denied to the user with Login ID {LoginId}.", entityAccessId, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "DELETE FROM config.entity_access WHERE entity_access_id=@0;";
            Factory.NonQuery(this._Catalog, sql, entityAccessId);
        }

        /// <summary>
        /// Performs a select statement on table "config.entity_access" producing a paginated result of 10.
        /// </summary>
        /// <returns>Returns the first page of collection of "EntityAccess" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.Config.Entities.EntityAccess> GetPaginatedResult()
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the first page of the entity \"EntityAccess\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            const string sql = "SELECT * FROM config.entity_access ORDER BY entity_access_id LIMIT 10 OFFSET 0;";
            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a select statement on table "config.entity_access" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "EntityAccess" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.Config.Entities.EntityAccess> GetPaginatedResult(long pageNumber)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the entity \"EntityAccess\" was denied to the user with Login ID {LoginId}.", pageNumber, this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            const string sql = "SELECT * FROM config.entity_access ORDER BY entity_access_id LIMIT 10 OFFSET @0;";

            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql, offset);
        }

        public List<Frapid.DataAccess.Models.Filter> GetFilters(string catalog, string filterName)
        {
            const string sql = "SELECT * FROM config.filters WHERE object_name='config.entity_access' AND lower(filter_name)=lower(@0);";
            return Factory.Get<Frapid.DataAccess.Models.Filter>(catalog, sql, filterName).ToList();
        }

        /// <summary>
        /// Performs a filtered count on table "config.entity_access".
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "EntityAccess" class using the filter.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long CountWhere(List<Frapid.DataAccess.Models.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"EntityAccess\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM config.entity_access WHERE 1 = 1");
            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Frapid.Config.Entities.EntityAccess(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "config.entity_access" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "EntityAccess" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.Config.Entities.EntityAccess> GetWhere(long pageNumber, List<Frapid.DataAccess.Models.Filter> filters)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"EntityAccess\" was denied to the user with Login ID {LoginId}. Filters: {Filters}.", pageNumber, this._LoginId, filters);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM config.entity_access WHERE 1 = 1");

            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Frapid.Config.Entities.EntityAccess(), filters);

            sql.OrderBy("entity_access_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered count on table "config.entity_access".
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "EntityAccess" class using the filter.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long CountFiltered(string filterName)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return 0;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to count entity \"EntityAccess\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<Frapid.DataAccess.Models.Filter> filters = this.GetFilters(this._Catalog, filterName);
            Sql sql = Sql.Builder.Append("SELECT COUNT(*) FROM config.entity_access WHERE 1 = 1");
            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Frapid.Config.Entities.EntityAccess(), filters);

            return Factory.Scalar<long>(this._Catalog, sql);
        }

        /// <summary>
        /// Performs a filtered select statement on table "config.entity_access" producing a paginated result of 10.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "EntityAccess" class.</returns>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public IEnumerable<Frapid.Config.Entities.EntityAccess> GetFiltered(long pageNumber, string filterName)
        {
            if (string.IsNullOrWhiteSpace(this._Catalog))
            {
                return null;
            }

            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Read, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to Page #{Page} of the filtered entity \"EntityAccess\" was denied to the user with Login ID {LoginId}. Filter: {Filter}.", pageNumber, this._LoginId, filterName);
                    throw new UnauthorizedException("Access is denied.");
                }
            }

            List<Frapid.DataAccess.Models.Filter> filters = this.GetFilters(this._Catalog, filterName);

            long offset = (pageNumber - 1) * 10;
            Sql sql = Sql.Builder.Append("SELECT * FROM config.entity_access WHERE 1 = 1");

            Frapid.DataAccess.FilterManager.AddFilters(ref sql, new Frapid.Config.Entities.EntityAccess(), filters);

            sql.OrderBy("entity_access_id");

            if (pageNumber > 0)
            {
                sql.Append("LIMIT @0", 10);
                sql.Append("OFFSET @0", offset);
            }

            return Factory.Get<Frapid.Config.Entities.EntityAccess>(this._Catalog, sql);
        }


    }
}