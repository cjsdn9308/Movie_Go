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

namespace MOVIE_GO
{
    public partial class SelectSeat : Form
    {
        #region 폼로드
        public SelectSeat(string strRegion_cd, string strMovie_no ,string strMovie_nm,string strPick_ymd)
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cjsdn\Documents\Login_Account.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT SEAT FROM TICKETING WHERE REGION_CD = '" + strRegion_cd + "' AND MOVIE_NO = '"+ strMovie_no + "'", con);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    //"lbl_" + dt.Rows[i][0].ToString().Trim();
                    var lbl_res = this.Controls.Find("lbl_" + dt.Rows[i][0].ToString().Trim(),true).FirstOrDefault();
                    lbl_res.Enabled = false;
                    lbl_res.BackColor = Color.Red;
                    lbl_res.ForeColor = Color.White;
                    
                    i++;
                }
            }
            

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region 클릭 이벤트
        private void btn_End_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SeatSelect_Click(object sender, EventArgs e)
        {
            if ((sender as Label).BackColor == Color.White)
            {
                (sender as Label).BackColor = Color.LightBlue;
                (sender as Label).ForeColor = Color.White;
            }
            else
            {
                (sender as Label).BackColor = Color.White;
                (sender as Label).ForeColor = Color.Black;
            }
        }
        #endregion
    }
}
