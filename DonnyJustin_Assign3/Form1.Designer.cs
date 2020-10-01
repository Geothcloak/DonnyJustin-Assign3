namespace DonnyJustin_Assign3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ZID_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.gradeReportOneStudent_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lessThan_RadioButton1 = new System.Windows.Forms.RadioButton();
            this.greaterThan_RadioButton1 = new System.Windows.Forms.RadioButton();
            this.Threshold_GroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grade1_ComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.courseThreshold_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.gradeThreshold_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.major_ComboBox = new System.Windows.Forms.ComboBox();
            this.gradeThreshold_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.majorFails_Button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.gradeReport_RichTextBox = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gradeReportOneCourse_Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lessThan_RadioButton2 = new System.Windows.Forms.RadioButton();
            this.greaterThan_RadioButton2 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lessThan_RadioButton3 = new System.Windows.Forms.RadioButton();
            this.greaterThan_RadioButton3 = new System.Windows.Forms.RadioButton();
            this.failReport_Button = new System.Windows.Forms.Button();
            this.passReport_Button = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.failReport_UpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.passReport_ComboBox = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.query_ListBox = new System.Windows.Forms.ListBox();
            this.Threshold_GroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.failReport_UpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grade Report for One Student";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Z-ID";
            // 
            // ZID_RichTextBox
            // 
            this.ZID_RichTextBox.Location = new System.Drawing.Point(46, 35);
            this.ZID_RichTextBox.Name = "ZID_RichTextBox";
            this.ZID_RichTextBox.Size = new System.Drawing.Size(100, 23);
            this.ZID_RichTextBox.TabIndex = 2;
            this.ZID_RichTextBox.Text = "";
            // 
            // gradeReportOneStudent_Button
            // 
            this.gradeReportOneStudent_Button.AutoEllipsis = true;
            this.gradeReportOneStudent_Button.BackColor = System.Drawing.Color.Transparent;
            this.gradeReportOneStudent_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.gradeReportOneStudent_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.gradeReportOneStudent_Button.Location = new System.Drawing.Point(382, 33);
            this.gradeReportOneStudent_Button.Name = "gradeReportOneStudent_Button";
            this.gradeReportOneStudent_Button.Size = new System.Drawing.Size(82, 23);
            this.gradeReportOneStudent_Button.TabIndex = 3;
            this.gradeReportOneStudent_Button.Text = "Show Results";
            this.gradeReportOneStudent_Button.UseVisualStyleBackColor = false;
            this.gradeReportOneStudent_Button.Click += new System.EventHandler(this.gradeReportOneStudent_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Grade Threshold for One Course";
            // 
            // lessThan_RadioButton1
            // 
            this.lessThan_RadioButton1.AutoSize = true;
            this.lessThan_RadioButton1.Location = new System.Drawing.Point(6, 19);
            this.lessThan_RadioButton1.Name = "lessThan_RadioButton1";
            this.lessThan_RadioButton1.Size = new System.Drawing.Size(133, 17);
            this.lessThan_RadioButton1.TabIndex = 5;
            this.lessThan_RadioButton1.TabStop = true;
            this.lessThan_RadioButton1.Text = "Less Than or Equal To";
            this.lessThan_RadioButton1.UseVisualStyleBackColor = true;
            // 
            // greaterThan_RadioButton1
            // 
            this.greaterThan_RadioButton1.AutoSize = true;
            this.greaterThan_RadioButton1.Location = new System.Drawing.Point(6, 42);
            this.greaterThan_RadioButton1.Name = "greaterThan_RadioButton1";
            this.greaterThan_RadioButton1.Size = new System.Drawing.Size(146, 17);
            this.greaterThan_RadioButton1.TabIndex = 6;
            this.greaterThan_RadioButton1.TabStop = true;
            this.greaterThan_RadioButton1.Text = "Greater Than or Equal To";
            this.greaterThan_RadioButton1.UseVisualStyleBackColor = true;
            // 
            // Threshold_GroupBox
            // 
            this.Threshold_GroupBox.Controls.Add(this.lessThan_RadioButton1);
            this.Threshold_GroupBox.Controls.Add(this.greaterThan_RadioButton1);
            this.Threshold_GroupBox.Location = new System.Drawing.Point(15, 108);
            this.Threshold_GroupBox.Name = "Threshold_GroupBox";
            this.Threshold_GroupBox.Size = new System.Drawing.Size(200, 73);
            this.Threshold_GroupBox.TabIndex = 7;
            this.Threshold_GroupBox.TabStop = false;
            this.Threshold_GroupBox.Text = "groupBox1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Grade";
            // 
            // grade1_ComboBox
            // 
            this.grade1_ComboBox.FormattingEnabled = true;
            this.grade1_ComboBox.Location = new System.Drawing.Point(221, 147);
            this.grade1_ComboBox.Name = "grade1_ComboBox";
            this.grade1_ComboBox.Size = new System.Drawing.Size(36, 21);
            this.grade1_ComboBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Course";
            // 
            // courseThreshold_RichTextBox
            // 
            this.courseThreshold_RichTextBox.Location = new System.Drawing.Point(276, 147);
            this.courseThreshold_RichTextBox.Name = "courseThreshold_RichTextBox";
            this.courseThreshold_RichTextBox.Size = new System.Drawing.Size(100, 23);
            this.courseThreshold_RichTextBox.TabIndex = 11;
            this.courseThreshold_RichTextBox.Text = "";
            // 
            // gradeThreshold_Button
            // 
            this.gradeThreshold_Button.AutoEllipsis = true;
            this.gradeThreshold_Button.BackColor = System.Drawing.Color.Transparent;
            this.gradeThreshold_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.gradeThreshold_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.gradeThreshold_Button.Location = new System.Drawing.Point(382, 144);
            this.gradeThreshold_Button.Name = "gradeThreshold_Button";
            this.gradeThreshold_Button.Size = new System.Drawing.Size(82, 23);
            this.gradeThreshold_Button.TabIndex = 12;
            this.gradeThreshold_Button.Text = "Show Results";
            this.gradeThreshold_Button.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Major Students Who Failed A Course";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Major";
            // 
            // major_ComboBox
            // 
            this.major_ComboBox.FormattingEnabled = true;
            this.major_ComboBox.Location = new System.Drawing.Point(21, 244);
            this.major_ComboBox.Name = "major_ComboBox";
            this.major_ComboBox.Size = new System.Drawing.Size(146, 21);
            this.major_ComboBox.TabIndex = 15;
            // 
            // gradeThreshold_RichTextBox
            // 
            this.gradeThreshold_RichTextBox.Location = new System.Drawing.Point(276, 244);
            this.gradeThreshold_RichTextBox.Name = "gradeThreshold_RichTextBox";
            this.gradeThreshold_RichTextBox.Size = new System.Drawing.Size(100, 23);
            this.gradeThreshold_RichTextBox.TabIndex = 17;
            this.gradeThreshold_RichTextBox.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(273, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Course";
            // 
            // majorFails_Button
            // 
            this.majorFails_Button.AutoEllipsis = true;
            this.majorFails_Button.BackColor = System.Drawing.Color.Transparent;
            this.majorFails_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.majorFails_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.majorFails_Button.Location = new System.Drawing.Point(382, 244);
            this.majorFails_Button.Name = "majorFails_Button";
            this.majorFails_Button.Size = new System.Drawing.Size(82, 23);
            this.majorFails_Button.TabIndex = 18;
            this.majorFails_Button.Text = "Show Results";
            this.majorFails_Button.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 18);
            this.label9.TabIndex = 19;
            this.label9.Text = "Grade Report for One Course";
            // 
            // gradeReport_RichTextBox
            // 
            this.gradeReport_RichTextBox.Location = new System.Drawing.Point(63, 327);
            this.gradeReport_RichTextBox.Name = "gradeReport_RichTextBox";
            this.gradeReport_RichTextBox.Size = new System.Drawing.Size(100, 23);
            this.gradeReport_RichTextBox.TabIndex = 21;
            this.gradeReport_RichTextBox.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 330);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Course";
            // 
            // gradeReportOneCourse_Button
            // 
            this.gradeReportOneCourse_Button.AutoEllipsis = true;
            this.gradeReportOneCourse_Button.BackColor = System.Drawing.Color.Transparent;
            this.gradeReportOneCourse_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.gradeReportOneCourse_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.gradeReportOneCourse_Button.Location = new System.Drawing.Point(382, 325);
            this.gradeReportOneCourse_Button.Name = "gradeReportOneCourse_Button";
            this.gradeReportOneCourse_Button.Size = new System.Drawing.Size(82, 23);
            this.gradeReportOneCourse_Button.TabIndex = 22;
            this.gradeReportOneCourse_Button.Text = "Show Results";
            this.gradeReportOneCourse_Button.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lessThan_RadioButton2);
            this.groupBox1.Controls.Add(this.greaterThan_RadioButton2);
            this.groupBox1.Location = new System.Drawing.Point(15, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 73);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lessThan_RadioButton2
            // 
            this.lessThan_RadioButton2.AutoSize = true;
            this.lessThan_RadioButton2.Location = new System.Drawing.Point(6, 19);
            this.lessThan_RadioButton2.Name = "lessThan_RadioButton2";
            this.lessThan_RadioButton2.Size = new System.Drawing.Size(133, 17);
            this.lessThan_RadioButton2.TabIndex = 5;
            this.lessThan_RadioButton2.TabStop = true;
            this.lessThan_RadioButton2.Text = "Less Than or Equal To";
            this.lessThan_RadioButton2.UseVisualStyleBackColor = true;
            // 
            // greaterThan_RadioButton2
            // 
            this.greaterThan_RadioButton2.AutoSize = true;
            this.greaterThan_RadioButton2.Location = new System.Drawing.Point(6, 42);
            this.greaterThan_RadioButton2.Name = "greaterThan_RadioButton2";
            this.greaterThan_RadioButton2.Size = new System.Drawing.Size(146, 17);
            this.greaterThan_RadioButton2.TabIndex = 6;
            this.greaterThan_RadioButton2.TabStop = true;
            this.greaterThan_RadioButton2.Text = "Greater Than or Equal To";
            this.greaterThan_RadioButton2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 373);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(214, 18);
            this.label11.TabIndex = 23;
            this.label11.Text = "Fail Report For All Courses";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 478);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(225, 18);
            this.label12.TabIndex = 25;
            this.label12.Text = "Pass Report For All Courses";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lessThan_RadioButton3);
            this.groupBox2.Controls.Add(this.greaterThan_RadioButton3);
            this.groupBox2.Location = new System.Drawing.Point(15, 499);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 73);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // lessThan_RadioButton3
            // 
            this.lessThan_RadioButton3.AutoSize = true;
            this.lessThan_RadioButton3.Location = new System.Drawing.Point(6, 19);
            this.lessThan_RadioButton3.Name = "lessThan_RadioButton3";
            this.lessThan_RadioButton3.Size = new System.Drawing.Size(133, 17);
            this.lessThan_RadioButton3.TabIndex = 7;
            this.lessThan_RadioButton3.TabStop = true;
            this.lessThan_RadioButton3.Text = "Less Than or Equal To";
            this.lessThan_RadioButton3.UseVisualStyleBackColor = true;
            // 
            // greaterThan_RadioButton3
            // 
            this.greaterThan_RadioButton3.AutoSize = true;
            this.greaterThan_RadioButton3.Location = new System.Drawing.Point(6, 42);
            this.greaterThan_RadioButton3.Name = "greaterThan_RadioButton3";
            this.greaterThan_RadioButton3.Size = new System.Drawing.Size(146, 17);
            this.greaterThan_RadioButton3.TabIndex = 6;
            this.greaterThan_RadioButton3.TabStop = true;
            this.greaterThan_RadioButton3.Text = "Greater Than or Equal To";
            this.greaterThan_RadioButton3.UseVisualStyleBackColor = true;
            // 
            // failReport_Button
            // 
            this.failReport_Button.AutoEllipsis = true;
            this.failReport_Button.BackColor = System.Drawing.Color.Transparent;
            this.failReport_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.failReport_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.failReport_Button.Location = new System.Drawing.Point(382, 430);
            this.failReport_Button.Name = "failReport_Button";
            this.failReport_Button.Size = new System.Drawing.Size(82, 23);
            this.failReport_Button.TabIndex = 26;
            this.failReport_Button.Text = "Show Results";
            this.failReport_Button.UseVisualStyleBackColor = false;
            // 
            // passReport_Button
            // 
            this.passReport_Button.AutoEllipsis = true;
            this.passReport_Button.BackColor = System.Drawing.Color.Transparent;
            this.passReport_Button.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.passReport_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.passReport_Button.Location = new System.Drawing.Point(382, 535);
            this.passReport_Button.Name = "passReport_Button";
            this.passReport_Button.Size = new System.Drawing.Size(82, 23);
            this.passReport_Button.TabIndex = 27;
            this.passReport_Button.Text = "Show Results";
            this.passReport_Button.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 417);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Percentage";
            // 
            // failReport_UpDown
            // 
            this.failReport_UpDown.Location = new System.Drawing.Point(221, 433);
            this.failReport_UpDown.Name = "failReport_UpDown";
            this.failReport_UpDown.Size = new System.Drawing.Size(62, 20);
            this.failReport_UpDown.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(221, 522);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Grade";
            // 
            // passReport_ComboBox
            // 
            this.passReport_ComboBox.FormattingEnabled = true;
            this.passReport_ComboBox.Location = new System.Drawing.Point(221, 541);
            this.passReport_ComboBox.Name = "passReport_ComboBox";
            this.passReport_ComboBox.Size = new System.Drawing.Size(36, 21);
            this.passReport_ComboBox.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(487, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 18);
            this.label15.TabIndex = 32;
            this.label15.Text = "Query Results";
            // 
            // query_ListBox
            // 
            this.query_ListBox.FormattingEnabled = true;
            this.query_ListBox.Location = new System.Drawing.Point(490, 33);
            this.query_ListBox.Name = "query_ListBox";
            this.query_ListBox.Size = new System.Drawing.Size(479, 589);
            this.query_ListBox.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 627);
            this.Controls.Add(this.query_ListBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.passReport_ComboBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.failReport_UpDown);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.passReport_Button);
            this.Controls.Add(this.failReport_Button);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gradeReportOneCourse_Button);
            this.Controls.Add(this.gradeReport_RichTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.majorFails_Button);
            this.Controls.Add(this.gradeThreshold_RichTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.major_ComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gradeThreshold_Button);
            this.Controls.Add(this.courseThreshold_RichTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grade1_ComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Threshold_GroupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gradeReportOneStudent_Button);
            this.Controls.Add(this.ZID_RichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Threshold_GroupBox.ResumeLayout(false);
            this.Threshold_GroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.failReport_UpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox ZID_RichTextBox;
        private System.Windows.Forms.Button gradeReportOneStudent_Button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton lessThan_RadioButton1;
        private System.Windows.Forms.RadioButton greaterThan_RadioButton1;
        private System.Windows.Forms.GroupBox Threshold_GroupBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox grade1_ComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox courseThreshold_RichTextBox;
        private System.Windows.Forms.Button gradeThreshold_Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox major_ComboBox;
        private System.Windows.Forms.RichTextBox gradeThreshold_RichTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button majorFails_Button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox gradeReport_RichTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button gradeReportOneCourse_Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton lessThan_RadioButton2;
        private System.Windows.Forms.RadioButton greaterThan_RadioButton2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox2;
        //private System.Windows.Forms.RadioButton lessThan_RadioButton3;
        private System.Windows.Forms.RadioButton greaterThan_RadioButton3;
        private System.Windows.Forms.RadioButton lessThan_RadioButton3;
        private System.Windows.Forms.Button failReport_Button;
        private System.Windows.Forms.Button passReport_Button;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown failReport_UpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox passReport_ComboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox query_ListBox;
    }
}

