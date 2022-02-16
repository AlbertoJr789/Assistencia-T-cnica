namespace Assistencia_Técnica
{
    partial class FormCadFuncionario
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
            this.estadoFuncionario = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.labelTel1 = new System.Windows.Forms.Label();
            this.labelTel2 = new System.Windows.Forms.Label();
            this.telefone1Funcionario = new System.Windows.Forms.MaskedTextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.labelBairro = new System.Windows.Forms.Label();
            this.labelLog = new System.Windows.Forms.Label();
            this.numeroEndFuncionario = new System.Windows.Forms.TextBox();
            this.labelNum = new System.Windows.Forms.Label();
            this.cidadeFuncionario = new System.Windows.Forms.TextBox();
            this.labelCidade = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.logradouroFuncionario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.botLimpar = new System.Windows.Forms.Button();
            this.botaoAdd = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.bairroFuncionario = new System.Windows.Forms.TextBox();
            this.telefone2Funcionario = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.nomeFuncionario = new System.Windows.Forms.TextBox();
            this.labelRG = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rgFuncionario = new System.Windows.Forms.MaskedTextBox();
            this.labelCPF = new System.Windows.Forms.Label();
            this.cpfFuncionario = new System.Windows.Forms.MaskedTextBox();
            this.labelFuncao = new System.Windows.Forms.Label();
            this.funcaoFuncionario = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // estadoFuncionario
            // 
            this.estadoFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.estadoFuncionario.Location = new System.Drawing.Point(386, 214);
            this.estadoFuncionario.Name = "estadoFuncionario";
            this.estadoFuncionario.Size = new System.Drawing.Size(198, 20);
            this.estadoFuncionario.TabIndex = 20;
            this.estadoFuncionario.TextChanged += new System.EventHandler(this.estadoFuncionario_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.label15.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label15.Location = new System.Drawing.Point(3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(294, 75);
            this.label15.TabIndex = 16;
            this.label15.Text = "Contato(s)";
            // 
            // labelTel1
            // 
            this.labelTel1.AutoSize = true;
            this.labelTel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTel1.Location = new System.Drawing.Point(3, 75);
            this.labelTel1.Name = "labelTel1";
            this.labelTel1.Size = new System.Drawing.Size(294, 41);
            this.labelTel1.TabIndex = 17;
            this.labelTel1.Text = "Telefone Celular *";
            // 
            // labelTel2
            // 
            this.labelTel2.AutoSize = true;
            this.labelTel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTel2.Location = new System.Drawing.Point(3, 157);
            this.labelTel2.Name = "labelTel2";
            this.labelTel2.Size = new System.Drawing.Size(294, 41);
            this.labelTel2.TabIndex = 19;
            this.labelTel2.Text = "Telefone Fixo";
            // 
            // telefone1Funcionario
            // 
            this.telefone1Funcionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telefone1Funcionario.Location = new System.Drawing.Point(3, 119);
            this.telefone1Funcionario.Mask = "(00)00000-0000";
            this.telefone1Funcionario.Name = "telefone1Funcionario";
            this.telefone1Funcionario.Size = new System.Drawing.Size(294, 20);
            this.telefone1Funcionario.TabIndex = 20;
            this.telefone1Funcionario.TextChanged += new System.EventHandler(this.telefone1Funcionario_TextChanged);
            // 
            // labelEstado
            // 
            this.labelEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEstado.AutoSize = true;
            this.labelEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelEstado.Location = new System.Drawing.Point(386, 190);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(198, 21);
            this.labelEstado.TabIndex = 27;
            this.labelEstado.Text = "Estado *";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(377, 46);
            this.label11.TabIndex = 16;
            this.label11.Text = "Dados de endereço";
            // 
            // labelBairro
            // 
            this.labelBairro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBairro.AutoSize = true;
            this.labelBairro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelBairro.Location = new System.Drawing.Point(3, 140);
            this.labelBairro.Name = "labelBairro";
            this.labelBairro.Size = new System.Drawing.Size(377, 18);
            this.labelBairro.TabIndex = 22;
            this.labelBairro.Text = "Bairro *";
            // 
            // labelLog
            // 
            this.labelLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLog.AutoSize = true;
            this.labelLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelLog.Location = new System.Drawing.Point(3, 65);
            this.labelLog.Name = "labelLog";
            this.labelLog.Size = new System.Drawing.Size(377, 23);
            this.labelLog.TabIndex = 17;
            this.labelLog.Text = "Logradouro *";
            // 
            // numeroEndFuncionario
            // 
            this.numeroEndFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numeroEndFuncionario.Location = new System.Drawing.Point(386, 113);
            this.numeroEndFuncionario.Name = "numeroEndFuncionario";
            this.numeroEndFuncionario.Size = new System.Drawing.Size(198, 20);
            this.numeroEndFuncionario.TabIndex = 21;
            this.numeroEndFuncionario.TextChanged += new System.EventHandler(this.numeroEndFuncionario_TextChanged);
            // 
            // labelNum
            // 
            this.labelNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNum.AutoSize = true;
            this.labelNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelNum.Location = new System.Drawing.Point(386, 88);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(198, 22);
            this.labelNum.TabIndex = 20;
            this.labelNum.Text = "Número *";
            // 
            // cidadeFuncionario
            // 
            this.cidadeFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cidadeFuncionario.Location = new System.Drawing.Point(3, 214);
            this.cidadeFuncionario.Name = "cidadeFuncionario";
            this.cidadeFuncionario.Size = new System.Drawing.Size(377, 20);
            this.cidadeFuncionario.TabIndex = 25;
            this.cidadeFuncionario.TextChanged += new System.EventHandler(this.cidadeFuncionario_TextChanged);
            // 
            // labelCidade
            // 
            this.labelCidade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCidade.AutoSize = true;
            this.labelCidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelCidade.Location = new System.Drawing.Point(3, 190);
            this.labelCidade.Name = "labelCidade";
            this.labelCidade.Size = new System.Drawing.Size(377, 21);
            this.labelCidade.TabIndex = 26;
            this.labelCidade.Text = "Cidade *";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label12.Location = new System.Drawing.Point(3, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "(Ex: Rua/Avenida/Rodovia Antonio Soares)";
            // 
            // logradouroFuncionario
            // 
            this.logradouroFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logradouroFuncionario.Location = new System.Drawing.Point(3, 113);
            this.logradouroFuncionario.Name = "logradouroFuncionario";
            this.logradouroFuncionario.Size = new System.Drawing.Size(377, 20);
            this.logradouroFuncionario.TabIndex = 19;
            this.logradouroFuncionario.TextChanged += new System.EventHandler(this.logradouroFuncionario_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(600, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(588, 60);
            this.label2.TabIndex = 3;
            this.label2.Text = "Campos marcados com (*) requerem preenchimento obrigatório\r\nCampos opcionais que " +
    "não contêm demarcações, como CPF e Telefone Fixo, devem estar ou vazios ou total" +
    "mente preenchidos.";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.botLimpar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.botaoAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.botCancelar, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 570);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1191, 118);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // botLimpar
            // 
            this.botLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.botLimpar.AutoSize = true;
            this.botLimpar.BackColor = System.Drawing.SystemColors.Highlight;
            this.botLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botLimpar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.botLimpar.Location = new System.Drawing.Point(400, 3);
            this.botLimpar.Name = "botLimpar";
            this.botLimpar.Size = new System.Drawing.Size(391, 112);
            this.botLimpar.TabIndex = 1;
            this.botLimpar.Text = "Limpar";
            this.botLimpar.UseVisualStyleBackColor = false;
            this.botLimpar.Click += new System.EventHandler(this.botLimpar_Click_1);
            // 
            // botaoAdd
            // 
            this.botaoAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.botaoAdd.AutoSize = true;
            this.botaoAdd.BackColor = System.Drawing.SystemColors.Highlight;
            this.botaoAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botaoAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botaoAdd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.botaoAdd.Location = new System.Drawing.Point(3, 3);
            this.botaoAdd.Name = "botaoAdd";
            this.botaoAdd.Size = new System.Drawing.Size(391, 112);
            this.botaoAdd.TabIndex = 0;
            this.botaoAdd.Text = "Adicionar";
            this.botaoAdd.UseVisualStyleBackColor = false;
            this.botaoAdd.Click += new System.EventHandler(this.botaoAdd_Click);
            // 
            // botCancelar
            // 
            this.botCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.botCancelar.AutoSize = true;
            this.botCancelar.BackColor = System.Drawing.SystemColors.Highlight;
            this.botCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.botCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.botCancelar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.botCancelar.Location = new System.Drawing.Point(797, 3);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(391, 112);
            this.botCancelar.TabIndex = 2;
            this.botCancelar.Text = "Sair";
            this.botCancelar.UseVisualStyleBackColor = false;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click_1);
            // 
            // bairroFuncionario
            // 
            this.bairroFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bairroFuncionario.Location = new System.Drawing.Point(3, 161);
            this.bairroFuncionario.Name = "bairroFuncionario";
            this.bairroFuncionario.Size = new System.Drawing.Size(377, 20);
            this.bairroFuncionario.TabIndex = 23;
            this.bairroFuncionario.TextChanged += new System.EventHandler(this.bairroFuncionario_TextChanged);
            // 
            // telefone2Funcionario
            // 
            this.telefone2Funcionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.telefone2Funcionario.Location = new System.Drawing.Point(3, 201);
            this.telefone2Funcionario.Mask = "(00)0000-0000";
            this.telefone2Funcionario.Name = "telefone2Funcionario";
            this.telefone2Funcionario.Size = new System.Drawing.Size(294, 20);
            this.telefone2Funcionario.TabIndex = 21;
            this.telefone2Funcionario.TextChanged += new System.EventHandler(this.telefone2Funcionario_TextChanged);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.labelTel1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelTel2, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.telefone1Funcionario, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.telefone2Funcionario, 0, 4);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 286);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.90272F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.61946F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.61946F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.61946F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.61946F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.61946F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(300, 281);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.80989F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.19011F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1191, 570);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelNome, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.nomeFuncionario, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelRG, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.rgFuncionario, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelCPF, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.cpfFuncionario, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.labelFuncao, 0, 11);
            this.tableLayoutPanel3.Controls.Add(this.funcaoFuncionario, 0, 12);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 14;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.59203F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.286999F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.66426F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.971119F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.283504F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.254942F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.02527F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.610108F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.286999F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.303249F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.971119F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.286999F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.286999F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.286999F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(589, 277);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(583, 46);
            this.label10.TabIndex = 2;
            this.label10.Text = "Dados Pessoais";
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelNome.Location = new System.Drawing.Point(3, 49);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(65, 17);
            this.labelNome.TabIndex = 5;
            this.labelNome.Text = "Nome * ";
            // 
            // nomeFuncionario
            // 
            this.nomeFuncionario.BackColor = System.Drawing.SystemColors.Window;
            this.nomeFuncionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomeFuncionario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nomeFuncionario.Location = new System.Drawing.Point(3, 69);
            this.nomeFuncionario.Name = "nomeFuncionario";
            this.nomeFuncionario.Size = new System.Drawing.Size(583, 20);
            this.nomeFuncionario.TabIndex = 6;
            this.nomeFuncionario.TextChanged += new System.EventHandler(this.nomeFuncionario_TextChanged);
            // 
            // labelRG
            // 
            this.labelRG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRG.AutoSize = true;
            this.labelRG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelRG.Location = new System.Drawing.Point(3, 101);
            this.labelRG.Name = "labelRG";
            this.labelRG.Size = new System.Drawing.Size(583, 17);
            this.labelRG.TabIndex = 7;
            this.labelRG.Text = "R.G (Registro Geral)";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(3, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(583, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "(Ex: MG-11.111.111)";
            // 
            // rgFuncionario
            // 
            this.rgFuncionario.Location = new System.Drawing.Point(3, 138);
            this.rgFuncionario.Name = "rgFuncionario";
            this.rgFuncionario.Size = new System.Drawing.Size(583, 20);
            this.rgFuncionario.TabIndex = 17;
            // 
            // labelCPF
            // 
            this.labelCPF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCPF.AutoSize = true;
            this.labelCPF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelCPF.Location = new System.Drawing.Point(3, 170);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(583, 17);
            this.labelCPF.TabIndex = 18;
            this.labelCPF.Text = "CPF (Cadastro de Pessoa Física)";
            // 
            // cpfFuncionario
            // 
            this.cpfFuncionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cpfFuncionario.Location = new System.Drawing.Point(3, 190);
            this.cpfFuncionario.Mask = "000,000,000-00";
            this.cpfFuncionario.Name = "cpfFuncionario";
            this.cpfFuncionario.Size = new System.Drawing.Size(583, 20);
            this.cpfFuncionario.TabIndex = 19;
            this.cpfFuncionario.TextChanged += new System.EventHandler(this.cpfFuncionario_TextChanged);
            // 
            // labelFuncao
            // 
            this.labelFuncao.AutoSize = true;
            this.labelFuncao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelFuncao.Location = new System.Drawing.Point(3, 221);
            this.labelFuncao.Name = "labelFuncao";
            this.labelFuncao.Size = new System.Drawing.Size(77, 17);
            this.labelFuncao.TabIndex = 20;
            this.labelFuncao.Text = "Função * ";
            // 
            // funcaoFuncionario
            // 
            this.funcaoFuncionario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.funcaoFuncionario.FormattingEnabled = true;
            this.funcaoFuncionario.Items.AddRange(new object[] {
            "Administrador",
            "Gerente",
            "Técnico",
            "Vendedor"});
            this.funcaoFuncionario.Location = new System.Drawing.Point(3, 241);
            this.funcaoFuncionario.Name = "funcaoFuncionario";
            this.funcaoFuncionario.Size = new System.Drawing.Size(583, 21);
            this.funcaoFuncionario.TabIndex = 21;
            this.funcaoFuncionario.TextChanged += new System.EventHandler(this.funcaoFuncionario_TextChanged);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tableLayoutPanel5.Controls.Add(this.estadoFuncionario, 1, 8);
            this.tableLayoutPanel5.Controls.Add(this.labelEstado, 1, 7);
            this.tableLayoutPanel5.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.labelBairro, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.labelLog, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.numeroEndFuncionario, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.labelNum, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.bairroFuncionario, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.cidadeFuncionario, 0, 8);
            this.tableLayoutPanel5.Controls.Add(this.labelCidade, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.label12, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.logradouroFuncionario, 0, 4);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(598, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 11;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.56938F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.22657F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.261501F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.931042F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.9375F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.640625F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.5661F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.743768F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.743768F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.743768F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.038799F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(587, 277);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Funcionário";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1191, 810);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1191, 118);
            this.panel1.TabIndex = 3;
            // 
            // FormCadFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 810);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormCadFuncionario";
            this.Text = "FormCadFuncionario";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox estadoFuncionario;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelTel1;
        private System.Windows.Forms.Label labelTel2;
        private System.Windows.Forms.MaskedTextBox telefone1Funcionario;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelBairro;
        private System.Windows.Forms.Label labelLog;
        private System.Windows.Forms.TextBox numeroEndFuncionario;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.TextBox cidadeFuncionario;
        private System.Windows.Forms.Label labelCidade;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox logradouroFuncionario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button botLimpar;
        private System.Windows.Forms.Button botaoAdd;
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.TextBox bairroFuncionario;
        private System.Windows.Forms.MaskedTextBox telefone2Funcionario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox nomeFuncionario;
        private System.Windows.Forms.Label labelRG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox rgFuncionario;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.MaskedTextBox cpfFuncionario;
        private System.Windows.Forms.Label labelFuncao;
        private System.Windows.Forms.ComboBox funcaoFuncionario;
    }
}