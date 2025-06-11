namespace zd3
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            textBox8 = new TextBox();
            label8 = new Label();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(307, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(481, 242);
            dataGridView1.TabIndex = 0;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(34, 269);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(139, 19);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "С доп информацией";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Click += Доп_Данные;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(110, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 25);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 3;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 54);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 5;
            label2.Text = "Цена";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(110, 51);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 83);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 7;
            label3.Text = "Количество";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(110, 80);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 112);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 9;
            label4.Text = "Тип";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(110, 109);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 141);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 11;
            label5.Text = "Дата Получения";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(110, 138);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 170);
            label6.Name = "label6";
            label6.Size = new Size(75, 15);
            label6.TabIndex = 13;
            label6.Text = "Год выпуска";
            label6.Visible = false;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(110, 167);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 12;
            textBox6.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(34, 204);
            label7.Name = "label7";
            label7.Size = new Size(70, 15);
            label7.TabIndex = 15;
            label7.Text = "Поставщик";
            label7.Visible = false;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(110, 196);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(100, 23);
            textBox7.TabIndex = 14;
            textBox7.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(110, 225);
            button1.Name = "button1";
            button1.Size = new Size(100, 38);
            button1.TabIndex = 16;
            button1.Text = "Добавить товар";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Добавить;
            // 
            // button2
            // 
            button2.Location = new Point(418, 12);
            button2.Name = "button2";
            button2.Size = new Size(83, 41);
            button2.TabIndex = 17;
            button2.Text = "Удалить по имени";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Удалить_по_имени;
            // 
            // button3
            // 
            button3.Location = new Point(518, 12);
            button3.Name = "button3";
            button3.Size = new Size(103, 55);
            button3.TabIndex = 18;
            button3.Text = "Удалить по выбранному индексу\r\n\r\n";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Улалить_по_индексу;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(418, 86);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(83, 23);
            textBox8.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(440, 68);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 20;
            label8.Text = "Имя";
            // 
            // button4
            // 
            button4.Location = new Point(262, 12);
            button4.Name = "button4";
            button4.Size = new Size(88, 72);
            button4.TabIndex = 21;
            button4.Text = "Получить Качество выбранного товара";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Получить_Q;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(label8);
            Controls.Add(textBox8);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(textBox7);
            Controls.Add(label6);
            Controls.Add(textBox6);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox7;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox8;
        private Label label8;
        private Button button4;
    }
}
