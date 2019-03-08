using Business.Contracts.Services;
using Data.Contracts;
using Data.Models;
using Hosting.WebApp.Models;
using MediaRadar.Api;
using MediaRadar.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hosting.WebApp.Controllers.Api
{
    [RoutePrefix("api/paa")]
    public class PublicationAdActivityController : ApiController
    {
        #region Fields
        private readonly IPublicationAdActivityService publicationAdActivityService;
        private readonly IPublicationService publicationService;
        private readonly IUnitOfWork unitOfWork;
        #endregion

        #region Constructors
        public PublicationAdActivityController(IPublicationAdActivityService publicationAdActivityService, IPublicationService publicationService, IUnitOfWork unitOfWork)
        {
            this.publicationAdActivityService = publicationAdActivityService;
            this.publicationService = publicationService;
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        [HttpPost]
        [Route("load")]
        public async Task<HttpResponseMessage> PopulateDatabaseAsync(HttpRequestMessage request)
        {
            try
            {
                if (publicationAdActivityService.ContainsData())
                {
                    return request.CreateResponse(HttpStatusCode.OK, new { Status = true });
                }

                //Hardcoded here, however these could be passed in to provide more flexibility
                var startDate = new DateTime(2011, 01, 1);
                var endDate = new DateTime(2011, 04, 1);

                var rawData = await publicationService.GetPublicationAdActivitiesAsync(new DateRange(startDate, endDate));

                var publicationAdActivities = rawData.Select(model => new PublicationAdActivity
                {
                    AdPages = model.AdPages,
                    BrandId = model.BrandId,
                    BrandName = model.BrandName,
                    EstPrintSpend = model.EstPrintSpend,
                    Month = DateTime.Parse(model.Month),
                    ParentCompany = model.ParentCompany,
                    ParentCompanyId = model.ParentCompanyId,
                    ProductCategory = model.ProductCategory,
                    PublicationId = model.PublicationId,
                    PublicationName = model.PublicationName
                });

                unitOfWork.Publications.AddRange(publicationAdActivities);

                await unitOfWork.SaveChangesAsync();

                return request.CreateResponse(HttpStatusCode.OK, new { Status = publicationAdActivities.Count() > 0 });
            }
            catch (Exception)
            {
                //TODO: Add error logging

                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception("An internal Server error occurred, Please rest assured we have informed someone of this issue."));
            }

        }

        [HttpGet]
        [Route("ads")]
        public HttpResponseMessage GetPublicationAdActivities(HttpRequestMessage request)
        {
            try
            {
                var dataModel = publicationAdActivityService.GetPublicationAdActivities().Select(model => new PublicationAdActivityModel
                {
                    AdPages = model.AdPages,
                    BrandId = model.BrandId,
                    BrandName = model.BrandName,
                    EstPrintSpend = model.EstPrintSpend.ToString("C", CultureInfo.CurrentCulture),
                    Month = model.Month.ToShortDateString(),
                    ParentCompany = model.ParentCompany,
                    ParentCompanyId = model.ParentCompanyId,
                    ProductCategory = model.ProductCategory,
                    PublicationId = model.PublicationId,
                    PublicationName = model.PublicationName
                });

                return request.CreateResponse(HttpStatusCode.OK, dataModel);
            }
            catch (Exception)
            {
                //TODO: Add error logging

                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception("An internal Server error occurred, Please rest assured we have informed someone of this issue."));
            }
        }

        [HttpGet]
        [Route("brands")]
        public HttpResponseMessage GetBrands(HttpRequestMessage request)
        {
            try
            {
                var dataModel = publicationAdActivityService.GetBrands().Select(model => new BrandModel
                {
                    AdPages = model.AdPages,
                    BrandId = model.BrandId,
                    BrandName = model.BrandName,
                    ProductCategory = model.ProductCategory
                });

                return request.CreateResponse(HttpStatusCode.OK, dataModel);
            }
            catch (Exception)
            {
                //TODO: Add error logging

                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception("An internal Server error occurred, Please rest assured we have informed someone of this issue."));
            }
        }

        [HttpGet]
        [Route("categories")]
        public HttpResponseMessage GetCategories(HttpRequestMessage request)
        {
            try
            {
                var dataModel = publicationAdActivityService.GetTopProductCategories().Select(model => new ProductCategoryModel
                {
                    AdPages = model.AdPages,
                    EstPrintSpend = model.EstPrintSpend.ToString("C", CultureInfo.CurrentCulture),
                    ProductCategory = model.ProductCategory
                });

                return request.CreateResponse(HttpStatusCode.OK, dataModel);
            }
            catch (Exception)
            {
                //TODO: Add error logging

                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception("An internal Server error occurred, Please rest assured we have informed someone of this issue."));
            }

        }

        [HttpGet]
        [Route("companies")]
        public HttpResponseMessage GetCompanies(HttpRequestMessage request)
        {
            try
            {
                var dataModel = publicationAdActivityService.GetTopParentCompaines().Select(model => new ParentCompanyModel
                {
                    AdPages = model.AdPages,
                    EstPrintSpend = model.EstPrintSpend.ToString("C", CultureInfo.CurrentCulture),
                    Month = model.Month.ToShortDateString(),
                    ParentCompany = model.ParentCompany,
                    ParentCompanyId = model.ParentCompanyId,
                    PublicationId = model.PublicationId,
                    PublicationName = model.PublicationName
                });

                return request.CreateResponse(HttpStatusCode.OK, dataModel);
            }
            catch (Exception)
            {
                //TODO: Add error logging

                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception("An internal Server error occurred, Please rest assured we have informed someone of this issue."));
            }
        }
        #endregion
    }
}
