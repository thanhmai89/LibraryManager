using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace Library_Manager
{
    public partial class DataForm : DevExpress.XtraEditors.XtraForm
    {
        string imgLogcation = "";
        //DataTable table;

        public DataForm()
        {
            InitializeComponent();
        }

        private void timeSystem_Tick(object sender, EventArgs e)
        {
            lblTimeSys.Text = " | " + DateTime.Now.ToLongTimeString();
        }

        private void setButton(bool status)
        {
            lblPassword.Visible = lblReTypePass.Visible = lblSupperAdmin.Visible = lblUserName.Visible = status;
            btnCreate.Visible = txtPassword.Visible = txtReTypePass.Visible = txtUserName.Visible = txtSuperAdminPass.Visible = status;
            dgvAnalytics.Visible = cbxAnalytics.Visible = status;
        }

        private void setAutoComplete()
        {
        }

       
        private void VerifyInput_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            for (int i = 0; i < textBox.TextLength; i++)
            {
                if (!char.IsLetterOrDigit(textBox.Text[i]) && textBox.Text[i] != ' ' && textBox.Text[i] != '@' && textBox.Text[i] != '.')
                {
                    textBox.Text = textBox.Text.Remove(i, 1);
                    textBox.SelectionStart = i;
                    textBox.SelectionLength = 0;
                }
            }
        }
        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            dgvLog.Rows.Clear();
            dgvLog.Visible = true;

            setButton(false);
            try
            {
                DataTable dataTable = Data.ViewLog();
                foreach(DataRow row in dataTable.Rows)
                {
                    dgvLog.Rows.Add(row[0].ToString(), row[1].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message,"Lỗi");
            }
        }

        private void btnViewAnalytics_Click(object sender, EventArgs e)
        {
            setButton(false);
            dgvLog.Visible = false;
            dgvAnalytics.Visible = true;
            cbxAnalytics.Visible = true;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            dgvLog.Visible = false;
            btnCreate.Text = "Tạo tài khoản";
            lblPassword.Text = "Mật khẩu";
            lblReTypePass.Text = "Gõ lại mật khẩu";
            lblSupperAdmin.Text = "Mật khẩu Super admin";
            setButton(true);
            dgvAnalytics.Visible = false;
            cbxAnalytics.Visible = false;
        }

        private void btnFixAccount_Click(object sender, EventArgs e)
        {
            dgvLog.Visible = false;
            btnCreate.Text = "Sửa tài khoản";
            lblPassword.Text = "Mật khẩu mới";
            lblReTypePass.Text = "Gõ lại mật khẩu mới";
            lblSupperAdmin.Text = "Mật khẩu cũ";
            setButton(true);
            dgvAnalytics.Visible = false;
            cbxAnalytics.Visible = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Text == "Tạo tài khoản")
            {
                if (txtPassword.Text != txtReTypePass.Text)
                {
                    MessageBox.Show("Mật khẩu gõ lại chưa chính xác!", "Thông báo");
                }
                else
                {
                    if (SysAccount.ComputeSha256Hash(txtSuperAdminPass.Text).ToUpper() != Utility.SUPER_ADMIN_PASSWORD)
                    {
                        MessageBox.Show("Mật khẩu Super Admin chưa chính xác!", "Thông báo");
                    }
                    else
                    {
                        if (SysAccount.CreateAccount(txtUserName.Text, txtPassword.Text))
                            MessageBox.Show("Tạo tài khoản thành công", "Thành công!");
                        else
                            MessageBox.Show("Tạo tài khoản thất bại", "Lỗi!");
                    }
                }
            }
            else
            {
                if (txtUserName.TextLength * txtPassword.TextLength == 0)
                {
                    MessageBox.Show("Hãy điền hết các ô!", "Thông báo");
                }
                else
                {
                    if (txtPassword.Text != txtReTypePass.Text)
                    {
                        MessageBox.Show("Mật khẩu gõ lại chưa chính xác!", "Thông báo");
                    }
                    else
                    {
                        if (!SysAccount.CheckOldPass(txtUserName.Text, txtSuperAdminPass.Text))
                        {
                            MessageBox.Show("Mật khẩu cũ bạn nhập chưa chính xác!", "Thông báo");
                        }
                        else
                        {
                            if (SysAccount.UpdateAccount(txtUserName.Text, txtPassword.Text))
                                MessageBox.Show("Sửa tài khoản thành công", "Thành công!");
                            else
                                MessageBox.Show("Sửa tài khoản thất bại", "Lỗi!");
                        }
                    }
                }
            }
        }

        #region TOOLSTRIP
        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnViewLog_Click(sender, e);
        }

        private void viewAnalyticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnViewAnalytics_Click(sender, e);
        }

        private void addAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddAccount_Click(sender, e);
        }

        private void editAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnFixAccount_Click(sender, e);
        }
        #endregion TOOLSTRIP

        private void btnReset_Click(object sender, EventArgs e)
        {
            setButton(false);
            dgvLog.Visible = false;
        }

        private void cbxAnalytics_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxAnalytics.SelectedIndex)
            {
                case 0:
                    {
                        dgvAnalytics.AutoGenerateColumns = true;
                        dgvAnalytics.DataSource = Data.ViewBorrowOverTime();

                    }
                    break;
                case 1:
                    {
                        dgvAnalytics.AutoGenerateColumns = true;
                        dgvAnalytics.DataSource = Data.ViewAllBook();

                    }
                    break;
                case 2:
                    {
                        dgvAnalytics.AutoGenerateColumns = true;
                        dgvAnalytics.DataSource = Data.ViewAllStudent();

                    }
                    break;
                case 3:
                    {
                        dgvAnalytics.AutoGenerateColumns = true;
                        dgvAnalytics.DataSource = Data.ViewAllBorrowCard();

                    }
                    break;
            }

        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            setButton(false);
            dgvLog.Visible = false;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
                if (form.Name == "RouterForm")
                {
                    form.Close();
                    break;
                }
        }
    }
}