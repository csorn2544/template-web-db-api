public class PdpaPrivacy
{
  public int pdpaPrivacyID { get; set; }
  public string Name { get; set; }
  public string Version { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public bool IsDeleted { get; set; }
  public DateTime? Date { get; set; } = DateTime.UtcNow;

}
