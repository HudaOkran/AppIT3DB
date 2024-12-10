using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace AppIT3DB.Forms
{
    public partial class Frm_Login : Form
    {
        Classes.Connection cl = new Classes.Connection();
        DataTable dt;
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void Id_User_Validated(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt = cl.Execute_Select("select Name_User from Table_Users where Id_User=" + Id_User.Text);
            if (dt.Rows.Count > 0)
            {
                Name_User.Text = dt.Rows[0][0].ToString();
                Pass_User.Focus();
            }
            else
            {
                MessageBox.Show("المستخدم مهلوش");
                Id_User.Clear();
                Name_User.Clear();
                Pass_User.Clear();
                Id_User.Focus();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                dt = new DataTable();
                string s = string.Format("select * from Table_Users where Id_User={0} and Pass_User='{1}'",Id_User.Text,Pass_User.Text);
               dt= cl.Execute_Select(s);
                if(dt.Rows.Count>0)
                {
                    Classes.Connection.UserName = dt.Rows[0][1].ToString();
                    Frm_Main frm = new Frm_Main();
                    this.Hide();
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("كلمة المرور خاطئة");
                    Pass_User.Clear();
                    Pass_User.Focus();
                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}
