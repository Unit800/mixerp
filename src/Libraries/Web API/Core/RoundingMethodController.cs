using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using PetaPoco;

namespace MixERP.Net.Api.Core
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Rounding Methods.
    /// </summary>
    [RoutePrefix("api/v1.5/core/rounding-method")]
    public class RoundingMethodController : ApiController
    {
        /// <summary>
        ///     The RoundingMethod data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Core.Data.RoundingMethod RoundingMethodContext;

        public RoundingMethodController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.RoundingMethodContext = new MixERP.Net.Schemas.Core.Data.RoundingMethod
            {
                Catalog = this.Catalog,
                LoginId = this.LoginId
            };
        }

        public long LoginId { get; }
        public int UserId { get; private set; }
        public int OfficeId { get; private set; }
        public string Catalog { get; }

        /// <summary>
        ///     Counts the number of rounding methods.
        /// </summary>
        /// <returns>Returns the count of the rounding methods.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        public long Count()
        {
            try
            {
                return this.RoundingMethodContext.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Returns an instance of rounding method.
        /// </summary>
        /// <param name="roundingMethodCode">Enter RoundingMethodCode to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{roundingMethodCode}")]
        public MixERP.Net.Entities.Core.RoundingMethod Get(string roundingMethodCode)
        {
            try
            {
                return this.RoundingMethodContext.Get(roundingMethodCode);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 rounding methods on each page, sorted by the property RoundingMethodCode.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        public IEnumerable<MixERP.Net.Entities.Core.RoundingMethod> GetPagedResult()
        {
            try
            {
                return this.RoundingMethodContext.GetPagedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 rounding methods on each page, sorted by the property RoundingMethodCode.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Core.RoundingMethod> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.RoundingMethodContext.GetPagedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Displayfields is a lightweight key/value collection of rounding methods.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of rounding methods.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.RoundingMethodContext.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds your instance of Account class.
        /// </summary>
        /// <param name="roundingMethod">Your instance of rounding methods class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{roundingMethod}")]
        public void Add(MixERP.Net.Entities.Core.RoundingMethod roundingMethod)
        {
            if (roundingMethod == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.RoundingMethodContext.Add(roundingMethod);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Edits existing record with your instance of Account class.
        /// </summary>
        /// <param name="roundingMethod">Your instance of Account class to edit.</param>
        /// <param name="roundingMethodCode">Enter the value for RoundingMethodCode in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{roundingMethodCode}/{roundingMethod}")]
        public void Edit(string roundingMethodCode, MixERP.Net.Entities.Core.RoundingMethod roundingMethod)
        {
            if (roundingMethod == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.RoundingMethodContext.Update(roundingMethod, roundingMethodCode);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Deletes an existing instance of Account class via RoundingMethodCode.
        /// </summary>
        /// <param name="roundingMethodCode">Enter the value for RoundingMethodCode in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{roundingMethodCode}")]
        public void Delete(string roundingMethodCode)
        {
            try
            {
                this.RoundingMethodContext.Delete(roundingMethodCode);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }
    }
}