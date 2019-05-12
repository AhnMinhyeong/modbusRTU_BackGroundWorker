namespace modbusRTU
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connect = new System.Windows.Forms.Button();
            this.txtConnectstatus = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FC1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(99, 58);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(128, 35);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect!";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // txtConnectstatus
            // 
            this.txtConnectstatus.AutoSize = true;
            this.txtConnectstatus.BackColor = System.Drawing.Color.Red;
            this.txtConnectstatus.Font = new System.Drawing.Font("Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtConnectstatus.Location = new System.Drawing.Point(575, 406);
            this.txtConnectstatus.Name = "txtConnectstatus";
            this.txtConnectstatus.Size = new System.Drawing.Size(139, 21);
            this.txtConnectstatus.TabIndex = 1;
            this.txtConnectstatus.Text = "Disconnected";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(460, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 21);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Read data";
            // 
            // FC1
            // 
            this.FC1.Location = new System.Drawing.Point(99, 104);
            this.FC1.Name = "FC1";
            this.FC1.Size = new System.Drawing.Size(127, 33);
            this.FC1.TabIndex = 4;
            this.FC1.Text = "Read Single Coil";
            this.FC1.UseVisualStyleBackColor = true;
            this.FC1.Click += new System.EventHandler(this.FC1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FC1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtConnectstatus);
            this.Controls.Add(this.connect);
            this.Name = "MainForm";
            this.Text = "modbus RTU Client Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Label txtConnectstatus;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FC1;
    }
}

