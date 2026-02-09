namespace BakerApi.Entities
{
    public class ServiceDetail
    {
        public int ServiceDetailId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
