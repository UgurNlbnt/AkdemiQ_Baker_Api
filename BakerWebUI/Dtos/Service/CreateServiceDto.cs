namespace BakerWebUI.Dtos.Service
{
    public class CreateServiceDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int ServiceDetailId { get; set; }
    }
}
