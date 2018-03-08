namespace Xipho_HAL_LU_LVL_JSON_Generator {
    partial class MainWindow {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DropDown_Open = new System.Windows.Forms.ToolStripDropDownButton();
            this.DropDown_Save = new System.Windows.Forms.ToolStripDropDownButton();
            this.CreditsButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.ToolStrip_OpenLUZ = new System.Windows.Forms.ToolStripMenuItem();
            this.LUZOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DropDown_Open,
            this.DropDown_Save,
            this.CreditsButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DropDown_Open
            // 
            this.DropDown_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DropDown_Open.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip_OpenLUZ});
            this.DropDown_Open.Image = ((System.Drawing.Image)(resources.GetObject("DropDown_Open.Image")));
            this.DropDown_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DropDown_Open.Name = "DropDown_Open";
            this.DropDown_Open.Size = new System.Drawing.Size(49, 22);
            this.DropDown_Open.Text = "Open";
            // 
            // DropDown_Save
            // 
            this.DropDown_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DropDown_Save.Image = ((System.Drawing.Image)(resources.GetObject("DropDown_Save.Image")));
            this.DropDown_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DropDown_Save.Name = "DropDown_Save";
            this.DropDown_Save.Size = new System.Drawing.Size(44, 22);
            this.DropDown_Save.Text = "Save";
            this.DropDown_Save.ToolTipText = "Save";
            // 
            // CreditsButton
            // 
            this.CreditsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CreditsButton.Image = ((System.Drawing.Image)(resources.GetObject("CreditsButton.Image")));
            this.CreditsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.Size = new System.Drawing.Size(48, 22);
            this.CreditsButton.Text = "Credits";
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText});
            this.statusStrip.Location = new System.Drawing.Point(0, 379);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(782, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(72, 17);
            this.StatusText.Text = "Uninitialized";
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(782, 354);
            this.treeView.TabIndex = 2;
            // 
            // ToolStrip_OpenLUZ
            // 
            this.ToolStrip_OpenLUZ.Name = "ToolStrip_OpenLUZ";
            this.ToolStrip_OpenLUZ.Size = new System.Drawing.Size(152, 22);
            this.ToolStrip_OpenLUZ.Text = "Open LUZ";
            this.ToolStrip_OpenLUZ.Click += new System.EventHandler(this.ToolStrip_OpenLUZ_Click);
            // 
            // LUZOpenFileDialog
            // 
            this.LUZOpenFileDialog.Filter = "LU World|*.luz";
            this.LUZOpenFileDialog.Title = "Select .luz File";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 401);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainWindow";
            this.Text = "Xipho\'s HAL-LU Json Generator by Simon Nitzsche";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton DropDown_Open;
        private System.Windows.Forms.ToolStripDropDownButton DropDown_Save;
        private System.Windows.Forms.ToolStripButton CreditsButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_OpenLUZ;
        private System.Windows.Forms.OpenFileDialog LUZOpenFileDialog;
    }
}

