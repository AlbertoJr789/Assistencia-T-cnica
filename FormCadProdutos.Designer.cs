namespace Assistencia_Técnica
{
    partial class FormCadProdutos
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
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.botLimpar = new System.Windows.Forms.Button();
            this.botaoAdd = new System.Windows.Forms.Button();
            this.botCancelar = new System.Windows.Forms.Button();
            this.labelDescricao = new System.Windows.Forms.Label();
            this.labelEstoque = new System.Windows.Forms.Label();
            this.labelPreco = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.descricao = new System.Windows.Forms.TextBox();
            this.estoque = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.preco = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estoque)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.Location = new System.Drawing.Point(3, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Campos marcados com (*) requerem preenchimento obrigatório\r\n";
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 469);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(436, 118);
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
            this.botLimpar.Location = new System.Drawing.Point(148, 3);
            this.botLimpar.Name = "botLimpar";
            this.botLimpar.Size = new System.Drawing.Size(139, 112);
            this.botLimpar.TabIndex = 1;
            this.botLimpar.Text = "Limpar";
            this.botLimpar.UseVisualStyleBackColor = false;
            this.botLimpar.Click += new System.EventHandler(this.botLimpar_Click);
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
            this.botaoAdd.Size = new System.Drawing.Size(139, 112);
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
            this.botCancelar.Location = new System.Drawing.Point(293, 3);
            this.botCancelar.Name = "botCancelar";
            this.botCancelar.Size = new System.Drawing.Size(140, 112);
            this.botCancelar.TabIndex = 2;
            this.botCancelar.Text = "Sair";
            this.botCancelar.UseVisualStyleBackColor = false;
            this.botCancelar.Click += new System.EventHandler(this.botCancelar_Click);
            // 
            // labelDescricao
            // 
            this.labelDescricao.AutoSize = true;
            this.labelDescricao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelDescricao.Location = new System.Drawing.Point(3, 0);
            this.labelDescricao.Name = "labelDescricao";
            this.labelDescricao.Size = new System.Drawing.Size(130, 26);
            this.labelDescricao.TabIndex = 4;
            this.labelDescricao.Text = "Descrição * ";
            // 
            // labelEstoque
            // 
            this.labelEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEstoque.AutoSize = true;
            this.labelEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelEstoque.Location = new System.Drawing.Point(3, 221);
            this.labelEstoque.Name = "labelEstoque";
            this.labelEstoque.Size = new System.Drawing.Size(424, 35);
            this.labelEstoque.TabIndex = 6;
            this.labelEstoque.Text = "Estoque *";
            // 
            // labelPreco
            // 
            this.labelPreco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPreco.AutoSize = true;
            this.labelPreco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelPreco.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelPreco.Location = new System.Drawing.Point(3, 102);
            this.labelPreco.Name = "labelPreco";
            this.labelPreco.Size = new System.Drawing.Size(424, 36);
            this.labelPreco.TabIndex = 14;
            this.labelPreco.Text = "Preço *";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.descricao, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelPreco, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.preco, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.labelDescricao, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelEstoque, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.estoque, 0, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.913669F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.14868F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.913669F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.352518F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.633094F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.673861F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.70983F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.80169F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(430, 463);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // descricao
            // 
            this.descricao.BackColor = System.Drawing.SystemColors.Window;
            this.descricao.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.descricao.Location = new System.Drawing.Point(3, 39);
            this.descricao.Name = "descricao";
            this.descricao.Size = new System.Drawing.Size(203, 20);
            this.descricao.TabIndex = 5;
            this.descricao.TextChanged += new System.EventHandler(this.descricao_TextChanged);
            // 
            // estoque
            // 
            this.estoque.Location = new System.Drawing.Point(3, 259);
            this.estoque.Name = "estoque";
            this.estoque.Size = new System.Drawing.Size(203, 20);
            this.estoque.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.80989F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 469F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 469F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 469F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(436, 469);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.label1.Size = new System.Drawing.Size(389, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Produto";
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
            this.splitContainer1.Size = new System.Drawing.Size(436, 709);
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
            this.panel1.Size = new System.Drawing.Size(436, 118);
            this.panel1.TabIndex = 3;
            // 
            // preco
            // 
            this.preco.Location = new System.Drawing.Point(3, 141);
            this.preco.Name = "preco";
            this.preco.Size = new System.Drawing.Size(203, 20);
            this.preco.TabIndex = 16;
            this.preco.TextChanged += new System.EventHandler(this.preco_TextChanged);
            this.preco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.preco_KeyPress);
            this.preco.KeyUp += new System.Windows.Forms.KeyEventHandler(this.preco_KeyUp);
            this.preco.Leave += new System.EventHandler(this.preco_Leave);
            // 
            // FormCadProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 709);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormCadProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.estoque)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button botLimpar;
        private System.Windows.Forms.Button botaoAdd;
        private System.Windows.Forms.Button botCancelar;
        private System.Windows.Forms.Label labelDescricao;
        private System.Windows.Forms.Label labelEstoque;
        private System.Windows.Forms.Label labelPreco;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox descricao;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown estoque;
        private System.Windows.Forms.MaskedTextBox preco;
    }
}