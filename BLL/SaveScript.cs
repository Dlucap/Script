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

    public void SalvarScriptSQL(string fileName,List<GDefCompl> gDefCompls ,List<GCamposGDic> gCamposGDic)
    {
      using (StreamWriter outfile = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
      {
        SqlGCamposGDic sqlGDefCompl = new SqlGCamposGDic();
        foreach (var item in gDefCompls)
        {
          outfile.Write(sqlGDefCompl.GeraInsertSqlGDef(item));
        }

        foreach (var item in gCamposGDic)
        {          
          outfile.Write(sqlGDefCompl.GeraInsertSqlGCamposGDic(item));
        }
      }
    }

    public void SalvarScriptOracle(string fileName, List<GDefCompl> gDefCompls, List<GCamposGDic> modeloCamposGDic)
    {
      using (StreamWriter outfile = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
      {
        OracleGCamposGDic oracleSsqlGCamposGDic = new OracleGCamposGDic();

        foreach (var item in gDefCompls)
        {
          outfile.Write(oracleSsqlGCamposGDic.GeraInsertOracleGDef(item));
        }

        foreach (var item in modeloCamposGDic)
        {
          StringBuilder builder = new StringBuilder();
          outfile.Write(oracleSsqlGCamposGDic.GeraInsertOracleGCamposGDic(item));
        }
      }
    }

  }
}
