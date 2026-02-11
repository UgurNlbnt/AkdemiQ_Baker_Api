namespace BakerApi.Dto
{
    public class ServiceWithServiceDetailsDto
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public List<ServiceDetailDto> ServiceDetails { get; set; }
    }
}
