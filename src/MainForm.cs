using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalReporterApp
{
    public partial class MainForm : Form
    {
        private Button btnReportIssues;
        private Button btnEvents;
        private Button btnStatus;
        private Label title;
        private ToolTip tooltip;

        public MainForm()
        {
            // InitializeComponent();
            Text = "Municipal Reporter – Main Menu";
            MinimumSize = new Size(600, 380);
            StartPosition = FormStartPosition.CenterScreen;


            title = new Label
            {
                Text = "Welcome to Municipal Reporter",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            btnReportIssues = new Button
            {
                Text = "Report Issues",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Size = new Size(220, 50),
                Location = new Point(20, 80)
            };
            btnReportIssues.Click += (s, e) =>
            {
                using (var f = new ReportIssueForm())
                {
                    f.ShowDialog(this);
                }
            };

            btnEvents = new Button
            {
                Text = "Local Events & Announcements (Coming Soon)",
                Enabled = false,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Size = new Size(420, 50),
                Location = new Point(20, 150)
            };


            btnStatus = new Button
            {
                Text = "Service Request Status (Coming Soon)",
                Enabled = false,
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Size = new Size(420, 50),
                Location = new Point(20, 220)
            };

            tooltip = new ToolTip();
            tooltip.SetToolTip(btnEvents, "This feature will be enabled in a future version.");
            tooltip.SetToolTip(btnStatus, "This feature will be enabled in a future version.");


            Controls.Add(title);
            Controls.Add(btnReportIssues);
            Controls.Add(btnEvents);
            Controls.Add(btnStatus);


            // Anchors for basic responsiveness
            title.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnReportIssues.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEvents.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
