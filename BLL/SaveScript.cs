using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
 public class SaveScript
  {



    public StringBuilder Cabecalho(string nomeProjeto)
    {
      return new StringBuilder();
    }

    public void SalvarScriptSQL(string fileName, StringBuilder buider, List<GCamposGDic> modeloCamposGDic)
    {
      using (StreamWriter outfile = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
      {
        SqlGCamposGDic sqlGCamposGDic = new SqlGCamposGDic();
        foreach (var item in modeloCamposGDic)
        {
          if (item.IsSql)
          {
            StringBuilder builder = new StringBuilder();
            outfile.Write(sqlGCamposGDic.GeraInsertSqlGCamposGDic(item, builder));
          }

        }
      }
    }

    public void SalvarScriptOracle(string fileName, StringBuilder buider, List<GCamposGDic> modeloCamposGDic)
    {
      using (StreamWriter outfile = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
      {
        OracleGCamposGDic oracleSsqlGCamposGDic = new OracleGCamposGDic();

        foreach (var item in modeloCamposGDic)
        {
          if (item.IsOracle)
          {
            StringBuilder builder = new StringBuilder();
            outfile.Write(oracleSsqlGCamposGDic.GeraInsertOracle(item, builder));
          }
        }
      }
    }

  }
}
