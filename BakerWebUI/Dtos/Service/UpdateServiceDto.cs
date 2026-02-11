namespace BakerWebUI.Dtos.Service
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int ServiceDetailId { get; set; }
    }
}
