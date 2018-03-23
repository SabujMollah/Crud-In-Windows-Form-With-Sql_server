using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proj
{
    public partial class Form1 : Form
    {
        static string constr = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd;
        DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            cmd = new SqlCommand("Sp_DisplayData", con);
            con.Open();
            dt.Clear();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Sp_InsertData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@deptname", SqlDbType.VarChar).Value = txtdname.Text;
            cmd.Parameters.Add("@empname", SqlDbType.VarChar).Value = txtename.Text;
            cmd.Parameters.Add("@empjoiningdate", SqlDbType.Date).Value = dateTimePicker1.Text;
            cmd.Parameters.Add("@bossname", SqlDbType.VarChar).Value = txtbname.Text;          
            cmd.Parameters.Add("@perdayrate", SqlDbType.Real).Value = txtperdayrate.Text;
            con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Success");

                con.Close();
                LoadGrid();
                Emptybox();
            }
            
        }

        private void Emptybox()
        {
            txtdname.Text = "";
            txtename.Text = "";
            dateTimePicker1.Text = "";
            txtbname.Text = "";
          
            txtperdayrate.Text="";
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                foreach (DataRow r in dt.Rows)
                {
                    if ((int)r["Serial No"] == id)
                    {
                        txtdname.Text = r["Dept.Name"].ToString();
                        txtename.Text = r["Emp.Name"].ToString();
                        dateTimePicker1.Text = r["Emp.Joindate"].ToString();
                        txtbname.Text = r["Boss Name"].ToString();
                      
                        txtperdayrate.Text = r["Per Day Rate"].ToString();
                        txtsalary.Text = r["Monthly Salary"].ToString();
                        txtslno.Text = r["Serial No"].ToString();

                        break;
                    }
                }

            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Sp_UpdateData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = txtslno.Text;
            cmd.Parameters.Add("@deptname", SqlDbType.VarChar).Value = txtdname.Text;
            cmd.Parameters.Add("@empname", SqlDbType.VarChar).Value = txtename.Text;
            cmd.Parameters.Add("@empjoiningdate", SqlDbType.Date).Value = dateTimePicker1.Text;
            cmd.Parameters.Add("@bossname", SqlDbType.VarChar).Value = txtbname.Text;
          
            cmd.Parameters.Add("@perdayrate", SqlDbType.Real).Value = txtperdayrate.Text;
                 
            con.Open();
         
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show(" Update Success");

                con.Close();
                LoadGrid();
                Emptybox();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                foreach (DataRow r in dt.Rows)
                {
                    if ((int)r["Serial No"] == id)
                    {
                        cmd = new SqlCommand("Delete from Department Where deptid=" + id, con);
                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Successfully deleted");
                            con.Close();
                            LoadGrid();
                        }                     
                        break;
                    }
                }

            }
        }
    }
}
