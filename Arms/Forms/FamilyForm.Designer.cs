namespace Arms.Forms
{
    partial class FamilyForm
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
            this.labelUserId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelUserFirstSureName = new System.Windows.Forms.Label();
            this.dataGridViewUserFamily = new System.Windows.Forms.DataGridView();
            this.buttonUserFamilyDelete = new System.Windows.Forms.Button();
            this.buttonUserFamilyEdit = new System.Windows.Forms.Button();
            this.textBoxFirstSureName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonUserFamilyAdd = new System.Windows.Forms.Button();
            this.comboBoxRelation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelNationalId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNationalId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUserFamilyId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserFamily)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(1057, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "شناسه کاربر";
            // 
            // labelUserId
            // 
            this.labelUserId.AutoSize = true;
            this.labelUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelUserId.Location = new System.Drawing.Point(935, 16);
            this.labelUserId.Name = "labelUserId";
            this.labelUserId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelUserId.Size = new System.Drawing.Size(110, 25);
            this.labelUserId.TabIndex = 1;
            this.labelUserId.Text = "labelUserId";
            this.labelUserId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(1057, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "نام نام خانوادگی";
            // 
            // labelUserFirstSureName
            // 
            this.labelUserFirstSureName.AutoSize = true;
            this.labelUserFirstSureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelUserFirstSureName.Location = new System.Drawing.Point(816, 62);
            this.labelUserFirstSureName.Name = "labelUserFirstSureName";
            this.labelUserFirstSureName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelUserFirstSureName.Size = new System.Drawing.Size(225, 25);
            this.labelUserFirstSureName.TabIndex = 3;
            this.labelUserFirstSureName.Text = "labelUserFirstSureName";
            this.labelUserFirstSureName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewUserFamily
            // 
            this.dataGridViewUserFamily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUserFamily.Location = new System.Drawing.Point(25, 12);
            this.dataGridViewUserFamily.Name = "dataGridViewUserFamily";
            this.dataGridViewUserFamily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewUserFamily.RowTemplate.Height = 28;
            this.dataGridViewUserFamily.Size = new System.Drawing.Size(658, 469);
            this.dataGridViewUserFamily.TabIndex = 4;
            // 
            // buttonUserFamilyDelete
            // 
            this.buttonUserFamilyDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonUserFamilyDelete.Location = new System.Drawing.Point(1064, 436);
            this.buttonUserFamilyDelete.Name = "buttonUserFamilyDelete";
            this.buttonUserFamilyDelete.Size = new System.Drawing.Size(112, 43);
            this.buttonUserFamilyDelete.TabIndex = 19;
            this.buttonUserFamilyDelete.Text = "حذف";
            this.buttonUserFamilyDelete.UseVisualStyleBackColor = true;
            this.buttonUserFamilyDelete.Click += new System.EventHandler(this.buttonUserFamilyDelete_Click);
            // 
            // buttonUserFamilyEdit
            // 
            this.buttonUserFamilyEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonUserFamilyEdit.Location = new System.Drawing.Point(946, 436);
            this.buttonUserFamilyEdit.Name = "buttonUserFamilyEdit";
            this.buttonUserFamilyEdit.Size = new System.Drawing.Size(112, 43);
            this.buttonUserFamilyEdit.TabIndex = 18;
            this.buttonUserFamilyEdit.Text = "ویرایش";
            this.buttonUserFamilyEdit.UseVisualStyleBackColor = true;
            this.buttonUserFamilyEdit.Click += new System.EventHandler(this.buttonUserFamilyEdit_Click);
            // 
            // textBoxFirstSureName
            // 
            this.textBoxFirstSureName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxFirstSureName.Location = new System.Drawing.Point(824, 337);
            this.textBoxFirstSureName.Name = "textBoxFirstSureName";
            this.textBoxFirstSureName.Size = new System.Drawing.Size(221, 30);
            this.textBoxFirstSureName.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(1076, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "نام و نشان";
            // 
            // buttonUserFamilyAdd
            // 
            this.buttonUserFamilyAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.buttonUserFamilyAdd.Location = new System.Drawing.Point(821, 436);
            this.buttonUserFamilyAdd.Name = "buttonUserFamilyAdd";
            this.buttonUserFamilyAdd.Size = new System.Drawing.Size(119, 43);
            this.buttonUserFamilyAdd.TabIndex = 13;
            this.buttonUserFamilyAdd.Text = "افزودن";
            this.buttonUserFamilyAdd.UseVisualStyleBackColor = true;
            this.buttonUserFamilyAdd.Click += new System.EventHandler(this.buttonUserFamilyAdd_Click);
            // 
            // comboBoxRelation
            // 
            this.comboBoxRelation.FormattingEnabled = true;
            this.comboBoxRelation.Location = new System.Drawing.Point(824, 385);
            this.comboBoxRelation.Name = "comboBoxRelation";
            this.comboBoxRelation.Size = new System.Drawing.Size(221, 28);
            this.comboBoxRelation.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(1077, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "نسبت";
            // 
            // labelNationalId
            // 
            this.labelNationalId.AutoSize = true;
            this.labelNationalId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelNationalId.Location = new System.Drawing.Point(905, 108);
            this.labelNationalId.Name = "labelNationalId";
            this.labelNationalId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelNationalId.Size = new System.Drawing.Size(140, 25);
            this.labelNationalId.TabIndex = 23;
            this.labelNationalId.Text = "labelNationalId";
            this.labelNationalId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(1061, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "کد ملی";
            // 
            // textBoxNationalId
            // 
            this.textBoxNationalId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxNationalId.Location = new System.Drawing.Point(823, 287);
            this.textBoxNationalId.Name = "textBoxNationalId";
            this.textBoxNationalId.Size = new System.Drawing.Size(221, 30);
            this.textBoxNationalId.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(1075, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "کد ملی";
            // 
            // textBoxUserFamilyId
            // 
            this.textBoxUserFamilyId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxUserFamilyId.Location = new System.Drawing.Point(824, 233);
            this.textBoxUserFamilyId.Name = "textBoxUserFamilyId";
            this.textBoxUserFamilyId.ReadOnly = true;
            this.textBoxUserFamilyId.Size = new System.Drawing.Size(221, 30);
            this.textBoxUserFamilyId.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(1082, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 25);
            this.label6.TabIndex = 26;
            this.label6.Text = "شناسه";
            // 
            // FamilyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 575);
            this.Controls.Add(this.textBoxUserFamilyId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxNationalId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelNationalId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxRelation);
            this.Controls.Add(this.buttonUserFamilyDelete);
            this.Controls.Add(this.buttonUserFamilyEdit);
            this.Controls.Add(this.textBoxFirstSureName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonUserFamilyAdd);
            this.Controls.Add(this.dataGridViewUserFamily);
            this.Controls.Add(this.labelUserFirstSureName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelUserId);
            this.Controls.Add(this.label1);
            this.Name = "FamilyForm";
            this.Text = "عائله تحت تکفل";
            this.Load += new System.EventHandler(this.FamilyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUserFamily)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUserId;
        private System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.Label labelUserFirstSureName;
        private System.Windows.Forms.DataGridView dataGridViewUserFamily;
        private System.Windows.Forms.Button buttonUserFamilyDelete;
        private System.Windows.Forms.Button buttonUserFamilyEdit;
        private System.Windows.Forms.TextBox textBoxFirstSureName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonUserFamilyAdd;
        private System.Windows.Forms.ComboBox comboBoxRelation;
        private System.Windows.Forms.Label label5;
        protected internal System.Windows.Forms.Label labelNationalId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNationalId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUserFamilyId;
        private System.Windows.Forms.Label label6;
    }
}