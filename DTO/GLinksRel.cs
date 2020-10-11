using System;

namespace DTO
{
  public class GLinksRel
  {
    public string MasterTable { get; set; }
    public string ChildTable { get; set; }
    public string MasterField { get; set; }
    public string ChildField { get; set; }
    public string RecCreatedBy { get; set; }
    public DateTime RecCreatedOn { get; set; }
  }
}
