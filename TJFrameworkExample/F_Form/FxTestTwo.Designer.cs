﻿namespace TJFrameworkExample
{
    partial class FxTestTwo
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
      this.LbFormTwo = new Telerik.WinControls.UI.RadLabel();
      this.BtnMessage1 = new Telerik.WinControls.UI.RadButton();
      this.BtnMessage2 = new Telerik.WinControls.UI.RadButton();
      this.BtnMessage3 = new Telerik.WinControls.UI.RadButton();
      this.BtnMessage4 = new Telerik.WinControls.UI.RadButton();
      this.BtnMessage5 = new Telerik.WinControls.UI.RadButton();
      this.TxtMessage = new Telerik.WinControls.UI.RadTextBoxControl();
      this.BtnTestQueue = new Telerik.WinControls.UI.RadButton();
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage3)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage4)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage5)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnTestQueue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // LbFormTwo
      // 
      this.LbFormTwo.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LbFormTwo.ForeColor = System.Drawing.Color.Blue;
      this.LbFormTwo.Location = new System.Drawing.Point(141, 395);
      this.LbFormTwo.Name = "LbFormTwo";
      this.LbFormTwo.Size = new System.Drawing.Size(253, 38);
      this.LbFormTwo.TabIndex = 1;
      this.LbFormTwo.Text = "Form Numer Two";
      // 
      // BtnMessage1
      // 
      this.BtnMessage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnMessage1.Location = new System.Drawing.Point(12, 279);
      this.BtnMessage1.Name = "BtnMessage1";
      this.BtnMessage1.Size = new System.Drawing.Size(122, 25);
      this.BtnMessage1.TabIndex = 2;
      this.BtnMessage1.Text = "Тест сообщение 1";
      // 
      // BtnMessage2
      // 
      this.BtnMessage2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnMessage2.Location = new System.Drawing.Point(57, 51);
      this.BtnMessage2.Name = "BtnMessage2";
      this.BtnMessage2.Size = new System.Drawing.Size(60, 25);
      this.BtnMessage2.TabIndex = 2;
      this.BtnMessage2.Text = "Тест 2";
      // 
      // BtnMessage3
      // 
      this.BtnMessage3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnMessage3.Location = new System.Drawing.Point(57, 106);
      this.BtnMessage3.Name = "BtnMessage3";
      this.BtnMessage3.Size = new System.Drawing.Size(60, 25);
      this.BtnMessage3.TabIndex = 2;
      this.BtnMessage3.Text = "Тест 3";
      // 
      // BtnMessage4
      // 
      this.BtnMessage4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnMessage4.Location = new System.Drawing.Point(57, 162);
      this.BtnMessage4.Name = "BtnMessage4";
      this.BtnMessage4.Size = new System.Drawing.Size(60, 25);
      this.BtnMessage4.TabIndex = 2;
      this.BtnMessage4.Text = "Тест 4";
      // 
      // BtnMessage5
      // 
      this.BtnMessage5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnMessage5.Location = new System.Drawing.Point(57, 221);
      this.BtnMessage5.Name = "BtnMessage5";
      this.BtnMessage5.Size = new System.Drawing.Size(60, 25);
      this.BtnMessage5.TabIndex = 2;
      this.BtnMessage5.Text = "Тест 5";
      // 
      // TxtMessage
      // 
      this.TxtMessage.Location = new System.Drawing.Point(172, 51);
      this.TxtMessage.MaxLength = 90000;
      this.TxtMessage.Multiline = true;
      this.TxtMessage.Name = "TxtMessage";
      this.TxtMessage.Size = new System.Drawing.Size(660, 303);
      this.TxtMessage.TabIndex = 3;
      this.TxtMessage.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      // 
      // BtnTestQueue
      // 
      this.BtnTestQueue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnTestQueue.Location = new System.Drawing.Point(648, 383);
      this.BtnTestQueue.Name = "BtnTestQueue";
      this.BtnTestQueue.Size = new System.Drawing.Size(184, 25);
      this.BtnTestQueue.TabIndex = 2;
      this.BtnTestQueue.Text = "Тестирование очереди";
      // 
      // FxTestTwo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(844, 507);
      this.Controls.Add(this.TxtMessage);
      this.Controls.Add(this.BtnMessage5);
      this.Controls.Add(this.BtnMessage4);
      this.Controls.Add(this.BtnMessage3);
      this.Controls.Add(this.BtnMessage2);
      this.Controls.Add(this.BtnTestQueue);
      this.Controls.Add(this.BtnMessage1);
      this.Controls.Add(this.LbFormTwo);
      this.Name = "FxTestTwo";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "FxTestTwo";
      ((System.ComponentModel.ISupportInitialize)(this.LbFormTwo)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage3)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage4)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnMessage5)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnTestQueue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    private Telerik.WinControls.UI.RadLabel LbFormTwo;
    private Telerik.WinControls.UI.RadButton BtnMessage1;
    private Telerik.WinControls.UI.RadButton BtnMessage2;
    private Telerik.WinControls.UI.RadButton BtnMessage3;
    private Telerik.WinControls.UI.RadButton BtnMessage4;
    private Telerik.WinControls.UI.RadButton BtnMessage5;
    public Telerik.WinControls.UI.RadTextBoxControl TxtMessage;
    public Telerik.WinControls.UI.RadButton BtnTestQueue;
  }
}