using NpgsqlTypes;

namespace Havedesign_Web_API.Model
{
    public class GardensUnityItem
    {
        public GardensUnityItem(int id, int gardenId, int itemId, string prefabName, NpgsqlPoint placement, double rotation)
        {
            Id = id;
            GardenId = gardenId;
            ItemId = itemId;
            PrefabName = prefabName;
            X = placement.X;
            Y = placement.Y;
            Rotation = rotation;
        }

        public int Id { get; set; }
        public int GardenId { get; set; }
        public int ItemId { get; set; }
        public string PrefabName { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Rotation { get; set; }
    }
}
