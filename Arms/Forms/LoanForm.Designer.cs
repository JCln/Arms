namespace Arms.Forms
{
    partial class LoanForm
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
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUserLoanId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewLoans = new System.Windows.Forms.DataGridView();
            this.textBoxPersonnelCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxSureName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDayRegister = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDayReceive = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoans)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRemove
            // 
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonRemove.Location = new System.Drawing.Point(77, 536);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(280, 46);
            this.buttonRemove.TabIndex = 36;
            this.buttonRemove.Text = "حذف";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonEdit.Location = new System.Drawing.Point(390, 536);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(272, 46);
            this.buttonEdit.TabIndex = 35;
            this.buttonEdit.Text = "ویرایش";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonAdd.Location = new System.Drawing.Point(692, 536);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(260, 46);
            this.buttonAdd.TabIndex = 34;
            this.buttonAdd.Text = "افزودن";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(77, 437);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBoxDescription.Size = new System.Drawing.Size(508, 81);
            this.richTextBoxDescription.TabIndex = 33;
            this.richTextBoxDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(604, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 32;
            this.label3.Text = "توضیحات";
            // 
            // textBoxUserLoanId
            // 
            this.textBoxUserLoanId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxUserLoanId.Location = new System.Drawing.Point(737, 344);
            this.textBoxUserLoanId.Name = "textBoxUserLoanId";
            this.textBoxUserLoanId.ReadOnly = true;
            this.textBoxUserLoanId.Size = new System.Drawing.Size(174, 30);
            this.textBoxUserLoanId.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(931, 344);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "شناسه ";
            // 
            // dataGridViewLoans
            // 
            this.dataGridViewLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLoans.Location = new System.Drawing.Point(77, 84);
            this.dataGridViewLoans.Name = "dataGridViewLoans";
            this.dataGridViewLoans.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewLoans.RowTemplate.Height = 28;
            this.dataGridViewLoans.ShowEditingIcon = false;
            this.dataGridViewLoans.Size = new System.Drawing.Size(889, 233);
            this.dataGridViewLoans.TabIndex = 27;
            // 
            // textBoxPersonnelCode
            // 
            this.textBoxPersonnelCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxPersonnelCode.Location = new System.Drawing.Point(77, 28);
            this.textBoxPersonnelCode.Name = "textBoxPersonnelCode";
            this.textBoxPersonnelCode.ReadOnly = true;
            this.textBoxPersonnelCode.Size = new System.Drawing.Size(174, 30);
            this.textBoxPersonnelCode.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(278, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 25;
            this.label4.Text = "کد پرسنلی";
            // 
            // textBoxSureName
            // 
            this.textBoxSureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxSureName.Location = new System.Drawing.Point(411, 28);
            this.textBoxSureName.Name = "textBoxSureName";
            this.textBoxSureName.ReadOnly = true;
            this.textBoxSureName.Size = new System.Drawing.Size(174, 30);
            this.textBoxSureName.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(611, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "نشان";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxFirstName.Location = new System.Drawing.Point(737, 27);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.ReadOnly = true;
            this.textBoxFirstName.Size = new System.Drawing.Size(174, 30);
            this.textBoxFirstName.TabIndex = 22;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelFirstName.Location = new System.Drawing.Point(937, 28);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(29, 25);
            this.labelFirstName.TabIndex = 21;
            this.labelFirstName.Text = "نام";
            // 
            // textBoxCode
            // 
            this.textBoxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxCode.Location = new System.Drawing.Point(411, 344);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxCode.Size = new System.Drawing.Size(174, 30);
            this.textBoxCode.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(604, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 37;
            this.label5.Text = "کد وام";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxAmount.Location = new System.Drawing.Point(77, 344);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxAmount.Size = new System.Drawing.Size(174, 30);
            this.textBoxAmount.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(277, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 25);
            this.label6.TabIndex = 39;
            this.label6.Text = "مبلغ وام";
            // 
            // textBoxDayRegister
            // 
            this.textBoxDayRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxDayRegister.Location = new System.Drawing.Point(411, 391);
            this.textBoxDayRegister.Name = "textBoxDayRegister";
            this.textBoxDayRegister.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxDayRegister.Size = new System.Drawing.Size(174, 30);
            this.textBoxDayRegister.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(604, 394);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 25);
            this.label7.TabIndex = 41;
            this.label7.Text = "تاریخ درخواست";
            // 
            // textBoxDayReceive
            // 
            this.textBoxDayReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxDayReceive.Location = new System.Drawing.Point(77, 394);
            this.textBoxDayReceive.Name = "textBoxDayReceive";
            this.textBoxDayReceive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxDayReceive.Size = new System.Drawing.Size(174, 30);
            this.textBoxDayReceive.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(270, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 25);
            this.label8.TabIndex = 43;
            this.label8.Text = "تاریخ دریافت";
            // 
            // LoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 608);
            this.Controls.Add(this.textBoxDayReceive);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxDayRegister);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUserLoanId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewLoans);
            this.Controls.Add(this.textBoxPersonnelCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxSureName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelFirstName);
            this.Name = "LoanForm";
            this.Text = "فرم ثبت وام";
            this.Load += new System.EventHandler(this.LoanForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLoans)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUserLoanId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewLoans;
        private System.Windows.Forms.TextBox textBoxPersonnelCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxSureName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDayRegister;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxDayReceive;
        private System.Windows.Forms.Label label8;
    }
}