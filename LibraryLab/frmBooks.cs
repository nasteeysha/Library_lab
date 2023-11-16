using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryLab
{
    public partial class frmBooks : Form
    {
        public static string connectionString = @"Server=localhost;Database=master;Trusted_Connection=True;";
        DataSet dsBooks = new DataSet();
        SqlDataAdapter adapter;
        public frmBooks()
        {
            InitializeComponent();

            RefreshView();
        }
        void RefreshView()
        {   
            string selectString="select Books.ID, Books.Name, Books.Year, Authors.Fam from Books left outer join Authors on Books.AuthorID=Authors.ID ";
            if (tbNameFilter.Text != "")
            {
                selectString = selectString + " where dbo.Books.Name like '%" + tbNameFilter.Text + "%'";
            }

            connectionString = selectString;
            adapter = new SqlDataAdapter(selectString, connectionString);
            dsBooks = new DataSet();
           
            adapter.Fill(dsBooks, "Books");
            dgvBooks.DataSource = dsBooks.Tables["Books"];
            dgvBooks.Columns["ID"].Visible = false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEditBook frm = new frmEditBook();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                RefreshView();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ThisRow =dgvBooks.CurrentCell.RowIndex;
            int id = int.Parse(dgvBooks["ID", ThisRow].EditedFormattedValue.ToString());
            frmEditBook frm = new frmEditBook(id);
            if (frm.ShowDialog()==DialogResult.OK)
            {
                RefreshView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ThisRow = dgvBooks.CurrentCell.RowIndex;
            int id = int.Parse(dgvBooks["ID", ThisRow].EditedFormattedValue.ToString());
            string name= CBook.Proc(id);
            DialogResult res= MessageBox.Show(name, "Подтверждение удаления", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                CBook.Delete(id);
                RefreshView();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void btnProc_Click(object sender, EventArgs e)
        {
            MessageBox.Show(CBook.Proc(3));
        }
    }
}
