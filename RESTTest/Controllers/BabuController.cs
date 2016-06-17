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
    public class BabuController : ApiController
    {
        private BaBuIngredientRepository brep;

        public BabuController()
        {
            this.brep = new BaBuIngredientRepository();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<controller>/5
        [ActionName("GetByType")]
        public IEnumerable<FoodComponent> Get(string type)
        {
            ItemType t;

            switch(type.ToUpper())
            {
                case "CONDIMENT": t = ItemType.Condiment; break;
                case "COOKINGMETHOD": t = ItemType.CookingMethod; break;
                case "GARNISH": t = ItemType.Garnish; break;
                case "INGREDIENTS": t = ItemType.Ingredients; break;
                case "SPICES": t = ItemType.Spices; break;
                default: return new FoodComponent[0];
            }

            return this.brep.GetAllItems(t);
        }

        // POST api/<controller>
        [HttpPost]
        [ActionName("SaveNewItem")]
        public HttpResponseMessage SaveNewItem(FoodComponent newItem)
        {

            this.brep.SaveUser(newItem);

            IEnumerable<FoodComponent> itemlist = this.brep.GetAllItems(newItem.ItemType);

            var response = Request.CreateResponse<IEnumerable<FoodComponent>>(System.Net.HttpStatusCode.Created, itemlist);

            

            return response;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
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