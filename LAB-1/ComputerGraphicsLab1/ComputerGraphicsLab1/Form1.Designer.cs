namespace ComputerGraphicsLab1
{
    partial class ComputerGraphicLab1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.background = new System.Windows.Forms.Button();
            this.graphic = new System.Windows.Forms.Button();
            this.draw_image = new System.Windows.Forms.Button();
            this.draw = new System.Windows.Forms.Button();
            this.turnY = new System.Windows.Forms.TrackBar();
            this.turnZ = new System.Windows.Forms.TrackBar();
            this.turnX = new System.Windows.Forms.TrackBar();
            this.space = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.turnY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.space)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.Location = new System.Drawing.Point(1025, 427);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(101, 65);
            this.background.TabIndex = 0;
            this.background.Text = "Background";
            this.background.UseVisualStyleBackColor = true;
            this.background.Click += new System.EventHandler(this.background_Click);
            // 
            // graphic
            // 
            this.graphic.Location = new System.Drawing.Point(1118, 427);
            this.graphic.Name = "graphic";
            this.graphic.Size = new System.Drawing.Size(101, 65);
            this.graphic.TabIndex = 1;
            this.graphic.Text = "Graphic";
            this.graphic.UseVisualStyleBackColor = true;
            this.graphic.Click += new System.EventHandler(this.graphic_Click);
            // 
            // draw_image
            // 
            this.draw_image.Location = new System.Drawing.Point(1025, 515);
            this.draw_image.Name = "draw_image";
            this.draw_image.Size = new System.Drawing.Size(193, 36);
            this.draw_image.TabIndex = 2;
            this.draw_image.Text = "Download image";
            this.draw_image.UseVisualStyleBackColor = true;
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(1026, 568);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(193, 36);
            this.draw.TabIndex = 3;
            this.draw.Text = "Draw";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // turnY
            // 
            this.turnY.Location = new System.Drawing.Point(998, 213);
            this.turnY.Name = "turnY";
            this.turnY.Size = new System.Drawing.Size(221, 56);
            this.turnY.TabIndex = 4;
            this.turnY.Scroll += new System.EventHandler(this.turnY_Scroll);
            // 
            // turnZ
            // 
            this.turnZ.Location = new System.Drawing.Point(998, 275);
            this.turnZ.Name = "turnZ";
            this.turnZ.Size = new System.Drawing.Size(221, 56);
            this.turnZ.TabIndex = 5;
            this.turnZ.Scroll += new System.EventHandler(this.turnZ_Scroll);
            // 
            // turnX
            // 
            this.turnX.Location = new System.Drawing.Point(997, 151);
            this.turnX.Name = "turnX";
            this.turnX.Size = new System.Drawing.Size(221, 56);
            this.turnX.TabIndex = 6;
            this.turnX.Scroll += new System.EventHandler(this.turnX_Scroll);
            // 
            // space
            // 
            this.space.BackColor = System.Drawing.Color.Black;
            this.space.Location = new System.Drawing.Point(12, 12);
            this.space.Name = "space";
            this.space.Size = new System.Drawing.Size(903, 623);
            this.space.TabIndex = 7;
            this.space.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1175, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 29);
            this.button5.TabIndex = 8;
            this.button5.Text = "ok";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1080, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Turns";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1102, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Colors";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(954, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(954, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(954, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Z:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(987, 50);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 24);
            this.comboBox1.TabIndex = 15;
            // 
            // ComputerGraphicLab1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 662);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.space);
            this.Controls.Add(this.turnX);
            this.Controls.Add(this.turnZ);
            this.Controls.Add(this.turnY);
            this.Controls.Add(this.draw);
            this.Controls.Add(this.draw_image);
            this.Controls.Add(this.graphic);
            this.Controls.Add(this.background);
            this.Name = "ComputerGraphicLab1";
            this.Text = "ComputerGraphicsLab1";
            this.Load += new System.EventHandler(this.ComputerGraphicLab1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.turnY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turnX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.space)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button background;
        private System.Windows.Forms.Button graphic;
        private System.Windows.Forms.Button draw_image;
        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.TrackBar turnY;
        private System.Windows.Forms.TrackBar turnZ;
        private System.Windows.Forms.TrackBar turnX;
        private System.Windows.Forms.PictureBox space;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

