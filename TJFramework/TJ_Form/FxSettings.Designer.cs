namespace TJFramework.Form
{
    partial class FxSettings
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
      this.PnTool = new Telerik.WinControls.UI.RadPanel();
      this.BtnSaveSettings = new Telerik.WinControls.UI.RadButton();
      this.panel_Grid = new Telerik.WinControls.UI.RadPanel();
      this.GxProperty = new Telerik.WinControls.UI.RadPropertyGrid();
      ((System.ComponentModel.ISupportInitialize)(this.PnTool)).BeginInit();
      this.PnTool.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BtnSaveSettings)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_Grid)).BeginInit();
      this.panel_Grid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.GxProperty)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // PnTool
      // 
      this.PnTool.Controls.Add(this.BtnSaveSettings);
      this.PnTool.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PnTool.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.PnTool.Location = new System.Drawing.Point(0, 610);
      this.PnTool.Name = "PnTool";
      this.PnTool.Size = new System.Drawing.Size(656, 50);
      this.PnTool.TabIndex = 1;
      // 
      // BtnSaveSettings
      // 
      this.BtnSaveSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
      this.BtnSaveSettings.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnSaveSettings.Location = new System.Drawing.Point(30, 14);
      this.BtnSaveSettings.Name = "BtnSaveSettings";
      this.BtnSaveSettings.Size = new System.Drawing.Size(130, 22);
      this.BtnSaveSettings.TabIndex = 0;
      this.BtnSaveSettings.Text = "Save settings";
      // 
      // panel_Grid
      // 
      this.panel_Grid.Controls.Add(this.GxProperty);
      this.panel_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel_Grid.Location = new System.Drawing.Point(0, 0);
      this.panel_Grid.Name = "panel_Grid";
      this.panel_Grid.Size = new System.Drawing.Size(656, 610);
      this.panel_Grid.TabIndex = 2;
      this.panel_Grid.Text = "radPanel2";
      // 
      // GxProperty
      // 
      this.GxProperty.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GxProperty.EnableGrouping = false;
      this.GxProperty.EnableSorting = false;
      this.GxProperty.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.GxProperty.ItemHeight = 28;
      this.GxProperty.ItemIndent = 30;
      this.GxProperty.Location = new System.Drawing.Point(0, 0);
      this.GxProperty.Margin = new System.Windows.Forms.Padding(10);
      this.GxProperty.Name = "GxProperty";
      this.GxProperty.Padding = new System.Windows.Forms.Padding(30);
      this.GxProperty.PropertySort = System.Windows.Forms.PropertySort.Categorized;
      this.GxProperty.Size = new System.Drawing.Size(656, 610);
      this.GxProperty.SortOrder = System.Windows.Forms.SortOrder.Ascending;
      this.GxProperty.TabIndex = 0;
      this.GxProperty.ToolbarVisible = true;
      ((Telerik.WinControls.UI.PropertyGridElement)(this.GxProperty.GetChildAt(0))).Padding = new System.Windows.Forms.Padding(30);
      ((Telerik.WinControls.UI.PropertyGridTableElement)(this.GxProperty.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ItemHeight = 28;
      ((Telerik.WinControls.UI.PropertyGridTableElement)(this.GxProperty.GetChildAt(0).GetChildAt(1).GetChildAt(0))).ItemIndent = 30;
      ((Telerik.WinControls.UI.PropertyGridHelpTitleElement)(this.GxProperty.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      ((Telerik.WinControls.UI.PropertyGridHelpContentElement)(this.GxProperty.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1))).Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      // 
      // FxSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(656, 660);
      this.Controls.Add(this.panel_Grid);
      this.Controls.Add(this.PnTool);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FxSettings";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "FxSettings";
      ((System.ComponentModel.ISupportInitialize)(this.PnTool)).EndInit();
      this.PnTool.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.BtnSaveSettings)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panel_Grid)).EndInit();
      this.panel_Grid.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.GxProperty)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion
    private Telerik.WinControls.UI.RadPanel panel_Grid;
    public Telerik.WinControls.UI.RadPropertyGrid GxProperty;
    public Telerik.WinControls.UI.RadPanel PnTool;
    public Telerik.WinControls.UI.RadButton BtnSaveSettings;
  }
}
