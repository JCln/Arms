using Arms.Data;
using Arms.Models;
using Arms.Services;
using System;
using System.Windows.Forms;
using DNTPersianUtils.Core;

namespace Arms.Forms
{
    public partial class UserAddEdit : Form
    {
        private readonly ArmsDbContext _context;
        private IBadgeService _badgeService;
        private IUserService _userService;
        private IEducationService _educationService;
        private IProficiencyService _proficiencyService;
        private IJobService _jobService;
        private readonly int? _userId;
        private MasterForm _parentForm { get; }
        bool _isReadOnly;
        public UserAddEdit(int? userId, MasterForm masterForm, bool isReadOnly=false)
        {
            InitializeComponent();
            _context = new ArmsDbContext();
            _badgeService = new BadgeService(_context);
            _userService = new UserService(_context);
            _educationService = new EducationService(_context);
            _proficiencyService = new ProficiencyService(_context);
            _jobService = new JobService(_context);
            _userId = userId;
            _parentForm = masterForm;
            _isReadOnly = isReadOnly;
        }

        private void UserAddEdit_Load(object sender, EventArgs e)
        {
            FillAllComboBoxes();
            FillIsAddOrEditItems();
            this.maskedTextBoxEnteranceDate.LostFocus += new EventHandler(this.EnteranceDate_LostFocus);
        }
        private void FillIsAddOrEditItems()
        {
            if (_userId.HasValue)
            {
                var user = _userService.Get(_userId.Value);
                labelIsAddOrEdit.Text = "(ویرایش کاربر)";
                textBoxUserName.Text = user.FirstName;
                textBoxUserNeshan.Text = user.SureName;
                textBoxUserFatherName.Text = user.FatherName;
                maskedTextBoxUserNationalCode.Text = user.NationalId;
                maskedTextBoxUserPersonnelCode.Text = user.PersonnelId;
                maskedTextBoxUserBirthday.Text = user.BirthDate;
                maskedTextBoxElevationDay.Text = user.LastElevationDate;
                //badge
                maskedTextBoxMonthOfService.Text = GetMonthOfServiceString(user.MonthOfService);
                maskedTextBoxAddedDays.Text = user.AddedDays.ToString();
                maskedTextBoxBounce.Text = user.Bounes.ToString();
                checkBoxIsSoldier.Checked = user.IsSoldier > 0;
                richTextBoxDescription.Text = user.Description;

                richTextBoxAddress.Text = user.Address;
                maskedTextBoxEnteranceDate.Text = user.EnteranceDate;
                textBoxUserIdCode.Text = user.IdCode;
                textBoxUserIdFrom.Text = user.IdFrom;
                checkBoxIsHardToCure.Checked = user.IsHardToCure > 0;
                checkBoxIsMartyrFamily.Checked = user.IsMartyrFamily > 0;
                checkBoxIsUncurable.Checked = user.IsUncurable > 0;
                textBoxUserLocationOfService.Text = user.LocationOfService;
                maskedTextBoxMobile.Text = user.Mobile;
                maskedTextBoxUserPhoneNumber.Text = user.PhoneNumber;
                textBoxUserSickness.Text = user.Sickness;

                comboBoxBadges.SelectedValue = user.BadgeId;
                comboBoxUserJob.SelectedValue = user.JobId;
                comboBoxUserProficiency.SelectedValue = user.ProficiencyId;
                comboBoxUserEducation.SelectedValue = user.EducationId;

                textBoxSepah.Text = user.Sepah;
                textBoxHekmat.Text = user.Hekmat;
                maskedTextBoxPayeshPlanDate.Text = user.PayeshPlanDate;
                maskedTextBoxShootingDate.Text = user.ShootingDate;
                maskedTextBoxFitnessTestDate.Text = user.FitnessTestDate;
            }
            else
            {
                labelIsAddOrEdit.Text = "(افزودن کاربر)";
            }

            if (_isReadOnly)
            {
                buttonDoAddOrEditUser.Hide();
                labelIsAddOrEdit.Text = "(نمایش کاربر)";
            }
        }
        private void FillAllComboBoxes()
        {
            //badge
            var badges = _badgeService.Get();
            comboBoxBadges.DataSource = badges;
            comboBoxBadges.DisplayMember = "Title";
            comboBoxBadges.ValueMember = "Id";

            //education
            var educations = _educationService.Get();
            comboBoxUserEducation.DataSource = educations;
            comboBoxUserEducation.DisplayMember = "Title";
            comboBoxUserEducation.ValueMember = "Id";

            //job
            var jobs = _jobService.Get();
            comboBoxUserJob.DataSource = jobs;
            comboBoxUserJob.DisplayMember = "Title";
            comboBoxUserJob.ValueMember = "Id";

            //proficiency
            var proficienies = _proficiencyService.Get();
            comboBoxUserProficiency.DataSource = proficienies;
            comboBoxUserProficiency.DisplayMember = "Title";
            comboBoxUserProficiency.ValueMember = "Id";
        }
        private void DoAddOrEdit()
        {
            try
            {
                if (_userId.HasValue)
                {
                    var user = CreateUser();
                    _userService.Remove(_userId.Value);                   
                    _userService.Add(user);
                    _context.SaveChanges();
                }
                else
                {
                    var user = CreateUser();
                    _userService.Add(user);
                    _context.SaveChanges();
                }
                var message = _userId.HasValue ? "ویرایش با موفقیت انجام شد" : "افزودن با موفقیت انجام شد";
                MessageBox.Show(message, "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _parentForm.RefreshUserGrid();
                this.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private User CreateUser()
        {
            var user = new User()
            {
                //AddedDays = Convert.ToInt32(maskedTextBoxAddedDays.Text),
                BadgeId = Convert.ToInt32(comboBoxBadges.SelectedValue),
                BadgeTitle = comboBoxBadges.Text,
                BirthDate = maskedTextBoxUserBirthday.Text,
                //Bounes = Convert.ToInt32(maskedTextBoxBounce.Text),
                Description = richTextBoxDescription.Text,
                FatherName = textBoxUserFatherName.Text,
                FirstName = textBoxUserName.Text,
                Id = 0,
                IsDeleted = 0,
                IsSoldier = checkBoxIsSoldier.Checked ? 1 : 0,
                LastElevationDate = maskedTextBoxElevationDay.Text,
                MonthOfService = GetMonthOfService(),
                NationalId = maskedTextBoxUserNationalCode.Text,
                PersonnelId = maskedTextBoxUserPersonnelCode.Text,
                SureName = textBoxUserNeshan.Text,
                Address=richTextBoxAddress.Text,
                EducationId=Convert.ToInt32(comboBoxUserEducation.SelectedValue),
                EducationTitle=comboBoxUserEducation.Text,
                EnteranceDate=maskedTextBoxEnteranceDate.Text,
                IdCode= textBoxUserIdCode.Text,
                IdFrom=textBoxUserIdFrom.Text,
                IsHardToCure=checkBoxIsHardToCure.Checked?1:0,
                IsMartyrFamily=checkBoxIsMartyrFamily.Checked?1:0,
                IsUncurable=checkBoxIsUncurable.Checked?1:0,
                JobId=Convert.ToInt32(comboBoxUserJob.SelectedValue),
                JobTitle=comboBoxUserJob.Text,
                LocationOfService=textBoxUserLocationOfService.Text,
                Mobile=maskedTextBoxMobile.Text,
                PhoneNumber=maskedTextBoxUserPhoneNumber.Text,
                ProficiencyId=Convert.ToInt32(comboBoxUserProficiency.SelectedValue),
                ProficiencyTitle=comboBoxUserProficiency.Text,
                Sickness=textBoxUserSickness.Text,
                Sepah=textBoxSepah.Text,
                Hekmat=textBoxHekmat.Text,
                PayeshPlanDate = maskedTextBoxPayeshPlanDate.Text,
                FitnessTestDate = maskedTextBoxFitnessTestDate.Text,
                ShootingDate = maskedTextBoxShootingDate.Text,
            };
            return user;
        }

        private void buttonDoAddOrEditUser_Click(object sender, EventArgs e)
        {
            DoAddOrEdit();
        }
        private int GetMonthOfService()
        {
            try
            {
                var enteranceDay = maskedTextBoxEnteranceDate.Text.ToGregorianDateTime().Value;
                var daysOfService = (DateTime.Now - enteranceDay).Days;
                return daysOfService;
            }
            catch 
            {
                MessageBox.Show("سیستم قادر به محاسبه مدت خدمت نیست، لطفا تاریخ ورود را دقیق وارد فرمایید");
                return 0;
            }
        } 
        private string GetMonthOfServiceString(int daysOfService)
        {
            var years = Math.Truncate((float)daysOfService / 365);
            var months = Math.Truncate(((float)daysOfService % 365) / 30);
            var days = Math.Truncate(((float)daysOfService % 365) % 30);
            return $"{years} سال و {months} ماه و {days} روز";
        }
        private void EnteranceDate_LostFocus(object sender, EventArgs e)
        {
            var totalDays = GetMonthOfService();
            maskedTextBoxMonthOfService.Text = GetMonthOfServiceString(totalDays);
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBoxShootingDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBoxFitnessTestDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
