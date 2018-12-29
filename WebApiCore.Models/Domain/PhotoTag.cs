using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiCore.Models.Domain
{
    public class PhotoTag
    {
        [Key, Column(Order=0)]
        public int PhotoId { get; set; }
        [Key, Column(Order=1)]
        public int TagId { get; set; }
    }
}
