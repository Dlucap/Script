using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
  public class GDic
  {
    public string Tabela { get; set; }
    public string Coluna { get; set; }
    public string Descricao { get; set; }
    public bool Relatorio { get; set; }
    public string Aplicacoes { get; set; }/*Principais*/
    /*
    public bool ConsultaTexo { get; set; }
    public string Action { get; set; }
    public string ActionKeyField { get; set; }
    public string ActionSearchField { get; set; }
    public string SecColName { get; set; }
    public string SecColigadaColumn{ get; set; }
    public bool Status { get; set; }
    public string RecCreatedBy { get; set; }
    public DateTime RecCreatedOn { get; set; }
    */
  }
}