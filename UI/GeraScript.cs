using BLL;
using DTO;
using GeraScript;
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
  public partial class FormScript : Form
  {
    #region Objetos GDIC e GDEFCOMPL

    CollectionsGDic gdic = new CollectionsGDic();
    CollectionsGDefCompl gDefCompl = new CollectionsGDefCompl();
    int idGDic = 0;
    CrudEnum operacao = CrudEnum.Inserir;

    #endregion Objetos GDIC e GDEFCOMPL

    #region Construtor
    public FormScript()
    {
      InitializeComponent();
    }
    #endregion Construtor

    #region GDIC Métodos e eventos

    #region Eventos GDIC

    private void btnInserirDadosGDic_Click(object sender, EventArgs e)
    {
      try
      {
        StringBuilder builder = new StringBuilder();
        if (!ValidaCamposPreenchidosGDic(out builder))
        {
          switch (operacao)
          {
            case CrudEnum.Inserir:
              gdic.Add(GetDadosGDic(CrudEnum.Inserir));

              break;
            case CrudEnum.Editar:
              Atualizar(gdic, GetDadosGDic(CrudEnum.Editar), idGDic);
              operacao = CrudEnum.Inserir;
              break;
          }
          btnInserirDadosGdic.Text = CrudEnum.Inserir.ToString();
          AlimentaGridViewGDic(gdic);
          LimparGDic(1);
          CongelarCampoTabela();
        }
        else
        {
          throw new Exception(Convert.ToString(builder));
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, DTO.Properties.Resources.GSAviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }
    }

    private void btnGcamposGDicExcluir_Click(object sender, EventArgs e)
    {
      if (dgvGdic.SelectedRows.Count == 0)
      {
        MessageBox.Show(DTO.Properties.Resources.GSNenhumRegistroSelecionado, DTO.Properties.Resources.GSAtencao);
        return;
      }
      else
      {
        int indice = dgvGdic.CurrentRow.Index;
        if (dgvGdic.Rows[indice].Cells[indice].Value.ToString() != null)
        {
          gdic.RemoveAt(indice);
          AlimentaGridViewGDic(gdic);
        }
        if (VerificaGridView(dgvGdic))
        {
          DescongelaCampoTabela();
          LimparGDic();
        }
      }
    }

    private void btlGCamposGdicLimparCampos_Click(object sender, EventArgs e)
    {
      if (dgvGdic.Rows.Count < 0)
      {
        LimparGDic();
      }
      else
      {
        LimparGDic(1);
        CongelarCampoTabela();
      }
    }

    private void btnExcluirDadosGrid_Click(object sender, EventArgs e)
    {
      if (dgvGdic.RowCount == 0)
      {
        MessageBox.Show(DTO.Properties.Resources.GSNaoEhPossivelExcluirDadosGrid, DTO.Properties.Resources.GSAviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }

      gdic = new CollectionsGDic();
      dgvGdic.DataSource = null;
      gdic.Clear();
      txtGdicTabela.Enabled = true;
      LimparGDic();
    }

    private void btnVisualizarScriptGDic_Click(object sender, EventArgs e)
    {
      StringBuilder teste = new StringBuilder();

      FormVisualizar formVisualizar = new FormVisualizar(teste);
      formVisualizar.Show();
    }

    private void btnGdicCancelar_Click(object sender, EventArgs e)
    {
      LimparGDic();
    }

    private void dgvGdic_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      idGDic = 0;
      DataGridViewRow row = dgvGdic.CurrentRow;
     
      idGDic = dgvGdic.CurrentRow.Index + 1;
      if (idGDic >= 0)
      {
        txtGdicColuna.Text = Convert.ToString(dgvGdic.Rows[row.Index].Cells[2].Value);
        txtGdicDescricao.Text = Convert.ToString(dgvGdic.Rows[row.Index].Cells[3].Value);
        chbGdicRelatorio.Checked = Convert.ToBoolean(dgvGdic.Rows[row.Index].Cells[4].Value);
        txtGdicAplicacao.Text = Convert.ToString(dgvGdic.Rows[row.Index].Cells[5].Value);
        CongelarCampos();
      }
      else
      {
        MessageBox.Show(DTO.Properties.Resources.GSnsiraRegistroGrid, DTO.Properties.Resources.GSAviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    #endregion Eventos GDIC

    #region Métodos GDIC
    private void Atualizar(CollectionsGDic gDic, GDic gdic, int id)
    {
      foreach (var item in gDic)
      {
        if (item.id == id)
        {
          item.Tabela = txtGdicTabela.Text.ToUpper();
          item.Coluna = txtGdicColuna.Text.ToUpper();
          item.Descricao = txtGdicDescricao.Text;
          item.Relatorio = chbGdicRelatorio.Checked;
          item.Aplicacoes = txtGdicAplicacao.Text.ToUpper();
        }
      }
    }

    private void CongelarCampoTabela()
    {
      txtGdicTabela.Enabled = false;
    }

    private void CongelarCampos()
    {
      txtGdicColuna.Enabled = false;
      txtGdicDescricao.Enabled = false;
      chbGdicRelatorio.Enabled = false;
      txtGdicAplicacao.Enabled = false;
    }

    private void DescongelaCampos()
    {
      txtGdicColuna.Enabled = true;
      txtGdicDescricao.Enabled = true;
      chbGdicRelatorio.Enabled = true;
      txtGdicAplicacao.Enabled = true;
    }

    private string ManipulaNomeArquivo(string fileName, bool sqlOracle)
    {
      var banco = (sqlOracle) ? "_MSSQL.sql" : "_ORACLE.sql";
      return fileName.Replace(".sql", banco);
    }

    private void DescongelaCampoTabela()
    {
      txtGdicTabela.Enabled = true;
      txtGdicTabela.Text = String.Empty;
    }

    private void AlimentaGridViewGDic(CollectionsGDic gdic)
    {
      dgvGdic.DataSource = null;
      dgvGdic.AutoGenerateColumns = true;
      dgvGdic.DataSource = new BindingList<GDic>(gdic.ToList());
      dgvGdic.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
    }

    private bool VerificaGridView(DataGridView dgv)
    {
      if (dgv.CurrentRow == null)
      {
        return true;
      }
      return false;
    }

    private void CarregaColunasDataGridGDic()
    {
      dgvGdic.AutoGenerateColumns = true;
      dgvGdic.Columns.Add("tabela", "Tabela");//Acrescenta colunas
                                              // dgvGdic.Columns[0].Width= 200;//Acrescenta colunas

      dgvGdic.Columns.Add("coluna", "Coluna");//Acrescenta colunas
                                              // dgvGdic.Columns[1].Width = 200;

      dgvGdic.Columns.Add("descricao", "Descrição");//Acrescenta colunas
                                                    //  dgvGdic.Columns[2].Width = 200;

      dgvGdic.Columns.Add("relatório", "Relatório");//Acrescenta colunas
      //dgvGdic.Columns[3].Width = 60;

      dgvGdic.Columns.Add("aplicacooes", "Aplicações");//Acrescenta colunas
                                                       // dgvGdic.Columns[0].Width = 100;

    }

    private void LimparGDic(int flag = 0)
    {
      if (flag == 0)
      {
        txtGdicTabela.Text = String.Empty;
      }
      txtGdicColuna.Text = String.Empty;
      txtGdicDescricao.Text = String.Empty;
      chbGdicRelatorio.Checked = false;
      txtGdicAplicacao.Text = String.Empty;
    }

    private GDic GetDadosGDic(CrudEnum crud)
    {
      GDic gDic = new GDic();
      if (crud == CrudEnum.Inserir)
      {
        gDic.id = gdic.Count() + 1;
      }

      if (crud == CrudEnum.Editar)
      {
        gDic.id = idGDic;
      }

      gDic.Tabela = txtGdicTabela.Text.ToUpper();
      gDic.Coluna = txtGdicColuna.Text.ToUpper();
      gDic.Descricao = txtGdicDescricao.Text;
      gDic.Relatorio = chbGdicRelatorio.Checked;
      gDic.Aplicacoes = txtGdicAplicacao.Text.ToUpper();

      return gDic;
    }

    private bool ValidaCamposPreenchidosGDic(out StringBuilder builder)
    {
      builder = new StringBuilder();
      bool erro = false;

      if (String.IsNullOrEmpty(txtGdicTabela.Text) || String.IsNullOrWhiteSpace(txtGdicTabela.Text))
      {
        erro = true;
        builder.AppendLine("Informe o campo tabela");
      }

      if (String.IsNullOrEmpty(txtGdicColuna.Text) || String.IsNullOrWhiteSpace(txtGdicColuna.Text))
      {
        erro = true;
        builder.AppendLine("Informe campo Coluna");
      }
      if (VerificarAplicacaoGDic(txtGdicAplicacao.Text))
      {
        erro = true;
        builder.AppendLine("O campo Aplicação. Deve ter o caracter ';' após cada letra, e  não deve ser finalizado com o mesmo caracter. \n\nEx: S;A;D  ");
      }

      return erro;
    }

    private void button2_Click(object sender, EventArgs e)
    {
      DescongelaCampos();
      btnInserirDadosGdic.Text = DTO.Properties.Resources.GSAtualizar;
      operacao = CrudEnum.Editar;
    }

    #endregion Métodos GDIC

    #endregion Gdic Métodos e eventos

    #region GDEFCOMPEL Métodos e eventos

    #region Eventos GDEFCOMPEL

    private void btGDefIncluirGDefCompl_Click(object sender, EventArgs e)
    {
      try
      {
        StringBuilder builder = new StringBuilder();
        if (!ValidaCamposPreenchidosGDef(out builder))
        {
          var gdef = GetDadosGDefCompl();
          
          gDefCompl.Add(gdef);

          dgvGDefCompl.AutoGenerateColumns = true;
          dgvGDefCompl.DataSource = new BindingList<GDefCompl>(gDefCompl.ToList());
          dgvGDefCompl.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
         
        }
        throw new Exception(Convert.ToString(builder));
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, DTO.Properties.Resources.GSAviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

    }

    private void btGDefExcluir_Click(object sender, EventArgs e)
    {
      if (dgvGDefCompl.SelectedRows.Count == 0)
      {
        MessageBox.Show(DTO.Properties.Resources.GSNenhumRegistroSelecionado, DTO.Properties.Resources.GSAtencao);
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

    private void btnVisualizarScriptGDefCompl_Click(object sender, EventArgs e)
    {

    }

    #endregion Eventos GDEFCOMPEL

    #region Métodos GDEFCOMPEL

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

      return erro;
    }

    private bool VerificarAplicacaoGDic(string aplicacao)
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

    private void LimparGDefCompl()
    {
      txtGDefTamanhoColuna.Text = String.Empty;
      txtGdefAplicacao.Text = String.Empty;
      txtGDefTabelaDados.Text = String.Empty;
      txtGDefNomeColuna.Text = String.Empty;
      txtGdicDescricao.Text = String.Empty;
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
      gDefCompl.TipoTexto = txtGDefTamanhoColuna.Text.ToUpper();

      return gDefCompl;
    }

    private void CarregaColunasDataGridGDefCompl()
    {

      dgvGdic.Columns[0].HeaderText = "Coligada";//Acrescenta colunas
      dgvGdic.Columns[0].Width = 10;

      dgvGdic.Columns[1].HeaderText = "Aplicação";//Acrescenta colunas
      dgvGdic.Columns[1].Width = 20;

      dgvGdic.Columns[2].HeaderText = "Tabela De Dados";//Acrescenta colunas
      dgvGdic.Columns[2].Width = 50;

      dgvGdic.Columns[3].HeaderText = "Nome Coluna";//Acrescenta colunas
      dgvGdic.Columns[3].Width = 50;

      dgvGdic.Columns[4].HeaderText = "Descrição";//Acrescenta colunas
      dgvGdic.Columns[4].Width = 75;

      dgvGdic.Columns[5].HeaderText = "Cod. Tab. Dinâmica";//Acrescenta colunas
      dgvGdic.Columns[5].Width = 50;

      dgvGdic.Columns[6].HeaderText = "Aplicação Tab. dinâmica";//Acrescenta colunas
      dgvGdic.Columns[6].Width = 50;

      dgvGdic.Columns[7].HeaderText = "Ordem";//Acrescenta colunas
      dgvGdic.Columns[7].Width = 50;

      dgvGdic.Columns[8].HeaderText = "Quebra Linha";//Acrescenta colunas
      dgvGdic.Columns[8].Width = 50;

      dgvGdic.Columns[9].HeaderText = "Oracle";//Acrescenta colunas
      dgvGdic.Columns[9].Width = 50;

      dgvGdic.Columns[10].HeaderText = "Pesq. Tab. Dinâm. Por Código";//Acrescenta colunas
      dgvGdic.Columns[10].Width = 50;

      dgvGdic.Columns[11].HeaderText = "Cod. Coligada Fórmula";//Acrescenta colunas
      dgvGdic.Columns[11].Width = 50;

      dgvGdic.Columns[12].HeaderText = "Cod. Aplicação Fórmula";//Acrescenta colunas
      dgvGdic.Columns[12].Width = 50;

      dgvGdic.Columns[13].HeaderText = "Tipo Texto";//Acrescenta colunas
      dgvGdic.Columns[13].Width = 50;
    }

    #endregion Métodos GDEFCOMPEL

    #endregion GDEFCOMPEL Métodos e eventos

    #region MenuItem
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

    #endregion MenuItem

    #region Métodos e Eventos Tela Principal

    #region Eventos Tela Principal

    private void btnSalvarScript_Click(object sender, EventArgs e)
    {
      SaveScript save = new SaveScript();
      //validar datagrid tem uma linha ou mais

      try
      {
        StringBuilder builder = new StringBuilder();
        if (verificaSalvarScript(out builder))
          throw new Exception(Convert.ToString(builder));

        if (dgvGdic.RowCount >= 1)
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
          throw new Exception(DTO.Properties.Resources.GSCadastreRegistroGerarScript);
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

    #endregion Eventos Tela Principal

    private DadosPorjeto GetDadosPorjeto()
    {
      DadosPorjeto dadosPorjeto = new DadosPorjeto();
      dadosPorjeto.Nome = txtNomeProjeto.Text;
      dadosPorjeto.CodProjeto = txtCodProj.Text;
      dadosPorjeto.tipoCliente = Convert.ToString(cbTipoCliente.SelectedItem);
      return dadosPorjeto;
    }

    #region Metodos Tela Principal

    private void btnSair_Click(object sender, EventArgs e)
    {
      Application.Exit();
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
          saveScript.SalvarScriptSQL(path, GetDadosPorjeto(), gDefCompl, gdic);
        }
        else
        {
          path = ManipulaNomeArquivo(saveFileDialog1.FileName, sql);
          saveScript.SalvarScriptOracle(path, GetDadosPorjeto(), gDefCompl, gdic);
        }
        Clipboard.SetText(path);
        MessageBox.Show($"Salvo com sucesso em: {path} {Environment.NewLine} O Caminho do script está na área de transferência.");
      }
    }

    #endregion Metodos Tela Principal

    #endregion Métodos e Eventos Tela Principal

    private void button1_Click(object sender, EventArgs e)
    {
      StringBuilder s = new StringBuilder();
      s.AppendLine("aaaaaaaaaaaaaaaaaaaaaaaaaa");
      s.AppendLine("aaaaaaaaaaaaaaaaaaaaaaaaaaDDDDDD");
      s.AppendLine("aaaaaaaaaaaaaaaaaaaaaaaaaaFFFFF");
      s.AppendLine("aaaaaaaaaaaaaaaaaaaaaaaaaaVVVVV");
      textBox2.Text = s.ToString();

    }

  }
}