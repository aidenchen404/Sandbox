using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class MainForm : Form
    {
        const int CanvasSizePadding = 5;
        const int CanvasSizingStep = 20;
        
        private StickerButton _selectedSticker;
        private bool _draggingSticker = false;
        private int _mouseX = 0;
        private int _mouseY = 0;

        public MainForm()
        {
            InitializeComponent();
            canvas.Visible = false;
        }

        private void CleanUI()
        {
            foreach (Control control in canvas.Controls)
            {
                var button = control as StickerButton;
                if (button != null)
                {
                    canvas.Controls.Remove(control);
                }
            }

            canvas.Model = null;
            canvas.Visible = false;
            SetDeskVisibility();
        }

        private void SetDeskVisibility()
        {
            menuNewBook.Enabled = canvas.Model == null;
            menuOpenBook.Enabled = canvas.Model == null;
            menuDeleteBook.Enabled = canvas.Model != null;
            menuRefreshBook.Enabled = canvas.Model != null;
            menuCloseBook.Enabled = canvas.Model != null;
            menuSaveBook.Enabled = canvas.Model != null;

            CanvasExpandLeft.Enabled = canvas.Model != null;
            CanvasExpandTop.Enabled = canvas.Model != null;
            CanvasExpandRight.Enabled = canvas.Model != null;
            CanvasExpandBottom.Enabled = canvas.Model != null;

            bkName.Visible = canvas.Model != null;
            bkDescription.Visible = canvas.Model != null;

            canvas.Visible = canvas.Model != null;

            if (canvas.Model != null)
            {
                bkName.Text = canvas.Model.Name;
                bkDescription.Text = canvas.Model.Desc;
            }
        }

        private void ModelToUI(List<StickerModel> stickers)
        {
            // menu item visibility
            SetDeskVisibility();

            // stickers visibility
            foreach (var s in stickers)
            {
                var button = new StickerButton();
                button.AutoSize = false;
                button.Model = s;
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                button.Location = new System.Drawing.Point(s.PosX, s.PosY);
                button.Name = s.Id.ToString();
                button.Text = s.Name;

                button.ForeColor = s.ForeColor;
                button.BackColor = s.BackColor;
                button.Width = s.Width;
                button.Height = s.Height;
                
                button.TabIndex = 1;
                button.UseVisualStyleBackColor = false;

                button.MouseDown += new MouseEventHandler(this.StickerMouseDowned);
                button.MouseUp += new MouseEventHandler(this.StickerMouseUped);

                canvas.Controls.Add(button);
            }

            canvas.Visible = true;
        }

        private void RefreshLocation()
        {
            foreach (Control control in canvas.Controls)
            {
                var button = control as StickerButton;
                if (button != null)
                {
                    button.Visible = true;
                    button.Location = new System.Drawing.Point(button.Model.PosX, button.Model.PosY);
                }
            }
        }

        private void LoadBook(Guid bookId)
        {
            foreach (Control control in canvas.Controls)
            {
                var button = control as StickerButton;
                if (button != null)
                {
                    canvas.Controls.Remove(control);
                }
            }

            canvas.Model = Desk.LoadBook(bookId);

            var stickers = Desk.LoadStickers(bookId);
            ModelToUI(stickers);
        }

        private void SaveBook()
        {
            canvas.Model.Name = bkName.Text;
            canvas.Model.Desc = bkDescription.Text; 
            canvas.Model.Width = CanvasCorner.Left + CanvasSizePadding;
            canvas.Model.Height = CanvasCorner.Top + CanvasSizePadding;
            canvas.Model = Desk.UpdateBook(canvas.Model);
            foreach (Control control in canvas.Controls)
            {
                var button = control as StickerButton;
                if (button != null)
                {
                    if (button.Visible)
                    {
                        //save
                        button.Model.PosX = button.Left;
                        button.Model.PosY = button.Top;
                        button.Model.Width = button.Width ;
                        button.Model.Height  = button.Height;
                        button.Model = Desk.SaveSticker(button.Model);
                    }
                    else
                    {
                        //delete
                        Desk.DeleteSticker(button.Model.Id);
                    }
                }
            }
        }

        private void BookCanvasChanged(int left, int top, int right, int bottom)
        {
            canvas.Model.Width += -left + right;
            canvas.Model.Height += -top + bottom;

            foreach (Control control in canvas.Controls)
            {
                var button = control as StickerButton;
                if (button != null)
                {
                    button.Model.PosX += -left;
                    button.Model.PosY += -top;
                    button.Location = new System.Drawing.Point(button.Model.PosX, button.Model.PosY);
                }
            }
        }

        #region main Menu events

        private void menuNewBook_Click(object sender, EventArgs e)
        {
            // trigger the scroll bar
            CanvasCorner.Top = canvas.Height - CanvasCorner.Height - CanvasSizePadding;
            CanvasCorner.Left = canvas.Width - CanvasCorner.Width - CanvasSizePadding;

            var book = Desk.CreateBook(CanvasCorner.Top, CanvasCorner.Left);
            canvas.Model = book;
            ModelToUI(new List<StickerModel>());
        }

        private void menuOpenBook_Click(object sender, EventArgs e)
        {
            var bookId = Guid.NewGuid(); // wait for OpenDialog
            var bookDlg = new SelectBookDialog();
            if (bookDlg.ShowDialog() == DialogResult.OK)
            {
                bookId = new Guid(bookDlg.BookId);
            }


            canvas.Model = Desk.LoadBook(bookId);

            var stickers = Desk.LoadStickers(bookId);
            ModelToUI(stickers);
        }

        private void menuSaveBook_Click(object sender, EventArgs e)
        {
            SaveBook();
            LoadBook(canvas.Model.Id);
        }

        private void menuRefreshBook_Click(object sender, EventArgs e)
        {
            RefreshLocation();
        }

        private void menuCloseBook_Click(object sender, EventArgs e)
        {
            SaveBook();
            CleanUI();
        }

        private void menuDeleteBook_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this book?",
                "Confirm Delete!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                Desk.DeleteBook(canvas.Model.Id);
                CleanUI();
            }
        }

        private void CanvasExpandLeft_Click(object sender, EventArgs e)
        {
            CanvasCorner.Left += CanvasSizingStep;
            BookCanvasChanged(-CanvasSizingStep, 0, 0, 0);
        }

        private void CanvasExpandTop_Click(object sender, EventArgs e)
        {
            CanvasCorner.Top += CanvasSizingStep;
            BookCanvasChanged(0, -CanvasSizingStep, 0, 0);
        }

        private void CanvasExpandRight_Click(object sender, EventArgs e)
        {
            CanvasCorner.Left += CanvasSizingStep;
            BookCanvasChanged(0, 0, CanvasSizingStep, 0);
        }

        private void CanvasExpandBottom_Click(object sender, EventArgs e)
        {
            CanvasCorner.Top += CanvasSizingStep;
            BookCanvasChanged(0, 0, 0, CanvasSizingStep);
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                canvasMenu.Show(Cursor.Position);
            }
        }

        #endregion main Menu events

        #region Sticker Menu events

        private void menuNewSticker_Click(object sender, EventArgs e)
        {
            var s = new StickerModel(canvas.Model.Id);
            var button = new StickerButton();
            s.PosX = Cursor.Position.X - canvas.Left - this.Left - 10;
            s.PosY = Cursor.Position.Y - canvas.Top - this.Top - 90;
            button.Model = s;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new System.Drawing.Point(s.PosX, s.PosY);
            button.Name = s.Id.ToString();
            button.Text = s.Name;

            button.ForeColor = s.ForeColor;
            button.BackColor = s.BackColor;
            button.Width = s.Width;
            button.Height = s.Height;

            button.TabIndex = 1;
            button.UseVisualStyleBackColor = false;
            button.MouseDown += new MouseEventHandler(this.StickerMouseDowned);
            button.MouseUp += new MouseEventHandler(this.StickerMouseUped);
            canvas.Controls.Add(button);
        }

        private void menuCopySticker_Click(object sender, EventArgs e)
        {
            if (_selectedSticker != null)
            {
                var s = _selectedSticker.Model.ShallowCopy();
                var button = new StickerButton();
                button.Model = s;
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Flat;
                button.Location = new System.Drawing.Point(s.PosX, s.PosY);

                button.Name = s.Id.ToString();
                button.Text = s.Name;
                button.ForeColor = s.ForeColor;
                button.BackColor = s.BackColor;
                button.Width = s.Width;
                button.Height = s.Height;
                
                button.TabIndex = 1;
                button.UseVisualStyleBackColor = false;
                button.MouseDown += new MouseEventHandler(this.StickerMouseDowned);
                button.MouseUp += new MouseEventHandler(this.StickerMouseUped);
                canvas.Controls.Add(button);
            }
        }

        private void menuDeleteSticker_Click(object sender, EventArgs e)
        {
            if (_selectedSticker != null)
            {
                _selectedSticker.Visible = false;
            }
        }

        private void menuDetailsSticker_Click(object sender, EventArgs e)
        {
            if (_selectedSticker != null)
            {
                var stickerDlg = new StickerDetailDialog();
                stickerDlg.StickerButton = _selectedSticker;
                if (stickerDlg.ShowDialog() == DialogResult.OK)
                {
                    _selectedSticker.ForeColor = _selectedSticker.Model.ForeColor;
                    _selectedSticker.BackColor = _selectedSticker.Model.BackColor;
                    _selectedSticker.Width = _selectedSticker.Model.Width;
                    _selectedSticker.Height= _selectedSticker.Model.Height;
                    _selectedSticker.Text = _selectedSticker.Model.Name;
                }
            }
        }

        private void StickerMouseDowned(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _selectedSticker = sender as StickerButton;
            if (e.Button == MouseButtons.Right)
            {
                stickerMenu.Show(Cursor.Position);
            }
            else if (e.Button == MouseButtons.Left)
            {
                _selectedSticker.Cursor = System.Windows.Forms.Cursors.Hand;
                _mouseX = e.X;
                _mouseY = e.Y;
                _draggingSticker = true;
            }
        }

        private void StickerMouseUped(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                if (_draggingSticker && _selectedSticker != null)
                {
                    _selectedSticker.Cursor = Cursors.Default;
                    _selectedSticker.Left += e.X - _mouseX;
                    _selectedSticker.Top += e.Y - _mouseY;
                }

            _draggingSticker = false;
        }

        #endregion Sticker Menu events

        private void bkDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                canvas.Model.Desc = bkDescription.Text;
            }
        }

        private void bkName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                canvas.Model.Name = bkName.Text;
            }
        }
    }
}
