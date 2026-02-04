namespace ShotUrl.Model
{
    public class EntityUrl
    {
        public string ShortId { get; set; }
        public string BaseUrl { get; set; }
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
    }
}