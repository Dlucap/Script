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
    public StringBuilder GeraInsertSqlGCamposGDic(GCamposGDic gCamposGDic)
    {
      StringBuilder builder = new StringBuilder();

      var rel = (gCamposGDic.Relatorio == true) ? 1 : 0;
      #region Monta insert
      return builder.Append($@"
/*************************************************************
         {gCamposGDic.TabelaPrincipal} - {gCamposGDic.Tabela} - {gCamposGDic.Coluna}
*************************************************************/
IF NOT EXISTS (SELECT NULL FROM {gCamposGDic.TabelaPrincipal} WHERE TABELA = '{gCamposGDic.Tabela}' AND COLUNA = '{gCamposGDic.Coluna}')
BEGIN
  INSERT INTO {gCamposGDic.TabelaPrincipal} (TABELA,COLUNA,DESCRICAO,RELATORIO,APLICACOES) 
  VALUES ('{gCamposGDic.Tabela}','{gCamposGDic.Coluna}','{gCamposGDic.Descricao}',{rel},'{gCamposGDic.Aplicacoes}')
END {Environment.NewLine}");
      #endregion Monta insert    
    }

    public StringBuilder GeraInsertSqlGDef(GDefCompl gDefCompl)
    {
      StringBuilder builder = new StringBuilder();
      var sentenca = $@"
/*************************************************************
         GDEFCOMPL - {gDefCompl.TabelaDados} - {gDefCompl.NomeColuna} 
*************************************************************/
DECLARE @COLIGADA INT
IF NOT EXISTS(SELECT 1 FROM SYS.COLUMNS WHERE NAME = N'{gDefCompl.NomeColuna}' and Object_ID = Object_ID(N'{gDefCompl.TabelaDados}'))
BEGIN
	ALTER TABLE {gDefCompl.TabelaDados} ADD {gDefCompl.NomeColuna} VARCHAR({gDefCompl.TamanhoColuna}) NULL

	DECLARE CURSOR_COLIGADA CURSOR FOR SELECT CODCOLIGADA FROM GCOLIGADA WHERE CODCOLIGADA <> 0
	OPEN CURSOR_COLIGADA
	FETCH NEXT FROM CURSOR_COLIGADA INTO @COLIGADA

	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO dbo.GDEFCOMPL (CODCOLIGADA, APLICACAO, TABDADOS, NOMECOLUNA, DESCRICAO, CODTABDINAM, CODFORMULA, VALORDEFAULT, CODCOLTABDINAM, APLICTABDINAM, ORDEM, QUEBRALINHA, PESQTABDINAMPORCOD, CODCOLFORMULA, CODAPLICFORMULA, TIPOTEXTO, RECCREATEDBY, RECCREATEDON, RECMODIFIEDBY, RECMODIFIEDON)
		VALUES (@COLIGADA, '{gDefCompl.Aplicacao}', '{gDefCompl.TabelaDados}', '{gDefCompl.NomeColuna}', '{gDefCompl.Descricao}', null, NULL, NULL, 0, 'S', {gDefCompl.Ordem}, NULL, 'T', NULL, NULL, '0', 'mestre', '2018-06-14', NULL, NULL)

		FETCH NEXT FROM CURSOR_COLIGADA INTO @COLIGADA
	END
	CLOSE CURSOR_COLIGADA
	DEALLOCATE CURSOR_COLIGADA
END

GO {Environment.NewLine}";

      return builder.Append(sentenca);
    }
  }
}
