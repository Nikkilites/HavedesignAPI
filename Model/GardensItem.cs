using NpgsqlTypes;

namespace Havedesign_Web_API.Model
{
    public class GardensItem
    {
        public GardensItem(int id, int itemID, int categoryID, string itemName)
        {
            Id = id;
            ItemID = itemID;
            CategoryID = categoryID;
            ItemName = itemName;
        }

        public int Id { get; set; }
        public int ItemID { get; set; }
        public int CategoryID { get; set; }
        public string ItemName { get; set; }
    }
}
