using Microsoft.AspNetCore.Mvc;
using Havedesign_Web_API.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Havedesign_Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HavedesignController : ControllerBase
    {
        [HttpGet("GetAllCustomers")]
        public IEnumerable<Customer> GetAllCustomers()
        {
            return DBHandler.RetrieveAllCustomers();
        }

        [HttpGet("GetAllItemCategories")]
        public IEnumerable<Category> GetAllItemCategories()
        {
            return DBHandler.RetrieveAllItemCategories();
        }

        [HttpGet("GetAllItems")]
        public IEnumerable<Item> GetAllItems()
        {
            return DBHandler.RetrieveAllItems();
        }

        [HttpGet("GetCustomer")]
        public Customer GetCustomer(int customerId)
        {
            return DBHandler.RetrieveCustomer(customerId);
        }

        [HttpGet("GetGarden")]
        public Garden GetGarden(int gardenId)
        {
            return DBHandler.RetrieveGarden(gardenId);
        }

        [HttpGet("GetCategory")]
        public Category GetCategory(int categoryId)
        {
            return DBHandler.RetrieveCategory(categoryId);
        }

        [HttpGet("GetItem")]
        public Item GetItem(int itemId)
        {
            return DBHandler.RetrieveItem(itemId);
        }

        [HttpGet("GetItemsInCategory")]
        public IEnumerable<Item> GetItemsInCategory(int categoryId)
        {
            return DBHandler.RetrieveItemsInCategory(categoryId);
        }

        [HttpGet("GetCustomersGardens")]
        public IEnumerable<Garden> GetCustomersGardens(int customerId)
        {
            return DBHandler.RetrieveCustomersGardens(customerId);
        }

        [HttpGet("GetGardensItems")]
        public IEnumerable<GardensItem> GetGardensItems(int gardenId)
        {
            return DBHandler.RetrieveGardensItems(gardenId);
        }

        [HttpGet("GetGardensUnityItems")]
        public IEnumerable<GardensUnityItem> GetGardensUnityItems(int gardenId)
        {
            return DBHandler.RetrieveGardensUnityItems(gardenId);
        }

        [HttpGet("GetGardensImgs")]
        public IEnumerable<GardensImg> GetGardensImgs(int gardenId)
        {
            return DBHandler.RetrieveGardensImgs(gardenId);
        }
    }
}
