using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADO.NET_Command
{
    public partial class CommandReader : Form
    {
        public CommandReader()
        {
            InitializeComponent();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            // Create connection
            SqlConnection conn = new SqlConnection(@"network address= .\sqlexpress; integrated security = true; database = EmployeeDb");

            // Create command
            string sql = @"select EmpId,Name
                          from dbo.EmployeeDetails where EmpID <=500";

            SqlCommand cmd = new SqlCommand(sql, conn);
            
            try
            {
                // Open connection
                conn.Open();

                // Execute query via ExecuteReader
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    txtReader.AppendText("\nEmpID: ");
                    txtReader.AppendText(rdr.GetValue(1) + "\t\t" + rdr.GetValue(0));
                    txtReader.AppendText("\n");
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Exception Details");
            }

            finally
            {
                conn.Close();               
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtReader.Clear();
        }

    }
}
