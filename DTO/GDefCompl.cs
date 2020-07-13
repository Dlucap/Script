using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class GDefCompl
  {
    public int CODCOLIGADA { get; set; }
    public string APLICACAO { get; set; }
    public string TABDADOS { get; set; }
    public string NOMECOLUNA { get; set; }
    public string DESCRICAO { get; set; }
    public string CODTABDINAM { get; set; }
    public string CODFORMULA { get; set; }
    public string VALORDEFAULT { get; set; }
    public int CODCOLTABDINAM { get; set; }
    public string APLICTABDINAM { get; set; }
    public int ORDEM { get; set; }
    public bool QUEBRALINHA { get; set; }
    public bool PESQTABDINAMPORCOD { get; set; }
    public int CODCOLFORMULA { get; set; }
    public string CODAPLICFORMULA { get; set; }
    public string TIPOTEXTO { get; set; }
    public string RECCREATEDBY { get; set; }
    public DateTime RECCREATEDON { get; set; }
    public string RECMODIFIEDBY { get; set; }
    public DateTime RECMODIFIEDON { get; set; }
    public bool IsSql { get; set; }
    public bool IsOracle { get; set; }
  }
}
