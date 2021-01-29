namespace TJFramework.Form
{
    partial class FxMain
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FxMain));
      this.MyNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.PnMainTop = new Telerik.WinControls.UI.RadPanel();
      this.PnMain = new Telerik.WinControls.UI.RadPanel();
      this.SplitterMainVertical = new System.Windows.Forms.Splitter();
      this.MainPageView = new Telerik.WinControls.UI.RadPageView();
      this.PnMainSide = new Telerik.WinControls.UI.RadPanel();
      this.SplitterMainHorizontal = new System.Windows.Forms.Splitter();
      this.MainFormMenu = new Telerik.WinControls.UI.RadMenu();
      this.MenuItemFirstItem = new Telerik.WinControls.UI.RadMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainTop)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMain)).BeginInit();
      this.PnMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MainPageView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainSide)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MainFormMenu)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
      this.SuspendLayout();
      // 
      // MyNotifyIcon
      // 
      this.MyNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MyNotifyIcon.Icon")));
      this.MyNotifyIcon.Text = "Application";
      this.MyNotifyIcon.Visible = true;
      // 
      // PnMainTop
      // 
      this.PnMainTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.PnMainTop.Location = new System.Drawing.Point(0, 28);
      this.PnMainTop.Name = "PnMainTop";
      this.PnMainTop.Size = new System.Drawing.Size(792, 35);
      this.PnMainTop.TabIndex = 0;
      // 
      // PnMain
      // 
      this.PnMain.Controls.Add(this.SplitterMainVertical);
      this.PnMain.Controls.Add(this.MainPageView);
      this.PnMain.Controls.Add(this.PnMainSide);
      this.PnMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.PnMain.Location = new System.Drawing.Point(0, 63);
      this.PnMain.Name = "PnMain";
      this.PnMain.Size = new System.Drawing.Size(792, 507);
      this.PnMain.TabIndex = 0;
      // 
      // SplitterMainVertical
      // 
      this.SplitterMainVertical.Location = new System.Drawing.Point(45, 0);
      this.SplitterMainVertical.Name = "SplitterMainVertical";
      this.SplitterMainVertical.Size = new System.Drawing.Size(5, 507);
      this.SplitterMainVertical.TabIndex = 2;
      this.SplitterMainVertical.TabStop = false;
      // 
      // MainPageView
      // 
      this.MainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.MainPageView.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.MainPageView.Location = new System.Drawing.Point(45, 0);
      this.MainPageView.Name = "MainPageView";
      this.MainPageView.Size = new System.Drawing.Size(747, 507);
      this.MainPageView.TabIndex = 1;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.Scroll;
      ((Telerik.WinControls.UI.RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).ShowItemCloseButton = false;
      // 
      // PnMainSide
      // 
      this.PnMainSide.Dock = System.Windows.Forms.DockStyle.Left;
      this.PnMainSide.Location = new System.Drawing.Point(0, 0);
      this.PnMainSide.Name = "PnMainSide";
      this.PnMainSide.Size = new System.Drawing.Size(45, 507);
      this.PnMainSide.TabIndex = 0;
      ((Telerik.WinControls.Primitives.FillPrimitive)(this.PnMainSide.GetChildAt(0).GetChildAt(0))).Padding = new System.Windows.Forms.Padding(0);
      ((Telerik.WinControls.Primitives.BorderPrimitive)(this.PnMainSide.GetChildAt(0).GetChildAt(1))).Padding = new System.Windows.Forms.Padding(0);
      // 
      // SplitterMainHorizontal
      // 
      this.SplitterMainHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
      this.SplitterMainHorizontal.Location = new System.Drawing.Point(0, 63);
      this.SplitterMainHorizontal.Name = "SplitterMainHorizontal";
      this.SplitterMainHorizontal.Size = new System.Drawing.Size(792, 5);
      this.SplitterMainHorizontal.TabIndex = 1;
      this.SplitterMainHorizontal.TabStop = false;
      // 
      // MainFormMenu
      // 
      this.MainFormMenu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.MainFormMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MenuItemFirstItem});
      this.MainFormMenu.Location = new System.Drawing.Point(0, 0);
      this.MainFormMenu.Name = "MainFormMenu";
      this.MainFormMenu.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
      this.MainFormMenu.Size = new System.Drawing.Size(792, 28);
      this.MainFormMenu.TabIndex = 0;
      // 
      // MenuItemFirstItem
      // 
      this.MenuItemFirstItem.Name = "MenuItemFirstItem";
      this.MenuItemFirstItem.Padding = new System.Windows.Forms.Padding(15, 1, 15, 1);
      this.MenuItemFirstItem.Text = "Main menu";
      // 
      // FxMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(792, 570);
      this.Controls.Add(this.SplitterMainHorizontal);
      this.Controls.Add(this.PnMain);
      this.Controls.Add(this.PnMainTop);
      this.Controls.Add(this.MainFormMenu);
      this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Name = "FxMain";
      // 
      // 
      // 
      this.RootElement.ApplyShapeToControl = true;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Tag = "";
      this.Text = "Application";
      ((System.ComponentModel.ISupportInitialize)(this.PnMainTop)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMain)).EndInit();
      this.PnMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.MainPageView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.PnMainSide)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MainFormMenu)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    #endregion

    public System.Windows.Forms.NotifyIcon MyNotifyIcon;
    public Telerik.WinControls.UI.RadPanel PnMainTop;
    public Telerik.WinControls.UI.RadPanel PnMain;
    public System.Windows.Forms.Splitter SplitterMainVertical;
    public Telerik.WinControls.UI.RadPageView MainPageView;
    public Telerik.WinControls.UI.RadPanel PnMainSide;
    public System.Windows.Forms.Splitter SplitterMainHorizontal;
    public Telerik.WinControls.UI.RadMenu MainFormMenu;
    public Telerik.WinControls.UI.RadMenuItem MenuItemFirstItem;
  }
}
