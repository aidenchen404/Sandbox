using System;
using System.Windows.Forms;

namespace Sandbox
{
    public partial class SelectBookDialog : Form
    {
        public string BookId;

        public SelectBookDialog()
        {
            InitializeComponent();
        }

        private void SelectBookDialog_Load(object sender, EventArgs e)
        {
            var books = Desk.LoadBooks();
            lstBook.Items.Clear();
            lstBook.BeginUpdate();
            
            foreach (var book in books)
            {
                ListViewItem item = new ListViewItem(new[]
                    { book.IdString, book.Name, book.Desc });
                lstBook.Items.Add(item);
            }

            lstBook.EndUpdate();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            BookId = lstBook.SelectedItems[0].Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void lstBook_DoubleClick(object sender, EventArgs e)
        {
            this.btnOK_Click(sender, e);
        }
    }
}
