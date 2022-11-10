namespace Projeto
{
    partial class UC_Vendas
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVendaitem = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpNascimento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.gbVendaitem = new System.Windows.Forms.GroupBox();
            this.numQtd = new System.Windows.Forms.NumericUpDown();
            this.cbProduto = new System.Windows.Forms.ComboBox();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.gbVenda = new System.Windows.Forms.GroupBox();
            this.btnNovavenda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendaitem)).BeginInit();
            this.gbVendaitem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtd)).BeginInit();
            this.gbVenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVendaitem
            // 
            this.dgvVendaitem.AllowUserToAddRows = false;
            this.dgvVendaitem.AllowUserToDeleteRows = false;
            this.dgvVendaitem.AllowUserToResizeRows = false;
            this.dgvVendaitem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVendaitem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendaitem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVendaitem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendaitem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvVendaitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendaitem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvVendaitem.Location = new System.Drawing.Point(330, 28);
            this.dgvVendaitem.Margin = new System.Windows.Forms.Padding(8, 3, 8, 3);
            this.dgvVendaitem.MultiSelect = false;
            this.dgvVendaitem.Name = "dgvVendaitem";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVendaitem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVendaitem.RowHeadersVisible = false;
            this.dgvVendaitem.RowTemplate.Height = 25;
            this.dgvVendaitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendaitem.Size = new System.Drawing.Size(454, 471);
            this.dgvVendaitem.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Produto";
            // 
            // dtpNascimento
            // 
            this.dtpNascimento.Enabled = false;
            this.dtpNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpNascimento.Location = new System.Drawing.Point(69, 80);
            this.dtpNascimento.Name = "dtpNascimento";
            this.dtpNascimento.Size = new System.Drawing.Size(68, 23);
            this.dtpNascimento.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Hora";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Quantidade";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 26;
            this.label4.Text = "Vendedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Cliente";
            // 
            // cbVendedor
            // 
            this.cbVendedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbVendedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Items.AddRange(new object[] {
            "Milas Kei",
            "Volkswagen dos Santos",
            "João Caminhão"});
            this.cbVendedor.Location = new System.Drawing.Point(69, 22);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(231, 23);
            this.cbVendedor.TabIndex = 27;
            // 
            // cbCliente
            // 
            this.cbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Items.AddRange(new object[] {
            "Silas Kando",
            "Gabigol",
            "Honda Cilva"});
            this.cbCliente.Location = new System.Drawing.Point(69, 51);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(231, 23);
            this.cbCliente.TabIndex = 27;
            // 
            // gbVendaitem
            // 
            this.gbVendaitem.Controls.Add(this.numQtd);
            this.gbVendaitem.Controls.Add(this.cbProduto);
            this.gbVendaitem.Controls.Add(this.label3);
            this.gbVendaitem.Controls.Add(this.btnConcluir);
            this.gbVendaitem.Controls.Add(this.btnAdd);
            this.gbVendaitem.Controls.Add(this.label7);
            this.gbVendaitem.Controls.Add(this.label1);
            this.gbVendaitem.Controls.Add(this.txtPreco);
            this.gbVendaitem.Location = new System.Drawing.Point(13, 182);
            this.gbVendaitem.Name = "gbVendaitem";
            this.gbVendaitem.Size = new System.Drawing.Size(306, 144);
            this.gbVendaitem.TabIndex = 28;
            this.gbVendaitem.TabStop = false;
            this.gbVendaitem.Text = "VendaItem";
            // 
            // numQtd
            // 
            this.numQtd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numQtd.Enabled = false;
            this.numQtd.Location = new System.Drawing.Point(81, 45);
            this.numQtd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQtd.Name = "numQtd";
            this.numQtd.Size = new System.Drawing.Size(97, 23);
            this.numQtd.TabIndex = 29;
            this.numQtd.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbProduto
            // 
            this.cbProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProduto.Enabled = false;
            this.cbProduto.FormattingEnabled = true;
            this.cbProduto.Items.AddRange(new object[] {
            "Ração Whiskas Gato 2kg",
            "Ração Magnus Cachorro 1kg",
            "Ração Nike Peixe 14kg"});
            this.cbProduto.Location = new System.Drawing.Point(81, 16);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(219, 23);
            this.cbProduto.TabIndex = 27;
            // 
            // btnConcluir
            // 
            this.btnConcluir.Location = new System.Drawing.Point(105, 115);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(100, 23);
            this.btnConcluir.TabIndex = 21;
            this.btnConcluir.Text = "Concluir Venda";
            this.btnConcluir.UseVisualStyleBackColor = true;
            this.btnConcluir.Visible = false;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(6, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(93, 23);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "Adicionar Item";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 20;
            this.label7.Text = "Preço";
            // 
            // txtPreco
            // 
            this.txtPreco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPreco.Enabled = false;
            this.txtPreco.Location = new System.Drawing.Point(81, 74);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.ReadOnly = true;
            this.txtPreco.Size = new System.Drawing.Size(97, 23);
            this.txtPreco.TabIndex = 12;
            // 
            // gbVenda
            // 
            this.gbVenda.Controls.Add(this.cbVendedor);
            this.gbVenda.Controls.Add(this.cbCliente);
            this.gbVenda.Controls.Add(this.btnNovavenda);
            this.gbVenda.Controls.Add(this.label4);
            this.gbVenda.Controls.Add(this.label6);
            this.gbVenda.Controls.Add(this.label5);
            this.gbVenda.Controls.Add(this.dtpNascimento);
            this.gbVenda.Location = new System.Drawing.Point(13, 28);
            this.gbVenda.Name = "gbVenda";
            this.gbVenda.Size = new System.Drawing.Size(306, 148);
            this.gbVenda.TabIndex = 28;
            this.gbVenda.TabStop = false;
            this.gbVenda.Text = "Venda";
            // 
            // btnNovavenda
            // 
            this.btnNovavenda.Location = new System.Drawing.Point(6, 119);
            this.btnNovavenda.Name = "btnNovavenda";
            this.btnNovavenda.Size = new System.Drawing.Size(83, 23);
            this.btnNovavenda.TabIndex = 21;
            this.btnNovavenda.Text = "Nova Venda";
            this.btnNovavenda.UseVisualStyleBackColor = true;
            this.btnNovavenda.Click += new System.EventHandler(this.btnNovavenda_Click);
            // 
            // UC_Vendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Controls.Add(this.gbVenda);
            this.Controls.Add(this.gbVendaitem);
            this.Controls.Add(this.dgvVendaitem);
            this.Name = "UC_Vendas";
            this.Size = new System.Drawing.Size(792, 502);
            this.Load += new System.EventHandler(this.UC_Vendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendaitem)).EndInit();
            this.gbVendaitem.ResumeLayout(false);
            this.gbVendaitem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQtd)).EndInit();
            this.gbVenda.ResumeLayout(false);
            this.gbVenda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVendaitem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.GroupBox gbVendaitem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.GroupBox gbVenda;
        private System.Windows.Forms.Button btnNovavenda;
        private System.Windows.Forms.ComboBox cbProduto;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnConcluir;
        private System.Windows.Forms.NumericUpDown numQtd;
    }
}
