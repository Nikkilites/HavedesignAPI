namespace Havedesign_Web_API.Model
{
    public class Category
    {

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
