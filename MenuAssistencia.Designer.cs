namespace Assistencia_Técnica
{
    partial class MenuAssistencia
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAssistencia));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Hora = new System.Windows.Forms.Label();
            this.Data = new System.Windows.Forms.Label();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sair = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CadServico = new System.Windows.Forms.Button();
            this.CadProduto = new System.Windows.Forms.Button();
            this.CadFuncionario = new System.Windows.Forms.Button();
            this.CadCliente = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ordemServico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(-8, 177);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(351, 322);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(-322, -28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1060, 179);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.Hora);
            this.panel1.Controls.Add(this.Data);
            this.panel1.Controls.Add(this.labelUsuario);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 524);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(338, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 147);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // Hora
            // 
            this.Hora.AutoSize = true;
            this.Hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hora.Location = new System.Drawing.Point(1, 44);
            this.Hora.Name = "Hora";
            this.Hora.Size = new System.Drawing.Size(288, 20);
            this.Hora.TabIndex = 3;
            this.Hora.Text = "segunda-feira, XX de XXXXX de XXXX";
            // 
            // Data
            // 
            this.Data.AutoSize = true;
            this.Data.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Data.Location = new System.Drawing.Point(5, 72);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(89, 20);
            this.Data.TabIndex = 2;
            this.Data.Text = "HH:MM:SS";
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(1, 14);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(315, 26);
            this.labelUsuario.TabIndex = 1;
            this.labelUsuario.Text = "Bem-Vindo(a), ${nomeUsuario}";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.sair);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(-2, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(996, 139);
            this.panel2.TabIndex = 3;
            // 
            // sair
            // 
            this.sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sair.AutoSize = true;
            this.sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.sair.Location = new System.Drawing.Point(918, 11);
            this.sair.Name = "sair";
            this.sair.Size = new System.Drawing.Size(62, 31);
            this.sair.TabIndex = 2;
            this.sair.Text = "Sair";
            this.sair.Click += new System.EventHandler(this.sair_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.CadServico, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.CadProduto, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.CadFuncionario, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.CadCliente, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(340, 147);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(634, 111);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // CadServico
            // 
            this.CadServico.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CadServico.BackColor = System.Drawing.SystemColors.Highlight;
            this.CadServico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CadServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CadServico.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CadServico.Location = new System.Drawing.Point(477, 3);
            this.CadServico.Name = "CadServico";
            this.CadServico.Size = new System.Drawing.Size(154, 105);
            this.CadServico.TabIndex = 3;
            this.CadServico.Text = "Gerenciar Serviços";
            this.CadServico.UseVisualStyleBackColor = false;
            this.CadServico.Click += new System.EventHandler(this.CadServico_Click);
            // 
            // CadProduto
            // 
            this.CadProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CadProduto.BackColor = System.Drawing.SystemColors.Highlight;
            this.CadProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CadProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CadProduto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CadProduto.Location = new System.Drawing.Point(319, 3);
            this.CadProduto.Name = "CadProduto";
            this.CadProduto.Size = new System.Drawing.Size(152, 105);
            this.CadProduto.TabIndex = 2;
            this.CadProduto.Text = "Gerenciar Produtos";
            this.CadProduto.UseVisualStyleBackColor = false;
            this.CadProduto.Click += new System.EventHandler(this.CadProduto_Click);
            // 
            // CadFuncionario
            // 
            this.CadFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CadFuncionario.BackColor = System.Drawing.SystemColors.Highlight;
            this.CadFuncionario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CadFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CadFuncionario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CadFuncionario.Location = new System.Drawing.Point(161, 3);
            this.CadFuncionario.Name = "CadFuncionario";
            this.CadFuncionario.Size = new System.Drawing.Size(152, 105);
            this.CadFuncionario.TabIndex = 1;
            this.CadFuncionario.Text = "Gerenciar Funcionários";
            this.CadFuncionario.UseVisualStyleBackColor = false;
            this.CadFuncionario.Click += new System.EventHandler(this.CadFuncionario_Click);
            // 
            // CadCliente
            // 
            this.CadCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CadCliente.BackColor = System.Drawing.SystemColors.Highlight;
            this.CadCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CadCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CadCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CadCliente.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CadCliente.Location = new System.Drawing.Point(3, 3);
            this.CadCliente.Name = "CadCliente";
            this.CadCliente.Size = new System.Drawing.Size(152, 105);
            this.CadCliente.TabIndex = 0;
            this.CadCliente.Text = "Gerenciar Clientes";
            this.CadCliente.UseVisualStyleBackColor = false;
            this.CadCliente.Click += new System.EventHandler(this.CadCliente_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.ordemServico, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(343, 274);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(635, 338);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // ordemServico
            // 
            this.ordemServico.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordemServico.BackColor = System.Drawing.Color.SteelBlue;
            this.ordemServico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ordemServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordemServico.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ordemServico.Location = new System.Drawing.Point(3, 3);
            this.ordemServico.Name = "ordemServico";
            this.ordemServico.Size = new System.Drawing.Size(629, 332);
            this.ordemServico.TabIndex = 0;
            this.ordemServico.Text = "Gerar Ordem de Serviço";
            this.ordemServico.UseVisualStyleBackColor = false;
            this.ordemServico.Click += new System.EventHandler(this.ordemServico_Click);
            // 
            // MenuAssistencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 628);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MenuAssistencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.MenuAssistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label Hora;
        private System.Windows.Forms.Label Data;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button CadServico;
        private System.Windows.Forms.Button CadProduto;
        private System.Windows.Forms.Button CadFuncionario;
        private System.Windows.Forms.Button CadCliente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button ordemServico;
        private System.Windows.Forms.Label sair;
    }
}