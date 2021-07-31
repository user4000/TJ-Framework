namespace TJFrameworkExample
{
  partial class FxTestThree
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
      this.BxTestBigMessage = new Telerik.WinControls.UI.RadButton();
      this.BxTestRemovePreviousAlerts = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.BxTestBigMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTestRemovePreviousAlerts)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // BxTestBigMessage
      // 
      this.BxTestBigMessage.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BxTestBigMessage.Location = new System.Drawing.Point(19, 21);
      this.BxTestBigMessage.Name = "BxTestBigMessage";
      this.BxTestBigMessage.Size = new System.Drawing.Size(194, 35);
      this.BxTestBigMessage.TabIndex = 0;
      this.BxTestBigMessage.Text = "Тест большие сообщения";
      // 
      // BxTestRemovePreviousAlerts
      // 
      this.BxTestRemovePreviousAlerts.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BxTestRemovePreviousAlerts.Location = new System.Drawing.Point(248, 21);
      this.BxTestRemovePreviousAlerts.Name = "BxTestRemovePreviousAlerts";
      this.BxTestRemovePreviousAlerts.Size = new System.Drawing.Size(285, 35);
      this.BxTestRemovePreviousAlerts.TabIndex = 0;
      this.BxTestRemovePreviousAlerts.Text = "Тест метода Remove Previous Alerts";
      // 
      // FxTestThree
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(887, 470);
      this.Controls.Add(this.BxTestRemovePreviousAlerts);
      this.Controls.Add(this.BxTestBigMessage);
      this.Name = "FxTestThree";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "FxTestThree";
      ((System.ComponentModel.ISupportInitialize)(this.BxTestBigMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BxTestRemovePreviousAlerts)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private Telerik.WinControls.UI.RadButton BxTestBigMessage;
    public Telerik.WinControls.UI.RadButton BxTestRemovePreviousAlerts;
  }
}
