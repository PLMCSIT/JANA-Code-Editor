namespace JANA_Code_Editor
{
    partial class frmMain
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
            this.syntaxBox = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.document = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.dGridResults = new System.Windows.Forms.DataGridView();
            this.lexeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.token = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRun = new System.Windows.Forms.Button();
            this.picResult = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.grpOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // syntaxBox
            // 
            this.syntaxBox.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBox.AutoListPosition = null;
            this.syntaxBox.AutoListSelectedText = "a123";
            this.syntaxBox.AutoListVisible = false;
            this.syntaxBox.BackColor = System.Drawing.Color.White;
            this.syntaxBox.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBox.CopyAsRTF = false;
            this.syntaxBox.Document = this.document;
            this.syntaxBox.FontName = "Consolas";
            this.syntaxBox.FontSize = 12F;
            this.syntaxBox.HighLightActiveLine = true;
            this.syntaxBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBox.InfoTipCount = 1;
            this.syntaxBox.InfoTipPosition = null;
            this.syntaxBox.InfoTipSelectedIndex = 1;
            this.syntaxBox.InfoTipVisible = false;
            this.syntaxBox.Location = new System.Drawing.Point(13, 55);
            this.syntaxBox.LockCursorUpdate = false;
            this.syntaxBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.syntaxBox.Name = "syntaxBox";
            this.syntaxBox.ShowScopeIndicator = false;
            this.syntaxBox.Size = new System.Drawing.Size(500, 360);
            this.syntaxBox.SmoothScroll = false;
            this.syntaxBox.SplitviewH = -4;
            this.syntaxBox.SplitviewV = -4;
            this.syntaxBox.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.syntaxBox.TabIndex = 0;
            this.syntaxBox.Text = "Code Editor";
            this.syntaxBox.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            // 
            // document
            // 
            this.document.Lines = new string[] {
        "attempt{\r",
        "boolean var\r",
        "char var\r",
        "choice:\r",
        "clean(\r",
        "do{\r",
        "else{\r",
        "elseif{\r",
        "exit(\r",
        "fall:\r",
        "false;\r",
        "get-->\r",
        "handle{\r",
        "int var\r",
        "if\r",
        "iterate\r",
        "main(\r",
        "new var\r",
        "null\r",
        "out-->\r",
        "real var\r",
        "return \"this\"\r",
        "string var\r",
        "strlen\r",
        "struct var\r",
        "stop;\r",
        "test{\r",
        "then{\r",
        "true;\r",
        "tolower(\r",
        "toupper(\r",
        "until\r",
        "void var"};
            this.document.MaxUndoBufferSize = 1000;
            this.document.Modified = false;
            this.document.SyntaxFile = "C:\\Users\\wicoc\\Documents\\Visual Studio 2015\\Projects\\JANA Code Editor\\SyntaxFiles" +
    "\\JANA.syn";
            this.document.UndoStep = 0;
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.txtOutput);
            this.grpOutput.Location = new System.Drawing.Point(13, 426);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(759, 123);
            this.grpOutput.TabIndex = 1;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(7, 29);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(746, 88);
            this.txtOutput.TabIndex = 0;
            // 
            // dGridResults
            // 
            this.dGridResults.AllowUserToAddRows = false;
            this.dGridResults.AllowUserToDeleteRows = false;
            this.dGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lexeme,
            this.token});
            this.dGridResults.Enabled = false;
            this.dGridResults.Location = new System.Drawing.Point(521, 55);
            this.dGridResults.Name = "dGridResults";
            this.dGridResults.ReadOnly = true;
            this.dGridResults.RowHeadersWidth = 4;
            this.dGridResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGridResults.Size = new System.Drawing.Size(251, 360);
            this.dGridResults.TabIndex = 2;
            this.dGridResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGridResults_CellContentClick);
            this.dGridResults.SelectionChanged += new System.EventHandler(this.dGridResults_SelectionChanged);
            // 
            // lexeme
            // 
            this.lexeme.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lexeme.HeaderText = "Lexeme";
            this.lexeme.Name = "lexeme";
            this.lexeme.ReadOnly = true;
            // 
            // token
            // 
            this.token.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.token.HeaderText = "Token";
            this.token.Name = "token";
            this.token.ReadOnly = true;
            // 
            // btnRun
            // 
            this.btnRun.BackgroundImage = global::JANA_Code_Editor.Properties.Resources.compile;
            this.btnRun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRun.Location = new System.Drawing.Point(666, 2);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(50, 50);
            this.btnRun.TabIndex = 4;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // picResult
            // 
            this.picResult.Location = new System.Drawing.Point(722, 2);
            this.picResult.Name = "picResult";
            this.picResult.Size = new System.Drawing.Size(50, 50);
            this.picResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResult.TabIndex = 3;
            this.picResult.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.picResult);
            this.Controls.Add(this.dGridResults);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.syntaxBox);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JANA Code Editor";
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn lexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn token;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.PictureBox picResult;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.BindingSource bindingSource1;
        public Alsing.Windows.Forms.SyntaxBoxControl syntaxBox;
        public Alsing.SourceCode.SyntaxDocument document;
        public System.Windows.Forms.DataGridView dGridResults;
    }
}

