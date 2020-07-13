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
  public partial class Script : Form
  {
    CollectionsGCamposGDic gCamposGdic = new CollectionsGCamposGDic();
    CollectionsGDefCompl gDefCompl = new CollectionsGDefCompl();

    public Script()
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
        if (!ValidaCamposPreenchidosTabUm(out builder))
        {
          throw new Exception(Convert.ToString(builder));
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
        return;
      }
      gCamposGdic.Add(GetDadosGcamposGic());

      dgvGdicGcampos.AutoGenerateColumns = true;
      dgvGdicGcampos.DataSource = new BindingList<GCamposGDic>(gCamposGdic.ToList());
      dgvGdicGcampos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
      LimparCampos();
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
      LimparCampos();
    }

    private void btnSalvarScript_Click(object sender, EventArgs e)
    {
      SaveScript save = new SaveScript();
      //validar datagrid tem uma linha ou mais
      try
      {
        if (dgvGdicGcampos.RowCount >= 1)
        {
          if (gCamposGdic.Any(c => c.IsSql))
            Salvar(save, true);
          if (gCamposGdic.Any(c => c.IsOracle))
            Salvar(save, false);
        }
        else
        {
          throw new Exception("Cadastre um regstro para poder gerar o script");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message + ex.StackTrace);
        return;
      }
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
        StringBuilder script = new StringBuilder();// project.ScriptCreator.generateGLinksRelsAndGCampos();

        //verifica se salva sql ou oracle
        if (sql == true)
        {
          saveScript.SalvarScriptSQL(path, script, gCamposGdic);
        }
        else
        {
          saveScript.SalvarScriptOracle(path, script, gCamposGdic);
        }

        MessageBox.Show("Salvo com Sucesso em: \n" + path);
        //Process.Start("explorer.exe", path);
        //Clipboard.SetText(Convert.ToString(script));
      }

    }

    private void btnExcluirDadosGrid_Click(object sender, EventArgs e)
    {
      dgvGdicGcampos.DataSource = null;
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

    #region GDef
    private void btGDefIncluir_Click(object sender, EventArgs e)
    {
      
    }

    private void btGDefExcluir_Click(object sender, EventArgs e)
    {

    }

    private void btGDefLimpar_Click(object sender, EventArgs e)
    {

    }

    private void btnGDefExcluirDadosGrid_Click(object sender, EventArgs e)
    {

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
    #endregion  GDef

    private void btnSair_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

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
      gGCamposGDic.Apicacoes = txtAplicacao.Text;
      gGCamposGDic.IsSql = chbSql.Checked;
      gGCamposGDic.IsOracle = chbOracle.Checked;

      return gGCamposGDic;
    }

    private bool ValidaCamposPreenchidosTabUm(out StringBuilder builder)
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

      if (chbSql.Checked == false & chbOracle.Checked == false)
      {
        erro = false;
        builder.AppendLine("Informe qual script sera gerado");
      }

      return erro;
    }

    private void LimparCampos()
    {
      chkGDic.Checked = false;
      chkGampos.Checked = false;
      txtTabela.Text = String.Empty;
      txtColuna.Text = String.Empty;
      txtDescricao.Text = String.Empty;
      chbRelatorio.Checked = false;
      txtAplicacao.Text = String.Empty;
      chbSql.Checked = false;
      chbOracle.Checked = false;

    }

    #endregion métodos privados GCampos

  }
}
