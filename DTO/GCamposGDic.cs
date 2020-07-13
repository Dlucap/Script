using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class GCamposGDic
  {
    public string TabelaPrincipal { get; set; }
    public string Tabela { get; set; }
    public string Coluna { get; set; }
    public string Descricao { get; set; }
    public bool Relatorio { get; set; }
    public string Apicacoes { get; set; }
    public bool IsSql { get; set; }
    public bool IsOracle { get; set; }
  }
}
