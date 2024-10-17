using System;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class PaperDetailDialog : Form
    {
        public Guid StickerId;
        public Guid PaperId;
        public PaperModel Paper;

        public PaperDetailDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Paper.Desc = txtDesc.Text;
            Paper.Name = txtName.Text;
            Paper.Text = txtText.Text;
            Paper.StickerId = StickerId;
            Desk.SavePaper(Paper);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PaperDetailDialog_Load(object sender, EventArgs e)
        {
            if (PaperId == Guid.Empty)
            {
                Paper= new PaperModel();
            }
            else
            {
                Paper = Desk.LoadPaper(PaperId);
                txtDesc.Text = Paper.Desc;
                txtName.Text = Paper.Name;
                txtText.Text = Paper.Text;
            }
        }
    }
}
