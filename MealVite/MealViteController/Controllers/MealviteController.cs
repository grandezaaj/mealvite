using MealVite.Core.Interfaces;
using MealVite.Core.Repository;
using MealVite.Model;
using MealViteController.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MealViteController.Controllers
{
    [RoutePrefix("api/Mealvite")]
    public class MealviteController : ApiController
    {
        private IMealVite repo;

        public MealviteController()
        {
            this.repo = new MealViteRepository();
        }

        [Route("List")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var list = this.repo.GetAll();
            var items = list.Select(s => new
                {
                    Title = s.Title,
                    Price = s.Price,
                    Location = s.Location,
                    Description = s.Description,
                    Status = s.Status,
                    MealViteDate = s.MealViteDate,
                    Tags = s.Tags,
                    ImagePath = Path.GetFileName(s.ImagePath),
                    Host = new
                    {
                        HostId = s.Profile.ProfileId,
                        HostName = string.Format("{0} {1}", s.Profile.FirstName, s.Profile.LastName)
                    }
                });

            return Ok(items);
        }

        [Route("{id}")]
        public IHttpActionResult Find(int id)
        {
            var item = this.repo.FindById(id);

            if (item == null)
            {
                return BadRequest("Unable to find MealVite.");
            }

            return Ok(item);
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IHttpActionResult> Add()
        {

            try
            {
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                var root = HttpContext.Current.Server.MapPath("~/FileUploads");
                Directory.CreateDirectory(root);
                var provider = new PhotoMultipartFormDataStreamProvider(root);
                var result = await Request.Content.ReadAsMultipartAsync(provider);

                if (result.FormData["entity"] == null)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }


                var entity = JsonConvert.DeserializeObject<Mealvite>(result.FormData["entity"]);

                if (result.FileData.Count > 0)
                {
                    entity.ImagePath = Path.GetFileName(result.FileData[0].LocalFileName);
                }

                entity.DateCreated = DateTime.Now;
                entity.LastDateUpdated = DateTime.Now;
                entity.HostId = 1000; // todo
                entity.Status = ""; // todo
                this.repo.Insert(entity);

                return Ok();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update(Mealvite entity)
        {
            try
            {
                this.repo.Update(entity);

                return Ok();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [Route("Delete/{id}")]
        [HttpPut]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.repo.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
