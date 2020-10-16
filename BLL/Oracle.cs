﻿using DTO;
using System;
using System.Text;

namespace BLL
{
  public class Oracle
  {
    #region Gdic
    public StringBuilder GeraInsertOracleGDic(GDic gCamposGDic)
    {

      var rel = (gCamposGDic.Relatorio == true) ? 1 : 0;
      return new StringBuilder().AppendLine($@"
/*************************************************************
         GDIC - {gCamposGDic.Tabela}.{gCamposGDic.Coluna}
*************************************************************/
SELECT COUNT(*) INTO EXIST FROM GDIC WHERE TABELA = '{gCamposGDic.Tabela}' AND COLUNA = '{gCamposGDic.Coluna}';
IF EXIST = 0 THEN
  INSERT INTO GDIC (TABELA, COLUNA, DESCRICAO, RELATORIO, APLICACOES) 
  VALUES('{gCamposGDic.Tabela}', '{gCamposGDic.Coluna}', '{gCamposGDic.Descricao}', {rel}, '{gCamposGDic.Aplicacoes}');
END IF {Environment.NewLine};");

    }
    #endregion Gdic

    #region GDefCompl
    public StringBuilder GeraInsertOracleGDef(GDefCompl gDefCompl)
    {
      return new StringBuilder()
        .AppendLine ($@"
DECLARE EXIST INTEGER;
BEGIN
/*************************************************************
         GDEFCOMPL - {gDefCompl.TabelaDados}.{gDefCompl.NomeColuna}
*************************************************************/
SELECT COUNT(*) INTO EXIST FROM user_tab_cols where column_name = '{gDefCompl.NomeColuna}' and table_name = '{gDefCompl.TabelaDados}';
IF EXIST = 0 THEN
  EXECUTE IMMEDIATE
 'ALTER TABLE GDEFCOMPL ADD  {gDefCompl.NomeColuna} VARCHAR(60) NULL';

  DECLARE V_COLIGADA2 INTEGER;

  CURSOR COLIGADA_CUR2 IS SELECT CODCOLIGADA FROM GCOLIGADA WHERE CODCOLIGADA <> 0;
  BEGIN
      OPEN COLIGADA_CUR2;

    LOOP
        FETCH  COLIGADA_CUR2 INTO V_COLIGADA2;
      EXIT WHEN COLIGADA_CUR2 % NOTFOUND;

      INSERT INTO GDEFCOMPL(CODCOLIGADA, APLICACAO, TABDADOS, NOMECOLUNA, DESCRICAO, CODTABDINAM, CODFORMULA, VALORDEFAULT, CODCOLTABDINAM, APLICTABDINAM, ORDEM, QUEBRALINHA, PESQTABDINAMPORCOD, CODCOLFORMULA, CODAPLICFORMULA, TIPOTEXTO, RECCREATEDBY, RECCREATEDON, RECMODIFIEDBY, RECMODIFIEDON)
        VALUES(V_COLIGADA2,'{gDefCompl.Aplicacao}', '{gDefCompl.TabelaDados}', '{gDefCompl.NomeColuna}', '{gDefCompl.Descricao}', null, NULL, NULL, 0, 'S', {gDefCompl.Ordem}, NULL, 'T', NULL, NULL, '0', 'mestre', SYSDATE, NULL, NULL);
    END LOOP;

    CLOSE COLIGADA_CUR2;

  END;
END IF {Environment.NewLine};");
    }

    #endregion GDefCompl

    #region GLinksRel
    public StringBuilder GeraInsertOracleGLinksrel(GLinksRel gLinksRel)
    {
      return new StringBuilder()
      .AppendLine($@"");
    }

    #endregion GLinksRel
  }
}
