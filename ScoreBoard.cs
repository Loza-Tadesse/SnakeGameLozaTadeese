using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameLozaTadesse
{
    public partial class ScoreBoard : Form 

    {
        static String path = Path.GetFullPath(Environment.CurrentDirectory);
        static String dataBaseName = "data.mdf";
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + dataBaseName + "; Integrated Security=True;";
        public ScoreBoard()
        {
            InitializeComponent();
        }

        private void Home_btn_Click(object sender, EventArgs e)
        {
            Form GameForm = new GameForm();
            GameForm.Show();
            this.Hide();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       // addCurrentScoreToDatabase();
       // UpdateScoreBoard();



        private void UpdateScoreBoard()
        {
            //get data from database and show in data grid view 
            string query = "SELECT Date,Name,Scores FROM scores";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                var ds = new DataSet();
                adapter.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Descending);
            }
        }
        private void addCurrentScoresToDatabase()
        {
            //insert score label value in database with name and satatime
            string query = "INSERT INFO score(Date,Name,Scores) VALUES(@Date,@Name,@Scores);";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {

                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = DateTime.Now;
                 //   cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = ID.Text;
                  //  cmd.Parameters.Add("@Scores", SqlDbType.Int).Value = Game.CurrentScore.Text;

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    throw;
                }

            }
        }



    }
}
