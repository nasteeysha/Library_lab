using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryLab
{
    public partial class frmEditBook : Form
    {
        CBook book = new CBook();
        public frmEditBook()
        {
            InitializeComponent();
            SqlDataAdapter adapter = new SqlDataAdapter("select ID, Fam from Authors",frmBooks.connectionString);
            DataSet dsAuthors = new DataSet();
            adapter.Fill(dsAuthors,"Authors");
            cbAuthor.DataSource = dsAuthors.Tables["Authors"];
            cbAuthor.ValueMember = "ID";
            cbAuthor.DisplayMember = "Fam";
        }
        public frmEditBook(int ID)
        {
            InitializeComponent();
            SqlDataAdapter adapter = new SqlDataAdapter("select ID, Fam from Authors", frmBooks.connectionString);
            DataSet dsAuthors = new DataSet();
            adapter.Fill(dsAuthors, "Authors");
            cbAuthor.DataSource = dsAuthors.Tables["Authors"];
            cbAuthor.ValueMember = "ID";
            cbAuthor.DisplayMember = "Fam";
            book = CBook.Load(ID);
            tbName.Text = book.Name;
            tbYear.Text = book.Year.ToString();
            cbAuthor.SelectedValue = book.AuthorID;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            book.Name = tbName.Text;
            book.Year = int.Parse(tbYear.Text);
            book.AuthorID = (int)cbAuthor.SelectedValue;
            if (book.ID == 0)
            {
                book.Insert();
            }
            else
            {
                book.Update();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
