namespace battleship2
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Play_Btn = new System.Windows.Forms.Button();
            this.Clear_Btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.s_image = new System.Windows.Forms.PictureBox();
            this.d_image = new System.Windows.Forms.PictureBox();
            this.b_image = new System.Windows.Forms.PictureBox();
            this.ac_image = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_abc = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ac_image)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.Play_Btn);
            this.panel2.Controls.Add(this.Clear_Btn);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.panel2.Location = new System.Drawing.Point(84, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1200, 598);
            this.panel2.TabIndex = 3;
            // 
            // Play_Btn
            // 
            this.Play_Btn.BackColor = System.Drawing.Color.SteelBlue;
            this.Play_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Play_Btn.Location = new System.Drawing.Point(903, 478);
            this.Play_Btn.Name = "Play_Btn";
            this.Play_Btn.Size = new System.Drawing.Size(87, 40);
            this.Play_Btn.TabIndex = 26;
            this.Play_Btn.Text = "Play";
            this.Play_Btn.UseVisualStyleBackColor = false;
            this.Play_Btn.Click += new System.EventHandler(this.Play_Btn_Click);
            // 
            // Clear_Btn
            // 
            this.Clear_Btn.BackColor = System.Drawing.Color.SteelBlue;
            this.Clear_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Clear_Btn.Location = new System.Drawing.Point(903, 383);
            this.Clear_Btn.Name = "Clear_Btn";
            this.Clear_Btn.Size = new System.Drawing.Size(87, 40);
            this.Clear_Btn.TabIndex = 24;
            this.Clear_Btn.Text = "Clear";
            this.Clear_Btn.UseVisualStyleBackColor = false;
            this.Clear_Btn.Click += new System.EventHandler(this.Clear_Btn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.s_image);
            this.panel3.Controls.Add(this.d_image);
            this.panel3.Controls.Add(this.b_image);
            this.panel3.Controls.Add(this.ac_image);
            this.panel3.Location = new System.Drawing.Point(8, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(266, 564);
            this.panel3.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(16, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 29);
            this.label2.TabIndex = 25;
            this.label2.Text = " Επέλεξε πλοίο ";
            // 
            // s_image
            // 
            this.s_image.Image = global::battleship2.Properties.Resources.Submarine1;
            this.s_image.Location = new System.Drawing.Point(21, 149);
            this.s_image.Name = "s_image";
            this.s_image.Size = new System.Drawing.Size(90, 40);
            this.s_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.s_image.TabIndex = 4;
            this.s_image.TabStop = false;
            this.s_image.Tag = "2";
            this.s_image.Click += new System.EventHandler(this.Picture_Click);
            // 
            // d_image
            // 
            this.d_image.Image = global::battleship2.Properties.Resources.DESTROYER;
            this.d_image.Location = new System.Drawing.Point(20, 316);
            this.d_image.Name = "d_image";
            this.d_image.Size = new System.Drawing.Size(180, 40);
            this.d_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.d_image.TabIndex = 6;
            this.d_image.TabStop = false;
            this.d_image.Tag = "4";
            this.d_image.Click += new System.EventHandler(this.Picture_Click);
            // 
            // b_image
            // 
            this.b_image.Image = global::battleship2.Properties.Resources.BATTLESHIP;
            this.b_image.Location = new System.Drawing.Point(21, 232);
            this.b_image.Name = "b_image";
            this.b_image.Size = new System.Drawing.Size(135, 40);
            this.b_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.b_image.TabIndex = 5;
            this.b_image.TabStop = false;
            this.b_image.Tag = "3";
            this.b_image.Click += new System.EventHandler(this.Picture_Click);
            // 
            // ac_image
            // 
            this.ac_image.Image = global::battleship2.Properties.Resources.aircraft_carrier;
            this.ac_image.Location = new System.Drawing.Point(20, 413);
            this.ac_image.Name = "ac_image";
            this.ac_image.Size = new System.Drawing.Size(225, 40);
            this.ac_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ac_image.TabIndex = 3;
            this.ac_image.TabStop = false;
            this.ac_image.Tag = "5";
            this.ac_image.Click += new System.EventHandler(this.Picture_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel_abc);
            this.panel4.Location = new System.Drawing.Point(280, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(580, 575);
            this.panel4.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(243, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 32);
            this.label13.TabIndex = 24;
            this.label13.Text = "ΕΓΩ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "  1     2    3    4     5     6    7     8    9    10";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BackgroundImage = global::battleship2.Properties.Resources.Back;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(54, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 0;
            // 
            // panel_abc
            // 
            this.panel_abc.BackgroundImage = global::battleship2.Properties.Resources.abc;
            this.panel_abc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_abc.Location = new System.Drawing.Point(3, 72);
            this.panel_abc.Name = "panel_abc";
            this.panel_abc.Size = new System.Drawing.Size(45, 492);
            this.panel_abc.TabIndex = 29;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::battleship2.Properties.Resources.waves;
            this.ClientSize = new System.Drawing.Size(1376, 614);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.s_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ac_image)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Play_Btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Clear_Btn;
        private System.Windows.Forms.PictureBox d_image;
        private System.Windows.Forms.PictureBox b_image;
        private System.Windows.Forms.PictureBox s_image;
        private System.Windows.Forms.PictureBox ac_image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel_abc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
    }
}

