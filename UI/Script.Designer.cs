namespace UI
{
  partial class Script
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Script));
      this.txtNoeProjeto = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.dgvGdicGcampos = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.gbTabela = new System.Windows.Forms.GroupBox();
      this.chkGDic = new System.Windows.Forms.CheckBox();
      this.chkGampos = new System.Windows.Forms.CheckBox();
      this.btnGcamposGDicExcluir = new System.Windows.Forms.Button();
      this.btnExcluirDadosGrid = new System.Windows.Forms.Button();
      this.btnInserirDadosGCamposGdic = new System.Windows.Forms.Button();
      this.gbBancoDados = new System.Windows.Forms.GroupBox();
      this.chbSql = new System.Windows.Forms.CheckBox();
      this.chbOracle = new System.Windows.Forms.CheckBox();
      this.txtAplicacao = new System.Windows.Forms.TextBox();
      this.lblAplicacoes = new System.Windows.Forms.Label();
      this.txtTabela = new System.Windows.Forms.TextBox();
      this.btlGCamposGdicLimparCampos = new System.Windows.Forms.Button();
      this.chbRelatorio = new System.Windows.Forms.CheckBox();
      this.lblTabela = new System.Windows.Forms.Label();
      this.lblColuna = new System.Windows.Forms.Label();
      this.lblDescricao = new System.Windows.Forms.Label();
      this.txtColuna = new System.Windows.Forms.TextBox();
      this.txtDescricao = new System.Windows.Forms.TextBox();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.txtValorDefault = new System.Windows.Forms.Panel();
      this.txtTipoTexto = new System.Windows.Forms.TextBox();
      this.lblTipoTexto = new System.Windows.Forms.Label();
      this.btnGDefExcluirDadosGrid = new System.Windows.Forms.Button();
      this.btGDefIncluir = new System.Windows.Forms.Button();
      this.btGDefExcluir = new System.Windows.Forms.Button();
      this.textBox9 = new System.Windows.Forms.TextBox();
      this.lblOrdem = new System.Windows.Forms.Label();
      this.btGDefLimpar = new System.Windows.Forms.Button();
      this.lblCodColTabDinamica = new System.Windows.Forms.Label();
      this.lblCodTabDinamica = new System.Windows.Forms.Label();
      this.lblGdfDescricao = new System.Windows.Forms.Label();
      this.lblNomeColuna = new System.Windows.Forms.Label();
      this.lblDodTabDinamica = new System.Windows.Forms.Label();
      this.lblCodigoFormula = new System.Windows.Forms.Label();
      this.lblApliccaoTabDinamica = new System.Windows.Forms.Label();
      this.lblCodColFormula = new System.Windows.Forms.Label();
      this.lblTabDados = new System.Windows.Forms.Label();
      this.lblAplicacao = new System.Windows.Forms.Label();
      this.lblColigada = new System.Windows.Forms.Label();
      this.lblValorDefault = new System.Windows.Forms.Label();
      this.txtCodColTabDinamica = new System.Windows.Forms.TextBox();
      this.textBox13 = new System.Windows.Forms.TextBox();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.textBox5 = new System.Windows.Forms.TextBox();
      this.textBox10 = new System.Windows.Forms.TextBox();
      this.textBox11 = new System.Windows.Forms.TextBox();
      this.chkBoxQuebraLinha = new System.Windows.Forms.CheckBox();
      this.chkBoxPesqTabDinamCod = new System.Windows.Forms.CheckBox();
      this.txtNomeColuna = new System.Windows.Forms.TextBox();
      this.textBox7 = new System.Windows.Forms.TextBox();
      this.textBox8 = new System.Windows.Forms.TextBox();
      this.textBox3 = new System.Windows.Forms.TextBox();
      this.txtColigada = new System.Windows.Forms.TextBox();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.dgvGDefCompl = new System.Windows.Forms.DataGridView();
      this.btnSair = new System.Windows.Forms.Button();
      this.btnSalvarScript = new System.Windows.Forms.Button();
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.lblProjeto = new System.Windows.Forms.Label();
      this.txtNoeProjeto.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvGdicGcampos)).BeginInit();
      this.panel1.SuspendLayout();
      this.gbTabela.SuspendLayout();
      this.gbBancoDados.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.txtValorDefault.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvGDefCompl)).BeginInit();
      this.SuspendLayout();
      // 
      // txtNoeProjeto
      // 
      this.txtNoeProjeto.Controls.Add(this.tabPage1);
      this.txtNoeProjeto.Controls.Add(this.tabPage2);
      this.txtNoeProjeto.Location = new System.Drawing.Point(1, 41);
      this.txtNoeProjeto.Name = "txtNoeProjeto";
      this.txtNoeProjeto.SelectedIndex = 0;
      this.txtNoeProjeto.Size = new System.Drawing.Size(1045, 367);
      this.txtNoeProjeto.TabIndex = 14;
      // 
      // tabPage1
      // 
      this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tabPage1.Controls.Add(this.dgvGdicGcampos);
      this.tabPage1.Controls.Add(this.panel1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(1037, 341);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "GCAMPOS/GDIC";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // dgvGdicGcampos
      // 
      this.dgvGdicGcampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvGdicGcampos.Location = new System.Drawing.Point(2, 2);
      this.dgvGdicGcampos.Name = "dgvGdicGcampos";
      this.dgvGdicGcampos.Size = new System.Drawing.Size(669, 331);
      this.dgvGdicGcampos.TabIndex = 11;
      // 
      // panel1
      // 
      this.panel1.AutoSize = true;
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.gbTabela);
      this.panel1.Controls.Add(this.btnGcamposGDicExcluir);
      this.panel1.Controls.Add(this.btnExcluirDadosGrid);
      this.panel1.Controls.Add(this.btnInserirDadosGCamposGdic);
      this.panel1.Controls.Add(this.gbBancoDados);
      this.panel1.Controls.Add(this.txtAplicacao);
      this.panel1.Controls.Add(this.lblAplicacoes);
      this.panel1.Controls.Add(this.txtTabela);
      this.panel1.Controls.Add(this.btlGCamposGdicLimparCampos);
      this.panel1.Controls.Add(this.chbRelatorio);
      this.panel1.Controls.Add(this.lblTabela);
      this.panel1.Controls.Add(this.lblColuna);
      this.panel1.Controls.Add(this.lblDescricao);
      this.panel1.Controls.Add(this.txtColuna);
      this.panel1.Controls.Add(this.txtDescricao);
      this.panel1.Location = new System.Drawing.Point(677, 2);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(353, 296);
      this.panel1.TabIndex = 7;
      // 
      // gbTabela
      // 
      this.gbTabela.Controls.Add(this.chkGDic);
      this.gbTabela.Controls.Add(this.chkGampos);
      this.gbTabela.Location = new System.Drawing.Point(5, 11);
      this.gbTabela.Name = "gbTabela";
      this.gbTabela.Size = new System.Drawing.Size(233, 43);
      this.gbTabela.TabIndex = 19;
      this.gbTabela.TabStop = false;
      this.gbTabela.Text = "Tabela";
      // 
      // chkGDic
      // 
      this.chkGDic.AutoSize = true;
      this.chkGDic.Location = new System.Drawing.Point(16, 19);
      this.chkGDic.Name = "chkGDic";
      this.chkGDic.Size = new System.Drawing.Size(52, 17);
      this.chkGDic.TabIndex = 17;
      this.chkGDic.Text = "GDIC";
      this.chkGDic.UseVisualStyleBackColor = true;
      // 
      // chkGampos
      // 
      this.chkGampos.AutoSize = true;
      this.chkGampos.Location = new System.Drawing.Point(85, 19);
      this.chkGampos.Name = "chkGampos";
      this.chkGampos.Size = new System.Drawing.Size(79, 17);
      this.chkGampos.TabIndex = 18;
      this.chkGampos.Text = "GCAMPOS";
      this.chkGampos.UseVisualStyleBackColor = true;
      // 
      // btnGcamposGDicExcluir
      // 
      this.btnGcamposGDicExcluir.Location = new System.Drawing.Point(262, 179);
      this.btnGcamposGDicExcluir.Name = "btnGcamposGDicExcluir";
      this.btnGcamposGDicExcluir.Size = new System.Drawing.Size(75, 23);
      this.btnGcamposGDicExcluir.TabIndex = 16;
      this.btnGcamposGDicExcluir.Text = "Excluir";
      this.btnGcamposGDicExcluir.UseVisualStyleBackColor = true;
      this.btnGcamposGDicExcluir.Click += new System.EventHandler(this.btnGcamposGDicExcluir_Click);
      // 
      // btnExcluirDadosGrid
      // 
      this.btnExcluirDadosGrid.Location = new System.Drawing.Point(201, 268);
      this.btnExcluirDadosGrid.Name = "btnExcluirDadosGrid";
      this.btnExcluirDadosGrid.Size = new System.Drawing.Size(136, 23);
      this.btnExcluirDadosGrid.TabIndex = 12;
      this.btnExcluirDadosGrid.Text = "Excluir Dados no Grid";
      this.btnExcluirDadosGrid.UseVisualStyleBackColor = true;
      this.btnExcluirDadosGrid.Click += new System.EventHandler(this.btnExcluirDadosGrid_Click);
      // 
      // btnInserirDadosGCamposGdic
      // 
      this.btnInserirDadosGCamposGdic.Location = new System.Drawing.Point(262, 129);
      this.btnInserirDadosGCamposGdic.Name = "btnInserirDadosGCamposGdic";
      this.btnInserirDadosGCamposGdic.Size = new System.Drawing.Size(75, 23);
      this.btnInserirDadosGCamposGdic.TabIndex = 12;
      this.btnInserirDadosGCamposGdic.Text = "Inserir";
      this.btnInserirDadosGCamposGdic.UseVisualStyleBackColor = true;
      this.btnInserirDadosGCamposGdic.Click += new System.EventHandler(this.btnInserirDados_Click);
      // 
      // gbBancoDados
      // 
      this.gbBancoDados.Controls.Add(this.chbSql);
      this.gbBancoDados.Controls.Add(this.chbOracle);
      this.gbBancoDados.Location = new System.Drawing.Point(258, 11);
      this.gbBancoDados.Name = "gbBancoDados";
      this.gbBancoDados.Size = new System.Drawing.Size(76, 72);
      this.gbBancoDados.TabIndex = 15;
      this.gbBancoDados.TabStop = false;
      this.gbBancoDados.Text = "Banco";
      // 
      // chbSql
      // 
      this.chbSql.AutoSize = true;
      this.chbSql.Location = new System.Drawing.Point(15, 19);
      this.chbSql.Name = "chbSql";
      this.chbSql.Size = new System.Drawing.Size(41, 17);
      this.chbSql.TabIndex = 6;
      this.chbSql.Text = "Sql";
      this.chbSql.UseVisualStyleBackColor = true;
      // 
      // chbOracle
      // 
      this.chbOracle.AutoSize = true;
      this.chbOracle.Location = new System.Drawing.Point(15, 42);
      this.chbOracle.Name = "chbOracle";
      this.chbOracle.Size = new System.Drawing.Size(57, 17);
      this.chbOracle.TabIndex = 5;
      this.chbOracle.Text = "Oracle";
      this.chbOracle.UseVisualStyleBackColor = true;
      // 
      // txtAplicacao
      // 
      this.txtAplicacao.Location = new System.Drawing.Point(6, 231);
      this.txtAplicacao.Name = "txtAplicacao";
      this.txtAplicacao.Size = new System.Drawing.Size(232, 20);
      this.txtAplicacao.TabIndex = 12;
      // 
      // lblAplicacoes
      // 
      this.lblAplicacoes.AutoSize = true;
      this.lblAplicacoes.Location = new System.Drawing.Point(3, 215);
      this.lblAplicacoes.Name = "lblAplicacoes";
      this.lblAplicacoes.Size = new System.Drawing.Size(59, 13);
      this.lblAplicacoes.TabIndex = 13;
      this.lblAplicacoes.Text = "Aplicações";
      // 
      // txtTabela
      // 
      this.txtTabela.ForeColor = System.Drawing.Color.Black;
      this.txtTabela.Location = new System.Drawing.Point(6, 83);
      this.txtTabela.Name = "txtTabela";
      this.txtTabela.Size = new System.Drawing.Size(232, 20);
      this.txtTabela.TabIndex = 2;
      // 
      // btlGCamposGdicLimparCampos
      // 
      this.btlGCamposGdicLimparCampos.Location = new System.Drawing.Point(262, 228);
      this.btlGCamposGdicLimparCampos.Name = "btlGCamposGdicLimparCampos";
      this.btlGCamposGdicLimparCampos.Size = new System.Drawing.Size(75, 23);
      this.btlGCamposGdicLimparCampos.TabIndex = 9;
      this.btlGCamposGdicLimparCampos.Text = "Limpar";
      this.btlGCamposGdicLimparCampos.UseVisualStyleBackColor = true;
      this.btlGCamposGdicLimparCampos.Click += new System.EventHandler(this.btlGCamposGdicLimparCampos_Click);
      // 
      // chbRelatorio
      // 
      this.chbRelatorio.AutoSize = true;
      this.chbRelatorio.Location = new System.Drawing.Point(262, 89);
      this.chbRelatorio.Name = "chbRelatorio";
      this.chbRelatorio.Size = new System.Drawing.Size(68, 17);
      this.chbRelatorio.TabIndex = 14;
      this.chbRelatorio.Text = "Relatório";
      this.chbRelatorio.UseVisualStyleBackColor = true;
      // 
      // lblTabela
      // 
      this.lblTabela.AutoSize = true;
      this.lblTabela.Location = new System.Drawing.Point(3, 64);
      this.lblTabela.Name = "lblTabela";
      this.lblTabela.Size = new System.Drawing.Size(43, 13);
      this.lblTabela.TabIndex = 11;
      this.lblTabela.Text = "Tabela ";
      // 
      // lblColuna
      // 
      this.lblColuna.AutoSize = true;
      this.lblColuna.Location = new System.Drawing.Point(6, 116);
      this.lblColuna.Name = "lblColuna";
      this.lblColuna.Size = new System.Drawing.Size(40, 13);
      this.lblColuna.TabIndex = 10;
      this.lblColuna.Text = "Coluna";
      // 
      // lblDescricao
      // 
      this.lblDescricao.AutoSize = true;
      this.lblDescricao.Location = new System.Drawing.Point(3, 165);
      this.lblDescricao.Name = "lblDescricao";
      this.lblDescricao.Size = new System.Drawing.Size(55, 13);
      this.lblDescricao.TabIndex = 8;
      this.lblDescricao.Text = "Descrição";
      // 
      // txtColuna
      // 
      this.txtColuna.Location = new System.Drawing.Point(6, 132);
      this.txtColuna.Name = "txtColuna";
      this.txtColuna.Size = new System.Drawing.Size(232, 20);
      this.txtColuna.TabIndex = 4;
      // 
      // txtDescricao
      // 
      this.txtDescricao.Location = new System.Drawing.Point(6, 182);
      this.txtDescricao.Name = "txtDescricao";
      this.txtDescricao.Size = new System.Drawing.Size(232, 20);
      this.txtDescricao.TabIndex = 3;
      // 
      // tabPage2
      // 
      this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tabPage2.Controls.Add(this.txtValorDefault);
      this.tabPage2.Controls.Add(this.dgvGDefCompl);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(1037, 341);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "GDEFCOMPL";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // txtValorDefault
      // 
      this.txtValorDefault.Controls.Add(this.txtTipoTexto);
      this.txtValorDefault.Controls.Add(this.lblTipoTexto);
      this.txtValorDefault.Controls.Add(this.btnGDefExcluirDadosGrid);
      this.txtValorDefault.Controls.Add(this.btGDefIncluir);
      this.txtValorDefault.Controls.Add(this.btGDefExcluir);
      this.txtValorDefault.Controls.Add(this.textBox9);
      this.txtValorDefault.Controls.Add(this.lblOrdem);
      this.txtValorDefault.Controls.Add(this.btGDefLimpar);
      this.txtValorDefault.Controls.Add(this.lblCodColTabDinamica);
      this.txtValorDefault.Controls.Add(this.lblCodTabDinamica);
      this.txtValorDefault.Controls.Add(this.lblGdfDescricao);
      this.txtValorDefault.Controls.Add(this.lblNomeColuna);
      this.txtValorDefault.Controls.Add(this.lblDodTabDinamica);
      this.txtValorDefault.Controls.Add(this.lblCodigoFormula);
      this.txtValorDefault.Controls.Add(this.lblApliccaoTabDinamica);
      this.txtValorDefault.Controls.Add(this.lblCodColFormula);
      this.txtValorDefault.Controls.Add(this.lblTabDados);
      this.txtValorDefault.Controls.Add(this.lblAplicacao);
      this.txtValorDefault.Controls.Add(this.lblColigada);
      this.txtValorDefault.Controls.Add(this.lblValorDefault);
      this.txtValorDefault.Controls.Add(this.txtCodColTabDinamica);
      this.txtValorDefault.Controls.Add(this.textBox13);
      this.txtValorDefault.Controls.Add(this.textBox4);
      this.txtValorDefault.Controls.Add(this.textBox5);
      this.txtValorDefault.Controls.Add(this.textBox10);
      this.txtValorDefault.Controls.Add(this.textBox11);
      this.txtValorDefault.Controls.Add(this.chkBoxQuebraLinha);
      this.txtValorDefault.Controls.Add(this.chkBoxPesqTabDinamCod);
      this.txtValorDefault.Controls.Add(this.txtNomeColuna);
      this.txtValorDefault.Controls.Add(this.textBox7);
      this.txtValorDefault.Controls.Add(this.textBox8);
      this.txtValorDefault.Controls.Add(this.textBox3);
      this.txtValorDefault.Controls.Add(this.txtColigada);
      this.txtValorDefault.Controls.Add(this.textBox1);
      this.txtValorDefault.Location = new System.Drawing.Point(619, 2);
      this.txtValorDefault.Name = "txtValorDefault";
      this.txtValorDefault.Size = new System.Drawing.Size(407, 329);
      this.txtValorDefault.TabIndex = 1;
      // 
      // txtTipoTexto
      // 
      this.txtTipoTexto.Location = new System.Drawing.Point(285, 209);
      this.txtTipoTexto.Name = "txtTipoTexto";
      this.txtTipoTexto.Size = new System.Drawing.Size(51, 20);
      this.txtTipoTexto.TabIndex = 72;
      // 
      // lblTipoTexto
      // 
      this.lblTipoTexto.AutoSize = true;
      this.lblTipoTexto.Location = new System.Drawing.Point(282, 193);
      this.lblTipoTexto.Name = "lblTipoTexto";
      this.lblTipoTexto.Size = new System.Drawing.Size(58, 13);
      this.lblTipoTexto.TabIndex = 73;
      this.lblTipoTexto.Text = "Tipo Texto";
      // 
      // btnGDefExcluirDadosGrid
      // 
      this.btnGDefExcluirDadosGrid.Location = new System.Drawing.Point(249, 283);
      this.btnGDefExcluirDadosGrid.Name = "btnGDefExcluirDadosGrid";
      this.btnGDefExcluirDadosGrid.Size = new System.Drawing.Size(150, 23);
      this.btnGDefExcluirDadosGrid.TabIndex = 71;
      this.btnGDefExcluirDadosGrid.Text = "Excluir Dados Grid";
      this.btnGDefExcluirDadosGrid.UseVisualStyleBackColor = true;
      this.btnGDefExcluirDadosGrid.Click += new System.EventHandler(this.btnGDefExcluirDadosGrid_Click);
      // 
      // btGDefIncluir
      // 
      this.btGDefIncluir.Location = new System.Drawing.Point(6, 283);
      this.btGDefIncluir.Name = "btGDefIncluir";
      this.btGDefIncluir.Size = new System.Drawing.Size(75, 23);
      this.btGDefIncluir.TabIndex = 70;
      this.btGDefIncluir.Text = "Incluir";
      this.btGDefIncluir.UseVisualStyleBackColor = true;
      this.btGDefIncluir.Click += new System.EventHandler(this.btGDefIncluir_Click);
      // 
      // btGDefExcluir
      // 
      this.btGDefExcluir.Location = new System.Drawing.Point(87, 283);
      this.btGDefExcluir.Name = "btGDefExcluir";
      this.btGDefExcluir.Size = new System.Drawing.Size(75, 23);
      this.btGDefExcluir.TabIndex = 69;
      this.btGDefExcluir.Text = "Excluir";
      this.btGDefExcluir.UseVisualStyleBackColor = true;
      this.btGDefExcluir.Click += new System.EventHandler(this.btGDefExcluir_Click);
      // 
      // textBox9
      // 
      this.textBox9.Location = new System.Drawing.Point(111, 209);
      this.textBox9.Name = "textBox9";
      this.textBox9.Size = new System.Drawing.Size(51, 20);
      this.textBox9.TabIndex = 48;
      // 
      // lblOrdem
      // 
      this.lblOrdem.AutoSize = true;
      this.lblOrdem.Location = new System.Drawing.Point(108, 193);
      this.lblOrdem.Name = "lblOrdem";
      this.lblOrdem.Size = new System.Drawing.Size(38, 13);
      this.lblOrdem.TabIndex = 61;
      this.lblOrdem.Text = "Ordem";
      // 
      // btGDefLimpar
      // 
      this.btGDefLimpar.Location = new System.Drawing.Point(168, 283);
      this.btGDefLimpar.Name = "btGDefLimpar";
      this.btGDefLimpar.Size = new System.Drawing.Size(75, 23);
      this.btGDefLimpar.TabIndex = 68;
      this.btGDefLimpar.Text = "Limpar";
      this.btGDefLimpar.UseVisualStyleBackColor = true;
      this.btGDefLimpar.Click += new System.EventHandler(this.btGDefLimpar_Click);
      // 
      // lblCodColTabDinamica
      // 
      this.lblCodColTabDinamica.AutoSize = true;
      this.lblCodColTabDinamica.Location = new System.Drawing.Point(205, 93);
      this.lblCodColTabDinamica.Name = "lblCodColTabDinamica";
      this.lblCodColTabDinamica.Size = new System.Drawing.Size(113, 13);
      this.lblCodColTabDinamica.TabIndex = 67;
      this.lblCodColTabDinamica.Text = "Cod.Col.Tab.Dinamica";
      // 
      // lblCodTabDinamica
      // 
      this.lblCodTabDinamica.AutoSize = true;
      this.lblCodTabDinamica.Location = new System.Drawing.Point(205, 54);
      this.lblCodTabDinamica.Name = "lblCodTabDinamica";
      this.lblCodTabDinamica.Size = new System.Drawing.Size(101, 13);
      this.lblCodTabDinamica.TabIndex = 66;
      this.lblCodTabDinamica.Text = "Cod. Tab. Dinâmica";
      // 
      // lblGdfDescricao
      // 
      this.lblGdfDescricao.AutoSize = true;
      this.lblGdfDescricao.Location = new System.Drawing.Point(6, 54);
      this.lblGdfDescricao.Name = "lblGdfDescricao";
      this.lblGdfDescricao.Size = new System.Drawing.Size(55, 13);
      this.lblGdfDescricao.TabIndex = 65;
      this.lblGdfDescricao.Text = "Descrição";
      // 
      // lblNomeColuna
      // 
      this.lblNomeColuna.AutoSize = true;
      this.lblNomeColuna.Location = new System.Drawing.Point(205, 8);
      this.lblNomeColuna.Name = "lblNomeColuna";
      this.lblNomeColuna.Size = new System.Drawing.Size(70, 13);
      this.lblNomeColuna.TabIndex = 64;
      this.lblNomeColuna.Text = "Nome coluna";
      // 
      // lblDodTabDinamica
      // 
      this.lblDodTabDinamica.AutoSize = true;
      this.lblDodTabDinamica.Location = new System.Drawing.Point(4, 97);
      this.lblDodTabDinamica.Name = "lblDodTabDinamica";
      this.lblDodTabDinamica.Size = new System.Drawing.Size(98, 13);
      this.lblDodTabDinamica.TabIndex = 63;
      this.lblDodTabDinamica.Text = "Cod.Tab. Dinamica";
      // 
      // lblCodigoFormula
      // 
      this.lblCodigoFormula.AutoSize = true;
      this.lblCodigoFormula.Location = new System.Drawing.Point(116, 97);
      this.lblCodigoFormula.Name = "lblCodigoFormula";
      this.lblCodigoFormula.Size = new System.Drawing.Size(69, 13);
      this.lblCodigoFormula.TabIndex = 62;
      this.lblCodigoFormula.Text = "Cod. Formula";
      // 
      // lblApliccaoTabDinamica
      // 
      this.lblApliccaoTabDinamica.AutoSize = true;
      this.lblApliccaoTabDinamica.Location = new System.Drawing.Point(6, 193);
      this.lblApliccaoTabDinamica.Name = "lblApliccaoTabDinamica";
      this.lblApliccaoTabDinamica.Size = new System.Drawing.Size(95, 13);
      this.lblApliccaoTabDinamica.TabIndex = 60;
      this.lblApliccaoTabDinamica.Text = "Apli. tab. Dinamica";
      // 
      // lblCodColFormula
      // 
      this.lblCodColFormula.AutoSize = true;
      this.lblCodColFormula.Location = new System.Drawing.Point(177, 193);
      this.lblCodColFormula.Name = "lblCodColFormula";
      this.lblCodColFormula.Size = new System.Drawing.Size(87, 13);
      this.lblCodColFormula.TabIndex = 59;
      this.lblCodColFormula.Text = "Cod.Col. Formula";
      // 
      // lblTabDados
      // 
      this.lblTabDados.AutoSize = true;
      this.lblTabDados.Location = new System.Drawing.Point(134, 8);
      this.lblTabDados.Name = "lblTabDados";
      this.lblTabDados.Size = new System.Drawing.Size(60, 13);
      this.lblTabDados.TabIndex = 58;
      this.lblTabDados.Text = "Tab Dados";
      // 
      // lblAplicacao
      // 
      this.lblAplicacao.AutoSize = true;
      this.lblAplicacao.Location = new System.Drawing.Point(70, 8);
      this.lblAplicacao.Name = "lblAplicacao";
      this.lblAplicacao.Size = new System.Drawing.Size(54, 13);
      this.lblAplicacao.TabIndex = 57;
      this.lblAplicacao.Text = "Aplicação";
      // 
      // lblColigada
      // 
      this.lblColigada.AutoSize = true;
      this.lblColigada.Location = new System.Drawing.Point(4, 8);
      this.lblColigada.Name = "lblColigada";
      this.lblColigada.Size = new System.Drawing.Size(48, 13);
      this.lblColigada.TabIndex = 56;
      this.lblColigada.Text = "Coligada";
      // 
      // lblValorDefault
      // 
      this.lblValorDefault.AutoSize = true;
      this.lblValorDefault.Location = new System.Drawing.Point(8, 145);
      this.lblValorDefault.Name = "lblValorDefault";
      this.lblValorDefault.Size = new System.Drawing.Size(68, 13);
      this.lblValorDefault.TabIndex = 55;
      this.lblValorDefault.Text = "Valor Default";
      // 
      // txtCodColTabDinamica
      // 
      this.txtCodColTabDinamica.Location = new System.Drawing.Point(208, 113);
      this.txtCodColTabDinamica.Name = "txtCodColTabDinamica";
      this.txtCodColTabDinamica.Size = new System.Drawing.Size(194, 20);
      this.txtCodColTabDinamica.TabIndex = 54;
      // 
      // textBox13
      // 
      this.textBox13.Location = new System.Drawing.Point(6, 209);
      this.textBox13.Name = "textBox13";
      this.textBox13.Size = new System.Drawing.Size(91, 20);
      this.textBox13.TabIndex = 53;
      // 
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(208, 70);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(194, 20);
      this.textBox4.TabIndex = 52;
      // 
      // textBox5
      // 
      this.textBox5.Location = new System.Drawing.Point(7, 70);
      this.textBox5.Name = "textBox5";
      this.textBox5.Size = new System.Drawing.Size(182, 20);
      this.textBox5.TabIndex = 51;
      // 
      // textBox10
      // 
      this.textBox10.Location = new System.Drawing.Point(178, 209);
      this.textBox10.Name = "textBox10";
      this.textBox10.Size = new System.Drawing.Size(86, 20);
      this.textBox10.TabIndex = 50;
      // 
      // textBox11
      // 
      this.textBox11.Location = new System.Drawing.Point(138, 24);
      this.textBox11.Name = "textBox11";
      this.textBox11.Size = new System.Drawing.Size(51, 20);
      this.textBox11.TabIndex = 49;
      // 
      // chkBoxQuebraLinha
      // 
      this.chkBoxQuebraLinha.AutoSize = true;
      this.chkBoxQuebraLinha.Location = new System.Drawing.Point(4, 251);
      this.chkBoxQuebraLinha.Name = "chkBoxQuebraLinha";
      this.chkBoxQuebraLinha.Size = new System.Drawing.Size(112, 17);
      this.chkBoxQuebraLinha.TabIndex = 47;
      this.chkBoxQuebraLinha.Text = "Quebra De Linhas";
      this.chkBoxQuebraLinha.UseVisualStyleBackColor = true;
      // 
      // chkBoxPesqTabDinamCod
      // 
      this.chkBoxPesqTabDinamCod.AutoSize = true;
      this.chkBoxPesqTabDinamCod.Location = new System.Drawing.Point(122, 251);
      this.chkBoxPesqTabDinamCod.Name = "chkBoxPesqTabDinamCod";
      this.chkBoxPesqTabDinamCod.Size = new System.Drawing.Size(203, 17);
      this.chkBoxPesqTabDinamCod.TabIndex = 46;
      this.chkBoxPesqTabDinamCod.Text = "Pesquisa Tabea dinamica Por Código";
      this.chkBoxPesqTabDinamCod.UseVisualStyleBackColor = true;
      // 
      // txtNomeColuna
      // 
      this.txtNomeColuna.Location = new System.Drawing.Point(208, 24);
      this.txtNomeColuna.Name = "txtNomeColuna";
      this.txtNomeColuna.Size = new System.Drawing.Size(194, 20);
      this.txtNomeColuna.TabIndex = 45;
      // 
      // textBox7
      // 
      this.textBox7.Location = new System.Drawing.Point(6, 113);
      this.textBox7.Name = "textBox7";
      this.textBox7.Size = new System.Drawing.Size(101, 20);
      this.textBox7.TabIndex = 44;
      // 
      // textBox8
      // 
      this.textBox8.Location = new System.Drawing.Point(116, 113);
      this.textBox8.Name = "textBox8";
      this.textBox8.Size = new System.Drawing.Size(74, 20);
      this.textBox8.TabIndex = 43;
      // 
      // textBox3
      // 
      this.textBox3.Location = new System.Drawing.Point(72, 24);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new System.Drawing.Size(51, 20);
      this.textBox3.TabIndex = 42;
      // 
      // txtColigada
      // 
      this.txtColigada.Location = new System.Drawing.Point(7, 24);
      this.txtColigada.Name = "txtColigada";
      this.txtColigada.Size = new System.Drawing.Size(50, 20);
      this.txtColigada.TabIndex = 41;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(6, 161);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(396, 20);
      this.textBox1.TabIndex = 40;
      // 
      // dgvGDefCompl
      // 
      this.dgvGDefCompl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvGDefCompl.Location = new System.Drawing.Point(-1, -1);
      this.dgvGDefCompl.Name = "dgvGDefCompl";
      this.dgvGDefCompl.Size = new System.Drawing.Size(614, 332);
      this.dgvGDefCompl.TabIndex = 0;
      // 
      // btnSair
      // 
      this.btnSair.Location = new System.Drawing.Point(959, 415);
      this.btnSair.Name = "btnSair";
      this.btnSair.Size = new System.Drawing.Size(75, 23);
      this.btnSair.TabIndex = 16;
      this.btnSair.Text = "Sair";
      this.btnSair.UseVisualStyleBackColor = true;
      this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
      // 
      // btnSalvarScript
      // 
      this.btnSalvarScript.Location = new System.Drawing.Point(875, 415);
      this.btnSalvarScript.Name = "btnSalvarScript";
      this.btnSalvarScript.Size = new System.Drawing.Size(75, 23);
      this.btnSalvarScript.TabIndex = 15;
      this.btnSalvarScript.Text = "Salvar Script";
      this.btnSalvarScript.UseVisualStyleBackColor = true;
      this.btnSalvarScript.Click += new System.EventHandler(this.btnSalvarScript_Click);
      // 
      // textBox2
      // 
      this.textBox2.ForeColor = System.Drawing.Color.Black;
      this.textBox2.Location = new System.Drawing.Point(58, 12);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(232, 20);
      this.textBox2.TabIndex = 20;
      // 
      // lblProjeto
      // 
      this.lblProjeto.AutoSize = true;
      this.lblProjeto.Location = new System.Drawing.Point(12, 15);
      this.lblProjeto.Name = "lblProjeto";
      this.lblProjeto.Size = new System.Drawing.Size(40, 13);
      this.lblProjeto.TabIndex = 20;
      this.lblProjeto.Text = "Projeto";
      // 
      // Script
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1045, 450);
      this.Controls.Add(this.lblProjeto);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.btnSair);
      this.Controls.Add(this.btnSalvarScript);
      this.Controls.Add(this.txtNoeProjeto);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Script";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Script";
      this.txtNoeProjeto.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvGdicGcampos)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.gbTabela.ResumeLayout(false);
      this.gbTabela.PerformLayout();
      this.gbBancoDados.ResumeLayout(false);
      this.gbBancoDados.PerformLayout();
      this.tabPage2.ResumeLayout(false);
      this.txtValorDefault.ResumeLayout(false);
      this.txtValorDefault.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvGDefCompl)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl txtNoeProjeto;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.DataGridView dgvGdicGcampos;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox gbTabela;
    private System.Windows.Forms.CheckBox chkGDic;
    private System.Windows.Forms.CheckBox chkGampos;
    private System.Windows.Forms.Button btnGcamposGDicExcluir;
    private System.Windows.Forms.Button btnExcluirDadosGrid;
    private System.Windows.Forms.Button btnInserirDadosGCamposGdic;
    private System.Windows.Forms.GroupBox gbBancoDados;
    private System.Windows.Forms.CheckBox chbSql;
    private System.Windows.Forms.CheckBox chbOracle;
    private System.Windows.Forms.TextBox txtAplicacao;
    private System.Windows.Forms.Label lblAplicacoes;
    private System.Windows.Forms.TextBox txtTabela;
    private System.Windows.Forms.Button btlGCamposGdicLimparCampos;
    private System.Windows.Forms.CheckBox chbRelatorio;
    private System.Windows.Forms.Label lblTabela;
    private System.Windows.Forms.Label lblColuna;
    private System.Windows.Forms.Label lblDescricao;
    private System.Windows.Forms.TextBox txtColuna;
    private System.Windows.Forms.TextBox txtDescricao;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Panel txtValorDefault;
    private System.Windows.Forms.TextBox txtTipoTexto;
    private System.Windows.Forms.Label lblTipoTexto;
    private System.Windows.Forms.Button btnGDefExcluirDadosGrid;
    private System.Windows.Forms.Button btGDefIncluir;
    private System.Windows.Forms.Button btGDefExcluir;
    private System.Windows.Forms.TextBox textBox9;
    private System.Windows.Forms.Label lblOrdem;
    private System.Windows.Forms.Button btGDefLimpar;
    private System.Windows.Forms.Label lblCodColTabDinamica;
    private System.Windows.Forms.Label lblCodTabDinamica;
    private System.Windows.Forms.Label lblGdfDescricao;
    private System.Windows.Forms.Label lblNomeColuna;
    private System.Windows.Forms.Label lblDodTabDinamica;
    private System.Windows.Forms.Label lblCodigoFormula;
    private System.Windows.Forms.Label lblApliccaoTabDinamica;
    private System.Windows.Forms.Label lblCodColFormula;
    private System.Windows.Forms.Label lblTabDados;
    private System.Windows.Forms.Label lblAplicacao;
    private System.Windows.Forms.Label lblColigada;
    private System.Windows.Forms.Label lblValorDefault;
    private System.Windows.Forms.TextBox txtCodColTabDinamica;
    private System.Windows.Forms.TextBox textBox13;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.TextBox textBox10;
    private System.Windows.Forms.TextBox textBox11;
    private System.Windows.Forms.CheckBox chkBoxQuebraLinha;
    private System.Windows.Forms.CheckBox chkBoxPesqTabDinamCod;
    private System.Windows.Forms.TextBox txtNomeColuna;
    private System.Windows.Forms.TextBox textBox7;
    private System.Windows.Forms.TextBox textBox8;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox txtColigada;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.DataGridView dgvGDefCompl;
    private System.Windows.Forms.Button btnSair;
    private System.Windows.Forms.Button btnSalvarScript;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label lblProjeto;
  }
}