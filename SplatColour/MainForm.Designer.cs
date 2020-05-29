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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.fileList = new System.Windows.Forms.ListView();
            this.lvColumnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuSetParamsDir = new System.Windows.Forms.MenuItem();
            this.menuSave = new System.Windows.Forms.MenuItem();
            this.menuLoad = new System.Windows.Forms.MenuItem();
            this.menuCopy = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
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
            this.btnAlphaColour.Location = new System.Drawing.Point(582, 10);
            this.btnAlphaColour.Name = "btnAlphaColour";
            this.btnAlphaColour.Size = new System.Drawing.Size(75, 27);
            this.btnAlphaColour.TabIndex = 0;
            this.btnAlphaColour.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Team Alpha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Team Bravo:";
            // 
            // btnBravoColour
            // 
            this.btnBravoColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(148)))));
            this.btnBravoColour.Location = new System.Drawing.Point(582, 43);
            this.btnBravoColour.Name = "btnBravoColour";
            this.btnBravoColour.Size = new System.Drawing.Size(75, 26);
            this.btnBravoColour.TabIndex = 3;
            this.btnBravoColour.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Neutral:";
            // 
            // btnNeutralColour
            // 
            this.btnNeutralColour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.btnNeutralColour.Location = new System.Drawing.Point(582, 74);
            this.btnNeutralColour.Name = "btnNeutralColour";
            this.btnNeutralColour.Size = new System.Drawing.Size(75, 26);
            this.btnNeutralColour.TabIndex = 5;
            this.btnNeutralColour.UseVisualStyleBackColor = false;
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.Color.White;
            this.tbCode.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCode.Location = new System.Drawing.Point(187, 122);
            this.tbCode.Multiline = true;
            this.tbCode.Name = "tbCode";
            this.tbCode.ReadOnly = true;
            this.tbCode.Size = new System.Drawing.Size(473, 242);
            this.tbCode.TabIndex = 6;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(503, 370);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(585, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save As";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "params";
            this.saveDialog.Filter = "Parameter files|*.params";
            this.saveDialog.Title = "Save ink colour parameters";
            // 
            // openDialog
            // 
            this.openDialog.FileName = "openFileDialog1";
            this.openDialog.Filter = "Parameter files|*.params";
            this.openDialog.Title = "Open ink colour parameters";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Generated .params file:";
            // 
            // fileList
            // 
            this.fileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvColumnName});
            this.fileList.FullRowSelect = true;
            this.fileList.Location = new System.Drawing.Point(13, 13);
            this.fileList.MultiSelect = false;
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(167, 380);
            this.fileList.TabIndex = 11;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.Details;
            this.fileList.SelectedIndexChanged += new System.EventHandler(this.fileList_SelectedIndexChanged);
            // 
            // lvColumnName
            // 
            this.lvColumnName.Text = "Name";
            this.lvColumnName.Width = 300;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuLoad,
            this.menuSave,
            this.menuCopy});
            this.menuItem1.Text = "File";
            // 
            // menuSetParamsDir
            // 
            this.menuSetParamsDir.Index = 0;
            this.menuSetParamsDir.Text = "Set Params directory";
            this.menuSetParamsDir.Click += new System.EventHandler(this.menuSetParamsDir_Click);
            // 
            // menuSave
            // 
            this.menuSave.Index = 1;
            this.menuSave.Text = "Save As";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuLoad
            // 
            this.menuLoad.Index = 0;
            this.menuLoad.Text = "Open";
            this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
            // 
            // menuCopy
            // 
            this.menuCopy.Index = 2;
            this.menuCopy.Text = "Copy";
            this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSetParamsDir});
            this.menuItem2.Text = "Options";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            this.menuItem3.Text = "Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 405);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.label4);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "SplatColour";
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
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ColumnHeader lvColumnName;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuSetParamsDir;
        private System.Windows.Forms.MenuItem menuSave;
        private System.Windows.Forms.MenuItem menuLoad;
        private System.Windows.Forms.MenuItem menuCopy;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuAbout;
    }
}

