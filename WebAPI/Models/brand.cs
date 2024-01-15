using Microsoft.EntityFrameworkCore;

public class Brand
{
  public int Id { get; set; }
  public string Code { get; set; }
  public string NameTh { get; set; }
  public string NameEn { get; set; }
  public string NameZh { get; set; }
  public string creationTime { get; set; }
  public int Status  { get; set; }
}

