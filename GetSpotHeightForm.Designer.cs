namespace GetSpotHeights
{
    partial class GetSpotHeightForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.blockDwgBtn = new System.Windows.Forms.Button();
            this.checkEveryVertext = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.blockScaleTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.plotButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.plineLengthLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Block to insert:";
            // 
            // blockDwgBtn
            // 
            this.blockDwgBtn.Location = new System.Drawing.Point(122, 22);
            this.blockDwgBtn.Name = "blockDwgBtn";
            this.blockDwgBtn.Size = new System.Drawing.Size(132, 23);
            this.blockDwgBtn.TabIndex = 1;
            this.blockDwgBtn.Text = "......";
            this.blockDwgBtn.UseVisualStyleBackColor = true;
            this.blockDwgBtn.Click += new System.EventHandler(this.blockDwgBtn_Click);
            // 
            // checkEveryVertext
            // 
            this.checkEveryVertext.AutoSize = true;
            this.checkEveryVertext.Location = new System.Drawing.Point(19, 69);
            this.checkEveryVertext.Name = "checkEveryVertext";
            this.checkEveryVertext.Size = new System.Drawing.Size(159, 17);
            this.checkEveryVertext.TabIndex = 2;
            this.checkEveryVertext.Text = "Or put height in every vertex";
            this.checkEveryVertext.UseVisualStyleBackColor = true;
            this.checkEveryVertext.CheckedChanged += new System.EventHandler(this.checkEveryVertext_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Offset(m):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.blockScaleTxtBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.blockDwgBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 103);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Block Details";
            // 
            // blockScaleTxtBox
            // 
            this.blockScaleTxtBox.Location = new System.Drawing.Point(122, 63);
            this.blockScaleTxtBox.Name = "blockScaleTxtBox";
            this.blockScaleTxtBox.Size = new System.Drawing.Size(37, 20);
            this.blockScaleTxtBox.TabIndex = 3;
            this.blockScaleTxtBox.Text = "1.0";
            this.blockScaleTxtBox.Leave += new System.EventHandler(this.blockScaleTxtBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Block Scale:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.plineLengthLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.checkEveryVertext);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 106);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Labelling Options";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(88, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "6.0";
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // plotButton
            // 
            this.plotButton.Enabled = false;
            this.plotButton.Location = new System.Drawing.Point(61, 236);
            this.plotButton.Name = "plotButton";
            this.plotButton.Size = new System.Drawing.Size(198, 23);
            this.plotButton.TabIndex = 1;
            this.plotButton.Text = "Plot Heights";
            this.plotButton.UseVisualStyleBackColor = true;
            this.plotButton.Click += new System.EventHandler(this.plotButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selected Pline Length:";
            // 
            // plineLengthLabel
            // 
            this.plineLengthLabel.AutoSize = true;
            this.plineLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plineLengthLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.plineLengthLabel.Location = new System.Drawing.Point(136, 42);
            this.plineLengthLabel.Name = "plineLengthLabel";
            this.plineLengthLabel.Size = new System.Drawing.Size(13, 13);
            this.plineLengthLabel.TabIndex = 0;
            this.plineLengthLabel.Text = "0";
            // 
            // GetSpotHeightForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 273);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.plotButton);
            this.Name = "GetSpotHeightForm";
            this.Text = "Get Spot Heights";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button blockDwgBtn;
        private System.Windows.Forms.CheckBox checkEveryVertext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox blockScaleTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button plotButton;
        private System.Windows.Forms.Label plineLengthLabel;
        private System.Windows.Forms.Label label2;
    }
}