using MunicipalReporterApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalReporterApp
{
    public partial class ReportIssueForm : Form
    {
        private Label lblHeader;
        private Label lblLocation;
        private TextBox txtLocation;

        private Label lblCategory;
        private ComboBox cmbCategory;
        private LinkLabel lnkAddCategoryHint;

        private Label lblDescription;
        private RichTextBox rtbDescription;

        private Label lblAttachments;
        private Button btnAttach;
        private ListBox lstAttachments;

        private ProgressBar progress;
        private Label lblEngagement;

        private Button btnSubmit;
        private Button btnBack;

        private OpenFileDialog ofd;

        public ReportIssueForm()
        {
            Text = "Report an Issue";
            MinimumSize = new Size(720, 650);
            StartPosition = FormStartPosition.CenterParent;

            // Header
            lblHeader = new Label
            {
                Text = "Help improve your community – log an issue",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            // Location
            lblLocation = new Label
            {
                Text = "Location:",
                Location = new Point(20, 70),
                AutoSize = true
            };
            txtLocation = new TextBox
            {
                Location = new Point(20, 95),
                Width = 420
            };
            txtLocation.TextChanged += (_, __) => UpdateEngagement();

            // Category
            lblCategory = new Label
            {
                Text = "Category:",
                Location = new Point(20, 135),
                AutoSize = true
            };
            cmbCategory = new ComboBox
            {
                Location = new Point(20, 160),
                Width = 300,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbCategory.Items.AddRange(DataStore.Categories.Cast<object>().ToArray());
            cmbCategory.SelectedIndexChanged += (_, __) => OnCategoryChanged();

            lnkAddCategoryHint = new LinkLabel
            {
                Text = "Suggest a new category (co-creation)",
                Location = new Point(330, 164),
                AutoSize = true
            };
            lnkAddCategoryHint.Click += (_, __) => PromptAddCategory();

            // Description
            lblDescription = new Label
            {
                Text = "Description:",
                Location = new Point(20, 200),
                AutoSize = true
            };
            rtbDescription = new RichTextBox
            {
                Location = new Point(20, 225),
                Width = 650,
                Height = 140
            };
            rtbDescription.TextChanged += (_, __) => UpdateEngagement();

            // Attachments
            lblAttachments = new Label
            {
                Text = "Attachments (images/docs):",
                Location = new Point(20, 375),
                AutoSize = true
            };
            btnAttach = new Button
            {
                Text = "Attach Files…",
                Location = new Point(20, 400),
                Size = new Size(140, 32)
            };
            btnAttach.Click += (_, __) => AttachFiles();

            lstAttachments = new ListBox
            {
                Location = new Point(170, 400),
                Width = 500,
                Height = 100
            };
            lstAttachments.DoubleClick += (_, __) => RemoveSelectedAttachment();

            // Engagement widgets
            progress = new ProgressBar
            {
                Location = new Point(20, 515),
                Width = 420,
                Height = 18,
                Minimum = 0,
                Maximum = 100
            };

            lblEngagement = new Label
            {
                Text = "Let's get started!",
                Location = new Point(450, 512),
                AutoSize = true
            };

            // Buttons
            btnSubmit = new Button
            {
                Text = "Submit",
                Location = new Point(20, 540),
                Size = new Size(120, 34)
            };
            btnSubmit.Click += (_, __) => Submit();

            btnBack = new Button
            {
                Text = "Back to Main Menu",
                Location = new Point(150, 540),
                Size = new Size(160, 34)
            };
            btnBack.Click += (_, __) => Close();

            // Add controls
            Controls.AddRange(new Control[]
            {
                lblHeader,
                lblLocation, txtLocation,
                lblCategory, cmbCategory, lnkAddCategoryHint,
                lblDescription, rtbDescription,
                lblAttachments, btnAttach, lstAttachments,
                progress, lblEngagement,
                btnSubmit, btnBack
            });

            // File dialog for attachments
            ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Image and Document Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.pdf;*.docx;*.txt"
            };
        }

        // Placeholder methods
        private void UpdateEngagement()
        {
            int score = 0;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) score += 30;
            if (cmbCategory.SelectedIndex >= 0) score += 30;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) score += 40;

            progress.Value = score;
            lblEngagement.Text = score == 100 ? "Great! Ready to submit." : "Keep going...";
        }

        private void OnCategoryChanged()
        {
            UpdateEngagement();
        }

        private void PromptAddCategory()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Enter a new category:", "Suggest Category", "");
            if (!string.IsNullOrWhiteSpace(input))
            {
                DataStore.Categories.Add(input);
                cmbCategory.Items.Add(input);
                MessageBox.Show("Thanks for your suggestion! It will be reviewed.");
            }
        }

        private void AttachFiles()
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                {
                    lstAttachments.Items.Add(file);
                }
            }
        }

        private void RemoveSelectedAttachment()
        {
            if (lstAttachments.SelectedItem != null)
                lstAttachments.Items.Remove(lstAttachments.SelectedItem);
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {
            // Optional: Do initialization here
        }

        private void Submit()
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text) ||
                cmbCategory.SelectedIndex < 0 ||
                string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please fill all required fields before submitting.");
                return;
            }

            var issue = new IssueReport
            {
                Location = txtLocation.Text,
                Category = cmbCategory.SelectedItem.ToString(),
                Description = rtbDescription.Text,
                Attachments = lstAttachments.Items.Cast<string>().ToList()
            };

            DataStore.Reports.Add(issue);

            MessageBox.Show("Thank you! Your issue has been reported successfully.");
            Close();
        }
    }
}
