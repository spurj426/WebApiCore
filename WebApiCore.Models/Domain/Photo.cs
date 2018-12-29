using System.Collections.Generic;

namespace WebApiCore.Models.Domain
{
    public class Photo
    {
        public int PhotoId { get; set; }

        public string FileName { get; set; }

        public string MediumFileName { get; set; }

        public string SmallFileName { get; set; }

        public string Caption { get; set; }

        public string Details { get; set; }

        public int OwnerId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
