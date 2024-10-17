using System.Drawing;
using System.Windows.Forms;

namespace Sandbox
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
            this.mainToolContainer = new System.Windows.Forms.ToolStripContainer();
            this.canvas = new Sandbox.CanvasPanel();
            this.CanvasCorner = new System.Windows.Forms.Label();
            this.mainTool = new System.Windows.Forms.ToolStrip();
            this.menuNewBook = new System.Windows.Forms.ToolStripButton();
            this.menuOpenBook = new System.Windows.Forms.ToolStripButton();
            this.menuSaveBook = new System.Windows.Forms.ToolStripButton();
            this.menuCloseBook = new System.Windows.Forms.ToolStripButton();
            this.menuRefreshBook = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CanvasExpandLeft = new System.Windows.Forms.ToolStripButton();
            this.CanvasExpandTop = new System.Windows.Forms.ToolStripButton();
            this.CanvasExpandBottom = new System.Windows.Forms.ToolStripButton();
            this.CanvasExpandRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.bkName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.bkDescription = new System.Windows.Forms.ToolStripTextBox();
            this.menuDeleteBook = new System.Windows.Forms.ToolStripButton();
            this.canvasMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuNewSticker = new System.Windows.Forms.ToolStripMenuItem();
            this.stickerMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDetailSticker = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopySticker = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveSticker = new System.Windows.Forms.ToolStripMenuItem();
            this.mainToolContainer.ContentPanel.SuspendLayout();
            this.mainToolContainer.TopToolStripPanel.SuspendLayout();
            this.mainToolContainer.SuspendLayout();
            this.canvas.SuspendLayout();
            this.mainTool.SuspendLayout();
            this.canvasMenu.SuspendLayout();
            this.stickerMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolContainer
            // 
            this.mainToolContainer.BottomToolStripPanelVisible = false;
            // 
            // mainToolContainer.ContentPanel
            // 
            this.mainToolContainer.ContentPanel.Controls.Add(this.canvas);
            this.mainToolContainer.ContentPanel.Size = new System.Drawing.Size(1080, 571);
            this.mainToolContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainToolContainer.LeftToolStripPanelVisible = false;
            this.mainToolContainer.Location = new System.Drawing.Point(0, 0);
            this.mainToolContainer.Name = "mainToolContainer";
            this.mainToolContainer.RightToolStripPanelVisible = false;
            this.mainToolContainer.Size = new System.Drawing.Size(1080, 600);
            this.mainToolContainer.TabIndex = 0;
            this.mainToolContainer.Text = "mainToolContainer";
            // 
            // mainToolContainer.TopToolStripPanel
            // 
            this.mainToolContainer.TopToolStripPanel.Controls.Add(this.mainTool);
            this.mainToolContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // canvas
            // 
            this.canvas.AutoScroll = true;
            this.canvas.BackColor = System.Drawing.SystemColors.Window;
            this.canvas.Controls.Add(this.CanvasCorner);
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1080, 571);
            this.canvas.TabIndex = 1;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // CanvasCorner
            // 
            this.CanvasCorner.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.CanvasCorner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CanvasCorner.Location = new System.Drawing.Point(800, 500);
            this.CanvasCorner.Name = "CanvasCorner";
            this.CanvasCorner.Size = new System.Drawing.Size(4, 4);
            this.CanvasCorner.TabIndex = 0;
            // 
            // mainTool
            // 
            this.mainTool.Dock = System.Windows.Forms.DockStyle.None;
            this.mainTool.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.mainTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewBook,
            this.menuOpenBook,
            this.menuSaveBook,
            this.menuCloseBook,
            this.menuRefreshBook,
            this.toolStripSeparator1,
            this.CanvasExpandLeft,
            this.CanvasExpandTop,
            this.CanvasExpandBottom,
            this.CanvasExpandRight,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.bkName,
            this.toolStripLabel2,
            this.bkDescription,
            this.menuDeleteBook});
            this.mainTool.Location = new System.Drawing.Point(8, 0);
            this.mainTool.Name = "mainTool";
            this.mainTool.Size = new System.Drawing.Size(328, 29);
            this.mainTool.TabIndex = 0;
            // 
            // menuNewBook
            // 
            this.menuNewBook.AutoSize = false;
            this.menuNewBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuNewBook.Image = ((System.Drawing.Image)(resources.GetObject("menuNewBook.Image")));
            this.menuNewBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNewBook.Name = "menuNewBook";
            this.menuNewBook.Size = new System.Drawing.Size(29, 22);
            this.menuNewBook.Text = "New Book";
            this.menuNewBook.Click += new System.EventHandler(this.menuNewBook_Click);
            // 
            // menuOpenBook
            // 
            this.menuOpenBook.AutoSize = false;
            this.menuOpenBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOpenBook.Image = ((System.Drawing.Image)(resources.GetObject("menuOpenBook.Image")));
            this.menuOpenBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOpenBook.Name = "menuOpenBook";
            this.menuOpenBook.Size = new System.Drawing.Size(29, 22);
            this.menuOpenBook.Text = "Open Book";
            this.menuOpenBook.Click += new System.EventHandler(this.menuOpenBook_Click);
            // 
            // menuSaveBook
            // 
            this.menuSaveBook.AutoSize = false;
            this.menuSaveBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuSaveBook.Enabled = false;
            this.menuSaveBook.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveBook.Image")));
            this.menuSaveBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSaveBook.Name = "menuSaveBook";
            this.menuSaveBook.Size = new System.Drawing.Size(29, 22);
            this.menuSaveBook.Text = "Save Book";
            this.menuSaveBook.Click += new System.EventHandler(this.menuSaveBook_Click);
            // 
            // menuCloseBook
            // 
            this.menuCloseBook.AutoSize = false;
            this.menuCloseBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuCloseBook.Enabled = false;
            this.menuCloseBook.Image = ((System.Drawing.Image)(resources.GetObject("menuCloseBook.Image")));
            this.menuCloseBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuCloseBook.Name = "menuCloseBook";
            this.menuCloseBook.Size = new System.Drawing.Size(29, 22);
            this.menuCloseBook.Text = "Close Book";
            this.menuCloseBook.Click += new System.EventHandler(this.menuCloseBook_Click);
            // 
            // menuRefreshBook
            // 
            this.menuRefreshBook.AutoSize = false;
            this.menuRefreshBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuRefreshBook.Enabled = false;
            this.menuRefreshBook.Image = ((System.Drawing.Image)(resources.GetObject("menuRefreshBook.Image")));
            this.menuRefreshBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuRefreshBook.Name = "menuRefreshBook";
            this.menuRefreshBook.Size = new System.Drawing.Size(29, 22);
            this.menuRefreshBook.Text = "Refresh";
            this.menuRefreshBook.Click += new System.EventHandler(this.menuRefreshBook_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // CanvasExpandLeft
            // 
            this.CanvasExpandLeft.AutoSize = false;
            this.CanvasExpandLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CanvasExpandLeft.Enabled = false;
            this.CanvasExpandLeft.Image = ((System.Drawing.Image)(resources.GetObject("CanvasExpandLeft.Image")));
            this.CanvasExpandLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CanvasExpandLeft.Name = "CanvasExpandLeft";
            this.CanvasExpandLeft.Size = new System.Drawing.Size(29, 22);
            this.CanvasExpandLeft.Text = "Expand Left";
            this.CanvasExpandLeft.Click += new System.EventHandler(this.CanvasExpandLeft_Click);
            // 
            // CanvasExpandTop
            // 
            this.CanvasExpandTop.AutoSize = false;
            this.CanvasExpandTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CanvasExpandTop.Enabled = false;
            this.CanvasExpandTop.Image = ((System.Drawing.Image)(resources.GetObject("CanvasExpandTop.Image")));
            this.CanvasExpandTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CanvasExpandTop.Name = "CanvasExpandTop";
            this.CanvasExpandTop.Size = new System.Drawing.Size(29, 22);
            this.CanvasExpandTop.Text = "Expand Top";
            this.CanvasExpandTop.Click += new System.EventHandler(this.CanvasExpandTop_Click);
            // 
            // CanvasExpandBottom
            // 
            this.CanvasExpandBottom.AutoSize = false;
            this.CanvasExpandBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CanvasExpandBottom.Enabled = false;
            this.CanvasExpandBottom.Image = ((System.Drawing.Image)(resources.GetObject("CanvasExpandBottom.Image")));
            this.CanvasExpandBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CanvasExpandBottom.Name = "CanvasExpandBottom";
            this.CanvasExpandBottom.Size = new System.Drawing.Size(29, 22);
            this.CanvasExpandBottom.Text = "Expand Bottom";
            this.CanvasExpandBottom.Click += new System.EventHandler(this.CanvasExpandBottom_Click);
            // 
            // CanvasExpandRight
            // 
            this.CanvasExpandRight.AutoSize = false;
            this.CanvasExpandRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CanvasExpandRight.Enabled = false;
            this.CanvasExpandRight.Image = ((System.Drawing.Image)(resources.GetObject("CanvasExpandRight.Image")));
            this.CanvasExpandRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CanvasExpandRight.Name = "CanvasExpandRight";
            this.CanvasExpandRight.Size = new System.Drawing.Size(29, 22);
            this.CanvasExpandRight.Text = "Expand Right";
            this.CanvasExpandRight.Click += new System.EventHandler(this.CanvasExpandRight_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.AutoSize = false;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(100, 27);
            this.toolStripLabel1.Text = "Book Name: ";
            this.toolStripLabel1.Visible = false;
            // 
            // bkName
            // 
            this.bkName.AutoSize = false;
            this.bkName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bkName.Name = "bkName";
            this.bkName.Size = new System.Drawing.Size(100, 27);
            this.bkName.Visible = false;
            this.bkName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bkName_KeyPress);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.AutoSize = false;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(150, 27);
            this.toolStripLabel2.Text = "Description:";
            this.toolStripLabel2.Visible = false;
            // 
            // bkDescription
            // 
            this.bkDescription.AutoSize = false;
            this.bkDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bkDescription.Name = "bkDescription";
            this.bkDescription.Size = new System.Drawing.Size(200, 27);
            this.bkDescription.Visible = false;
            this.bkDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bkDescription_KeyPress);
            // 
            // menuDeleteBook
            // 
            this.menuDeleteBook.AutoSize = false;
            this.menuDeleteBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDeleteBook.Enabled = false;
            this.menuDeleteBook.Image = ((System.Drawing.Image)(resources.GetObject("menuDeleteBook.Image")));
            this.menuDeleteBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuDeleteBook.Name = "menuDeleteBook";
            this.menuDeleteBook.Size = new System.Drawing.Size(29, 22);
            this.menuDeleteBook.Text = "Delete Book";
            this.menuDeleteBook.Click += new System.EventHandler(this.menuDeleteBook_Click);
            // 
            // canvasMenu
            // 
            this.canvasMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.canvasMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewSticker});
            this.canvasMenu.Name = "canvasMenu";
            this.canvasMenu.Size = new System.Drawing.Size(279, 52);
            // 
            // menuNewSticker
            // 
            this.menuNewSticker.Name = "menuNewSticker";
            this.menuNewSticker.Size = new System.Drawing.Size(278, 48);
            this.menuNewSticker.Text = "New A Sticker";
            this.menuNewSticker.Click += new System.EventHandler(this.menuNewSticker_Click);
            // 
            // stickerMenu
            // 
            this.stickerMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.stickerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDetailSticker,this.menuCopySticker,
            this.menuRemoveSticker});
            this.stickerMenu.Name = "stickerMenu";
            this.stickerMenu.Size = new System.Drawing.Size(204, 100);
            // 
            // menuDetailSticker
            // 
            this.menuDetailSticker.Name = "menuDetailSticker";
            this.menuDetailSticker.Size = new System.Drawing.Size(203, 48);
            this.menuDetailSticker.Text = "Details";
            this.menuDetailSticker.Click += new System.EventHandler(this.menuDetailsSticker_Click);
            // 
            // menuCopySticker
            // 
            this.menuCopySticker.Name = "menuCopySticker";
            this.menuCopySticker.Size = new System.Drawing.Size(203, 48);
            this.menuCopySticker.Text = "Copy";
            this.menuCopySticker.Click += new System.EventHandler(this.menuCopySticker_Click); // 
            // menuRemoveSticker
            // 
            this.menuRemoveSticker.Name = "menuRemoveSticker";
            this.menuRemoveSticker.Size = new System.Drawing.Size(203, 48);
            this.menuRemoveSticker.Text = "Remove";
            this.menuRemoveSticker.Click += new System.EventHandler(this.menuDeleteSticker_Click);
            // 
            // MainForm
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 600);
            this.Controls.Add(this.mainToolContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SandBox";
            this.mainToolContainer.ContentPanel.ResumeLayout(false);
            this.mainToolContainer.TopToolStripPanel.ResumeLayout(false);
            this.mainToolContainer.TopToolStripPanel.PerformLayout();
            this.mainToolContainer.ResumeLayout(false);
            this.mainToolContainer.PerformLayout();
            this.canvas.ResumeLayout(false);
            this.mainTool.ResumeLayout(false);
            this.mainTool.PerformLayout();
            this.canvasMenu.ResumeLayout(false);
            this.stickerMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.ToolStripContainer mainToolContainer;
        private System.Windows.Forms.ToolStrip mainTool;

        private System.Windows.Forms.ToolStripButton menuNewBook;
        private System.Windows.Forms.ToolStripButton menuOpenBook;
        private System.Windows.Forms.ToolStripButton menuSaveBook;
        private System.Windows.Forms.ToolStripButton menuDeleteBook;
        private System.Windows.Forms.ToolStripButton menuCloseBook;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CanvasExpandLeft;
        private System.Windows.Forms.ToolStripButton CanvasExpandTop;
        private System.Windows.Forms.ToolStripButton CanvasExpandRight;
        private System.Windows.Forms.ToolStripButton CanvasExpandBottom;

        private System.Windows.Forms.ContextMenuStrip canvasMenu;
        private System.Windows.Forms.ToolStripMenuItem menuNewSticker;

        private System.Windows.Forms.ContextMenuStrip stickerMenu;
        private System.Windows.Forms.ToolStripMenuItem menuDetailSticker;
        private System.Windows.Forms.ToolStripMenuItem menuCopySticker;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveSticker;

        private CanvasPanel canvas;
        private System.Windows.Forms.Label CanvasCorner;
        private System.Windows.Forms.ToolStripButton menuRefreshBook;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox bkName;
        private ToolStripLabel toolStripLabel2 ;
        private ToolStripTextBox bkDescription;
    }
}

