using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach
{
    public partial class frmEmail : Form
    {
        public frmEmail()
        {
            InitializeComponent();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
            }
        }

        private void SendEmail(Mail mail)
        {
            MailMessage email = new MailMessage();
            SmtpClient server = new SmtpClient("smtp.gmail.com");
            try
            {
                email.From = new MailAddress(mail.user);
                email.To.Add(mail.ToEmail);
                email.Subject = mail.Title;
                email.Body = mail.Content;
                // Kiểm tra file đính kèm có tồn tại không
                if (File.Exists(mail.File))
                {
                    Attachment attachFile = new Attachment(mail.File);
                    email.Attachments.Add(attachFile);
                }

                server.Port = 587;
                server.Credentials = new NetworkCredential(mail.user, mail.password);
                // Chứng chỉ bảo mật
                server.EnableSsl = true;
                server.Send(email);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshData()
        {
            txtToEmail.Enabled = true;
            txtToEmail.Clear();
            txtTitle.Clear();
            txtContent.Clear();
            txtPath.Clear();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            if (txtToEmail.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email bạn muốn gửi đến", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!(Regex.IsMatch(txtToEmail.Text.Trim(), pattern)))
            {
                MessageBox.Show("Sai định dạng email. Vui lòng kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtTitle.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tiêu đề email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtContent.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Mail mail = new Mail();

            string toEmail = txtToEmail.Text.Trim();
            string title = txtTitle.Text.Trim();
            string content = txtContent.Text.Trim();
            string file = txtPath.Text.Trim();

            mail.FromEmail = mail.user;
            mail.ToEmail = toEmail;
            mail.Title = title;
            mail.Content = content;
            mail.File = file;

            if (mail != null)
            {
                SendEmail(mail);
                MessageBox.Show("Gửi email thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Gửi email thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ToolStripColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = panel1.BackColor;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
            }
        }

        private void ToolStripFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = panel1.Font;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.Font = fontDialog1.Font;
            }
        }

        private void ToolStripExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng form không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
