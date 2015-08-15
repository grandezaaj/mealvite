using MealVite.Core.Interfaces;
using MealVite.Core.Repository;
using MealVite.Model;
using MealViteController.Providers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

            return Ok(list);
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
                    StringBuilder str = new StringBuilder();
                    foreach (var item in result.FileData)
                    {
                        str.Append(Path.GetFileName(item.LocalFileName));
                        str.Append(",");
                    }
                   // entity.ImagePath = str.ToString();
                }
                this.repo.Insert(entity);

                return Ok();
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
