namespace excounter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkedListBoxColumns = new System.Windows.Forms.CheckedListBox();
            this.buttonSearchCalculate = new System.Windows.Forms.Button();
            this.textBoxOutputs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBoxColumns
            // 
            this.checkedListBoxColumns.FormattingEnabled = true;
            this.checkedListBoxColumns.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.checkedListBoxColumns.Location = new System.Drawing.Point(12, 28);
            this.checkedListBoxColumns.Name = "checkedListBoxColumns";
            this.checkedListBoxColumns.Size = new System.Drawing.Size(85, 394);
            this.checkedListBoxColumns.TabIndex = 0;
            // 
            // buttonSearchCalculate
            // 
            this.buttonSearchCalculate.Location = new System.Drawing.Point(103, 399);
            this.buttonSearchCalculate.Name = "buttonSearchCalculate";
            this.buttonSearchCalculate.Size = new System.Drawing.Size(339, 23);
            this.buttonSearchCalculate.TabIndex = 1;
            this.buttonSearchCalculate.Text = "Search and Calculate";
            this.buttonSearchCalculate.UseVisualStyleBackColor = true;
            this.buttonSearchCalculate.Click += new System.EventHandler(this.buttonSearchCalculate_Click);
            // 
            // textBoxOutputs
            // 
            this.textBoxOutputs.Location = new System.Drawing.Point(103, 12);
            this.textBoxOutputs.Multiline = true;
            this.textBoxOutputs.Name = "textBoxOutputs";
            this.textBoxOutputs.ReadOnly = true;
            this.textBoxOutputs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutputs.Size = new System.Drawing.Size(339, 381);
            this.textBoxOutputs.TabIndex = 2;
            this.textBoxOutputs.TextChanged += new System.EventHandler(this.textBoxOutputs_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Include Columns";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOutputs);
            this.Controls.Add(this.buttonSearchCalculate);
            this.Controls.Add(this.checkedListBoxColumns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Excel character counter by Neo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxColumns;
        private System.Windows.Forms.Button buttonSearchCalculate;
        private System.Windows.Forms.TextBox textBoxOutputs;
        private System.Windows.Forms.Label label1;
    }
}

