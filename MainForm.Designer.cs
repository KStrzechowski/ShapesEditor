
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
            this.radiusLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.positionYTextBox = new System.Windows.Forms.TextBox();
            this.positionXTextBox = new System.Windows.Forms.TextBox();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.LockLengthButton = new System.Windows.Forms.Button();
            this.deleteRelationButton = new System.Windows.Forms.Button();
            this.lockCircleButton = new System.Windows.Forms.Button();
            this.equalLengthsButton = new System.Windows.Forms.Button();
            this.tangencyButton = new System.Windows.Forms.Button();
            this.orthogonalButton = new System.Windows.Forms.Button();
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
            this.mainTableLayoutPanel.SetRowSpan(this.mainPictureBox, 2);
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
            this.mainTableLayoutPanel.Controls.Add(this.optionsTableLayoutPanel, 0, 1);
            this.mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
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
            this.mainListBox.Size = new System.Drawing.Size(225, 184);
            this.mainListBox.TabIndex = 1;
            this.mainListBox.SelectedIndexChanged += new System.EventHandler(this.mainListBox_SelectedIndexChanged);
            // 
            // optionsTableLayoutPanel
            // 
            this.optionsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.ColumnCount = 3;
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.47287F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.35309F));
            this.optionsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.17403F));
            this.optionsTableLayoutPanel.Controls.Add(this.radiusLabel, 0, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.positionLabel, 0, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.positionYTextBox, 2, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.positionXTextBox, 1, 0);
            this.optionsTableLayoutPanel.Controls.Add(this.radiusTextBox, 1, 1);
            this.optionsTableLayoutPanel.Controls.Add(this.deleteButton, 0, 7);
            this.optionsTableLayoutPanel.Controls.Add(this.addButton, 1, 7);
            this.optionsTableLayoutPanel.Controls.Add(this.LockLengthButton, 1, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.deleteRelationButton, 0, 6);
            this.optionsTableLayoutPanel.Controls.Add(this.lockCircleButton, 0, 2);
            this.optionsTableLayoutPanel.Controls.Add(this.equalLengthsButton, 0, 3);
            this.optionsTableLayoutPanel.Controls.Add(this.tangencyButton, 0, 5);
            this.optionsTableLayoutPanel.Controls.Add(this.orthogonalButton, 0, 4);
            this.optionsTableLayoutPanel.Location = new System.Drawing.Point(3, 209);
            this.optionsTableLayoutPanel.Name = "optionsTableLayoutPanel";
            this.optionsTableLayoutPanel.RowCount = 8;
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.07371F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.05651F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.03931F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.optionsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.optionsTableLayoutPanel.Size = new System.Drawing.Size(225, 407);
            this.optionsTableLayoutPanel.TabIndex = 2;
            // 
            // radiusLabel
            // 
            this.radiusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radiusLabel.Location = new System.Drawing.Point(3, 50);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(107, 46);
            this.radiusLabel.TabIndex = 5;
            this.radiusLabel.Text = "Radius";
            this.radiusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.positionLabel.Size = new System.Drawing.Size(107, 50);
            this.positionLabel.TabIndex = 7;
            this.positionLabel.Text = "Position";
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // positionYTextBox
            // 
            this.positionYTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionYTextBox.BackColor = System.Drawing.Color.White;
            this.positionYTextBox.Location = new System.Drawing.Point(175, 3);
            this.positionYTextBox.Name = "positionYTextBox";
            this.positionYTextBox.PlaceholderText = "0";
            this.positionYTextBox.Size = new System.Drawing.Size(47, 27);
            this.positionYTextBox.TabIndex = 9;
            this.positionYTextBox.Text = "0";
            this.positionYTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.positionTextBox_KeyDown);
            // 
            // positionXTextBox
            // 
            this.positionXTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionXTextBox.Location = new System.Drawing.Point(116, 3);
            this.positionXTextBox.Name = "positionXTextBox";
            this.positionXTextBox.PlaceholderText = "0";
            this.positionXTextBox.Size = new System.Drawing.Size(53, 27);
            this.positionXTextBox.TabIndex = 8;
            this.positionXTextBox.Text = "0";
            this.positionXTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.positionTextBox_KeyDown);
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.radiusTextBox, 2);
            this.radiusTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radiusTextBox.Location = new System.Drawing.Point(116, 53);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.PlaceholderText = "50";
            this.radiusTextBox.Size = new System.Drawing.Size(106, 27);
            this.radiusTextBox.TabIndex = 6;
            this.radiusTextBox.Text = "50";
            this.radiusTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radiusTextBox_KeyDown);
            // 
            // deleteButton
            // 
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Location = new System.Drawing.Point(3, 354);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(107, 50);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.deleteButton_MouseClick);
            // 
            // addButton
            // 
            this.optionsTableLayoutPanel.SetColumnSpan(this.addButton, 2);
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(116, 354);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(106, 50);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addButton_MouseClick);
            // 
            // LockLengthButton
            // 
            this.LockLengthButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.LockLengthButton, 2);
            this.LockLengthButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LockLengthButton.Location = new System.Drawing.Point(116, 99);
            this.LockLengthButton.Name = "LockLengthButton";
            this.LockLengthButton.Size = new System.Drawing.Size(106, 44);
            this.LockLengthButton.TabIndex = 11;
            this.LockLengthButton.Text = "Lock Radius/Length";
            this.LockLengthButton.UseVisualStyleBackColor = true;
            this.LockLengthButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LockLengthButton_MouseDown);
            // 
            // deleteRelationButton
            // 
            this.deleteRelationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.deleteRelationButton, 3);
            this.deleteRelationButton.Location = new System.Drawing.Point(3, 304);
            this.deleteRelationButton.Name = "deleteRelationButton";
            this.deleteRelationButton.Size = new System.Drawing.Size(219, 44);
            this.deleteRelationButton.TabIndex = 15;
            this.deleteRelationButton.Text = "Delete Relation";
            this.deleteRelationButton.UseVisualStyleBackColor = true;
            this.deleteRelationButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.deleteRelationButton_MouseDown);
            // 
            // lockCircleButton
            // 
            this.lockCircleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lockCircleButton.Location = new System.Drawing.Point(3, 99);
            this.lockCircleButton.Name = "lockCircleButton";
            this.lockCircleButton.Size = new System.Drawing.Size(107, 44);
            this.lockCircleButton.TabIndex = 10;
            this.lockCircleButton.Text = "Lock Circle";
            this.lockCircleButton.UseVisualStyleBackColor = true;
            this.lockCircleButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lockCircleButton_MouseDown);
            // 
            // equalLengthsButton
            // 
            this.equalLengthsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.equalLengthsButton, 3);
            this.equalLengthsButton.Location = new System.Drawing.Point(3, 149);
            this.equalLengthsButton.Name = "equalLengthsButton";
            this.equalLengthsButton.Size = new System.Drawing.Size(219, 49);
            this.equalLengthsButton.TabIndex = 12;
            this.equalLengthsButton.Text = "Set Equal Lengths";
            this.equalLengthsButton.UseVisualStyleBackColor = true;
            this.equalLengthsButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.equalLengthsButton_MouseDown);
            // 
            // tangencyButton
            // 
            this.tangencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.tangencyButton, 3);
            this.tangencyButton.Location = new System.Drawing.Point(3, 254);
            this.tangencyButton.Name = "tangencyButton";
            this.tangencyButton.Size = new System.Drawing.Size(219, 44);
            this.tangencyButton.TabIndex = 14;
            this.tangencyButton.Text = "Set Tangency";
            this.tangencyButton.UseVisualStyleBackColor = true;
            this.tangencyButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tangencyButton_MouseDown);
            // 
            // orthogonalButton
            // 
            this.orthogonalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsTableLayoutPanel.SetColumnSpan(this.orthogonalButton, 3);
            this.orthogonalButton.Location = new System.Drawing.Point(3, 204);
            this.orthogonalButton.Name = "orthogonalButton";
            this.orthogonalButton.Size = new System.Drawing.Size(219, 44);
            this.orthogonalButton.TabIndex = 13;
            this.orthogonalButton.Text = "Make Edges Orthogonal";
            this.orthogonalButton.UseVisualStyleBackColor = true;
            this.orthogonalButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.orthogonalButton_MouseDown);
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
        private System.Windows.Forms.Button lockCircleButton;
        private System.Windows.Forms.Button LockLengthButton;
        private System.Windows.Forms.Button equalLengthsButton;
        private System.Windows.Forms.Button orthogonalButton;
        private System.Windows.Forms.Button tangencyButton;
        private System.Windows.Forms.Button deleteRelationButton;
    }
}

