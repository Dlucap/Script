using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public class SqlGCamposGDic
  {
    public StringBuilder GeraInsertSqlGCamposGDic(GCamposGDic gCamposGDic, StringBuilder buider)
    {
      var rel = (gCamposGDic.Relatorio == true) ? 1 : 0;
      #region Monta insert
      buider.Append($@"IF NOT EXISTS (SELECT NULL FROM {gCamposGDic.TabelaPrincipal} WHERE TABELA = '{gCamposGDic.Tabela}' AND COLUNA = '{gCamposGDic.Coluna}')
BEGIN
  INSERT INTO {gCamposGDic.TabelaPrincipal} (TABELA,COLUNA,DESCRICAO,RELATORIO,APLICACOES) 
  VALUES ('{gCamposGDic.Tabela}','{gCamposGDic.Coluna}','{gCamposGDic.Descricao}',{rel},'{gCamposGDic.Apicacoes}')
END {Environment.NewLine}");
      #endregion Monta insert    

      return buider;
    }

   
  }
}
