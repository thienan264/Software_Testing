using System;
using System.Drawing;
using System.Windows.Forms;
using OrganizationApp.Models;

namespace OrganizeationApp
{
    public partial class FrmDirector : Form
    {
        private Organization _org;

        private Label lblTitle, lblOrgId, lblOrgName, lblAddress;
        private Button btnClose;

        public FrmDirector(Organization org)
        {
            _org = org;
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            this.Text = "Director Management";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(400, 260);
            this.Font = new Font("Segoe UI", 10);

            lblTitle = new Label
            {
                Text = "Director Management",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Left = 90,
                Top = 20
            };

            lblOrgId = new Label
            {
                Text = $"OrgID: {_org.OrgID}",
                Left = 40,
                Top = 70,
                AutoSize = true
            };

            lblOrgName = new Label
            {
                Text = $"Organization: {_org.OrgName}",
                Left = 40,
                Top = 100,
                AutoSize = true
            };

            lblAddress = new Label
            {
                Text = $"Address: {_org.Address}",
                Left = 40,
                Top = 130,
                AutoSize = true
            };

            btnClose = new Button
            {
                Text = "Close",
                Width = 80,
                Left = 150,
                Top = 170
            };
            btnClose.Click += (s, e) => this.Close();

            Controls.AddRange(new Control[]
            {
                lblTitle, lblOrgId, lblOrgName, lblAddress, btnClose
            });
        }
    }
}