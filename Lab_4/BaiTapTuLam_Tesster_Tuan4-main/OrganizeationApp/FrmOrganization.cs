using System;
using System.Drawing;
using System.Windows.Forms;

using OrganizationApp.BLL;
using OrganizationApp.Models;
using OrganizationApp.Exceptions;

namespace OrganizeationApp
{
    public partial class FrmOrganization : Form
    {
        private TextBox txtOrgName, txtAddress, txtPhone, txtEmail;
        private Button btnSave, btnBack, btnDirector;
        private ErrorProvider errorProvider1;

        private readonly OrganizationService _service = new OrganizationService();
        private int _savedOrgId = 0;

        public FrmOrganization()
        {
            InitializeComponent();

            InitUI();
            RegisterEvent();
        }

        private void InitUI()
        {
            this.Text = "Organization Management";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(520, 320);
            this.Font = new Font("Segoe UI", 10);

            errorProvider1 = new ErrorProvider();
            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            int labelX = 30;
            int inputX = 210;
            int y = 30;
            int rowH = 40;

            CreateLabel("Organization Name *", labelX, y);
            txtOrgName = CreateTextBox("txtOrgName", inputX, y);
            y += rowH;

            CreateLabel("Address", labelX, y);
            txtAddress = CreateTextBox("txtAddress", inputX, y);
            y += rowH;

            CreateLabel("Phone", labelX, y);
            txtPhone = CreateTextBox("txtPhone", inputX, y);
            y += rowH;

            CreateLabel("Email", labelX, y);
            txtEmail = CreateTextBox("txtEmail", inputX, y);
            y += rowH + 10;

            btnSave = CreateButton("Save", "btnSave", 120, y);
            btnBack = CreateButton("Back", "btnBack", 220, y);
            btnDirector = CreateButton("Director", "btnDirector", 320, y);

            btnDirector.Enabled = false; 
        }

        private Label CreateLabel(string text, int x, int y)
        {
            var lb = new Label
            {
                Text = text,
                Left = x,
                Top = y + 4,
                AutoSize = true
            };
            this.Controls.Add(lb);
            return lb;
        }

        private TextBox CreateTextBox(string name, int x, int y)
        {
            var tb = new TextBox
            {
                Name = name,
                Left = x,
                Top = y,
                Width = 250
            };
            this.Controls.Add(tb);
            return tb;
        }

        private Button CreateButton(string text, string name, int x, int y)
        {
            var btn = new Button
            {
                Text = text,
                Name = name,
                Left = x,
                Top = y,
                Width = 85,
                Height = 32
            };
            this.Controls.Add(btn);
            return btn;
        }

        private void SetError(Control c, string message)
        {
            errorProvider1.SetError(c, message);
            c.BackColor = Color.MistyRose; 
        }

        private void ClearError(Control c)
        {
            errorProvider1.SetError(c, "");
            c.BackColor = Color.White;
        }

        private void ClearAllFieldErrors()
        {
            ClearError(txtOrgName);
            ClearError(txtPhone);
            ClearError(txtEmail);
        }

        private void RegisterEvent()
        {
            btnSave.Click += btnSave_Click;
            btnBack.Click += btnBack_Click;
            btnDirector.Click += btnDirector_Click;

            txtOrgName.TextChanged += (s, e) => ClearError(txtOrgName);
            txtPhone.TextChanged += (s, e) => ClearError(txtPhone);
            txtEmail.TextChanged += (s, e) => ClearError(txtEmail);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            ClearAllFieldErrors();

            var org = new Organization
            {
                OrgName = txtOrgName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text
            };

            try
            {
                _savedOrgId = _service.Save(org);

                MessageBox.Show("Save successfully");
                btnDirector.Enabled = true;
            }
            catch (ValidationException ve)
            {
                foreach (var kv in ve.Errors)
                {
                    if (kv.Key == "OrgName")
                        SetError(txtOrgName, kv.Value);

                    if (kv.Key == "Phone")
                        SetError(txtPhone, kv.Value);

                    if (kv.Key == "Email")
                        SetError(txtEmail, kv.Value);
                }
            }
            catch (BusinessException be)
            {
                MessageBox.Show(be.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDirector_Click(object sender, EventArgs e)
        {
            if (_savedOrgId <= 0)
            {
                MessageBox.Show("Bạn phải Save trước!");
                return;
            }

            var org = new Organization
            {
                OrgID = _savedOrgId,
                OrgName = txtOrgName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text
            };

            FrmDirector frm = new FrmDirector(org);
            frm.ShowDialog();
        }
    }
}