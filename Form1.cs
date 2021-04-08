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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = CSDL_TG.Instance.GetListSV(0);
            setCBB_LSH();
            setCBB_Sort();
        }

        public void setCBB_LSH()
        {
            cbboxLSH.Items.Add(new CBBox { text="All", Value=0} );
            foreach(LSH i in CSDL_TG.Instance.getListLSH())
            {
                cbboxLSH.Items.Add(new CBBox
                {
                    text = i.TenLop,
                    Value =i.ID_Lop
                });
            }
            cbboxLSH.SelectedIndex = 0;
        }
        
        public void setCBB_Sort()
        {
            foreach(DataColumn i in CSDL.Instance.DTSV.Columns)
            {
                cbboxSort.Items.Add(i.ColumnName);
            }    
        }

        private void btShow_Click(object sender, EventArgs e)
        {
            int index = ((CBBox)(cbboxLSH.SelectedItem)).Value;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL_TG.Instance.GetListSV(index);
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    dataGridView1.DataSource = null;
        //    dataGridView1.DataSource = CSDL_TG.Instance.searchSV(textBox1.Text);
        //}

        private void btAdd_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Hide();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            string mssv = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
            f2.Option(mssv, "edit");            
            f2.ShowDialog();
            this.Hide();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) MessageBox.Show("Danh sach sinh vien rong!", "Thong bao");
            else 
            {
                string mssv = dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString();
                CSDL_TG.Instance.deleteSV(mssv);
                dataGridView1.DataSource = CSDL_TG.Instance.GetListSV(0);
            }
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL_TG.Instance.searchSV(textBox1.Text);
        }

        private void btSort_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL_TG.Instance.listSVbySort(cbboxSort.SelectedItem.ToString());
        }
    }
}
