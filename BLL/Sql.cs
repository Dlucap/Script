using DTO;
using System;
using System.Text;

namespace BLL
{
  public class Sql
  {
    #region Gdic
    public StringBuilder GeraInsertSqlGDic(GDic gDic, bool cabecalho)
    {
      StringBuilder builder = new StringBuilder();

      var rel = (gDic.Relatorio == true) ? 1 : 0;

      if (cabecalho)
      {
        builder.Append($@"
/*************************************************************
         GDIC - {gDic.Tabela} 
*************************************************************/");
      }

      return builder.Append($@"
IF NOT EXISTS (SELECT NULL FROM GDIC WHERE TABELA = '{gDic.Tabela}' AND COLUNA = '{gDic.Coluna}')
BEGIN
  INSERT INTO GDIC (TABELA,COLUNA,DESCRICAO,RELATORIO,APLICACOES) 
  VALUES ('{gDic.Tabela}','{gDic.Coluna}','{gDic.Descricao}',{rel},'{gDic.Aplicacoes}')
END {Environment.NewLine}");

    }
    #endregion Gdic

    #region GDefCompl

    public StringBuilder GeraInsertSqlGDef(GDefCompl gDefCompl)
    {
      StringBuilder builder = new StringBuilder();
      var sentenca = $@"
/*************************************************************
         GDEFCOMPL - {gDefCompl.TabelaDados}.{gDefCompl.NomeColuna}
*************************************************************/
DECLARE @COLIGADA INT
IF NOT EXISTS(SELECT 1 FROM SYS.COLUMNS WHERE NAME = N'{gDefCompl.NomeColuna}' and Object_ID = Object_ID(N'{gDefCompl.TabelaDados}'))
BEGIN
	ALTER TABLE GDEFCOMPL ADD {gDefCompl.NomeColuna} VARCHAR({gDefCompl.TamanhoColuna}) NULL

	DECLARE CURSOR_COLIGADA CURSOR FOR SELECT CODCOLIGADA FROM GCOLIGADA WHERE CODCOLIGADA <> 0
	OPEN CURSOR_COLIGADA
	FETCH NEXT FROM CURSOR_COLIGADA INTO @COLIGADA

	WHILE @@FETCH_STATUS = 0
	BEGIN
		INSERT INTO GDEFCOMPL (CODCOLIGADA, APLICACAO, TABDADOS, NOMECOLUNA, DESCRICAO, CODTABDINAM, CODFORMULA, VALORDEFAULT, CODCOLTABDINAM, APLICTABDINAM, ORDEM, QUEBRALINHA, PESQTABDINAMPORCOD, CODCOLFORMULA, CODAPLICFORMULA, TIPOTEXTO, RECCREATEDBY, RECCREATEDON, RECMODIFIEDBY, RECMODIFIEDON)
		VALUES (@COLIGADA, '{gDefCompl.Aplicacao}', '{gDefCompl.TabelaDados}', '{gDefCompl.NomeColuna}', '{gDefCompl.Descricao}', null, NULL, NULL, 0, 'S', {gDefCompl.Ordem}, NULL, 'T', NULL, NULL, '0', 'mestre', GETDATE(), NULL, NULL)

		FETCH NEXT FROM CURSOR_COLIGADA INTO @COLIGADA
	END
	CLOSE CURSOR_COLIGADA
	DEALLOCATE CURSOR_COLIGADA
END

GO {Environment.NewLine}";

      return builder.Append(sentenca);
    }
    #endregion GDefCompl

    #region GLinksRel
    public StringBuilder GeraInsertOracleGLinksrel(GLinksRel gLinksRel)
    {
      return new StringBuilder()
      .AppendLine($@"
/*************************************************************
         GLINKSREL -   
*************************************************************/
     INSERT INTO GLINKSREL (MASTERTABLE,CHILDTABLE,MASTERFIELD,CHILDFIELD,RECCREATEDBY,RECCREATEDON,RECMODIFIEDBY,RECMODIFIEDON])
     VALUES  ({gLinksRel.MasterTable}, {gLinksRel.ChildTable}, {gLinksRel.MasterField}, {gLinksRel.ChildField}, 'mestre', GETDATE(), NULL, NULL)");
    }
    #endregion GLinksRel
  }
}
/*
    INSERT INTO dbo.GDEFCOMPL(CODCOLIGADA, APLICACAO, TABDADOS, NOMECOLUNA, DESCRICAO, CODTABDINAM, CODFORMULA, VALORDEFAULT, CODCOLTABDINAM, APLICTABDINAM, ORDEM, QUEBRALINHA, PESQTABDINAMPORCOD, CODCOLFORMULA, CODAPLICFORMULA, TIPOTEXTO, RECCREATEDBY, RECCREATEDON, RECMODIFIEDBY, RECMODIFIEDON)

    VALUES(@COLIGADA, 'S', 'SALUNOCOMPL', 'EMAILGOOGLE', 'E-mail Google:', null, NULL, NULL, 0, 'S', 5, NULL, 'T', NULL, NULL, '0', 'mestre', '2018-06-14', NULL, NULL)


    FETCH NEXT FROM CURSOR_COLIGADA INTO @COLIGADA

  END
  CLOSE CURSOR_COLIGADA
  DEALLOCATE CURSOR_COLIGADA
END
*/
