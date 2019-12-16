namespace SplatColour
{
    partial class MainForm
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
            this.colourDialog = new System.Windows.Forms.ColorDialog();
            this.btnAlphaColour = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBravoColour = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNeutralColour = new System.Windows.Forms.Button();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // colourDialog
            // 
            this.colourDialog.AnyColor = true;
            this.colourDialog.FullOpen = true;
            // 
            // btnAlphaColour
            // 
            this.btnAlphaColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(88)))), ((int)(((byte)(28)))));
            this.btnAlphaColour.Location = new System.Drawing.Point(411, 13);
            this.btnAlphaColour.Name = "btnAlphaColour";
            this.btnAlphaColour.Size = new System.Drawing.Size(75, 27);
            this.btnAlphaColour.TabIndex = 0;
            this.btnAlphaColour.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Team Alpha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Team Bravo:";
            // 
            // btnBravoColour
            // 
            this.btnBravoColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(148)))));
            this.btnBravoColour.Location = new System.Drawing.Point(411, 43);
            this.btnBravoColour.Name = "btnBravoColour";
            this.btnBravoColour.Size = new System.Drawing.Size(75, 26);
            this.btnBravoColour.TabIndex = 3;
            this.btnBravoColour.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Neutral:";
            // 
            // btnNeutralColour
            // 
            this.btnNeutralColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnNeutralColour.Location = new System.Drawing.Point(411, 74);
            this.btnNeutralColour.Name = "btnNeutralColour";
            this.btnNeutralColour.Size = new System.Drawing.Size(75, 26);
            this.btnNeutralColour.TabIndex = 5;
            this.btnNeutralColour.UseVisualStyleBackColor = false;
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.Color.White;
            this.tbCode.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCode.Location = new System.Drawing.Point(15, 106);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ReadOnly = true;
            this.tbCode.Size = new System.Drawing.Size(473, 238);
            this.tbCode.TabIndex = 6;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(331, 350);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(413, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "params";
            this.saveDialog.Filter = "Parameter files|*.params";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 383);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.btnNeutralColour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBravoColour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAlphaColour);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Colour editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colourDialog;
        private System.Windows.Forms.Button btnAlphaColour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBravoColour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNeutralColour;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveDialog;
    }
}

