using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTVN_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lastName  = txtLastName.Text;
            string firstName = txtFirstName.Text;
            string phone     = txtPhone.Text;

            if (string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Vui lòng nhập Họ hoặc Tên.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem(lastName);  // lấy cột đầu tiên
            item.SubItems.Add(firstName);                    // nối tiếp cột đầu
            item.SubItems.Add(phone);
            listViewDanhBa.Items.Add(item);                  // Tạo hàng mớiii

            // Xóa nội dung TextBox và đặt con trỏ
            txtLastName.Clear();
            txtFirstName.Clear();
            txtPhone.Clear();
            txtLastName.Focus();                             //return con trỏ về tbox Lastname
        }

        private void listViewDanhBa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDanhBa.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewDanhBa.SelectedItems[0];

                txtLastName.Text  = selectedItem.Text;
                txtFirstName.Text = selectedItem.SubItems[1].Text;
                txtPhone.Text     = selectedItem.SubItems[2].Text;
            }
            else
            {
                // Xóa nội dung các TextBox
                txtLastName.Clear();
                txtFirstName.Clear();
                txtPhone.Clear();
            }
        }
    }
}
