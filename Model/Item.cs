namespace Havedesign_Web_API.Model
{
    public class Item
    {
        public Item(int id, int categoryID, string name, string prefabName, string thumbnailPath)
        {
            Id = id;
            CategoryID = categoryID;
            Name = name;
            PrefabName = prefabName;
            ThumbnailPath = thumbnailPath;
        }

        public int Id { get; set; }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string PrefabName { get; set; }
        public string ThumbnailPath { get; set; }
    }
}
