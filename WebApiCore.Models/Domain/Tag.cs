namespace WebApiCore.Models.Domain
{
    public class Tag
    {
        public int TagId { get; set; }

        public string TagName { get; set; }

        public virtual Photo Photo { get; set; }
    }
}
