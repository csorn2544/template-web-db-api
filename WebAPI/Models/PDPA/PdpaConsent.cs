namespace WebAPI.Models.PDPA
{
    public partial class PdpaConsent : Auditable
    {
        public int Id { get; set; }
        public string ConCode { get; set; } = null;
        public ulong? Status { get; set; }
        public string Version { get; set; } = null;
        public string TitleTh { get; set; } = null;
        public string TitleEn { get; set; } = null;
        public string TitleZh { get; set; } = null;
        public string DescriptionTh { get; set; } = null;
        public string DescriptionEn { get; set; } = null;
        public string DescriptionZh { get; set; } = null;
    }
}
