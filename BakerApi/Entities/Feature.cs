using System.Security.Principal;

namespace BakerApi.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string SubTitle { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
