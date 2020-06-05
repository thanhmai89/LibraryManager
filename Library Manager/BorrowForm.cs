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
    public partial class BorrowForm : DevExpress.XtraEditors.XtraForm
    {
        //Map<string, int> cart;
        DataTable table;

        public BorrowForm()
        {
            InitializeComponent();
        }

        private void timeSystem_Tick(object sender, EventArgs e)
        {
            lblTimeSys.Text = " | " + DateTime.Now.ToLongTimeString();
        }

        private void setAutoComplete()
        {
            //Id Student
            txtIdBorrow.AutoCompleteMode = txtIdBook.AutoCompleteMode = txtIdStudent.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtIdStudent.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var txtIdStudentAutoCompleteCustomsource = new AutoCompleteStringCollection();
            txtIdStudentAutoCompleteCustomsource.AddRange(Student.getStudentId());
            txtIdStudent.AutoCompleteCustomSource = txtIdStudentAutoCompleteCustomsource;
            //Id borrow
            //txt.AutoCompleteMode = txtEmail.AutoCompleteMode = txtIdStudent.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtIdBorrow.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var txtIdBorrowAutoCompleteCustomsource = new AutoCompleteStringCollection();
            txtIdBorrowAutoCompleteCustomsource.AddRange(Borrow.getBorrowId());
            txtIdBorrow.AutoCompleteCustomSource = txtIdBorrowAutoCompleteCustomsource;

            //id Book
            txtIdBook.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var txtIdBookAutoCompleteCustomsource = new AutoCompleteStringCollection();
            txtIdBookAutoCompleteCustomsource.AddRange(Book.getBookSerial());
            txtIdBook.AutoCompleteCustomSource = txtIdBookAutoCompleteCustomsource;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            lblAccount.Text = Utility.ACCOUNT;
            setLabel("chưa chọn");
            setButton("", false);
            //set txt source
            lblQuantum.Text = "0";
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
                    tsbtnAddMode.Enabled = tsbtnDelMode.Enabled = !status;
                    //set tool trip menu
                    thêmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = !status;
                    //set txt no need
                    txtAmount.Enabled = txtComment.Enabled = txtIdBook.Enabled = !status;
                    //Set rbtn find
                    rbtnFindbyIdBorrow.Select();
                    rbtnFindbyIdBorrow.Visible = rbtnFindbyIdStudent.Visible = true;
                    txtIdBorrow.Enabled = true;
                    txtIdStudent.Enabled = false;
                    btnAdd.Enabled = btnCancel.Enabled = btnFullCancel.Enabled = false;
                    break;
                #endregion FIND
                case "add":
                    #region ADD

                    btnMode.Enabled = btnReset.Enabled = tsbtnAddMode.Enabled = status;

                    tsbtnFindMode.Enabled = tsbtnDelMode.Enabled = !status;

                    tìmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = !status;
                    btnAdd.Enabled = btnCancel.Enabled = btnFullCancel.Enabled = status;

                    //set txt need
                    //
                    txtIdBorrow.Enabled = false;
                    txtIdStudent.Enabled = txtIdBook.Enabled = txtAmount.Enabled = txtComment.Enabled = status;
                    //Set rbtn find
                    //rbtnFindbyId.Select();
                    rbtnFindbyIdBorrow.Visible = rbtnFindbyIdStudent.Visible = false;
                    break;
                #endregion ADD
                case "del":
                    #region DELETE
                    btnMode.Enabled = btnReset.Enabled = tsbtnDelMode.Enabled = status;
                    txtIdStudent.Enabled = txtComment.Enabled = txtAmount.Enabled = txtIdBook.Enabled = !status;
                    tsbtnAddMode.Enabled = tsbtnFindMode.Enabled = !status;
                    thêmToolStripMenuItem.Enabled = tìmToolStripMenuItem.Enabled = !status;
                    break;
                #endregion DELETE
                case "":
                    btnMode.Enabled = btnReset.Enabled = status;
                    tsbtnAddMode.Enabled = tsbtnFindMode.Enabled = !status;
                    //must found before del or update
                    tsbtnDelMode.Enabled = status;
                    tìmToolStripMenuItem.Enabled = thêmToolStripMenuItem.Enabled = xóaToolStripMenuItem.Enabled = !status;
                    txtIdBook.Enabled = txtIdStudent.Enabled = txtAmount.Enabled = txtComment.Enabled = !status;
                    rbtnFindbyIdBorrow.Select();
                    rbtnFindbyIdBorrow.Visible = rbtnFindbyIdStudent.Visible = false;
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
            txtComment.Text = txtIdBook.Text = txtIdBorrow.Text = txtAmount.Text = txtIdStudent.Text = "";
            lblQuantum.Text = "0";
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
            //
        }

        private void tsbtnDelMode_Click(object sender, EventArgs e)
        {
            setLabel("Xóa");
            setButton("del", true);
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
        #endregion ToolStrip

        private void btnMode_Click(object sender, EventArgs e)
        {
            switch (btnMode.Text)
            {
                case "Tìm":
                    #region TÌM 
                    if (rbtnFindbyIdStudent.Checked)
                    {
                        dtgvCart.Rows.Clear();
                        try
                        {
                            table = Borrow.findBorrowByIdStudent(txtIdStudent.Text);
                            foreach (DataRow row in table.Rows)
                            {
                                if(!txtIdBook.Text.Contains(row[0].ToString()))
                                    txtIdBorrow.Text += row[0].ToString() + ", ";
                                dtgvCart.Rows.Add(row[1], Book.getBookNameBySerial(row[1].ToString()), row[2].ToString());
                 
                            }
                            //txtIdStudent.Text = table.Rows[0][0].ToString();
                            xóaToolStripMenuItem.Enabled = tsbtnDelMode.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            clear();
                            MessageBox.Show("Không tìm thấy sinh viên\nLỗi : " + ex.Message, "Thất bại!");
                        }
                        //MessageBox.Show("Không tìm thấy thẻ mượn sách của sinh viên", "Thất bại!");
                    }
                    else
                    {
                        try
                        {
                            dtgvCart.Rows.Clear();
                            table = Borrow.findBorrowById(txtIdBorrow.Text);
                            txtIdStudent.Text = table.Rows[0][0].ToString();
                            foreach (DataRow row in table.Rows)
                            {
                                dtgvCart.Rows.Add(row[1].ToString(), Book.getBookNameBySerial(row[1].ToString()), row[2].ToString());
                            }
                            //edit here             
                            xóaToolStripMenuItem.Enabled = tsbtnDelMode.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            clear();
                            MessageBox.Show("Không tìm thấy thẻ mượn sách của sinh viên\nLỗi : " + ex.Message, "Thất bại!");
                        }
                    }
                    #endregion TÌM
                    break;
                case "Thêm":
                    #region THÊM
                    {
                        //
                        if (txtAmount.Value*txtIdStudent.TextLength*dtgvCart.Rows.Count*cbxBorrowTime.Text.Length == 0)
                        {
                            MessageBox.Show("Bạn chưa điền đủ thông tin!", "Thông báo");
                        }
                        else
                        {
                            if (Borrow.numOfBorrowCard(txtIdStudent.Text) < 5)
                            {
                                if (Borrow.insertBorrow(txtIdStudent.Text) > 0)
                                    try
                                    {
                                        txtIdBorrow.Text = (Borrow.getId()).ToString();
                                        foreach (DataGridViewRow row in dtgvCart.Rows)
                                        {
                                            Borrow.insertBorrow(txtIdBorrow.Text, row.Cells[0].Value.ToString(), int.Parse(row.Cells[2].Value.ToString()), DateTime.Now, cbxBorrowTime.GetItemText(cbxBorrowTime.SelectedItem)[0] - '0', txtComment.Text);
                                        }
                                        txtIdBook.Text = "";
                                        txtAmount.Value = 1;
                                        txtComment.Text = "";
                                        lblQuantum.Text = "0";
                                        dtgvCart.Rows.Clear();
                                        MessageBox.Show("Tạo thành công thẻ mượn sách cho sinh viên : " + txtIdStudent.Text + "\nMã thẻ mượn : " + txtIdBorrow.Text, "Thông báo");
                                        cbxBorrowTime.SelectedIndex = -1;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Không thể tạo\nLỗi : " + ex.Message, "Thông báo");
                                        break;
                                    }
                            }
                            else
                            {
                                MessageBox.Show("Bạn đã đạt giới hạn 5 phiếu mượn sách", "Thông báo");
                            }
                        }
                        setAutoComplete();
                    }
                    #endregion THÊM
                    break;
                case "Xóa":
                    if (MessageBox.Show("Bạn có chắc muốn xóa thẻ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (Borrow.deleteBorrow(txtIdBorrow.Text))
                        {
                            MessageBox.Show("Xóa thẻ thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Không xóa được thẻ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    setAutoComplete();
                    break;
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
            dtgvCart.Rows.Clear();
            clear();
        }

        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Có vẻ như bạn chưa hoàn thành công việc... \n\n Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
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
        private void rbtnFindbyId_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion RADIOBUTTON

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
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFullCancel_Click(object sender, EventArgs e)
        {
            dtgvCart.Rows.Clear();
            dtgvCart.Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dtgvCart.Rows.Remove(dtgvCart.SelectedRows[0]);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Book.haveBook(txtIdBook.Text))
            {
                foreach (DataGridViewRow dataGridViewRow in dtgvCart.Rows)
                {
                    if (dataGridViewRow.Cells[0].Value.ToString().Equals(txtIdBook.Text))
                    {
                        if (int.Parse(dataGridViewRow.Cells[2].Value.ToString()) + int.Parse(txtAmount.Value.ToString()) > int.Parse(Book.getBookQuantumBySerial(txtIdBook.Text)))
                        {
                            MessageBox.Show("Số lượng sách bạn mượn vượt quá số sách còn trong thư viện!", "Thông báo!");
                        }
                        else
                        {
                            dataGridViewRow.Cells[2].Value = int.Parse(dataGridViewRow.Cells[2].Value.ToString()) + int.Parse(txtAmount.Value.ToString());
                        }
                        return;
                    }
                }
                if(int.Parse(txtAmount.Value.ToString()) > int.Parse(Book.getBookQuantumBySerial(txtIdBook.Text)))
                {
                    MessageBox.Show("Số lượng sách bạn mượn vượt quá số sách còn trong thư viện!", "Thông báo!");
                    return;
                }
                dtgvCart.Rows.Add(txtIdBook.Text, Book.getBookNameBySerial(txtIdBook.Text), txtAmount.Value);
                //cart.Add(txtIdBook.Text);
            }
        }

        private void txtIdBook_TextChanged(object sender, EventArgs e)
        {
            lblQuantum.Text = Book.getBookQuantumBySerial(txtIdBook.Text);
            VerifyInput_TextChanged(sender, e);
        }

        private void rbtnFindbyIdBorrow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFindbyIdBorrow.Checked)
            {
                txtIdBorrow.Enabled = true;
                txtIdBorrow.Select();
                txtIdStudent.Enabled = false;
            }
            else
            {
                txtIdBorrow.Enabled = false;
                txtIdStudent.Enabled = true;
                txtIdStudent.Select();
            }
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