using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hmsVideo
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            labelIndicator1.ForeColor = System.Drawing.Color.Red;
            labelIndicator2.ForeColor = System.Drawing.Color.Black;
            labelIndicator3.ForeColor = System.Drawing.Color.Black;
            labelIndicator4.ForeColor = System.Drawing.Color.Black;


            //show thow the panel
            panel1.Visible = true;

            //hides the panel2
            panel2.Visible = false;

            panel3.Visible = false;
            panel4.Visible = false;

        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {

            labelIndicator2.ForeColor = System.Drawing.Color.Green;
            labelIndicator1.ForeColor = System.Drawing.Color.Black;
            labelIndicator3.ForeColor = System.Drawing.Color.Black;
            labelIndicator4.ForeColor = System.Drawing.Color.Black;




            //hides the panel1
            panel1.Visible = false;

            //show the panel2
            panel2.Visible = true;

            panel3.Visible = false;
            panel4.Visible = false;

        }

        private void btnPatientHistory_Click(object sender, EventArgs e)
        {

            labelIndicator3.ForeColor = System.Drawing.Color.Blue;
            labelIndicator1.ForeColor = System.Drawing.Color.Black;
            labelIndicator2.ForeColor = System.Drawing.Color.Black;
            labelIndicator4.ForeColor = System.Drawing.Color.Black;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;


            using (SqlConnection con = new SqlConnection("Data Source=my-pc;Initial Catalog=Hospital;Integrated Security=True"))
            {
                con.Open();

                string sqlQuery = "  SELECT * FROM HMS.DiagnosisInfo INNER JOIN HMS.NewPatient ON DiagnosisInfo.pid = NewPatient.pid;";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                {


                    using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                    {
                        DataSet Ds = new DataSet();
                        DA.Fill(Ds);
                        dataGridView2.DataSource = Ds.Tables[0];
                    }
                }



            }


        }

        private void btnHospitalInfo_Click(object sender, EventArgs e)
        {

            labelIndicator4.ForeColor = System.Drawing.Color.OliveDrab;

            labelIndicator1.ForeColor = System.Drawing.Color.Black;
            labelIndicator2.ForeColor = System.Drawing.Color.Black;
            labelIndicator3.ForeColor = System.Drawing.Color.Black;
            labelIndicator4.ForeColor = System.Drawing.Color.DarkOrange;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtboxName.Text;
                string address = txtboxAdd.Text;
                int age = Convert.ToInt32(txtboxAge.Text);
                string gender = txtboxGen.Text;
                Int64 contact = Convert.ToInt64(txtboxCont.Text);
                string bloodgroup = txtboxBldGrp.Text;
                string disease = txtboxDis.Text;
                int pid = Convert.ToInt32(txtboxId.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=my-pc;Initial Catalog=Hospital;Integrated Security=True";
                con.Open(); // Open the connection

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                // Use a parameterized query to prevent SQL injection
                cmd.CommandText = "INSERT INTO Newpatient (Name, FullAddress, Age, Gender, Contact, Blood_Group, Major_Disease, Pid) " +
                                 "VALUES (@name, @address, @age, @gender, @contact, @bloodgroup, @disease, @pid)";

                // Add parameters
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@bloodgroup", bloodgroup);
                cmd.Parameters.AddWithValue("@disease", disease);
                cmd.Parameters.AddWithValue("@pid", pid);

                cmd.ExecuteNonQuery(); // Execute the query

                con.Close(); // Close the connection


                MessageBox.Show("Data saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            txtboxName.Clear();
            txtboxAdd.Clear();
            txtboxAge.Clear();
            txtboxGen.ResetText();
            txtboxCont.Clear();
            txtboxId.Clear();
            txtboxBldGrp.Clear();
            txtboxDis.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBoxPid1.Text);

                using (SqlConnection con = new SqlConnection("Data Source=my-pc;Initial Catalog=Hospital;Integrated Security=True"))
                {
                    con.Open();

                    string sqlQuery = "SELECT * FROM HMS.NewPatient WHERE pid = @pid";

                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@pid", pid);

                        using (SqlDataAdapter DA = new SqlDataAdapter(cmd))
                        {
                            DataSet Ds = new DataSet();
                            DA.Fill(Ds);
                            dataGridView1.DataSource = Ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., invalid input, database connection issues)
                // You should display an error message or log the exception details.
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            try
            {
                int pid = Convert.ToInt32(textBoxPid1.Text);
                string symptoms = textBoxSYmptoms.Text;
                string Diagnosis = textBoxDiagnosis.Text;
                string Medicine = txtBoxMedicine.Text;
                string Required = txtBoxReq.Text;
                string type = txtBoxType.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=my-pc;Initial Catalog=Hospital;Integrated Security=True";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "INSERT INTO  HMS.DiagnosisInfo (pid, Symptoms, Diagnosis, Medicines, Ward, Ward_Type ) " +
                    "VALUES(@pid, @symptoms, @Diagnosis, @Medicine, @Required, @type)";



                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.Parameters.AddWithValue("@symptoms", symptoms);
                cmd.Parameters.AddWithValue("@Diagnosis", Diagnosis);
                cmd.Parameters.AddWithValue("@Medicine", Medicine);
                cmd.Parameters.AddWithValue("@Required", Required);
                cmd.Parameters.AddWithValue("@type", type);


                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Data Added!!");


            }

            catch (Exception ex)
            {
                MessageBox.Show("An Error Occured: ", ex.Message);

            }

            textBoxPid1.Clear();
            textBoxSYmptoms.Clear();
            textBoxDiagnosis.Clear();
            txtBoxMedicine.Clear();
            txtBoxReq.ResetText();
            txtBoxType.ResetText();





        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

