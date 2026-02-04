using System.ComponentModel.DataAnnotations.Schema;

namespace ShotUrl.Model
{
    public class EntityUrl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ShortId { get; set; }
        public string BaseUrl { get; set; }
        public DateTime Created_at { get; set; } = DateTime.UtcNow;
    }
}