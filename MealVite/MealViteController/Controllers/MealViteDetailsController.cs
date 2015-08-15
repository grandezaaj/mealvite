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
    [RoutePrefix("api/MealViteDetail")]
    public class MealViteDetailsController : ApiController
    {

        private IMealViteDetails repo;

        public MealViteDetailsController() 
        {
            this.repo = new MealViteDetailRepository();
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
                return BadRequest("Unable to find MealViteDetails.");
            }

            return Ok(item);
        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult Add(MealViteDetail entity)
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
        public IHttpActionResult Update(MealViteDetail entity)
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
