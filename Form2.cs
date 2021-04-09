using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_QUAN_LY_SINH_VIEN
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Option = new MyDel(setDelegate);
            radioButton1.Checked = true;
            setCBB();
        }

        public delegate void MyDel(string MSSV, string Tentuychon);
        public MyDel Option;
        private static string IDSV = "";
        private static string NameOption="";
        public void setDelegate(string MSSV, string Tentuychon)
        {
            IDSV = MSSV;
            NameOption = Tentuychon;
        }
        private void setCBB()
        {
            foreach(LSH i in CSDL_TG.Instance.getListLSH())
            {
                comboBox1.Items.Add(new CBBox
                {
                    text = i.TenLop,
                    Value = i.ID_Lop
                });
            }
            comboBox1.SelectedIndex = 0;
        }

        private SV getInform()
        {
            SV s = new SV();
            s.HoTen = tbHoTen.Text.ToString();
            s.MSSV = tbMSSV.Text.ToString();
            s.ID_Lop = ((CBBox)comboBox1.SelectedItem).Value;
            s.NgaySinh = Convert.ToDateTime(dateTimePicker1.Value);
            if (radioButton1.Checked) s.GioiTinh = true;
            else s.GioiTinh = false;
            return s;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if(tbHoTen.Text != "" && tbMSSV.Text != "")
            {
                if (NameOption == "edit")
                {
                   CSDL_TG.Instance.editSV(getInform());
                }
                else
                {
                    addFUNC();
                }
                this.Close();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                MessageBox.Show("Mời bạn nhập đầy đủ thông tin!!");
            }
        }
        private void addFUNC()
        {
            SV s = new SV();
            s = getInform();
            if (CSDL_TG.Instance.addSV(s))
            {
                MessageBox.Show("Thêm sinh viên thành công", "Thông báo");
            }
            else
            {
                MessageBox.Show("Mã số sinh viên đã bị trùng!", "Thông báo");
            }
        }

        private void showEdit()
        {
            SV s = CSDL_TG.Instance.getSV_ByMSSV(IDSV);
            tbMSSV.Text = s.MSSV;
            tbHoTen.Text = s.HoTen;
            comboBox1.SelectedIndex = s.ID_Lop - 1;
            dateTimePicker1.Value = s.NgaySinh;
            if (radioButton1.Checked) s.GioiTinh = true;
            else s.GioiTinh = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (NameOption == "edit")
            {
                tbMSSV.Enabled = false;
                showEdit();
            }
            else tbMSSV.Enabled = true;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
