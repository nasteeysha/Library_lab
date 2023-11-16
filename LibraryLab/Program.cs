using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryLab
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmBooks());
        }
    }
}


//CREATE PROCEDURE GetBookName
//@ID int, @Name nvarchar(MAX) output AS
//SELECT @Name = Name from books where ID = @ID

//public static void Proc(int id)
//{
//    SqlConnection conn = new SqlConnection(ConnString);
//    SqlCommand command1 = new SqlCommand("GetBookName");//!!!!
//    command1.CommandType = CommandType.StoredProcedure;//!!!!
//    command1.Parameters.AddWithValue("@ID", id);

//    SqlParameter pName = new SqlParameter();
//    pName.ParameterName = "@Name";
//    pName.SqlDbType = SqlDbType.NVarChar;
//    pName.Size = 1000;
//    pName.Direction = ParameterDirection.Output;
//    pName.Value = "";
//    command1.Parameters.Add(pName);

//    command1.Connection = conn;
//    command1.Connection.Open();
//    command1.ExecuteNonQuery();
//    command1.Connection.Close();
//    Console.WriteLine(pName.Value);
//}