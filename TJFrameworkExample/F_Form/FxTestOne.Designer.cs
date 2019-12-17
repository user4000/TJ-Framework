namespace TJFrameworkExample
{
  partial class FxTestOne
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
      Telerik.WinControls.UI.ListViewDataItem listViewDataItem1 = new Telerik.WinControls.UI.ListViewDataItem("1");
      Telerik.WinControls.UI.ListViewDataItem listViewDataItem2 = new Telerik.WinControls.UI.ListViewDataItem("2");
      Telerik.WinControls.UI.ListViewDataItem listViewDataItem3 = new Telerik.WinControls.UI.ListViewDataItem("3");
      this.LxTest = new Telerik.WinControls.UI.RadLabel();
      this.LvNumbers = new Telerik.WinControls.UI.RadListView();
      this.BtnEnable = new Telerik.WinControls.UI.RadButton();
      this.BtnDisable = new Telerik.WinControls.UI.RadButton();
      this.BtnShow = new Telerik.WinControls.UI.RadButton();
      this.BtnHide = new Telerik.WinControls.UI.RadButton();
      this.BtnGoto = new Telerik.WinControls.UI.RadButton();
      this.radTextBoxControl1 = new Telerik.WinControls.UI.RadTextBoxControl();
      this.radTextBoxControl2 = new Telerik.WinControls.UI.RadTextBoxControl();
      this.BtnAlert = new Telerik.WinControls.UI.RadButton();
      this.BtnMessage = new Telerik.WinControls.UI.RadButton();
      this.BtnPageViewOrientation = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.LxTest)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LvNumbers)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnEnable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnDisable)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnShow)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnHide)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnGoto)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnAlert)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnPageViewOrientation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // LxTest
      // 
      this.LxTest.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LxTest.ForeColor = System.Drawing.Color.Fuchsia;
      this.LxTest.Location = new System.Drawing.Point(23, 12);
      this.LxTest.Name = "LxTest";
      this.LxTest.Size = new System.Drawing.Size(309, 38);
      this.LxTest.TabIndex = 1;
      this.LxTest.Text = "Тестируем страницы";
      // 
      // LvNumbers
      // 
      this.LvNumbers.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      listViewDataItem1.Text = "1";
      listViewDataItem2.Text = "2";
      listViewDataItem3.Text = "3";
      this.LvNumbers.Items.AddRange(new Telerik.WinControls.UI.ListViewDataItem[] {
            listViewDataItem1,
            listViewDataItem2,
            listViewDataItem3});
      this.LvNumbers.Location = new System.Drawing.Point(23, 65);
      this.LvNumbers.Name = "LvNumbers";
      this.LvNumbers.ShowGridLines = true;
      this.LvNumbers.Size = new System.Drawing.Size(206, 66);
      this.LvNumbers.TabIndex = 2;
      // 
      // BtnEnable
      // 
      this.BtnEnable.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnEnable.Location = new System.Drawing.Point(389, 65);
      this.BtnEnable.Name = "BtnEnable";
      this.BtnEnable.Size = new System.Drawing.Size(93, 27);
      this.BtnEnable.TabIndex = 3;
      this.BtnEnable.Text = "Enable";
      // 
      // BtnDisable
      // 
      this.BtnDisable.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnDisable.Location = new System.Drawing.Point(502, 65);
      this.BtnDisable.Name = "BtnDisable";
      this.BtnDisable.Size = new System.Drawing.Size(93, 27);
      this.BtnDisable.TabIndex = 3;
      this.BtnDisable.Text = "Disable";
      // 
      // BtnShow
      // 
      this.BtnShow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnShow.Location = new System.Drawing.Point(389, 104);
      this.BtnShow.Name = "BtnShow";
      this.BtnShow.Size = new System.Drawing.Size(93, 27);
      this.BtnShow.TabIndex = 3;
      this.BtnShow.Text = "Show";
      // 
      // BtnHide
      // 
      this.BtnHide.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnHide.Location = new System.Drawing.Point(502, 104);
      this.BtnHide.Name = "BtnHide";
      this.BtnHide.Size = new System.Drawing.Size(93, 27);
      this.BtnHide.TabIndex = 3;
      this.BtnHide.Text = "Hide";
      // 
      // BtnGoto
      // 
      this.BtnGoto.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnGoto.Location = new System.Drawing.Point(251, 65);
      this.BtnGoto.Name = "BtnGoto";
      this.BtnGoto.Size = new System.Drawing.Size(93, 27);
      this.BtnGoto.TabIndex = 3;
      this.BtnGoto.Text = "Goto";
      // 
      // radTextBoxControl1
      // 
      this.radTextBoxControl1.Font = new System.Drawing.Font("Wingdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
      this.radTextBoxControl1.Location = new System.Drawing.Point(5, 137);
      this.radTextBoxControl1.MaxLength = 2000;
      this.radTextBoxControl1.Multiline = true;
      this.radTextBoxControl1.Name = "radTextBoxControl1";
      this.radTextBoxControl1.Size = new System.Drawing.Size(861, 179);
      this.radTextBoxControl1.TabIndex = 4;
      // 
      // radTextBoxControl2
      // 
      this.radTextBoxControl2.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
      this.radTextBoxControl2.Location = new System.Drawing.Point(5, 322);
      this.radTextBoxControl2.MaxLength = 2000;
      this.radTextBoxControl2.Multiline = true;
      this.radTextBoxControl2.Name = "radTextBoxControl2";
      this.radTextBoxControl2.Size = new System.Drawing.Size(861, 178);
      this.radTextBoxControl2.TabIndex = 4;
      // 
      // BtnAlert
      // 
      this.BtnAlert.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnAlert.Location = new System.Drawing.Point(389, 23);
      this.BtnAlert.Name = "BtnAlert";
      this.BtnAlert.Size = new System.Drawing.Size(93, 27);
      this.BtnAlert.TabIndex = 3;
      this.BtnAlert.Text = "Alert";
      // 
      // BtnMessage
      // 
      this.BtnMessage.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnMessage.Location = new System.Drawing.Point(502, 23);
      this.BtnMessage.Name = "BtnMessage";
      this.BtnMessage.Size = new System.Drawing.Size(93, 27);
      this.BtnMessage.TabIndex = 5;
      this.BtnMessage.Text = "Message";
      this.BtnMessage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      // 
      // BtnPageViewOrientation
      // 
      this.BtnPageViewOrientation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnPageViewOrientation.Location = new System.Drawing.Point(657, 65);
      this.BtnPageViewOrientation.Name = "BtnPageViewOrientation";
      this.BtnPageViewOrientation.Size = new System.Drawing.Size(93, 27);
      this.BtnPageViewOrientation.TabIndex = 3;
      this.BtnPageViewOrientation.Text = "Orientation";
      // 
      // FxTestOne
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(870, 503);
      this.Controls.Add(this.BtnMessage);
      this.Controls.Add(this.radTextBoxControl2);
      this.Controls.Add(this.radTextBoxControl1);
      this.Controls.Add(this.BtnDisable);
      this.Controls.Add(this.BtnHide);
      this.Controls.Add(this.BtnShow);
      this.Controls.Add(this.BtnAlert);
      this.Controls.Add(this.BtnPageViewOrientation);
      this.Controls.Add(this.BtnGoto);
      this.Controls.Add(this.BtnEnable);
      this.Controls.Add(this.LvNumbers);
      this.Controls.Add(this.LxTest);
      this.Name = "FxTestOne";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "RadForm1";
      ((System.ComponentModel.ISupportInitialize)(this.LxTest)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LvNumbers)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnEnable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnDisable)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnShow)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnHide)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnGoto)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnAlert)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnPageViewOrientation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Telerik.WinControls.UI.RadLabel LxTest;
    public Telerik.WinControls.UI.RadListView LvNumbers;
    private Telerik.WinControls.UI.RadButton BtnEnable;
    private Telerik.WinControls.UI.RadButton BtnDisable;
    private Telerik.WinControls.UI.RadButton BtnShow;
    private Telerik.WinControls.UI.RadButton BtnHide;
    private Telerik.WinControls.UI.RadButton BtnGoto;
    private Telerik.WinControls.UI.RadTextBoxControl radTextBoxControl1;
    private Telerik.WinControls.UI.RadTextBoxControl radTextBoxControl2;
    private Telerik.WinControls.UI.RadButton BtnAlert;
    public Telerik.WinControls.UI.RadButton BtnMessage;
    private Telerik.WinControls.UI.RadButton BtnPageViewOrientation;
  }
}