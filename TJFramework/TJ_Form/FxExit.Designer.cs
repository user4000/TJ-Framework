namespace TJFramework.Form
{
    partial class FxExit
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
      this.BtnExit = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // BtnExit
      // 
      this.BtnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.BtnExit.AutoSize = true;
      this.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand;
      this.BtnExit.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnExit.Location = new System.Drawing.Point(139, 218);
      this.BtnExit.Name = "BtnExit";
      this.BtnExit.Padding = new System.Windows.Forms.Padding(5);
      this.BtnExit.Size = new System.Drawing.Size(213, 28);
      this.BtnExit.TabIndex = 0;
      this.BtnExit.Text = "Click this button to confirm exit";
      this.BtnExit.TextWrap = true;
      // 
      // FxExit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(492, 470);
      this.Controls.Add(this.BtnExit);
      this.Name = "FxExit";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "FxExit";
      ((System.ComponentModel.ISupportInitialize)(this.BtnExit)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    public Telerik.WinControls.UI.RadButton BtnExit;
  }
}
