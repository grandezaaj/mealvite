using MealVite.Core.Interfaces;
using MealVite.Core.Repository;
using MealVite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MealViteController.Controllers
{
    [RoutePrefix("api/Profile")]
    public class ProfilesController : ApiController
    {
        private IProfile repo;

        public ProfilesController() 
        {
            this.repo = new ProfileRepository();
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
                return BadRequest("Unable to find Profile.");
            }

            return Ok(item);
        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add(Profile entity)
        {
            try
            {
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
        public IHttpActionResult Update(Profile entity)
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
