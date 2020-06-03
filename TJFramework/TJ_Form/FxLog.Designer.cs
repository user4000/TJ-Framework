namespace TJFramework.Form
{
    partial class FxLog
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
      Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxLog));
      this.PnGrid = new Telerik.WinControls.UI.RadPanel();
      this.GxLog = new Telerik.WinControls.UI.RadGridView();
      this.PnMessage = new Telerik.WinControls.UI.RadPanel();
      this.TxtMessage = new Telerik.WinControls.UI.RadTextBoxControl();
      this.TxtHeader = new Telerik.WinControls.UI.RadTextBoxControl();
      this.PnMenu = new Telerik.WinControls.UI.RadPanel();
      this.BtnTest = new Telerik.WinControls.UI.RadButton();
      this.BtnSearchField = new Telerik.WinControls.UI.RadButton();
      this.BtnFilter = new Telerik.WinControls.UI.RadButton();
      this.BtnCopyToClipboard = new Telerik.WinControls.UI.RadButton();
      this.BtnShowDetailMessage = new Telerik.WinControls.UI.RadButton();
      this.ImageIcons = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.PnGrid)).BeginInit();
      this.PnGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.GxLog)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.GxLog.MasterTemplate)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMessage)).BeginInit();
      this.PnMessage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TxtMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtHeader)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMenu)).BeginInit();
      this.PnMenu.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.BtnTest)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnSearchField)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnFilter)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnCopyToClipboard)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnShowDetailMessage)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // PnGrid
      // 
      this.PnGrid.Controls.Add(this.GxLog);
      this.PnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PnGrid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.PnGrid.Location = new System.Drawing.Point(0, 0);
      this.PnGrid.Name = "PnGrid";
      this.PnGrid.Size = new System.Drawing.Size(988, 448);
      this.PnGrid.TabIndex = 0;
      // 
      // GxLog
      // 
      this.GxLog.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.GxLog.Location = new System.Drawing.Point(56, 69);
      // 
      // 
      // 
      this.GxLog.MasterTemplate.AllowAddNewRow = false;
      this.GxLog.MasterTemplate.AllowCellContextMenu = false;
      this.GxLog.MasterTemplate.AllowColumnChooser = false;
      this.GxLog.MasterTemplate.AllowColumnHeaderContextMenu = false;
      this.GxLog.MasterTemplate.AllowColumnReorder = false;
      this.GxLog.MasterTemplate.AllowDeleteRow = false;
      this.GxLog.MasterTemplate.AllowDragToGroup = false;
      this.GxLog.MasterTemplate.AllowEditRow = false;
      this.GxLog.MasterTemplate.AllowRowHeaderContextMenu = false;
      this.GxLog.MasterTemplate.AllowSearchRow = true;
      this.GxLog.MasterTemplate.AutoGenerateColumns = false;
      this.GxLog.MasterTemplate.EnableGrouping = false;
      this.GxLog.MasterTemplate.ShowColumnHeaders = false;
      this.GxLog.MasterTemplate.ShowRowHeaderColumn = false;
      this.GxLog.MasterTemplate.VerticalScrollState = Telerik.WinControls.UI.ScrollState.AlwaysShow;
      this.GxLog.MasterTemplate.ViewDefinition = tableViewDefinition2;
      this.GxLog.Name = "GxLog";
      this.GxLog.ReadOnly = true;
      this.GxLog.ShowGroupPanel = false;
      this.GxLog.ShowGroupPanelScrollbars = false;
      this.GxLog.ShowNoDataText = false;
      this.GxLog.ShowRowErrors = false;
      this.GxLog.Size = new System.Drawing.Size(848, 335);
      this.GxLog.TabIndex = 0;
      // 
      // PnMessage
      // 
      this.PnMessage.Controls.Add(this.TxtMessage);
      this.PnMessage.Controls.Add(this.TxtHeader);
      this.PnMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PnMessage.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.PnMessage.Location = new System.Drawing.Point(0, 448);
      this.PnMessage.Name = "PnMessage";
      this.PnMessage.Padding = new System.Windows.Forms.Padding(5);
      this.PnMessage.Size = new System.Drawing.Size(988, 360);
      this.PnMessage.TabIndex = 0;
      // 
      // TxtMessage
      // 
      this.TxtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TxtMessage.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TxtMessage.IsReadOnly = true;
      this.TxtMessage.IsReadOnlyCaretVisible = true;
      this.TxtMessage.Location = new System.Drawing.Point(5, 45);
      this.TxtMessage.Margin = new System.Windows.Forms.Padding(5);
      this.TxtMessage.MaxLength = 10000;
      this.TxtMessage.Multiline = true;
      this.TxtMessage.Name = "TxtMessage";
      this.TxtMessage.Size = new System.Drawing.Size(978, 310);
      this.TxtMessage.TabIndex = 0;
      // 
      // TxtHeader
      // 
      this.TxtHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.TxtHeader.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TxtHeader.IsReadOnly = true;
      this.TxtHeader.IsReadOnlyCaretVisible = true;
      this.TxtHeader.Location = new System.Drawing.Point(5, 5);
      this.TxtHeader.Margin = new System.Windows.Forms.Padding(5);
      this.TxtHeader.MaxLength = 5000;
      this.TxtHeader.Multiline = true;
      this.TxtHeader.Name = "TxtHeader";
      this.TxtHeader.Size = new System.Drawing.Size(978, 40);
      this.TxtHeader.TabIndex = 0;
      this.TxtHeader.VerticalScrollBarState = Telerik.WinControls.UI.ScrollState.AlwaysHide;
      // 
      // PnMenu
      // 
      this.PnMenu.Controls.Add(this.BtnTest);
      this.PnMenu.Controls.Add(this.BtnSearchField);
      this.PnMenu.Controls.Add(this.BtnFilter);
      this.PnMenu.Controls.Add(this.BtnCopyToClipboard);
      this.PnMenu.Controls.Add(this.BtnShowDetailMessage);
      this.PnMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.PnMenu.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.PnMenu.Location = new System.Drawing.Point(0, 808);
      this.PnMenu.Name = "PnMenu";
      this.PnMenu.Size = new System.Drawing.Size(988, 32);
      this.PnMenu.TabIndex = 0;
      // 
      // BtnTest
      // 
      this.BtnTest.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnTest.Location = new System.Drawing.Point(715, 6);
      this.BtnTest.Name = "BtnTest";
      this.BtnTest.Size = new System.Drawing.Size(75, 20);
      this.BtnTest.TabIndex = 0;
      this.BtnTest.Text = "Test";
      this.BtnTest.Visible = false;
      // 
      // BtnSearchField
      // 
      this.BtnSearchField.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnSearchField.Location = new System.Drawing.Point(288, 6);
      this.BtnSearchField.Name = "BtnSearchField";
      this.BtnSearchField.Size = new System.Drawing.Size(100, 20);
      this.BtnSearchField.TabIndex = 0;
      this.BtnSearchField.Text = "Search";
      // 
      // BtnFilter
      // 
      this.BtnFilter.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnFilter.Location = new System.Drawing.Point(150, 6);
      this.BtnFilter.Name = "BtnFilter";
      this.BtnFilter.Size = new System.Drawing.Size(100, 20);
      this.BtnFilter.TabIndex = 0;
      this.BtnFilter.Text = "Filter";
      // 
      // BtnCopyToClipboard
      // 
      this.BtnCopyToClipboard.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnCopyToClipboard.Location = new System.Drawing.Point(426, 6);
      this.BtnCopyToClipboard.Name = "BtnCopyToClipboard";
      this.BtnCopyToClipboard.Size = new System.Drawing.Size(100, 20);
      this.BtnCopyToClipboard.TabIndex = 0;
      this.BtnCopyToClipboard.Text = "Copy";
      // 
      // BtnShowDetailMessage
      // 
      this.BtnShowDetailMessage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BtnShowDetailMessage.Location = new System.Drawing.Point(12, 6);
      this.BtnShowDetailMessage.Name = "BtnShowDetailMessage";
      this.BtnShowDetailMessage.Size = new System.Drawing.Size(100, 20);
      this.BtnShowDetailMessage.TabIndex = 0;
      this.BtnShowDetailMessage.Text = "Message";
      // 
      // ImageIcons
      // 
      this.ImageIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageIcons.ImageStream")));
      this.ImageIcons.TransparentColor = System.Drawing.Color.Transparent;
      this.ImageIcons.Images.SetKeyName(0, "11_flag_blue.png");
      this.ImageIcons.Images.SetKeyName(1, "11_blueball.png");
      this.ImageIcons.Images.SetKeyName(2, "11_OK.png");
      this.ImageIcons.Images.SetKeyName(3, "11_vlc.png");
      this.ImageIcons.Images.SetKeyName(4, "11_error.png");
      this.ImageIcons.Images.SetKeyName(5, "11_error_2.png");
      // 
      // FxLog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(988, 840);
      this.Controls.Add(this.PnGrid);
      this.Controls.Add(this.PnMessage);
      this.Controls.Add(this.PnMenu);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FxLog";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.Text = "FxLog";
      ((System.ComponentModel.ISupportInitialize)(this.PnGrid)).EndInit();
      this.PnGrid.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.GxLog.MasterTemplate)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.GxLog)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMessage)).EndInit();
      this.PnMessage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TxtMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.TxtHeader)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMenu)).EndInit();
      this.PnMenu.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.BtnTest)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnSearchField)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnFilter)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnCopyToClipboard)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.BtnShowDetailMessage)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);

        }

    #endregion
    public Telerik.WinControls.UI.RadButton BtnShowDetailMessage;
    public Telerik.WinControls.UI.RadTextBoxControl TxtMessage;
    public Telerik.WinControls.UI.RadTextBoxControl TxtHeader;
    public Telerik.WinControls.UI.RadPanel PnMessage;
    public Telerik.WinControls.UI.RadGridView GxLog;
    public Telerik.WinControls.UI.RadButton BtnTest;
    public Telerik.WinControls.UI.RadButton BtnCopyToClipboard;
    public System.Windows.Forms.ImageList ImageIcons;
    public Telerik.WinControls.UI.RadButton BtnFilter;
    public Telerik.WinControls.UI.RadButton BtnSearchField;
    public Telerik.WinControls.UI.RadPanel PnGrid;
    public Telerik.WinControls.UI.RadPanel PnMenu;
  }
}
