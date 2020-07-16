using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
  public partial class GeraScript : Form
  {
    CollectionsGCamposGDic gCamposGdic = new CollectionsGCamposGDic();
    CollectionsGDefCompl gDefCompl = new CollectionsGDefCompl();

    public GeraScript()
    {
      InitializeComponent();
      //CarregaColunasDataGridGCamposGdic();
    }

    #region GCamposGdic
    private void btnInserirDados_Click(object sender, EventArgs e)
    {
      try
      {
        StringBuilder builder = new StringBuilder();
        if (!ValidaCamposPreenchidosGCampos(out builder))
        {
          throw new Exception(Convert.ToString(builder));
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message,"Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }
      gCamposGdic.Add(GetDadosGcamposGic());

      dgvGdicGcampos.AutoGenerateColumns = true;
      dgvGdicGcampos.DataSource = new BindingList<GCamposGDic>(gCamposGdic.ToList());
      dgvGdicGcampos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
      LimparGCamposGDic();
    }

    private void btnGcamposGDicExcluir_Click(object sender, EventArgs e)
    {
      if (dgvGdicGcampos.SelectedRows.Count == 0)
      {
        MessageBox.Show("Nenhum registro selecionado", "Atenção");
        return;
      }
      else
      {
        int indice = dgvGdicGcampos.CurrentRow.Index;
        if (dgvGdicGcampos.Rows[indice].Cells[indice].Value.ToString() != null)
        {
          if (indice != 0)
          {
            dgvGdicGcampos.Rows.RemoveAt(dgvGdicGcampos.Rows[indice].Index);
            gCamposGdic.RemoveAt(dgvGdicGcampos.Rows[indice].Index);
          }
        }
      }
    }

    private void btlGCamposGdicLimparCampos_Click(object sender, EventArgs e)
    {
      LimparGCamposGDic();
    }

    private void Salvar(SaveScript saveScript, bool sql)
    {
      SaveFileDialog saveFileDialog1 = new SaveFileDialog();
      saveFileDialog1.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
      saveFileDialog1.FilterIndex = 1;
      saveFileDialog1.Title = "Salvar - Script";
      saveFileDialog1.RestoreDirectory = true;

      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        String path = saveFileDialog1.FileName;
        //  StringBuilder script = new StringBuilder();// project.ScriptCreator.generateGLinksRelsAndGCampos();

        //verifica se salva sql ou oracle
        if (sql == true)
        {
          saveScript.SalvarScriptSQL(path, gDefCompl, gCamposGdic);
        }
        else
        {
          saveScript.SalvarScriptOracle(path, gDefCompl,gCamposGdic);
        }
        Clipboard.SetText(path);
        MessageBox.Show($"Salvo com sucesso em: {path} {Environment.NewLine} O Caminho do script está na área de transferência.");
        //Process.Start("explorer.exe", path);
        //Clipboard.SetText(Convert.ToString(script));
      }

    }

    private void btnExcluirDadosGrid_Click(object sender, EventArgs e)
    {
      dgvGdicGcampos.DataSource = null;
      gCamposGdic.Clear();
      // CarregaColunasDataGridGCamposGdic();
    }

    private void CarregaColunasDataGridGCamposGdic()
    {
      //dgvGDefCompl.AutoGenerateColumns = false;
      dgvGdicGcampos.Columns.Add("Tabela Principal", "Tabela Principal");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Tabela", "Tabela");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Coluna", "Coluna");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Descrição", "Descrição");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Relatório", "Relatório");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Aplicações", "Aplicações");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Sql", "Sql");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Oracle", "Oracle");//Acrescenta colunas
    }

    #endregion GCamposGdic

    #region GDefCompel
    private void btGDefIncluir_Click(object sender, EventArgs e)
    {
      try
      {
        StringBuilder builder = new StringBuilder();
        if (ValidaCamposPreenchidosGDef(out builder))
        {
          throw new Exception(Convert.ToString(builder));
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message,"Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        return;
      }
      gDefCompl.Add(GetDadosGDefCompl());

      dgvGDefCompl.AutoGenerateColumns = true;
      dgvGDefCompl.DataSource = new BindingList<GDefCompl>(gDefCompl.ToList());
      dgvGDefCompl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
      //LimparGDefCompl();
    }

    private bool ValidaCamposPreenchidosGDef(out StringBuilder builder)
    {
      builder = new StringBuilder();
      bool erro = false;
      /*
      if (String.IsNullOrEmpty(txtGDefColigada.Text))
      {
        erro = true;
        builder.Append("");
      }
      */
      if (String.IsNullOrEmpty(txtGdefAplicacao.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Aplicação.");
      }

      if (String.IsNullOrEmpty(txtGDefTabelaDados.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Tabela Dados.");
      }

      if (String.IsNullOrEmpty(txtGDefNomeColuna.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Nome Coluna.");
      }

      if (String.IsNullOrEmpty(txtGDefDescricao.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Descrição.");
      }
      /*
      if (String.IsNullOrEmpty(txtGDefCodigoTabelaDinamica.Text))
      {
        erro = true;
        builder.Append("");
      }

      if (String.IsNullOrEmpty(txtGDefCodigoFormula.Text))
      {
        erro = true;
        builder.Append("");
      }
      
      if (String.IsNullOrEmpty(txtGdefValorDefault.Text))
      {
        erro = true;
        builder.Append("");
      }
      */
      if (String.IsNullOrEmpty(txtGDefCodigoColigadaTabelaDinamica.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Codigo Coligada Tabela Dinâmica.");
      }

      if (String.IsNullOrEmpty(txtGDefAplicacaoTabelaDinamica.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Aplicação tabela Dinamica.");
      }

      if (String.IsNullOrEmpty(txtGdefOrdem.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Ordem.");
      }
      /*     
      if (String.IsNullOrEmpty(txtGdefCodigoColigadaFormula.Text))
      {
        erro = true;
        builder.Append("");
      }

      if (String.IsNullOrEmpty(txtGDefCodApliFormula.Text))
      {
        erro = true;
        builder.Append("");
      }
      */
      if (String.IsNullOrEmpty(txtGDefTamanhoColuna.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Tamanho Coluna.");
      }

      return erro;
    }

    private void btGDefExcluir_Click(object sender, EventArgs e)
    {
      if (dgvGDefCompl.SelectedRows.Count == 0)
      {
        MessageBox.Show("Nenhum registro selecionado", "Atenção");
        return;
      }
      else
      {
        int indice = dgvGDefCompl.CurrentRow.Index;
        if (dgvGDefCompl.Rows[indice].Cells[indice].Value.ToString() != null)
        {
          if (indice != 0)
          {
            dgvGDefCompl.Rows.RemoveAt(dgvGDefCompl.Rows[indice].Index);
            gDefCompl.RemoveAt(dgvGDefCompl.Rows[indice].Index);
          }
        }
      }
    }

    private void btGDefLimpar_Click(object sender, EventArgs e)
    {
      LimparGDefCompl();
    }

    private void btnGDefExcluirDadosGrid_Click(object sender, EventArgs e)
    {
      dgvGDefCompl.DataSource = null;
      gDefCompl.Clear();
    }
    #endregion GDefCompel

    #region  Métodos privados GDEFCOMPL
    private void LimparGDefCompl()
    {
      txtGDefTamanhoColuna.Text = String.Empty;
      txtGdefAplicacao.Text = String.Empty;
      txtGDefTabelaDados.Text = String.Empty;
      txtGDefNomeColuna.Text = String.Empty;
      txtDescricao.Text = String.Empty;
      txtGDefCodigoTabelaDinamica.Text = String.Empty;
      txtGDefCodigoFormula.Text = String.Empty;
      txtGdefValorDefault.Text = String.Empty;
      txtGDefCodigoColigadaTabelaDinamica.Text = String.Empty;
      txtGDefAplicacaoTabelaDinamica.Text = String.Empty;
      chkBGdefQuebraLinha.Checked = false;
      chkBoxGDefPesqTabDinamCod.Checked = false;
      txtGdefCodigoColigadaFormula.Text = String.Empty;
      txtGDefCodApliFormula.Text = String.Empty;
      txtGDefTamanhoColuna.Text = String.Empty;
    }

    private GDefCompl GetDadosGDefCompl()
    {
      GDefCompl gDefCompl = new GDefCompl();

      gDefCompl.TamanhoColuna = Convert.ToInt32(txtGDefTamanhoColuna.Text);
      gDefCompl.Aplicacao = txtGdefAplicacao.Text;
      gDefCompl.TabelaDados = txtGDefTabelaDados.Text;
      gDefCompl.NomeColuna = txtGDefNomeColuna.Text;
      gDefCompl.Descricao = txtGDefDescricao.Text;
      gDefCompl.CodTabelaDinamica = txtGDefCodigoTabelaDinamica.Text;
      gDefCompl.Codformula = txtGDefCodigoFormula.Text;
      gDefCompl.ValorDefault = txtGdefValorDefault.Text;
      gDefCompl.CodColigadaTabelaDinamica = Convert.ToInt32(txtGDefCodigoColigadaTabelaDinamica.Text);
      gDefCompl.AplicacaoTabelaDinamica = txtGDefAplicacaoTabelaDinamica.Text;
      gDefCompl.Ordem = Convert.ToInt32(txtGdefOrdem.Text);
      gDefCompl.QuebraLinha = (chkBGdefQuebraLinha.Checked) ? "T" : "F";
      gDefCompl.PesquisaTabelaDinamicaPorCodigo = (chkBoxGDefPesqTabDinamCod.Checked) ? "T" : "F";
      gDefCompl.CodColigadaFormula = Convert.ToInt32(txtGdefCodigoColigadaFormula.Text);
      gDefCompl.CodigoAplicacaoFormula = txtGDefCodApliFormula.Text;
      gDefCompl.TipoTexto = txtGDefTamanhoColuna.Text;

      return gDefCompl;
    }

    private void CarregaColunasDataGridGDefCompl()
    {
      //dgvGDefCompl.AutoGenerateColumns = false;
      dgvGdicGcampos.Columns.Add("Coligada", "Coligada");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Aplicação", "Aplicação");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Tabela De Dados", "Tabela De Dados");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Nome Coluna", "Nome Coluna");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Descrição", "Descrição");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Cod. Tab. Dinâmica", "Cod. Tab. Dinâmica");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Aplicação Tab. dinâmica", "Aplicação Tab. dinâmica");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Ordem", "Ordem");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Quebra Linha", "Quebra Linha");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Oracle", "Oracle");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Pesq. Tab. Dinâm. Por Código", "Pesq. Tab. Dinâm. Por Código");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Cod. Coligada Fórmula", "Cod. Coligada Formúla");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Cod. Aplicação Fórmula", "Cod. Aplicação Formúla");//Acrescenta colunas
      dgvGdicGcampos.Columns.Add("Tipo Texto", "Tipo Texto");//Acrescenta colunas
    }
    #endregion   Métodos privados GDEFCOMPL


    #region métodos privados GCampos
    private GCamposGDic GetDadosGcamposGic()
    {
      var tabela = string.Empty;

      GCamposGDic gGCamposGDic = new GCamposGDic();
      if (chkGDic.Checked == true)
        tabela = "GDIC";
      if (chkGDic.Checked == true)
        tabela = "GCAMPOS";

      gGCamposGDic.TabelaPrincipal = tabela;
      gGCamposGDic.Tabela = txtTabela.Text;
      gGCamposGDic.Coluna = txtColuna.Text;
      gGCamposGDic.Descricao = txtDescricao.Text;
      gGCamposGDic.Relatorio = chbRelatorio.Checked;
      gGCamposGDic.Aplicacoes = txtAplicacao.Text;

      return gGCamposGDic;
    }

    private bool ValidaCamposPreenchidosGCampos(out StringBuilder builder)
    {
      builder = new StringBuilder();
      bool erro = true;

      if (chkGDic.Checked == false & chkGampos.Checked == false)
      {
        erro = false;
        builder.AppendLine("Infome uma Tabela Princial do insert.");
      }
      if (chkGDic.Checked == true & chkGampos.Checked == true)
      {
        erro = false;
        builder.AppendLine("Infome apenas uma Tabela Princial do insert.");
      }
      if (String.IsNullOrEmpty(txtTabela.Text))
      {
        erro = false;
        builder.AppendLine("Informe o campo tabela");
      }

      if (String.IsNullOrEmpty(txtColuna.Text))
      {
        erro = false;
        builder.AppendLine("Informe campo Coluna");
      }

      if (String.IsNullOrEmpty(txtDescricao.Text))
      {
        erro = false;
        builder.AppendLine("Informe o Campo descrição");
      }

      if (String.IsNullOrEmpty(txtAplicacao.Text))
      {
        erro = false;
        builder.AppendLine("Informe o campo aplicações");

      }
      else
      {
        //http://www.macoratti.net/11/09/c_str1.htm
      }

      return erro;
    }

    private void LimparGCamposGDic()
    {
      chkGDic.Checked = false;
      chkGampos.Checked = false;
      txtTabela.Text = String.Empty;
      txtColuna.Text = String.Empty;
      txtDescricao.Text = String.Empty;
      chbRelatorio.Checked = false;
      txtAplicacao.Text = String.Empty;
     
    }

    #endregion métodos privados GCampos


    private void btnSair_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void btnSalvarScript_Click(object sender, EventArgs e)
    {
      SaveScript save = new SaveScript();
      //validar datagrid tem uma linha ou mais

      try
      {
        StringBuilder builder = new StringBuilder();
        if (verificaSalvarScript(out builder))
          throw new Exception(Convert.ToString(builder));

        if (dgvGdicGcampos.RowCount >= 1)
        {
          if (chbSql.Checked)
          {
            Salvar(save, true);
          }

          if (chbOracle.Checked)
          {
            Salvar(save, false);
          }
        }
        else
        {
          throw new Exception("Cadastre um regstro para poder gerar o script");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        return;
      }
    }

    private bool verificaSalvarScript(out StringBuilder builder)
    {
      builder = new StringBuilder();

      bool erro = false;

      if (String.IsNullOrEmpty(txtNomeProjeto.Text))
      {
        erro = true;
        builder.AppendLine("Infome o nome do projeto.");
      }
      if (chbSql.Checked == false & chbOracle.Checked == false)
      {
        erro = true;
        builder.AppendLine("Informe qual script sera gerado o script");
      }
      return erro;
    }
  }
}
