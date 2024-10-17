using System;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class StickerDetailDialog : Form
    {
        private StickerButton _stickerbutton;
        

        public StickerButton StickerButton {
            get
            {
                return _stickerbutton;
            }
            set
            {
                _stickerbutton = value;
                if (_stickerbutton != null)
                {
                    btnPreview.Text = _stickerbutton.Text;
                    txtName.Text = _stickerbutton.Text;
                    txtWidth .Text = _stickerbutton.Width.ToString();
                    txtHeight.Text = _stickerbutton.Height.ToString();
                    btnPreview.ForeColor = _stickerbutton.ForeColor;
                    btnPreview.BackColor = _stickerbutton.BackColor;

                    LoadAndPopulatePapers();
                }
            }
         }

        private void LoadAndPopulatePapers()
        {
            var papers = Desk.LoadPapers(_stickerbutton.Model.Id);
            lstPaper.Items.Clear();

            lstPaper.BeginUpdate();
            foreach (var paper in papers)
            {
                ListViewItem item = new ListViewItem(new[]
                    { paper.IdString, paper.Name, paper.Desc });
                lstPaper.Items.Add(item);
            }

            lstPaper.EndUpdate();
        }

        public StickerDetailDialog()
        {
            InitializeComponent();
        }
   
        private void lblForeColor_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnPreview.ForeColor = colorDlg.Color;
            }
        }

        private void lblBackColor_Click(object sender, EventArgs e)
        {
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                btnPreview.BackColor = colorDlg.Color;
            }
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPreview.Width = int.Parse(txtWidth.Text);
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnPreview.Height = int.Parse(txtHeight.Text);
            }

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnPreview.Text = txtName.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (StickerButton.Model != null)
            {
                StickerButton.Model.ForeColor = btnPreview.ForeColor;
                StickerButton.Model.BackColor = btnPreview.BackColor;
                StickerButton.Model.Width = int.Parse(txtWidth.Text);
                StickerButton.Model.Height = int.Parse(txtHeight.Text);
                StickerButton.Model.Name = txtName.Text;
                StickerButton.Model.Desc = txtDesc.Text;
                StickerButton.Model.Tag = txtTag.Text;
                StickerButton.Model = Desk.SaveSticker(StickerButton.Model);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void StickerDetailDialog_Load(object sender, EventArgs e)
        {
           
        }

        private void btnDeletePaper_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this paper?",
                "Confirm Delete!",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                var paperId = lstPaper.SelectedItems[0].Text;
                Desk.DeletePaper(new Guid(  paperId));
                LoadAndPopulatePapers();
            }
        }

        private Guid OpenPaperDialog(Guid paperId)
        {
            var paperDlg = new PaperDetailDialog();
            paperDlg.StickerId = this.StickerButton.Model.Id;
            paperDlg.PaperId  = paperId;
            if (paperDlg.ShowDialog() == DialogResult.OK)
            {
                paperId = paperDlg.PaperId;
                LoadAndPopulatePapers();
            }
            return paperId;
        }

        private void lstPaper_DoubleClick(object sender, EventArgs e)
        {
            var paperId = lstPaper.SelectedItems[0].Text;
            OpenPaperDialog( new Guid( paperId));
            LoadAndPopulatePapers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var paperId = lstPaper.SelectedItems[0].Text;
            OpenPaperDialog(new Guid(paperId));
            LoadAndPopulatePapers();
        }

        private void tbnAddPaper_Click(object sender, EventArgs e)
        {
            OpenPaperDialog(Guid.Empty);
            LoadAndPopulatePapers();
        }

    }
}
