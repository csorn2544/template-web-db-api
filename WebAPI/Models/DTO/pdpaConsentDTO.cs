public class PdpaConsentDTO
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string TitleTh { get; set; }
    public string TitleEn { get; set; }
    public string TitleZh { get; set; }
    public string DescriptionTh { get; set; }
    public string DescriptionEn { get; set; }
    public string DescriptionZh { get; set; }
    public DateTime? Date { get; set; } = DateTime.UtcNow;
    public PdpaConsentDTO() { }

    public PdpaConsentDTO(PdpaConsent pdpaConsentItem)
    {
        (Name, Version, TitleTh, TitleEn, TitleZh, DescriptionTh, DescriptionEn, DescriptionZh, Date) = (
            pdpaConsentItem.Name,
            pdpaConsentItem.Version,
            pdpaConsentItem.TitleTh,
            pdpaConsentItem.TitleEn,
            pdpaConsentItem.TitleZh,
            pdpaConsentItem.DescriptionTh,
            pdpaConsentItem.DescriptionEn,
            pdpaConsentItem.DescriptionZh,
            pdpaConsentItem.Date

        );

    }
}
