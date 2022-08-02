using MOVIE_GO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Test_Form
{
    public partial class Main : Form
    {
        DataTable MOVIE_DT = new DataTable();
        DataTable REGION_DT = new DataTable();
        DataTable CENTER_DT = new DataTable();
        DataTable MOVIE_LIST_TIME = new DataTable();
        DataTable dt4 = new DataTable();
        public Main()
        {
            InitializeComponent();
        }

        #region  폼로드
        private void Main_load(object sender, EventArgs e)                                                                                                                          // 폼 로드
        {
            //grd_Movie_List.Columns.Add("Movie_NM", "영화명");

            login login_form = new login();
            DialogResult Result = login_form.ShowDialog();


            if (Result != DialogResult.OK)
            {
                MessageBox.Show("프로그램이 종료되었습니다");
                this.Close();
            }
            else
            {
                WindowState = FormWindowState.Maximized;

                grd_Movie_List.Columns.Add("MOVIE_NM","영화명");
                grd_Movie_List.Columns.Add("MOVIE_CD", "코드");
                grd_Movie_List.Columns["MOVIE_CD"].Visible = false;
                grd_Movie_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                grd_Region.Columns.Add("REGION_NM", "지역");
                grd_Region.Columns.Add("REGION_CD", "지역_CD");
                grd_Region.Columns[1].Visible = false;      // 센터코드는 안보이게 설정
                grd_Region.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grd_Center.Columns.Add("CENTER_NM", "지점");
                grd_Center.Columns.Add("CENTER_CD", "지점코드");
                grd_Center.Columns["CENTER_CD"].Visible = false;
                grd_Center.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grd_Date.Columns.Add("DATE", "   일자");
                grd_Date.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grd_Date.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grd_Time.Columns.Add("TIME","시간");
                grd_Time.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grd_Time.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                Data_Load(sender, e);
            }
    
        }
        private void Data_Load(object sender, EventArgs e)                                                                                                                          // 데이터 가져오기
        {                                                                                           // 모두 초기화
            MOVIE_DT.Rows.Clear();                                            // 영화 리스트 초기화
            grd_Movie_List.Rows.Clear();

            REGION_DT.Rows.Clear();                                           // 지역 초기화
            grd_Region.Rows.Clear();



            CENTER_DT.Rows.Clear();                                           // 센터 초기화
            grd_Center.Rows.Clear();


            MOVIE_LIST_TIME.Rows.Clear();                                     // 시간 초기화
            grd_Time.Rows.Clear();

            grd_Date.Rows.Clear();

            lbl_Movie_check.Text = "X";
            lbl_Movie_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FA0202");
            lbl_Center_check.Text = "X";
            lbl_Center_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FA0202");
            lbl_Date_check.Text = "X";
            lbl_Date_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FA0202");

            lbl_MOVIE_NM.Text = "선택없음";
            lbl_Movie_REGION.Text = "선택없음";
            lbl_Movie_CENTER.Text = "선택없음";
            lbl_PICK_YMD.Text = "선택없음";
            lbl_PICK_TIME.Text = "선택없음";





            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cjsdn\Documents\Login_Account.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda0 = new SqlDataAdapter("SELECT MOVIE_NM, MOVIE_CD FROM MOVIE_LIST A WHERE A.USE_YN = 'Y' AND A.EXP_YMD IS NULL", con);
            sda0.Fill(MOVIE_DT);                                              // 영화 리스트 가져오기

            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT DISTINCT B.REGION_NM, B.REGION_CD FROM MOVIE_CENTER A, REGION_INFO B WHERE A.REGION_CD = B.REGION_CD AND A.USE_YN = 'Y' AND A.EXP_YMD IS NULL", con);
            sda1.Fill(REGION_DT);                                            // 지역정보 가져오기

            




            if (MOVIE_DT.Rows.Count > 0)                                                            // 영화 리스트 Row추가
            {
                foreach (DataRow a in MOVIE_DT.Rows)
                {
                    grd_Movie_List.Rows.Add(a["MOVIE_NM"].ToString().Trim(),a["MOVIE_CD"].ToString().Trim());
                }
            }
            else
            {
                MessageBox.Show("영화리스트가 없습니다.", "알림");
            }

            if (REGION_DT.Rows.Count > 0)                                                           // 지역 Row추가
            {
                foreach (DataRow b in REGION_DT.Rows)
                {
                    grd_Region.Rows.Add(b["REGION_NM"], b["REGION_CD"].ToString().Trim());
                }
            }
            else
            {
                MessageBox.Show("지역정보가 없습니다.", "알림");
            }

            var ToDay = DateTime.Now.ToString("yyyy-MM-dd");                                        // 날짜 추가
            var EndDay = DateTime.Now.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            DateTime startTime = DateTime.ParseExact(ToDay, "yyyy-MM-dd", null);
            DateTime endTime = DateTime.ParseExact(EndDay, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            for (var date = startTime; date <= endTime; date = date.AddDays(1))
            {
                grd_Date.Rows.Add(date.ToString("yyyy-MM-dd"));
            }



        }
        #endregion

        #region "Click 이벤트"
        private void Refresh_Click(object sender, EventArgs e)                                                                                                                      // 새로고침 버튼 클릭
        {
            Data_Load(sender, e);
        }
        private void grd_MOVIE_LIST_CellClick(object sender, DataGridViewCellEventArgs e)                                                                                           // 영화 리스트 클릭시
        {
            try
            {
                grd_Time.Rows.Clear();
                MOVIE_LIST_TIME.Rows.Clear();
                lbl_MOVIE_NM.Text = grd_Movie_List.Rows[e.RowIndex].Cells[0].Value.ToString();
                lbl_MOVIE_NM.Tag = grd_Movie_List.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (lbl_MOVIE_NM.Text != "선택없음")
                {
                    lbl_Movie_check.Text = "O";
                    lbl_Movie_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#02F81C");
                    Movie_List_Time_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Region_CellClick(object sender, DataGridViewCellEventArgs e)                                                                                                   // 지역정보 클릭시
        {
            try
            {
                lbl_Movie_REGION.Text = grd_Region.Rows[e.RowIndex].Cells[0].Value.ToString();      // 최종확인에 넣기
                lbl_Movie_REGION.Tag = grd_Region.Rows[e.RowIndex].Cells[1].Value.ToString();      // 최종확인에 넣기
                lbl_Movie_CENTER.Text = "선택없음";
                lbl_Center_check.Text = "X";
                
                lbl_Center_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FA0202");
                
                CENTER_DT.Rows.Clear();
                grd_Center.Rows.Clear();
                var center_cd = grd_Region.Rows[e.RowIndex].Cells[1].Value.ToString();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cjsdn\Documents\Login_Account.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT  A.CENTER_NM, A.CENTER_CD FROM MOVIE_CENTER A, REGION_INFO B WHERE A.REGION_CD = B.REGION_CD AND A.USE_YN = 'Y' AND A.EXP_YMD IS NULL AND A.REGION_CD = "+center_cd+"", con);
                sda.Fill(CENTER_DT);                                            // 센터정보 가져오기
            
                if (CENTER_DT.Rows.Count > 0)
                {
                    foreach (DataRow b in CENTER_DT.Rows)
                    {
                        grd_Center.Rows.Add(b["CENTER_NM"].ToString().Trim(), b["CENTER_CD"].ToString().Trim());
                    }
                }
                else
                {
                    MessageBox.Show("조회내역이 없습니다.", "알림");
                }

            }

            catch
            { }
        }
        private void CENTER_CellClick(object sender, DataGridViewCellEventArgs e)                                                                                                   // 지점(센터)클릭시
        {
            try
            {
                MOVIE_LIST_TIME.Rows.Clear();
                grd_Time.Rows.Clear();
                lbl_Movie_CENTER.Text = grd_Center.Rows[e.RowIndex].Cells[0].Value.ToString();
                lbl_Movie_CENTER.Tag = grd_Center.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (lbl_Movie_REGION.Text != "선택없음" && lbl_Movie_CENTER.Text != "선택없음")
                {
                    lbl_Center_check.Text = "O";
                    lbl_Center_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#02F81C");
                    Movie_List_Time_Load(sender, e);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Date_CellClick(object sender, DataGridViewCellEventArgs e)                                                                                                     // 일자 클릭시
        {
            try
            {
                lbl_PICK_TIME.Text = "선택없음";
                lbl_Date_check.Text = "X";
                lbl_Date_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FA0202");
                lbl_PICK_YMD.Text = grd_Date.Rows[e.RowIndex].Cells[0].Value.ToString();
                Movie_List_Time_Load(sender, e);
                if(lbl_PICK_YMD.Text != "선택없음" && lbl_PICK_TIME.Text != "선택없음")
                {
                    lbl_Date_check.Text = "O";
                    lbl_Date_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#02F81C");
                }
                else
                { }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void Time_CellClick(object sender, DataGridViewCellEventArgs e)                                                                                                     // 시간 클릭시
        {
            try
            {
                lbl_PICK_TIME.Text = grd_Time.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (lbl_PICK_YMD.Text != "선택없음" && lbl_PICK_TIME.Text != "선택없음")
                {
                    lbl_Date_check.Text = "O";
                    lbl_Date_check.ForeColor = System.Drawing.ColorTranslator.FromHtml("#02F81C");
                }
                else
                { }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private void btn_SelectSeat_Click(object sender, EventArgs e)
        {
            SelectSeat SelectSeat_form = new SelectSeat(lbl_Movie_REGION.Tag.ToString() ,lbl_MOVIE_NM.Tag.ToString() ,lbl_MOVIE_NM.Text.ToString(), lbl_PICK_YMD.Text.ToString().Replace("-",""));;
            SelectSeat_form.ShowDialog();
        }                                                                                                           // 좌석 선택 버튼 클릭시(Popup)
        #endregion

        #region Method

        private void Movie_List_Time_Load(object sender, EventArgs e)                                                                                                               // 시간가져오는 함수
        {
            MOVIE_LIST_TIME.Rows.Clear();
            grd_Time.Rows.Clear();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cjsdn\Documents\Login_Account.mdf;Integrated Security=True;Connect Timeout=30");
            string Query = string.Empty;
            Query = "SELECT B.MOVIE_TIME FROM MOVIE_LIST A, MOVIE_TIME_LIST B WHERE A.MOVIE_CD = B.MOVIE_CD AND A.USE_YN = B.USE_YN AND A.EXP_YMD IS NULL AND A.USE_YN = 'Y' AND A.MOVIE_CD = '" + lbl_MOVIE_NM.Tag.ToString().Trim() + "'";
            SqlDataAdapter sda2 = new SqlDataAdapter(Query, con);
            sda2.Fill(MOVIE_LIST_TIME);                                      // 영화 시간 가져오기
            if (lbl_Movie_check.Text == "O" && lbl_Center_check.Text == "O" && lbl_PICK_YMD.Text != "선택없음")
            {
                if (MOVIE_LIST_TIME.Rows.Count > 0)                                                            // 영화 시간 Row추가
                {
                    foreach (DataRow a in MOVIE_LIST_TIME.Rows)
                        grd_Time.Rows.Add(a["MOVIE_TIME"].ToString().Trim().Substring(0, 2) + "시 " + a["MOVIE_TIME"].ToString().Trim().Substring(2, 2) + "분");
                }
                else
                {
                    MessageBox.Show("영화에 지정된 시간이 없습니다.", "알림");
                }
            }
            else
            { }
        }
        private void timer1_Tick(object sender, EventArgs e)                                                                                                                        // 타이머
        {
            lbl_sysdate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");                                                // 시간표시
            if(lbl_Movie_check.Text == "O" && lbl_Center_check.Text == "O" && lbl_Date_check.Text == "O")                   // 좌석표시버튼 활성화 여부
            {
                btn_SelectSeat.Enabled = true;
            }
            else
            {
                btn_SelectSeat.Enabled = false;
            }
        }
        #endregion
        
    }
}
