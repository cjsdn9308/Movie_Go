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


namespace Test_Form
{
    public partial class login : Form
    {
        
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        public login()
        {
            InitializeComponent();
            LogoBox.Load(@"C:\Users\cjsdn\source\repos\Test_Form\Logo.png");
            LogoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            



        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cjsdn\Documents\Login_Account.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda0 = new SqlDataAdapter("SELECT COUNT(*) FROM LOGIN_INFO WHERE ID='" + login_id_txtbox.Text + "' AND PASSWORD = '" + login_pw_txtbox.Text + "'", con);
            sda0.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                dt.Rows.Clear();

                Main Main = new Main();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호를 확인해주세요");
                dt.Rows.Clear();

            }
        }


        private void Login_tbx_id(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(login_id_txtbox.Text == "" || login_id_txtbox == null)
                {

                }
                else
                {
                    // DB연결
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\cjsdn\Documents\Login_Account.mdf;Integrated Security=True;Connect Timeout=30");

                    SqlDataAdapter sda = new SqlDataAdapter("SELECT EMPL_NM FROM LOGIN_INFO WHERE ID='" + login_id_txtbox.Text + "' AND USE_YN = 'Y'" , con);
                    sda.Fill(dt2);

                    try
                    {
                        try
                        {
                            if (dt2.Rows[0][0].ToString() != "" || dt2.Rows[0][0].ToString() != null)
                            {
                                Login_info.TextAlign = HorizontalAlignment.Center;
                                Login_info.Text = dt2.Rows[0][0].ToString();
                                dt2.Rows.Clear();

                                e.SuppressKeyPress = true;
                                SendKeys.Send("{TAB}");
                            }
                            else if (dt2.Rows[0][0].ToString() == "" || dt2.Rows[0][0].ToString() == null)
                            {
                                dt2.Rows.Clear();
                            }
                        }
                        catch
                        {
                            Login_info.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void Login_tbx_pw(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (login_pw_txtbox.Text == "" || login_pw_txtbox.Text == null)
                {

                }
                else
                {
                    e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");
                    SendKeys.Send("{ENTER}");
                }
            }
        }

        private void Login_id_change(object sender, EventArgs e)
        {
            dt2.Rows.Clear();
            Login_info.Text = "";
        }
    }
}
