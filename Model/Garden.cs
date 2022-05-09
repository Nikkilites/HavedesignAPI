namespace Havedesign_Web_API.Model
{
    public class Garden
    {
        public Garden(int id, int costumerId, string name, DateTime? date, string? note)
        {
            Id = id;
            CostumerId = costumerId;
            Name = name;
            Date = date;
            Note = note;
        }

        public int Id { get; set; }
        public int CostumerId { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Note { get; set; }
    }
}
