namespace BakerApi.Entities
{
    public class AboutDetail
    {
        public int AboutDetailId { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
