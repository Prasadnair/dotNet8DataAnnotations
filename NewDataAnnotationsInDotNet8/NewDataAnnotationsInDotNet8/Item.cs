using System.ComponentModel.DataAnnotations;

namespace NewDataAnnotationsInDotNet8
{
    public class Item
    {
        [Length(5, 20)]
        public string Name { get; set; }

        [Range(250, 2000, MinimumIsExclusive = true, MaximumIsExclusive = false)]
        public double Price { get; set; }

        [AllowedValues("Phones","Tabs")]
        public string Category { get; set; }

        [DeniedValues("Monitors")]
        public string SubCategory { get; set; }

        [Base64String]
        public string Description { get; set; }
    }
}
