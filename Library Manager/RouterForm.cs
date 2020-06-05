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

namespace Library_Manager
{
    public partial class RouterForm : DevExpress.XtraEditors.XtraForm
    {
        public RouterForm()
        {
            InitializeComponent();
        }

        private void RouterForm_Load(object sender, EventArgs e)
        {
            lblAccount.Text = Utility.ACCOUNT;
            toolTipBook.SetToolTip(imgBook, "Thao tác với sách");
            toolTipUser.SetToolTip(imgUser, "Thao tác với tài khoản sinh viên");
            toolTipBorrow.SetToolTip(imgBorrow, "Thao tác với thẻ mượn sách");
            toolTipData.SetToolTip(imgData, "Thao tác với dữ liệu");
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

        private void timeSystem_Tick(object sender, EventArgs e)
        {
            lblTimeSys.Text = DateTime.Now.ToLongTimeString();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgGoToForm_Click(imgBook, e);
        }

        private void thẻThưViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgGoToForm_Click(imgUser , e);
        }

        private void dữLiệuHệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgGoToForm_Click(imgData, e);
        }

        private void phiếuMượnSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imgGoToForm_Click(imgBorrow, e);
        }

        private void RouterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Application.OpenForms.Count > 2)
            {
                MessageBox.Show("Hãy đóng tất cả cửa sổ làm việc trước khi đăng xuất!", "Thông báo");
                e.Cancel = true;
                return;
            }
            if (MessageBox.Show("Bạn có chắc là muốn đăng xuất khỏi tài khoản?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "LoginForm")
                {
                    SysAccount.LogOutAccount(Utility.ACCOUNT);
                    form.Show();
                }
                return;
            }
        }

        private void imgGoToForm_Click(object sender, EventArgs e)
        {
            PictureBox senderForm = (PictureBox)sender;
            bool opened = false;
            foreach (Form form in Application.OpenForms)
                if (form.Name == (string)senderForm.Tag)
                {
                    opened = true;
                    form.Show();
                    break;
                }
            if (!opened)
            {
                switch ((string)senderForm.Tag)
                {
                    case "BookForm":
                        BookForm bookForm = new BookForm();
                        bookForm.Show();
                        opened = true;
                        break;
                    case "StudentForm":
                        StudentForm studentForm = new StudentForm();
                        studentForm.Show();
                        opened = true;
                        break;
                    case "DataForm":
                        DataForm dataForm = new DataForm();
                        dataForm.Show();
                        opened = true;
                        break;
                    case "BorrowForm":
                        BorrowForm borrowFrom = new BorrowForm();
                        borrowFrom.Show();
                        opened = true;
                        break;
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}