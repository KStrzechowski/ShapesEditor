
namespace ShapesEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainListBox = new System.Windows.Forms.ListBox();
            this.optionsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionXTextBox = new System.Windows.Forms.TextBox();
            this.positionYTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.mainTableLayoutPanel.SuspendLayout();
            this.optionsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPictureBox.Location = new System.Drawing.Point(236, 5);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(5);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainTableLayoutPanel.SetRowSpan(this.mainPictureBox, 3);
            this.mainPictureBox.Size = new System.Drawing.Size(898, 609);
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBox_MouseUp);
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.ColumnCount = 2;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.28095F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.71905F));
            this.mainTableLayoutPanel.Controls.Add(this.mainPictureBox, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.mainListBox, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.optionsTableLayoutPanel, 0, 2);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 3;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 344F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(1139, 619);
            this.mainTableLayoutPanel.TabIndex = 1;
            // 
            // mainListBox
            // 
            this.mainListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainListBox.FormattingEnabled = true;
            this.mainListBox.ItemHeight = 20;
            this.mainListBox.Items.AddRange(new object[] {
            "Polygon",
            "Circle"});
            this.mainListBox.Location = new System.Drawing.Point(3, 3);
            this.mainListBox.Name = "mainListBox";
            this.mainListBox.Size = new System.Drawing.Size(225, 224);
            this.mainListBox.TabIndex = 1;
            this.mainListBox.SelectedIndexChanged += new System.EventHandler(this.mainListBox_SelectedIndexChanged);
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.ColumnCount = 3;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.66667F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.33333F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.55556F));
            this.optionsTableLayoutPanel.Controls.Add(this.deleteButton, 0, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.addButton, 1, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.radiusTextBox, 1, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.radiusLabel, 0, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.positionLabel, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.positionXTextBox, 1, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.positionYTextBox, 2, 0);
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(3, 278);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 4;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.23596F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.48315F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.05993F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.22097F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(225, 338);
            this.optionsTableLayoutPanel.TabIndex = 2;
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Location = new System.Drawing.Point(3, 260);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(108, 75);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Visible = false;
            this.deleteButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseClick);
            // 
            // addButton
            // 
            this.optionsTableLayoutPanel.SetColumnSpan(this.addButton, 2);
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(117, 260);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(105, 75);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Visible = false;
            this.addButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addButton_MouseClick);
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.radiusTextBox, 2);
            this.radiusTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radiusTextBox.Location = new System.Drawing.Point(117, 40);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.PlaceholderText = "50";
            this.radiusTextBox.Size = new System.Drawing.Size(105, 27);
            this.radiusTextBox.TabIndex = 6;
            this.radiusTextBox.Text = "50";
            this.radiusTextBox.Visible = false;
            this.radiusTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radiusTextBox_KeyDown);
            this.radiusTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_NumberValidation);
            // 
            // radiusLabel
            // 
            this.radiusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radiusLabel.Location = new System.Drawing.Point(3, 37);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(108, 45);
            this.radiusLabel.TabIndex = 5;
            this.radiusLabel.Text = "Radius";
            this.radiusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radiusLabel.Visible = false;
            // 
            // positionLabel
            // 
            this.positionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.positionLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.positionLabel.Location = new System.Drawing.Point(3, 0);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(108, 37);
            this.positionLabel.TabIndex = 7;
            this.positionLabel.Text = "Position";
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.positionLabel.Visible = false;
            // 
            // positionXTextBox
            // 
            this.positionXTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionXTextBox.Location = new System.Drawing.Point(117, 3);
            this.positionXTextBox.Name = "positionXTextBox";
            this.positionXTextBox.PlaceholderText = "0";
            this.positionXTextBox.Size = new System.Drawing.Size(51, 27);
            this.positionXTextBox.TabIndex = 8;
            this.positionXTextBox.Text = "0";
            this.positionXTextBox.Visible = false;
            this.positionXTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.positionTextBox_KeyDown);
            this.positionXTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_NumberValidation);
            // 
            // positionYTextBox
            // 
            this.positionYTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionYTextBox.BackColor = System.Drawing.Color.White;
            this.positionYTextBox.Location = new System.Drawing.Point(174, 3);
            this.positionYTextBox.Name = "positionYTextBox";
            this.positionYTextBox.PlaceholderText = "0";
            this.positionYTextBox.Size = new System.Drawing.Size(48, 27);
            this.positionYTextBox.TabIndex = 9;
            this.positionYTextBox.Text = "0";
            this.positionYTextBox.Visible = false;
            this.positionYTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.positionTextBox_KeyDown);
            this.positionYTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBox_NumberValidation);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 619);
            this.Controls.Add(this.mainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Shapes Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.ResumeLayout(false);
            this.optionsTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
        private System.Windows.Forms.ListBox mainListBox;
        private System.Windows.Forms.TableLayoutPanel optionsTableLayoutPanel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.TextBox positionXTextBox;
        private System.Windows.Forms.TextBox positionYTextBox;
    }
}

