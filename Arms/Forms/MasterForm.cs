using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DNTPersianUtils.Core;
using Arms.Services;
using Arms.Models;
using Arms.Data;
using Arms.Forms;
using Arms.Presentor;
using System.Linq.Dynamic;
using System.Data.SQLite;
using System.Configuration;

namespace Arms
{
    public partial class MasterForm : Form
    {        
        private readonly ArmsDbContext _context;
        private const string badgeGrigName = "درجات", bankGridName = "بانک", courseGridName = "دوره ها",
            proficiencyGridName="تخصص", educationGridName="مدارک تحصیلی", jobGridName="شغل سازمانی",
            offTypeGridName="علت مرخصی", userGridName="کاربر",
            add="افزودن",edit="ویرایش",remove="حذف";
        private IBadgeService _badgeService;
        private IBankService _bankService;
        private ICourseService _courseService;
        private IUserService _userService;
        private IProficiencyService _proficiencyService;
        private IEducationService _educationService;
        private IJobService _jobService;
        private IOffTypeService _offTypeService;
        private bool sortUserGridAscending = false;
        private ICollection<User> allUsesrs;
        private ILoanService _loanService;

        public MasterForm()
        {
            InitializeComponent();
            _context = new ArmsDbContext();
            _badgeService = new BadgeService(_context);
            _bankService = new BankService(_context);
            _courseService = new CourseService(_context);
            _userService = new UserService(_context);
            _proficiencyService = new ProficiencyService(_context);
            _educationService = new EducationService(_context);
            _jobService = new JobService(_context);
            _offTypeService = new OffTypeService(_context);
            _loanService = new LoanService(_context);

            AddAccountColumns();
        }

        private void MasterForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Maximized;
            this.Focus();
            this.Show();

            pictureBoxLogo.Location = new Point(this.Width-60,2);

            panelTopbar.Width = this.Width;

            panelLine.Width = this.Width;
            panelLine.Height = 1;

            panelLogin.Location = new Point(
                this.ClientSize.Width / 2 - panelLogin.Size.Width / 2,
                this.ClientSize.Height / 2 - panelLogin.Size.Height / 2);
            panelLogin.Anchor = AnchorStyles.None;

            panelMain.Hide();
            panelMain.Width = this.Width-30;
            panelMain.Height = this.Height;
            panelMain.Location = new Point(1,35);           

            tabControlMain.Height = panelMain.Height;
            tabControlMain.Width = panelMain.Width-15;

            Timer Clock = new Timer();
            Clock.Interval = 60000; 
            Clock.Start();
            Clock.Tick += new EventHandler(timerTopbar_Tick);
            labelTodayValue.Text = DateTime.Now.ToPersianDateTextify();
            labelTimeValue.Text = DateTime.Now.ToString("HH:mm").ToPersianNumbers();

            AddUserGrid();
        }

