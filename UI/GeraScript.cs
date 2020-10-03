using BLL;
using DTO;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        if (ValidaCamposPreenchidos(out builder))
        {
          throw new Exception(Convert.ToString(builder));
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }
      gCamposGdic.Add(GetDadosGcamposGic());

      dgvGdicGcampos.AutoGenerateColumns = true;
      dgvGdicGcampos.DataSource = new BindingList<GCamposGDic>(gCamposGdic.ToList());
      dgvGdicGcampos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
      LimparGCamposGDic(1);
      CongelarCampos();
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
          dgvGdicGcampos.Rows.RemoveAt(dgvGdicGcampos.Rows[indice].Index);
          gCamposGdic.RemoveAt(dgvGdicGcampos.Rows[indice].Index);
        }
        if (VerificaGridView(dgvGdicGcampos))
        {
          DescongelaCampos();
        }
      }
    }

    private void DescongelaCampos()
    {
      rbGCampos.Enabled = true;
      rbGDic.Enabled = true;
      rbGDic.Checked = false;
      rbGCampos.Checked = false;
      txtTabela.Enabled = true;
      txtTabela.Text = String.Empty;
    }

    private bool VerificaGridView(DataGridView dgv)
    {
      if (dgv.CurrentRow == null)
      {
        return true;
      }
      return false;
    }

    private void btlGCamposGdicLimparCampos_Click(object sender, EventArgs e)
    {
      if (dgvGdicGcampos.Rows.Count < 0)
      {
        LimparGCamposGDic();
      }
      else
      {
        LimparGCamposGDic(1);
        CongelarCampos();
      }
    }

    private void CongelarCampos()
    {
      rbGCampos.Enabled = false;
      rbGDic.Enabled = false;
      txtTabela.Enabled = false;
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
        String path = String.Empty;
        //verifica se salva sql ou oracle
        if (sql == true)
        {
          path = ManipulaNomeArquivo(saveFileDialog1.FileName, sql);
          saveScript.SalvarScriptSQL(path, gDefCompl, gCamposGdic);
        }
        else
        {
          path = ManipulaNomeArquivo(saveFileDialog1.FileName, sql);
          saveScript.SalvarScriptOracle(path, gDefCompl, gCamposGdic);
        }
        Clipboard.SetText(path);
        MessageBox.Show($"Salvo com sucesso em: {path} {Environment.NewLine} O Caminho do script está na área de transferência.");
        //Process.Start("explorer.exe", path);

      }

    }

    private string ManipulaNomeArquivo(string fileName, bool sqlOracle)
    {
      var banco = (sqlOracle) ? "_MSSQL.sql" : "_ORACLE.sql";
      return fileName.Replace(".sql", banco);
    }

    private void btnExcluirDadosGrid_Click(object sender, EventArgs e)
    {
      dgvGdicGcampos.DataSource = null;
      gCamposGdic.Clear();
      rbGCampos.Enabled = true;
      rbGDic.Enabled = true;
      txtTabela.Enabled = true;
      LimparGCamposGDic();
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
      //dgvGdicGcampos.Columns.Add("Sql", "Sql");//Acrescenta colunas
      //dgvGdicGcampos.Columns.Add("Oracle", "Oracle");//Acrescenta colunas
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
        MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

      if (String.IsNullOrEmpty(txtGdefAplicacao.Text) || String.IsNullOrWhiteSpace(txtGdefAplicacao.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Aplicação.");
      }

      if (String.IsNullOrEmpty(txtGDefTabelaDados.Text) || String.IsNullOrWhiteSpace(txtGDefTabelaDados.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Tabela Dados.");
      }

      if (String.IsNullOrEmpty(txtGDefNomeColuna.Text) || String.IsNullOrWhiteSpace(txtGDefNomeColuna.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Nome Coluna.");
      }

      if (String.IsNullOrEmpty(txtGDefDescricao.Text) || String.IsNullOrWhiteSpace(txtGDefDescricao.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Descrição.");
      }

      if (String.IsNullOrEmpty(txtGDefCodigoColigadaTabelaDinamica.Text) || String.IsNullOrWhiteSpace(txtGDefCodigoColigadaTabelaDinamica.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Codigo Coligada Tabela Dinâmica.");
      }

      if (String.IsNullOrEmpty(txtGDefAplicacaoTabelaDinamica.Text) || String.IsNullOrWhiteSpace(txtGDefAplicacaoTabelaDinamica.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Aplicação tabela Dinamica.");
      }

      if (String.IsNullOrEmpty(txtGdefOrdem.Text) || String.IsNullOrWhiteSpace(txtGdefOrdem.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Ordem.");
      }

      if (String.IsNullOrEmpty(txtGDefTamanhoColuna.Text) || String.IsNullOrWhiteSpace(txtGDefTamanhoColuna.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo Tamanho Coluna.");
      }

      #region validações excluidas
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
    
     if (String.IsNullOrEmpty(txtGDefColigada.Text))
     {
       erro = true;
       builder.Append("");
     }
     */
      #endregion validações excluidas

      return erro;
    }

    private bool VerificarAplicacaoGCampos(string aplicacao)
    {
      return VerificarAplicacao(aplicacao);
    }

    private bool VerificarAplicacao(string aplicacao)
    {
      if (aplicacao.EndsWith(";"))
      {
        return true;
      }
      return false;
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
          dgvGDefCompl.Rows.RemoveAt(dgvGDefCompl.Rows[indice].Index);
          gDefCompl.RemoveAt(dgvGDefCompl.Rows[indice].Index);
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
      gDefCompl.Aplicacao = txtGdefAplicacao.Text.ToUpper();
      gDefCompl.TabelaDados = txtGDefTabelaDados.Text.ToUpper();
      gDefCompl.NomeColuna = txtGDefNomeColuna.Text.ToUpper();
      gDefCompl.Descricao = txtGDefDescricao.Text.ToUpper();
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
      gDefCompl.TipoTexto = txtGDefTamanhoColuna.Text.ToUpper();

      return gDefCompl;
    }

    private void CarregaColunasDataGridGDefCompl()
    {
      //dgvGDefCompl.AutoGenerateColumnsHeaderText= false;
      dgvGdicGcampos.Columns[0].HeaderText = "Coligada";//Acrescenta colunas
      dgvGdicGcampos.Columns[1].HeaderText = "Aplicação";//Acrescenta colunas
      dgvGdicGcampos.Columns[2].HeaderText = "Tabela De Dados";//Acrescenta colunas
      dgvGdicGcampos.Columns[3].HeaderText = "Nome Coluna";//Acrescenta colunas
      dgvGdicGcampos.Columns[4].HeaderText = "Descrição";//Acrescenta colunas
      dgvGdicGcampos.Columns[5].HeaderText = "Cod. Tab. Dinâmica";//Acrescenta colunas
      dgvGdicGcampos.Columns[6].HeaderText = "Aplicação Tab. dinâmica";//Acrescenta colunas
      dgvGdicGcampos.Columns[7].HeaderText = "Ordem";//Acrescenta colunas
      dgvGdicGcampos.Columns[8].HeaderText = "Quebra Linha";//Acrescenta colunas
      dgvGdicGcampos.Columns[9].HeaderText = "Oracle";//Acrescenta colunas
      dgvGdicGcampos.Columns[10].HeaderText = "Pesq. Tab. Dinâm. Por Código";//Acrescenta colunas
      dgvGdicGcampos.Columns[11].HeaderText = "Cod. Coligada Fórmula";//Acrescenta colunas
      dgvGdicGcampos.Columns[12].HeaderText = "Cod. Aplicação Fórmula";//Acrescenta colunas
      dgvGdicGcampos.Columns[13].HeaderText = "Tipo Texto";//Acrescenta colunas
    }
    #endregion   Métodos privados GDEFCOMPL

    #region métodos privados GCampos
    private GCamposGDic GetDadosGcamposGic()
    {
      var tabela = string.Empty;

      GCamposGDic gGCamposGDic = new GCamposGDic();
      if (rbGDic.Checked == true)
        tabela = "GDIC";
      if (rbGCampos.Checked == true)
        tabela = "GCAMPOS";

      gGCamposGDic.TabelaPrincipal = tabela;
      gGCamposGDic.Tabela = txtTabela.Text.ToUpper();
      gGCamposGDic.Coluna = txtColuna.Text.ToUpper();
      gGCamposGDic.Descricao = txtDescricao.Text.ToUpper();
      gGCamposGDic.Relatorio = chbRelatorio.Checked;
      gGCamposGDic.Aplicacoes = txtAplicacao.Text.ToUpper();

      return gGCamposGDic;
    }

    private bool ValidaCamposPreenchidos(out StringBuilder builder)
    {
      builder = new StringBuilder();
      bool erro = false;

      if (rbGDic.Checked == false & rbGCampos.Checked == false)
      {
        erro = true;
        builder.AppendLine("Infome uma Tabela Princial do insert.");
      }
      if (rbGCampos.Checked == false & rbGDic.Checked == false)
      {
        erro = true;
        builder.AppendLine("Infome apenas uma Tabela Princial do insert.");
      }
      if (String.IsNullOrEmpty(txtTabela.Text) || String.IsNullOrWhiteSpace(txtTabela.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo tabela");
      }

      if (String.IsNullOrEmpty(txtColuna.Text) || String.IsNullOrWhiteSpace(txtColuna.Text))
      {
        erro = true;
        builder.AppendLine("Informe campo Coluna");
      }

      if (String.IsNullOrEmpty(txtDescricao.Text) || String.IsNullOrWhiteSpace(txtDescricao.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo descrição");
      }

      if (String.IsNullOrEmpty(txtAplicacao.Text) || String.IsNullOrWhiteSpace(txtAplicacao.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo aplicações");

      }
      if (VerificarAplicacaoGCampos(txtAplicacao.Text))
      {
        erro = true;
        builder.AppendLine("O campo Aplicação. Deve ter o caracter ';' após cada letra, e  não deve ser finalizado com o mesmo caracter. \n\nEx: S;A;D  ");
      }

      return erro;
    }

    private void LimparGCamposGDic(int flag = 0)
    {
      if (flag == 0)
      {
        rbGCampos.Checked = false;
        rbGDic.Checked = false;
        txtTabela.Text = String.Empty;
      }
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

    private void btnLimparNomeProjeto_Click(object sender, EventArgs e)
    {
      txtNomeProjeto.Text = String.Empty;
    }

    private void gDICToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDialog = new OpenFileDialog();
      fileDialog.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
      fileDialog.Title = "Abrir - Script GDIC/GCAMPOS";
      fileDialog.ShowDialog();
    }

    private void gDEFCOMPLToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog fileDialog = new OpenFileDialog();
      fileDialog.Filter = "sql files (*.sql)|*.sql|All files (*.*)|*.*";
      fileDialog.Title = "Abrir - Script GDEFCOMPL";
      if (fileDialog.ShowDialog() == DialogResult.OK)
      {
        var fileContent = string.Empty;
        var filePath = string.Empty;

        filePath = fileDialog.FileName;

        //Read the contents of the file into a stream
        var fileStream = fileDialog.OpenFile();

        using (StreamReader reader = new StreamReader(fileStream))
        {
          StringBuilder sb = new StringBuilder();
          while ((fileContent = reader.ReadLine()) != null)
          {
            sb.Append(fileContent);
          }

        }
      }

    }
  }
}