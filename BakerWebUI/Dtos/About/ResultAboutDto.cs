namespace BakerWebUI.Dtos.About
{
    public class ResultAboutDto
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> DetailDescription { get; set; }
    }
}
