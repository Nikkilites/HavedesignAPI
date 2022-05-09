namespace Havedesign_Web_API.Model
{
    public class GardensImg
    {
        public GardensImg(int id, int gardenId, string imgPath, bool isMainImg)
        {
            Id = id;
            GardenId = gardenId;
            ImgPath = imgPath;
            IsMainImg = isMainImg;
        }

        public int Id { get; set; }
        public int GardenId { get; set; }
        public string ImgPath { get; set; }
        public bool IsMainImg { get; set; }
    }
}