        private void labelLoginHeader_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if(textBoxUsername.Text=="admin" && textBoxPassword.Text == "q123456")
            {
                panelLogin.Hide();
                panelMain.Show();
            }
            else
            {
                MessageBox.Show("نام کاربری یا گذرواژه ناصحیح میباشد");
            }
        }

        private void timerTopbar_Tick(object sender, EventArgs e)
        {           
            labelTimeValue.Text = DateTime.Now.ToString("HH:mm").ToPersianNumbers();
        }       

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchValue=textBoxSearch.Text ;
            var users = _userService.Get();
            try
            {
                bool valueResult = false;
                var filteredUsesrs = users.Where(u =>
                     u.FirstName.Contains(searchValue) ||
                     u.SureName.Contains(searchValue) ||
                     u.Address.Contains(searchValue) ||
                     u.BadgeTitle.Contains(searchValue) ||
                     u.BirthDate.Contains(searchValue) ||
                     u.Description.Contains(searchValue) ||
                     u.EducationTitle.Contains(searchValue) ||
                     u.FatherName.Contains(searchValue) ||
                     u.Hekmat.Contains(searchValue) ||
                     u.IdCode.Contains(searchValue) ||
                     u.JobTitle.Contains(searchValue) ||
                     u.LastElevationDate.Contains(searchValue) ||
                     u.LocationOfService.Contains(searchValue) ||
                     u.Mobile.Contains(searchValue) ||
                     u.NationalId.Contains(searchValue) ||
                     u.PersonnelId.Contains(searchValue) ||
                     u.PhoneNumber.Contains(searchValue) ||
                     u.ProficiencyTitle.Contains(searchValue) ||
                     u.Sepah.Contains(searchValue)
                    ).ToList();
                valueResult = filteredUsesrs.Any();
                if (!valueResult)
                {
                    MessageBox.Show("مقدار " + searchValue, "در هیچ ستونی پیدا نشد");
                }
                else
                {
                    dataGridViewUsers.DataSource = filteredUsesrs;                   
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }       
        
        private bool CheckIdIsFull(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("لطفا یکی از سطر ها را انتخاب فرمایید");
                return false;
            }
            return true;
        }
        private bool CheckTitleIsFull(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("لطفا عنوان را وارد فرمایید");
                return false;
            }
            return true;
        }

        public void AddSuccess(string gridName)
        {
            MessageBox.Show($"افزودن مورد در جدول {gridName} با موفقیت انجام شد");
        }
        public void EditSuccess(string gridName)
        {
            MessageBox.Show($"ویرایش مورد در جدول {gridName} با موفقیت انجام شد");
        }
        public void RemoveSuccess(string gridName)
        {
            MessageBox.Show($"حذف مورد در جدول {gridName} با موفقیت انجام شد");
        }

        private void AddBadgeGrid()
        {
            dataGridViewBadges.ReadOnly = true;
            var badges = _badgeService.Get();
            dataGridViewBadges.DataSource = badges;
            dataGridViewBadges.Columns[0].HeaderText = "شناسه";
            dataGridViewBadges.Columns[1].HeaderText = "عنوان";
            dataGridViewBadges.Columns[2].Visible = false;
            dataGridViewBadges.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBadges.SelectionChanged += new EventHandler(dgv_Badge_SelectionChanged);
        }
        private void dgv_Badge_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                var id = Convert.ToString(row.Cells["Id"].Value);
                var title = Convert.ToString(row.Cells["Title"].Value);
                textBoxBadgeId.Text = id;
                textBoxBadgeTitle.Text = title;
            }
        }
        private void buttonBageAdd_Click(object sender, EventArgs e)
        {           
            if (!CheckTitleIsFull(textBoxBadgeTitle))
            {
                return;
            }
            try
            {
                _badgeService.Add(textBoxBadgeTitle.Text);
                _context.SaveChanges();
                AddSuccess(badgeGrigName);
                RefreshBadge();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(badgeGrigName, add);
            }            
        }
        private void buttonBadgeEdit_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxBadgeId))
            {
                return;
            }
            if (!CheckTitleIsFull(textBoxBadgeTitle))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxBadgeId.Text);
            var badge = _badgeService.Get(id);
            badge.IsDeleted = 1;
            _badgeService.Add(textBoxBadgeTitle.Text);

            _context.SaveChanges();
            RefreshBadge();
            EditSuccess(badgeGrigName);
        }
        private void buttonBadgeDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxBadgeId))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxBadgeId.Text);
             _badgeService.Remove(id);
            _context.SaveChanges();
            RefreshBadge();
            RemoveSuccess(badgeGrigName);
        }
        private void RefreshBadge()
        {
            var badges = _badgeService.Get();
            dataGridViewBadges.DataSource = badges;
        }


        private void AddBanksGrid()
        {
            dataGridViewBank.ReadOnly = true;
            var banks = _bankService.Get();
            dataGridViewBank.DataSource = banks;
            dataGridViewBank.Columns[0].HeaderText = "شناسه";
            dataGridViewBank.Columns[1].HeaderText = "عنوان";
            dataGridViewBank.Columns[2].Visible = false;
            dataGridViewBank.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBank.SelectionChanged += new EventHandler(dgv_Bank_SelectionChanged);
        }
        private void buttonBankAdd_Click(object sender, EventArgs e)
        {
            if (!CheckTitleIsFull(textBoxBankTitle))
            {
                return;
            }
            try
            {
                _bankService.Add(textBoxBankTitle.Text);
                _context.SaveChanges();
                AddSuccess(bankGridName);
                RefreshBank();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(bankGridName, add);
            }
        }
        private void buttonBankEdit_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxBankId))
            {
                return;
            }
            if (!CheckTitleIsFull(textBoxBankTitle))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxBankId.Text);
            var bank = _bankService.Get(id);
            bank.IsDeleted = 1;
            _bankService.Add(textBoxBankTitle.Text);

            _context.SaveChanges();
            RefreshBank();
            EditSuccess(bankGridName);
        }
        private void buttonBankDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxBankId))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxBankId.Text);
            _bankService.Remove(id);
            _context.SaveChanges();
            RefreshBank();
            RemoveSuccess(bankGridName);
        }
        private void dgv_Bank_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                var id = Convert.ToString(row.Cells["Id"].Value);
                var title = Convert.ToString(row.Cells["Title"].Value);
                textBoxBankId.Text = id;
                textBoxBankTitle.Text = title;
            }
        }
        private void RefreshBank()
        {
            var banks = _bankService.Get();
            dataGridViewBank.DataSource = banks;
        }

        private void AddCoursesGrid()
        {
            dataGridViewCourse.ReadOnly = true;
            var courses = _courseService.Get();
            dataGridViewCourse.DataSource = courses;
            dataGridViewCourse.Columns[0].HeaderText = "شناسه";
            dataGridViewCourse.Columns[1].HeaderText = "عنوان";
            dataGridViewCourse.Columns[2].Visible = false;
            dataGridViewCourse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCourse.SelectionChanged += new EventHandler(dgv_Course_SelectionChanged);
        }
        private void buttonCourseAdd_Click(object sender, EventArgs e)
        {
            if (!CheckTitleIsFull(textBoxCourseTitle))
            {
                return;
            }
            try
            {
                _courseService.Add(textBoxCourseTitle.Text);
                _context.SaveChanges();
                AddSuccess(courseGridName);
                RefreshCourse();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(courseGridName, add);
            }
        }
        private void buttonCourseEdit_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxCourseId))
            {
                return;
            }
            if (!CheckTitleIsFull(textBoxCourseTitle))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxCourseId.Text);
            var course = _courseService.Get(id);
            course.IsDeleted = 1;
            _courseService.Add(textBoxCourseTitle.Text);

            _context.SaveChanges();
            RefreshCourse();
            EditSuccess(courseGridName);
        }
        private void buttonCourseDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxCourseId))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxCourseId.Text);
            _courseService.Remove(id);
            _context.SaveChanges();
            RefreshCourse();
            RemoveSuccess(courseGridName);
        }
        private void dgv_Course_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                var id = Convert.ToString(row.Cells["Id"].Value);
                var title = Convert.ToString(row.Cells["Title"].Value);
                textBoxCourseId.Text = id;
                textBoxCourseTitle.Text = title;
            }
        }
        private void RefreshCourse()
        {
            var courses = _courseService.Get();
            dataGridViewCourse.DataSource = courses;
        }

        private void AddProficiencysGrid()
        {
            dataGridViewProficiency.ReadOnly = true;
            var proficiencys = _proficiencyService.Get();
            dataGridViewProficiency.DataSource = proficiencys;
            dataGridViewProficiency.Columns[0].HeaderText = "شناسه";
            dataGridViewProficiency.Columns[1].HeaderText = "عنوان";
            dataGridViewProficiency.Columns[2].Visible = false;
            dataGridViewProficiency.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProficiency.SelectionChanged += new EventHandler(dgv_Proficiency_SelectionChanged);
        }
        private void buttonProficiencyAdd_Click(object sender, EventArgs e)
        {
            if (!CheckTitleIsFull(textBoxProficiencyTitle))
            {
                return;
            }
            try
            {
                _proficiencyService.Add(textBoxProficiencyTitle.Text);
                _context.SaveChanges();
                AddSuccess(proficiencyGridName);
                RefreshProficiency();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(proficiencyGridName, add);
            }
        }
        private void buttonProficiencyEdit_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxProficiencyId))
            {
                return;
            }
            if (!CheckTitleIsFull(textBoxProficiencyTitle))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxProficiencyId.Text);
            var proficiency = _proficiencyService.Get(id);
            proficiency.IsDeleted = 1;
            _proficiencyService.Add(textBoxProficiencyTitle.Text);

            _context.SaveChanges();
            RefreshProficiency();
            EditSuccess(proficiencyGridName);
        }
        private void buttonProficiencyDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxProficiencyId))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxProficiencyId.Text);
            _proficiencyService.Remove(id);
            _context.SaveChanges();
            RefreshProficiency();
            RemoveSuccess(proficiencyGridName);
        }
        private void dgv_Proficiency_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                var id = Convert.ToString(row.Cells["Id"].Value);
                var title = Convert.ToString(row.Cells["Title"].Value);
                textBoxProficiencyId.Text = id;
                textBoxProficiencyTitle.Text = title;
            }
        }
        private void RefreshProficiency()
        {
            var proficiencys = _proficiencyService.Get();
            dataGridViewProficiency.DataSource = proficiencys;
        }

        private void AddEducationGrid()
        {
            dataGridViewEducation.ReadOnly = true;
            var educations = _educationService.Get();
            dataGridViewEducation.DataSource = educations;
            dataGridViewEducation.Columns[0].HeaderText = "شناسه";
            dataGridViewEducation.Columns[1].HeaderText = "عنوان";
            dataGridViewEducation.Columns[2].Visible = false;
            dataGridViewEducation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewEducation.SelectionChanged += new EventHandler(dgv_Education_SelectionChanged);
        }
        private void dgv_Education_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                var id = Convert.ToString(row.Cells["Id"].Value);
                var title = Convert.ToString(row.Cells["Title"].Value);
                textBoxEducationId.Text = id;
                textBoxEducationTitle.Text = title;
            }
        }
        private void buttonEducationAdd_Click(object sender, EventArgs e)
        {
            if (!CheckTitleIsFull(textBoxEducationTitle))
            {
                return;
            }
            try
            {
                _educationService.Add(textBoxEducationTitle.Text);
                _context.SaveChanges();
                AddSuccess(educationGridName);
                RefreshEducation();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(educationGridName, add);
            }
        }
        private void buttonEducationEdit_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxEducationId))
            {
                return;
            }
            if (!CheckTitleIsFull(textBoxEducationTitle))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxEducationId.Text);
            var education = _educationService.Get(id);
            education.IsDeleted = 1;
            _educationService.Add(textBoxEducationTitle.Text);

            _context.SaveChanges();
            RefreshEducation();
            EditSuccess(educationGridName);
        }
        private void buttonEducationDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxEducationId))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxEducationId.Text);
            _educationService.Remove(id);
            _context.SaveChanges();
            RefreshEducation();
            RemoveSuccess(educationGridName);
        }
        private void RefreshEducation()
        {
            var educations = _educationService.Get();
            dataGridViewEducation.DataSource = educations;
        }

        private void AddJobGrid()
        {
            dataGridViewJob.ReadOnly = true;
            var jobs = _jobService.Get();
            dataGridViewJob.DataSource = jobs;
            dataGridViewJob.Columns[0].HeaderText = "شناسه";
            dataGridViewJob.Columns[1].HeaderText = "عنوان";
            dataGridViewJob.Columns[2].Visible = false;
            dataGridViewJob.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewJob.SelectionChanged += new EventHandler(dgv_Job_SelectionChanged);
        }
        private void dgv_Job_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                var id = Convert.ToString(row.Cells["Id"].Value);
                var title = Convert.ToString(row.Cells["Title"].Value);
                textBoxJobId.Text = id;
                textBoxJobTitle.Text = title;
            }
        }
        private void buttonJobAdd_Click(object sender, EventArgs e)
        {
            if (!CheckTitleIsFull(textBoxJobTitle))
            {
                return;
            }
            try
            {
                _jobService.Add(textBoxJobTitle.Text);
                _context.SaveChanges();
                AddSuccess(jobGridName);
                RefreshJob();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(jobGridName, add);
            }
        }
        private void buttonJobEdit_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxJobId))
            {
                return;
            }
            if (!CheckTitleIsFull(textBoxJobTitle))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxJobId.Text);
            var job = _jobService.Get(id);
            job.IsDeleted = 1;
            _jobService.Add(textBoxJobTitle.Text);

            _context.SaveChanges();
            RefreshJob();
            EditSuccess(jobGridName);
        }
        private void buttonJobDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxJobId))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxJobId.Text);
            _jobService.Remove(id);
            _context.SaveChanges();
            RefreshJob();
            RemoveSuccess(jobGridName);
        }
        private void RefreshJob()
        {
            var jobs = _jobService.Get();
            dataGridViewJob.DataSource = jobs;
        }

        private void AddOffTypesGrid()
        {
            dataGridViewOffType.ReadOnly = true;
            var offTypes = _offTypeService.Get();
            dataGridViewOffType.DataSource = offTypes;
            dataGridViewOffType.Columns[0].HeaderText = "شناسه";
            dataGridViewOffType.Columns[1].HeaderText = "عنوان";
            dataGridViewOffType.Columns[2].Visible = false;
            dataGridViewOffType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewOffType.SelectionChanged += new EventHandler(dgv_OffType_SelectionChanged);
        }
        private void buttonOffTypeAdd_Click(object sender, EventArgs e)
        {
            if (!CheckTitleIsFull(textBoxOffTypeTitle))
            {
                return;
            }
            try
            {
                _offTypeService.Add(textBoxOffTypeTitle.Text);
                _context.SaveChanges();
                AddSuccess(offTypeGridName);
                RefreshOffType();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(offTypeGridName, add);
            }
        }
        private void buttonOffTypeEdit_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxOffTypeId))
            {
                return;
            }
            if (!CheckTitleIsFull(textBoxOffTypeTitle))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxOffTypeId.Text);
            var offType = _offTypeService.Get(id);
            offType.IsDeleted = 1;
            _offTypeService.Add(textBoxOffTypeTitle.Text);

            _context.SaveChanges();
            RefreshOffType();
            EditSuccess(offTypeGridName);
        }
        private void buttonOffTypeDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxOffTypeId))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxOffTypeId.Text);
            _offTypeService.Remove(id);
            _context.SaveChanges();
            RefreshOffType();
            RemoveSuccess(offTypeGridName);
        }
        private void dgv_OffType_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                var id = Convert.ToString(row.Cells["Id"].Value);
                var title = Convert.ToString(row.Cells["Title"].Value);
                textBoxOffTypeId.Text = id;
                textBoxOffTypeTitle.Text = title;
            }
        }
        private void RefreshOffType()
        {
            var offTypes = _offTypeService.Get();
            dataGridViewOffType.DataSource = offTypes;
        }

        private void AddUserGrid()
        {
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.AllowUserToOrderColumns = true;
            dataGridViewUsers.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            var data = _userService.Get();
            allUsesrs = data;
            var colSettings = _userService.GetColumnSettings();
            dataGridViewUsers.DataSource = data;
            foreach (DataGridViewColumn col in dataGridViewUsers.Columns)
            {
                col.Visible = false;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
                var columnSetting = colSettings.FirstOrDefault(c => c.ColumnHeader == col.Name.ToString());
                if (columnSetting != null && columnSetting.Show)
                {
                    col.Visible = columnSetting.Show;
                    col.HeaderText = columnSetting.ColumnName;                    
                }
            }
            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUsers.SelectionChanged += new EventHandler(dgv_User_SelectionChanged);
        }
        private void buttonRefreshUserGrid_Click(object sender, EventArgs e)
        {
            RefreshUserGrid();
        }
        private void buttonRemoveUser_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            if (IsUserSelected(idString))
            {
                _userService.Remove(Convert.ToInt32(idString));
                _context.SaveChanges();
                MessageBox.Show("حذف با موفقیت انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshUserGrid();
            }
        }       
        public void RefreshUserGrid()
        {
            var users = _userService.Get();
            allUsesrs = users;
            dataGridViewUsers.DataSource = users;
        }
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            var userAddEditForm = new UserAddEdit(null, this);
            userAddEditForm.ShowDialog(this);
            userAddEditForm.Dispose();
        }

        private void buttonViewUser_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            ViewUser(idString);
        }
        private void dataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dataGridViewUsers.Rows[e.RowIndex].Cells[0].Value.ToString();
            ViewUser(cellValue);
        }
        private void ViewUser(string userId)
        {
            if (IsUserSelected(userId))
            {
                var userAddEditForm = new UserAddEdit(Convert.ToInt32(userId), this, true);
                userAddEditForm.ShowDialog(this);
                userAddEditForm.Dispose();
            }
        }

        private void dataGridViewUsers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var data = allUsesrs;
            if (sortUserGridAscending)
            {
                dataGridViewUsers.DataSource = data.OrderBy(dataGridViewUsers.Columns[e.ColumnIndex].DataPropertyName).ToList();
            }
            else
            {
                dataGridViewUsers.DataSource = data.OrderBy(dataGridViewUsers.Columns[e.ColumnIndex].DataPropertyName).Reverse().ToList();
                
            }
            sortUserGridAscending = !sortUserGridAscending;
        }

        private void buttonMigrate_Click(object sender, EventArgs e)
        {
            AddAccountColumns();
        }
        private void AddAccountColumns()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["armsDb"].ConnectionString;
                using (var con = new SQLiteConnection(cs))
                {
                    con.Open();
                    using (var cmd = new SQLiteCommand(con))
                    {
                        try
                        {
                            cmd.CommandText = "ALTER TABLE User ADD COLUMN Sepah TEXT NOT NULL default ''";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "ALTER TABLE User ADD COLUMN Hekmat TEXT NOT NULL default ''";
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تغییرات ستونها و جداول با موفقیت انجام شد");
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        //Loan
                        try
                        {
                            cmd.CommandText = @"CREATE TABLE ""Loan"" ( 'Id' INTEGER NOT NULL, 'Code' TEXT NOT NULL, 'UserTitle' TEXT NOT NULL, 'PersonnelId' TEXT NOT NULL, 'Amount' INTEGER NOT NULL, 'DayRegister' TEXT NOT NULL, 'DayReceive' TEXT NOT NULL, 'Description' TEXT NOT NULL, 'IsDeleted' INTEGER NOT NULL, PRIMARY KEY('Id') )";
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تغییرات ستونها و جداول با موفقیت انجام شد");
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        //
                        //Tanbihi Tashviqi
                        try
                        {
                            cmd.CommandText = @"CREATE TABLE ""TanbihiTashviqi"" ( 'Id' INTEGER NOT NULL, 'UserTitle' TEXT NOT NULL, 'PersonnelId' TEXT NOT NULL, 'AmrieCode' TEXT NOT NULL, 'AmrieDay' TEXT NOT NULL, 'Description' TEXT NOT NULL, 'IsUsed' INTEGER NOT NULL, 'IsTanbihi' INTEGER NOT NULL, 'IsDeleted' INTEGER NOT NULL, PRIMARY KEY('Id') )";
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("تغییرات ستونها و جداول با موفقیت انجام شد");
                        }
                        catch (SQLiteException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا در اجرای کوئری");
            }
        }

        private void buttonLoadRegister_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            if (IsUserSelected(idString))
            {
                var user = _userService.Get(Convert.ToInt32(idString));
                var loanForm = new LoanForm(user);
                loanForm.ShowDialog(this);
                loanForm.Dispose();
            }
        }

        private void buttonTanbihi_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            if (IsUserSelected(idString))
            {
                var user = _userService.Get(Convert.ToInt32(idString));
                var loanForm = new TashviqiTanbihiForm(user,true);
                loanForm.ShowDialog(this);
                loanForm.Dispose();
            }
        }

        private void buttonTashviqi_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            if (IsUserSelected(idString))
            {
                var user = _userService.Get(Convert.ToInt32(idString));
                var loanForm = new TashviqiTanbihiForm(user, false);
                loanForm.ShowDialog(this);
                loanForm.Dispose();
            }
        }

        private void tabPageLoan_MouseEnter(object sender, EventArgs e)
        {
           
        }
        private void tabPageLoan_Enter(object sender, EventArgs e)
        {
            AddLoanGrid();
        }
        private void AddLoanGrid()
        {
            dataGridViewLoanList.ReadOnly = true;
            dataGridViewLoanList.AllowUserToOrderColumns = true;
            dataGridViewLoanList.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridViewLoanList.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            var data = _loanService.Get();
            dataGridViewLoanList.DataSource = data;
            dataGridViewLoanList.Columns[0].HeaderText = "شناسه";
            dataGridViewLoanList.Columns[1].HeaderText = "کد وام";
            dataGridViewLoanList.Columns[2].HeaderText = "نام و نشان";
            dataGridViewLoanList.Columns[3].HeaderText = "کد پرسنلی";
            dataGridViewLoanList.Columns[4].HeaderText = "مبلغ";
            dataGridViewLoanList.Columns[5].HeaderText = "تاریخ ثبت";
            dataGridViewLoanList.Columns[6].HeaderText = "تاریخ دریافت";
            dataGridViewLoanList.Columns[7].HeaderText = "توضیحات";
            dataGridViewLoanList.Columns[8].HeaderText = "حذف شده";

            foreach (DataGridViewColumn col in dataGridViewLoanList.Columns)
            {               
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            dataGridViewLoanList.Columns[0].Visible = false;
            dataGridViewLoanList.Columns[8].Visible = false;

            dataGridViewLoanList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void RefreshLoanGrid()
        {
            dataGridViewLoanList.DataSource = _loanService.Get();
        }

        private void buttonLoanListRefresh_Click(object sender, EventArgs e)
        {
            RefreshLoanGrid();
        }

        private void dataGridViewLoanList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewLoanList.CurrentCell.ColumnIndex==7 && dataGridViewLoanList?.CurrentCell?.Value != null)
            {
                MessageBox.Show(dataGridViewLoanList.CurrentCell.Value.ToString());
            }
        }

        private void tabControlMain_Enter(object sender, EventArgs e)
        {
            AddBadgeGrid();
            AddCoursesGrid();
            AddBanksGrid();
            AddProficiencysGrid();
            AddEducationGrid();
            AddJobGrid();
            AddOffTypesGrid();
        }

        private void tabPageUsers_Enter(object sender, EventArgs e)
        {
            //AddUserGrid();
        }

        private void buttonViewReports_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            if (IsUserSelected(idString))
            {
                var offForm = new OffForm(Convert.ToInt32(idString),_badgeService,_userService,_proficiencyService,_jobService,
                    _offTypeService);
                offForm.ShowDialog(this);
                offForm.Dispose();
            }
        }

        private void buttonWifes_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            var user = _userService.Get(Convert.ToInt32(idString));
            if (IsUserSelected(idString))
            {
                var familyForm = new FamilyForm(user, _context, this);
                familyForm.ShowDialog(this);
                familyForm.Dispose();
            }
        }

        private void buttonChildren_Click(object sender, EventArgs e)
        {
            WillBeAddedSoon();
        }

        private void buttonBankInfo_Click(object sender, EventArgs e)
        {
            WillBeAddedSoon();
        }

        private void buttonEditUser_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            if (IsUserSelected(idString))
            {
                var userAddEditForm = new UserAddEdit(Convert.ToInt32(idString), this);
                userAddEditForm.ShowDialog(this);
                userAddEditForm.Dispose();
            }
        }
        private bool IsUserSelected(string idString)
        {
            if (string.IsNullOrWhiteSpace(idString))
            {
                MessageBox.Show("لطفا روی سطر شخص مد نظر کلیک فرمایید");
                return false;
            }
            return true;
        }      
        private void dgv_User_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                var id = Convert.ToString(row.Cells["Id"].Value);
                textBoxUserId.Text = id;
            }
        }
        public void ShowErrorMessage(string gridName, string section)
        {
            MessageBox.Show($" خطا در جدول مرتبط با {gridName} حین {section} مورد");
        }

        private void buttonManageUserCourse_Click(object sender, EventArgs e)
        {
            var idString = textBoxUserId.Text;
            if (IsUserSelected(idString))
            {
                var user = _userService.Get(Convert.ToInt32(idString));
                var userCourseForm = new UserCourseForm(user);
                userCourseForm.ShowDialog(this);
                userCourseForm.Dispose();
            }
        }


        private void WillBeAddedSoon()
        {
            MessageBox.Show("این بخش به زودی اضافه خواهد شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
    }
}
