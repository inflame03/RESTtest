using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using BaBu.Models;
using BaBu.Services;

namespace RESTTest.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BabuActionsController : ApiController
    {
        private BaBuIngredientRepository brep;

        public BabuActionsController()
        {
            this.brep = new BaBuIngredientRepository();
        }

        // GET: api/BabuDelete
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BabuDelete/5
        [HttpGet]
        [ActionName("RandomRecipe")]
        public Recipe Get(int id)
        {
            Recipe result = new Recipe();

            result = this.brep.GetRandomRecipe();

            return result;
        }

        //// PUT: api/BabuDelete/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/BabuDelete/5
        //public void Delete(int id)
        //{
        //}

        // POST api/<controller>/<object>
        [HttpPost]
        [ActionName("DeleteItem")]
        public HttpResponseMessage DeleteItem(FoodComponent item)
        {
            this.brep.DeleteItem(item);

            IEnumerable<FoodComponent> itemlist = this.brep.GetAllItems(item.ItemType);

            var response = Request.CreateResponse<IEnumerable<FoodComponent>>(System.Net.HttpStatusCode.Created, itemlist);

            return response;
        }
    }
}
