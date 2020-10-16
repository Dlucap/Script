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
    #region Cabeçalho
    public StringBuilder Cabecalho(DadosPorjeto dadosPorjeto)
    {
      StringBuilder stringBuilder = new StringBuilder();
      return stringBuilder.Append($@"
/*************************************************************
         {dadosPorjeto.Nome} - {dadosPorjeto.CodProjeto}
         {dadosPorjeto.tipoCliente}
 *************************************************************/");
    }

    #endregion  #region Cabeçalho

    #region  Salvar/Gerar Script SQl

    #region Salvar Sql
    public void SalvarScriptSQL(string fileName, DadosPorjeto dadosPorjeto, List<GDefCompl> gDefCompls, List<GDic> gGDic)
    {
      using (StreamWriter outfile = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
      {
        outfile.Write(GerarScriptSql(dadosPorjeto, gDefCompls, gGDic));
      }
    }
    #endregion Salvar Sql

    #region Gerar SQL
    private StringBuilder GerarScriptSql(DadosPorjeto dadosPorjeto, List<GDefCompl> gDefCompls, List<GDic> gGDic)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Sql sql = new Sql();

      stringBuilder.Append(Cabecalho(dadosPorjeto));
      if (gGDic.Any())
      {
        bool cabecalho = true;
        foreach (var item in gGDic)
        {
          stringBuilder.Append(sql.GeraInsertSqlGDic(item,cabecalho));
          cabecalho = false;
        }
      }

      if (gDefCompls.Any())
      {
        foreach (var item in gDefCompls)
        {
          stringBuilder.Append(sql.GeraInsertSqlGDef(item));
        }
      }
     
      return stringBuilder;
    }
    #endregion Gerar SQL

    #endregion  Salvar/Gerar Script SQl

    #region  Salvar/Gerar Script ORACLE

    #region  Salvar/Gerar Script ORACLE
    public void SalvarScriptOracle(string fileName, DadosPorjeto dadosPorjeto, List<GDefCompl> gDefCompls, List<GDic> gGDic)
    {
      using (StreamWriter outfile = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
      {
        outfile.Write(GeraScriptOracle(dadosPorjeto, gDefCompls, gGDic));
      }
    }
    #endregion  Salvar/Gerar Script ORACLE

    #region Gerar Oracle
    private StringBuilder GeraScriptOracle(DadosPorjeto dadosPorjeto, List<GDefCompl> gDefCompls, List<GDic> gGDic)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Oracle oracle = new Oracle();

      stringBuilder.Append(Cabecalho(dadosPorjeto));

      foreach (var item in gDefCompls)
      {
        stringBuilder.Append(oracle.GeraInsertOracleGDef(item));
      }

      foreach (var item in gGDic)
      {
        StringBuilder builder = new StringBuilder();
        stringBuilder.Append(oracle.GeraInsertOracleGDic(item));
      }

      return stringBuilder;
    }
    #endregion Gerar Oracle

    #endregion  Salvar/Gerar Script ORACLE

  }
}
