﻿using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KrispyKreme
{
    public partial class Form2 : Form
    {
        private string billDetails, loggedInUser;

        public Form2(string billDetails, string username)
        {
            InitializeComponent();
            loggedInUser = username;
            this.billDetails = billDetails;
            btnBack.Click += new EventHandler(btnBack_Click);
            btnPrint.Click += new EventHandler(btnPrint_Click);
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            string formattedBill = billDetails
            .Replace("Overall Total:", "Overall Total: ₹")
            .Replace("Discount:", "Discount: ₹")
            .Replace("Final Price:", "Final Price: ₹")
            .Replace(" x ", " x ₹") // Ensures ₹ appears before unit price
            .Replace(" = ", " = ₹"); // Ensures ₹ appears before total price

            lblBillDetails.Text = formattedBill;
        }

        private void btnBack_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to go back?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Step 1: Delete the most recent bill for the logged-in user
                DatabaseHelper.DeleteLatestBill(loggedInUser);  // Use loggedInUsername

                // Step 2: Close the current form
                this.Close();

                // Step 3: Reopen Form1 with the same user
                Form1 form1 = new Form1(loggedInUser); // Use loggedInUsername
                form1.Show();
            }
        }



        private void btnPrint_Click(object? sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };

            if (printPreviewDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font billFont = new Font("Segoe UI Black", 12F, FontStyle.Bold | FontStyle.Italic);
            Brush billBrush = Brushes.Black;

            float pageWidth = e.PageBounds.Width;
            float margin = 20f;

            // Centering calculations
            float logoWidth = 400;
            float logoHeight = 200;
            float logoX = (pageWidth - logoWidth) / 2; // Centering horizontally

            // Draw Logo (Check if it's not null)
            if (Properties.Resources.KrispyKreme != null)
            {
                e.Graphics.DrawImage(Properties.Resources.KrispyKreme, logoX, margin, logoWidth, logoHeight);
            }
            else
            {
                MessageBox.Show("Error: Krispy Kreme logo not found in Resources.", "Printing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Position bill details text below logo
            float billDetailsY = margin + logoHeight + 10;

            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center, // Center horizontally
                LineAlignment = StringAlignment.Near // Start from the top
            };

            // Define a RectangleF for better text alignment
            RectangleF textRect = new RectangleF(0, billDetailsY, pageWidth, pageWidth);

            e.Graphics.DrawString(lblBillDetails.Text, billFont, billBrush, textRect, stringFormat);
        }

    }
}