using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab
{
    class CBook
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public int AuthorID { set; get; }
        public int Year { set; get; }

        public void Insert()
        {
            SqlConnection connection = new SqlConnection(frmBooks.connectionString);
            connection.Open();
            SqlCommand insertCommand = new SqlCommand("insert into Books (Name,Year,AuthorID) values (@Name, @Year, @AuthorID)");
            insertCommand.Connection = connection;
            SqlParameter parName = new SqlParameter("@Name", System.Data.SqlDbType.NVarChar);
            parName.Value = Name;
            insertCommand.Parameters.Add(parName);
            insertCommand.Parameters.AddWithValue("@Year", Year);
            insertCommand.Parameters.AddWithValue("@AuthorID", AuthorID);
            insertCommand.ExecuteNonQuery();
        }
        public void Update()
        {
            SqlConnection connection = new SqlConnection(frmBooks.connectionString);
            connection.Open();
            SqlCommand updateCommand = new SqlCommand("update Books set Name=@Name, Year=@Year, AuthorID=@AuthorID where id=@ID");
            updateCommand.Parameters.AddWithValue("@ID", ID);
            updateCommand.Parameters.AddWithValue("@Name", Name);
            updateCommand.Parameters.AddWithValue("@Year", Year);
            updateCommand.Parameters.AddWithValue("@AuthorID", AuthorID);
            updateCommand.Connection = connection;
            updateCommand.ExecuteNonQuery();
            connection.Close();



        }
        public static void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(frmBooks.connectionString);
            connection.Open();
            SqlCommand deleteCommand = new SqlCommand("delete from Books where ID="+id);
            deleteCommand.Connection = connection;
            deleteCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static CBook Load(int id)
        {
            CBook book = new CBook();
            SqlConnection connection = new SqlConnection(frmBooks.connectionString);
            connection.Open();
            SqlCommand readerCommand = new SqlCommand("select Name, Year, AuthorID from Books where ID="+id);
            readerCommand.Connection = connection;
            SqlDataReader reader = readerCommand.ExecuteReader();
            while (reader.Read())
            {
                book.ID = id;
                book.Name=(string)reader["Name"];
                book.Year = (int)reader["Year"];
                book.AuthorID = (int)reader["AuthorID"];
            }
            reader.Close();
            connection.Close();
            return book;

        }
        public static string  Proc(int id)
        {
            SqlConnection conn = new SqlConnection(frmBooks.connectionString);
            SqlCommand command1 = new SqlCommand("GetBookName");//!!!!
            command1.CommandType = CommandType.StoredProcedure;//!!!!
            command1.Parameters.AddWithValue("@ID", id);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@Name";
            pName.SqlDbType = SqlDbType.NVarChar;
            pName.Size = 1000;
            pName.Direction = ParameterDirection.Output;///!!!!!
            pName.Value = "";
            command1.Parameters.Add(pName);

            command1.Connection = conn;
            command1.Connection.Open();
            command1.ExecuteNonQuery();
            command1.Connection.Close();
            
           return (string)pName.Value;
        }
    }
}
