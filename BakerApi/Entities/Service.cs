namespace BakerApi.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<ServiceDetail> ServiceDetails { get; set; }

    }
}
