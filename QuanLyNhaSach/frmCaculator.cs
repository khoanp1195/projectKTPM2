using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaSach
{
    public partial class frmCaculator : Form
    {
        public enum Operation
        {
            None,
            Add,
            Minus,
            Mul,
            Divide
        }

        public frmCaculator()
        {
            InitializeComponent();
        }

        // Khi bấm +,-,*,/ ta muốn xoá số trước đó đi và hiển thị số nhập sau đó
        // Khi bấm +,-,*,/ ta muốn số đầu tiên là số do chính ta nhập vào chứ không phải là số 0 ban đầu

        private double result = 0;
        //Khi nhấn +,-,*,/ thì chuyển flag là flase
        private bool flag = true;
        //Khi nhấn +,-,*,/ thì chuyển next là true. false là số thứ 1, true là số thứ 2
        private bool next = false;
        private Operation Op = Operation.None;

        private void DisableOperation()
        {
            btnAdd.Enabled = false;
            btnMinus.Enabled = false;
            btnMul.Enabled = false;
            btnDivide.Enabled = false;
        }

        private void EnableOperation()
        {
            btnAdd.Enabled = true;
            btnMinus.Enabled = true;
            btnMul.Enabled = true;
            btnDivide.Enabled = true;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                return;
            }
            // Số trước khi bấm cộng trừ nhân chia
            if (flag)
            {
                lblResult.Text += "0";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "0";
            }
            flag = true;
            EnableOperation();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            // Số trước khi bấm cộng trừ nhân chia
            if (flag)
            {
                lblResult.Text += "1";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "1";
            }
            flag = true;
            EnableOperation();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            if (flag)
            {
                lblResult.Text += "2";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "2";
            }
            flag = true;
            EnableOperation();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            if (flag)
            {
                lblResult.Text += "3";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "3";
            }
            flag = true;
            EnableOperation();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            if (flag)
            {
                lblResult.Text += "4";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "4";
            }
            flag = true;
            EnableOperation();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            if (flag)
            {
                lblResult.Text += "5";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "5";
            }
            flag = true;
            EnableOperation();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            if (flag)
            {
                lblResult.Text += "6";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "6";
            }
            flag = true;
            EnableOperation();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            if (flag)
            {
                lblResult.Text += "7";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "7";
            }
            flag = true;
            EnableOperation();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            if (flag)
            {
                lblResult.Text += "8";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "8";
            }
            flag = true;
            EnableOperation();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "";
            }
            if (flag)
            {
                lblResult.Text += "9";
            }
            // Số sau khi bấm cộng trừ nhân chia
            else
            {
                lblResult.Text = "9";
            }
            flag = true;
            EnableOperation();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Op = Operation.Add;
            if (!next)
            {
                this.result = Convert.ToDouble(this.lblResult.Text);
            }
            else
            {
                this.result = this.result + Convert.ToDouble(this.lblResult.Text);
            }
            this.flag = false;
            this.lblResult.Text = String.Format("{0}", this.result);
            this.next = true;
            btnEqual.Enabled = true;
            DisableOperation();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Op = Operation.Minus;
            if (!next)
            {
                this.result = Convert.ToDouble(this.lblResult.Text);
            }
            else
            {
                this.result = this.result - Convert.ToDouble(this.lblResult.Text);
            }
            this.flag = false;
            this.lblResult.Text = String.Format("{0}", this.result);
            this.next = true;
            btnEqual.Enabled = true;
            DisableOperation();
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            Op = Operation.Mul;
            if (!next)
            {
                this.result = Convert.ToDouble(this.lblResult.Text);
            }
            else
            {
                this.result = this.result * Convert.ToDouble(this.lblResult.Text);
            }
            this.flag = false;
            this.lblResult.Text = String.Format("{0}", this.result);
            this.next = true;
            btnEqual.Enabled = true;
            DisableOperation();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            Op = Operation.Divide;
            if (!next)
            {
                this.result = Convert.ToDouble(this.lblResult.Text);
            }
            else
            {
                this.result = this.result / Convert.ToDouble(this.lblResult.Text);
            }
            this.flag = false;
            this.lblResult.Text = String.Format("{0}", this.result);
            this.next = true;
            btnEqual.Enabled = true;
            DisableOperation();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            result = 0;
            flag = true;
            next = false;
            btnEqual.Enabled = true;
            EnableOperation();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            lblResult.Text = lblResult.Text.Substring(0, lblResult.Text.Length - 1);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblResult.Text == "0")
            {
                lblResult.Text = "0.";
            }
            else if (lblResult.Text.EndsWith("."))
            {
                btnDot.Enabled = false;
            }
            else
            {
                lblResult.Text += ".";
            }
            btnDot.Enabled = true;
            EnableOperation();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (Op == Operation.Add)
            {
                this.result = this.result + Convert.ToDouble(this.lblResult.Text);
            }
            else if (Op == Operation.Minus)
            {
                this.result = this.result - Convert.ToDouble(this.lblResult.Text);
            }
            else if (Op == Operation.Mul)
            {
                this.result = this.result * Convert.ToDouble(this.lblResult.Text);
            }
            else if (Op == Operation.Divide)
            {
                if (flag == true && lblResult.Text == "0")
                {
                    MessageBox.Show("Không thể thực hiện phép chia cho 0", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnCE_Click(sender, e);
                }
                else
                {
                    this.result = this.result / Convert.ToDouble(this.lblResult.Text);
                }
            }
            this.flag = false;
            this.lblResult.Text = String.Format("{0}", this.result);
            this.next = false;
            this.result = 0;
            btnEqual.Enabled = false;
        }

        private void ToolStripExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng máy tính không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
