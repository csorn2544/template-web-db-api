public class PdpaConsent
{
    public int pdpaConsentId { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string TitleTh { get; set; }
    public string TitleEn { get; set; }
    public string TitleZh { get; set; }
    public string DescriptionTh { get; set; }
    public string DescriptionEn { get; set; }
    public string DescriptionZh { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? Date { get; set; } = DateTime.UtcNow;
    public int userId { get; set; }
}