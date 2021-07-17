
namespace MusicLib.Control
{
    partial class ConfigControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathLabel = new System.Windows.Forms.Label();
            this.serverEnabledLabel = new System.Windows.Forms.Label();
            this.pathControl = new System.Windows.Forms.Button();
            this.serverEnabledControl = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pathLabel
            // 
            this.pathLabel.ForeColor = System.Drawing.Color.Purple;
            this.pathLabel.Location = new System.Drawing.Point(10, 10);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(200, 30);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "Music Path";
            // 
            // serverEnabledLabel
            // 
            this.serverEnabledLabel.ForeColor = System.Drawing.Color.Purple;
            this.serverEnabledLabel.Location = new System.Drawing.Point(10, 60);
            this.serverEnabledLabel.Name = "serverEnabledLabel";
            this.serverEnabledLabel.Size = new System.Drawing.Size(200, 13);
            this.serverEnabledLabel.TabIndex = 1;
            this.serverEnabledLabel.Text = "Server Enabled";
            // 
            // pathControl
            // 
            this.pathControl.ForeColor = System.Drawing.Color.Purple;
            this.pathControl.Location = new System.Drawing.Point(220, 10);
            this.pathControl.Name = "pathControl";
            this.pathControl.Size = new System.Drawing.Size(200, 30);
            this.pathControl.TabIndex = 2;
            this.pathControl.Text = "Chooise";
            this.pathControl.UseVisualStyleBackColor = true;
            this.pathControl.Click += new System.EventHandler(this.PathControl_Click);
            // 
            // serverEnabledControl
            // 
            this.serverEnabledControl.Location = new System.Drawing.Point(220, 63);
            this.serverEnabledControl.Name = "serverEnabledControl";
            this.serverEnabledControl.Size = new System.Drawing.Size(10, 10);
            this.serverEnabledControl.TabIndex = 3;
            this.serverEnabledControl.UseVisualStyleBackColor = true;
            this.serverEnabledControl.CheckStateChanged += new System.EventHandler(this.ServerEnabledControl_CheckStateChanged);
            // 
            // ConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.serverEnabledControl);
            this.Controls.Add(this.pathControl);
            this.Controls.Add(this.serverEnabledLabel);
            this.Controls.Add(this.pathLabel);
            this.Name = "ConfigControl";
            this.Size = new System.Drawing.Size(1200, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label serverEnabledLabel;
        private System.Windows.Forms.Button pathControl;
        private System.Windows.Forms.CheckBox serverEnabledControl;
    }
}
