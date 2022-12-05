namespace RSAPseRandoCrypterGUI
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
            this.OpenKeyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SecretKeyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.GenerateKeysButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OpenKeyTextBox
            // 
            this.OpenKeyTextBox.Location = new System.Drawing.Point(431, 24);
            this.OpenKeyTextBox.Multiline = true;
            this.OpenKeyTextBox.Name = "OpenKeyTextBox";
            this.OpenKeyTextBox.Size = new System.Drawing.Size(165, 261);
            this.OpenKeyTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Open (public) key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Secret key";
            // 
            // SecretKeyTextBox
            // 
            this.SecretKeyTextBox.Location = new System.Drawing.Point(602, 24);
            this.SecretKeyTextBox.Multiline = true;
            this.SecretKeyTextBox.Name = "SecretKeyTextBox";
            this.SecretKeyTextBox.Size = new System.Drawing.Size(165, 261);
            this.SecretKeyTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message / encrypted message";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Location = new System.Drawing.Point(12, 24);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(413, 357);
            this.MessageTextBox.TabIndex = 4;
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(431, 291);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(165, 42);
            this.EncryptButton.TabIndex = 6;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(603, 291);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(165, 42);
            this.DecryptButton.TabIndex = 7;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // GenerateKeysButton
            // 
            this.GenerateKeysButton.Location = new System.Drawing.Point(431, 339);
            this.GenerateKeysButton.Name = "GenerateKeysButton";
            this.GenerateKeysButton.Size = new System.Drawing.Size(337, 42);
            this.GenerateKeysButton.TabIndex = 8;
            this.GenerateKeysButton.Text = "GenerateKeys";
            this.GenerateKeysButton.UseVisualStyleBackColor = true;
            this.GenerateKeysButton.Click += new System.EventHandler(this.GenerateKeysButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 389);
            this.Controls.Add(this.GenerateKeysButton);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SecretKeyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpenKeyTextBox);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RSAPseRandoCrypter GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox OpenKeyTextBox;
        private Label label1;
        private Label label2;
        private TextBox SecretKeyTextBox;
        private Label label3;
        private TextBox MessageTextBox;
        private Button EncryptButton;
        private Button DecryptButton;
        private Button GenerateKeysButton;
    }
}