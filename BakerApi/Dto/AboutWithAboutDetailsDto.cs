namespace BakerApi.Dto
{
    public class AboutWithAboutDetailsDto
    {
        public int AboutId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public List<string> DetailDescription { get; set; }
    }
}
