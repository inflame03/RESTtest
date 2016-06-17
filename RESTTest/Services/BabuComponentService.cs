using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BaBu.Models;
using BaBu.Logic;

namespace BaBu.Services
{
    public class BaBuIngredientRepository
    {
        public BaBuIngredientRepository() {  }

        public FoodComponent[] GetAllItems(ItemType type)
        {
            BaBuLogic bl = new BaBuLogic();

            return bl.GetItemList(type);

        }

        public FoodComponent GetItem(int ID, ItemType type)
        {
            BaBuLogic bl = new BaBuLogic();

            return bl.GetItem(ID, type);
        }

        public FoodComponent SaveUser(FoodComponent item)
        {
            BaBuLogic bl = new BaBuLogic();

            return bl.SaveItem(item, item.ItemType);

        }

        public bool DeleteItem(FoodComponent item)
        {
            BaBuLogic ul = new BaBuLogic();

            return ul.DeleteUser(item.ID, item.ItemType);

        }

        public Recipe GetRandomRecipe()
        {
            BaBuLogic bl = new BaBuLogic();

            return bl.GetRandomRecipe();
        }
    }
}