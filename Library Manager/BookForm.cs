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
    public partial class BookForm : DevExpress.XtraEditors.XtraForm
    {
        string imgLogcation = "";
        DataTable table;
        public BookForm()
        {
            InitializeComponent();
        }

        private void timeSystem_Tick(object sender, EventArgs e)
        {
            lblTimeSys.Text = " | " + DateTime.Now.ToLongTimeString();
        }
        private void setAutoComplete()
        {
            txtName.AutoCompleteMode = txtAuthor.AutoCompleteMode = txtSerial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSerial.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var txtNameAutoCompleteCustomsource = new AutoCompleteStringCollection();
            txtNameAutoCompleteCustomsource.AddRange(Book.getBookName());
            txtName.AutoCompleteCustomSource = txtNameAutoCompleteCustomsource;
            //serial
            txtName.AutoCompleteMode = txtAuthor.AutoCompleteMode = txtSerial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSerial.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var txtSerialAutoCompleteCustomsource = new AutoCompleteStringCollection();
            txtSerialAutoCompleteCustomsource.AddRange(Book.getBookSerial());
            txtSerial.AutoCompleteCustomSource = txtSerialAutoCompleteCustomsource;
        }
        private void BookForm_Load(object sender, EventArgs e)
        {
            lblAccount.Text = Utility.ACCOUNT;
            setLabel("chưa chọn");
            setButton("", false);
            rbtnFindbySerial.Visible = rbtnFindbyName.Visible = false;
            //set txt source
            //name
            setAutoComplete();
        }

        private void setButton(string btn, bool status)
        {
            switch (btn)
            {
                case "find":
                    #region FIND
                    //set button
                    btnMode.Enabled = btnReset.Enabled = tsbtnFindMode.Enabled = status; 
                    //set menu strip
                    tsbtnAddMode.Enabled = tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = !status;
                    //set tool trip menu
                    thêmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = btnAddImage.Enabled = !status;
                    //set txt no need
                    txtAmount.Enabled = txtAuthor.Enabled = txtPH.Enabled = txtTag.Enabled = !status;
                    //Set rbtn find
                    rbtnFindbySerial.Select();
                    rbtnFindbyName.Visible = rbtnFindbySerial.Visible = true;
                    txtName.Enabled = false;
                    break;
                    #endregion FIND
                case "add":
                    #region ADD
                
                    btnAddImage.Enabled = btnMode.Enabled = btnReset.Enabled = tsbtnAddMode.Enabled = status;

                    tsbtnFindMode.Enabled = tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = !status;

                    tìmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = !status;

                    //set txt need
                    txtAmount.Enabled = txtAuthor.Enabled = txtPH.Enabled = txtTag.Enabled = txtName.Enabled = status;
                    //Set rbtn find
                    //rbtnFindbySerial.Select();
                    rbtnFindbyName.Visible = rbtnFindbySerial.Visible = false;
                    break;
                    #endregion ADD
                case "del":
                    #region DELETE
                    btnAddImage.Enabled = !status;
                    btnMode.Enabled = btnReset.Enabled = tsbtnDelMode.Enabled = status;
                    txtSerial.Enabled = txtAmount.Enabled = txtAuthor.Enabled = txtPH.Enabled = txtTag.Enabled = txtName.Enabled = !status;
                    tsbtnAddMode.Enabled = tsbtnFindMode.Enabled = tsbtnUpdateMode.Enabled = !status;
                    thêmToolStripMenuItem.Enabled = tìmToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = txtAmount.Enabled = !status;
                    rbtnFindbyName.Visible = rbtnFindbySerial.Visible = false;
                    break;
                    #endregion DELETE

                case "update":
                    txtSerial.Enabled = false;
                    txtAmount.Enabled = txtAuthor.Enabled = txtPH.Enabled = txtTag.Enabled = txtName.Enabled = status;
                    btnAddImage.Enabled = btnMode.Enabled = btnReset.Enabled = tsbtnUpdateMode.Enabled = status;
                    tsbtnAddMode.Enabled = tsbtnDelMode.Enabled = tsbtnFindMode.Enabled = !status;
                    thêmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = tìmToolStripMenuItem.Enabled = !status;
                    rbtnFindbyName.Visible = rbtnFindbySerial.Visible = false;
                    break;
                case "":
                    btnAddImage.Enabled = btnMode.Enabled = btnReset.Enabled = status;
                    tsbtnAddMode.Enabled = tsbtnFindMode.Enabled = !status;
                    //must found before del or update
                    tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = status;
                    tìmToolStripMenuItem.Enabled = thêmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = 
                    txtName.Enabled = txtAuthor.Enabled = txtSerial.Enabled = txtTag.Enabled =  txtAmount.Enabled = !status;
                    //rbtnFindbySerial.Select();
                    rbtnFindbyName.Visible = rbtnFindbySerial.Visible = false;
                    break;
            }

        }

        private void setLabel(string mode)
        {
            btnMode.Text = mode;
            lblMode.Text = "Chế độ " + mode;
        }

        private void clear()
        {
            txtAmount.ResetText();
            txtAuthor.Text = txtName.Text = txtPH.Text = txtSerial.Text = txtTag.Text = "";
            ptbImg.ImageLocation = null;
            ptbImg.Image = ptbImg.InitialImage;
        }

        #region ToolStrip

        private void tsbtnFindMode_Click(object sender, EventArgs e)
        {
            setLabel("Tìm");
            setButton("find", true);
        }

        private void tsbtnAddMode_Click(object sender, EventArgs e)
        {
            setLabel("Thêm");
            setButton("add", true);
        }

        private void tsbtnDelMode_Click(object sender, EventArgs e)
        {
            setLabel("Xóa");
            setButton("del", true);
        }

        private void tsbtnUpdateMode_Click(object sender, EventArgs e)
        {
            setLabel("Sửa");
            setButton("update", true);
        }

        private void tìmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnFindMode_Click(sender, e);
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnAddMode_Click(sender, e);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnDelMode_Click(sender, e);
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsbtnUpdateMode_Click(sender, e);
        }
        #endregion ToolStrip

        private void ptbImg_Click(object sender, EventArgs e)
        {
            if (btnAddImage.Enabled)
                btnAddImage_Click(sender, e);
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All Files (*.*)|*.*";
                openFileDialog.Title = "Chọn ảnh";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imgLogcation = openFileDialog.FileName.ToString();
                    ptbImg.ImageLocation = imgLogcation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            switch (btnMode.Text)
            {
                case "Tìm":
                    #region TÌM 
                    if (rbtnFindbySerial.Checked)
                    {
                        try
                        {
                            table = Book.findBookBySerial(txtSerial.Text);
                            txtSerial.Text = table.Rows[0][0].ToString();
                            txtName.Text = table.Rows[0][1].ToString();
                            txtAuthor.Text = table.Rows[0][2].ToString();
                            txtPH.Text = table.Rows[0][3].ToString();
                            txtAmount.Text = table.Rows[0][4].ToString();
                            //img
                            if (table.Rows[0][5] == DBNull.Value)
                            {
                                ptbImg.Image = ptbImg.InitialImage;
                            }
                            else
                            {
                                byte[] img = (byte[])table.Rows[0][5];
                                MemoryStream ms = new MemoryStream(img);
                                ptbImg.Image = Image.FromStream(ms);
                            }
                            //
                            txtTag.Text = table.Rows[0][6].ToString();
                            tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = true;
                            xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = true;
                        }
                        catch(Exception ex)
                        {
                            clear();
                            MessageBox.Show("Không tìm thấy sách", "Thất bại!");
                        }
                    }
                    else
                    {
                        try
                        {
                            table = Book.findBookByName(txtName.Text);
                            txtSerial.Text = table.Rows[0][0].ToString();
                            txtName.Text = table.Rows[0][1].ToString();
                            txtAuthor.Text = table.Rows[0][2].ToString();
                            txtPH.Text = table.Rows[0][3].ToString();
                            txtAmount.Text = table.Rows[0][4].ToString();
                            //img
                            try
                            {
                                if (table.Rows[0][5] == DBNull.Value)
                                {
                                    ptbImg.Image = ptbImg.InitialImage;
                                }
                                else
                                {
                                    byte[] img = (byte[])table.Rows[0][5];
                                    MemoryStream ms = new MemoryStream(img);
                                    ptbImg.Image = Image.FromStream(ms);
                                }
                                //
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            txtTag.Text = table.Rows[0][6].ToString();
                            tsbtnDelMode.Enabled = tsbtnUpdateMode.Enabled = true;
                            xóaToolStripMenuItem.Enabled = sửaToolStripMenuItem.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            clear();
                            MessageBox.Show("Không tìm thấy sách", "Thất bại!");
                        }
                    }
                    setAutoComplete();
                    #endregion TÌM
                    break;
                case "Thêm":
                    #region THÊM
                    if ((txtAuthor.TextLength * txtName.TextLength * txtPH.TextLength * txtSerial.TextLength * txtTag.TextLength * imgLogcation.Length) == 0)
                    {
                        MessageBox.Show("Bạn cần điền đầy đủ thông tin cho sách", "Lỗi", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                        if (Book.insertBook(txtSerial.Text, txtName.Text, txtAuthor.Text, txtPH.Text, (int)txtAmount.Value, imgLogcation, txtTag.Text))
                            MessageBox.Show("Thêm sách thành công!", "Thành công");
                        else
                            MessageBox.Show("Thêm sách thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    #endregion THÊM
                    setAutoComplete();
                    break;
                case "Xóa":
                    if (MessageBox.Show("Bạn có chắc muốn xóa sách?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (Book.deleteBook(txtSerial.Text))
                        {
                            MessageBox.Show("Xóa sách thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Không xóa được sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    setAutoComplete();
                    break;
                case "Sửa":
                    #region SỬA
                    if (MessageBox.Show("Bạn có chắc muốn sửa thông tin của sách?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if ((txtAuthor.TextLength * txtName.TextLength * txtPH.TextLength * txtSerial.TextLength * txtTag.TextLength)==0 || (imgLogcation.Length == 0 && table.Rows[0][5] == DBNull.Value))
                        {
                            MessageBox.Show("Bạn cần điền đầy đủ thông tin cho sách", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (!Book.updateBook(txtSerial.Text, txtName.Text, txtAuthor.Text, txtPH.Text, (int)txtAmount.Value, imgLogcation, txtTag.Text))
                                if (!Book.updateBook(txtSerial.Text, txtName.Text, txtAuthor.Text, txtPH.Text, (int)txtAmount.Value, (byte[])table.Rows[0][5], txtTag.Text))
                                {
                                    MessageBox.Show("Sửa sách thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            MessageBox.Show("Sửa sách thành công!", "Thành công");
                        }
                    }
                    setAutoComplete();
                    break;
                    #endregion SỬA
                default:
                    break;
            }
        }
        

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            setLabel("chưa chọn");
            setButton("", false);
            imgLogcation = "";
            clear();
            setAutoComplete();
        }

        private void BookForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((txtAuthor.TextLength + txtName.TextLength + txtPH.TextLength + txtSerial.TextLength + txtTag.TextLength) > 0)
            {
                if (MessageBox.Show("Có vẻ như bạn chưa hoàn thành công việc... \n\n Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đồ án môn Lập trình trên môi trường Windows\n" +
                            "Các thành viên thực hiện\n" +
                            "Nguyễn Thành Long\n" +
                            "Nguyễn Ngọc Thiên Long\n" +
                            "Đoàn Ngọc Thiện", "Thông tin");
        }

        #region RADIOBUTTON
        private void rbtnFindbySerial_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFindbySerial.Checked)
            {
                txtSerial.Enabled = true;
                txtSerial.Select();
                txtName.Enabled = false;
            }
            else
            {
                txtSerial.Enabled = false;
                txtName.Enabled = true;
                txtName.Select();
            }
        }
        #endregion RADIOBUTTON

        private void VerifyInput_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            for (int i = 0; i < textBox.TextLength; i++)
            {
                if (char.IsLetterOrDigit(textBox.Text[i]) == false && textBox.Text[i] != ' ' && textBox.Text[i] != ',')
                {
                    textBox.Text = textBox.Text.Remove(i, 1);
                    textBox.SelectionStart = i;
                    textBox.SelectionLength = 0;
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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