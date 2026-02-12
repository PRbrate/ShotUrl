namespace ShotUrl.Model
{
    public class UrlRedis
    {
        public string ShortUrl { get; set; }
        public string PrincipalUrl { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public int QuanGet { get; set; }

    }
}
