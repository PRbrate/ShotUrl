using System.ComponentModel.DataAnnotations.Schema;

namespace ShotUrl.Model
{
    public class EntityUrl
    {
        
        public string ShortId { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime Created_at { get; set; }
    }
}