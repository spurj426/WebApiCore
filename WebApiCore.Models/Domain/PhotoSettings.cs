namespace WebApiCore.Models
{
    public class PhotoSettings
    {
        /// <summary>
        /// The original photo size.
        /// </summary>
        public int FullSize { get; set; }

        /// <summary>
        /// The desired medium size for content format.
        /// </summary>
        public int MediumSize { get; set; }

        /// <summary>
        /// The desired small size for content format.
        /// </summary>
        public int SmallSize { get; set; }

        public string PhotosDirectory { get; set; }

        public string MediumSizeSuffix { get; } = "_md";

        public string SmallSizeSuffix { get; } = "_sm";
    } 
}
