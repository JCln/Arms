using Arms.Data;
using Arms.Models;
using Arms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arms.Forms
{
    public partial class UserCourseForm : Form
    {
        private readonly ArmsDbContext _context;
        private IUserCourseService _userCourseService;
        private IUserService _userService;
        private ICourseService _courseService;
        private readonly User _user;
        public UserCourseForm(User user)
        {
            InitializeComponent();
            _context = new ArmsDbContext();
            _userCourseService = new UserCourseService(_context);
            _userService = new UserService(_context);
            _courseService = new CourseService(_context);
            _user = user;
        }
        private void UserCourseForm_Load(object sender, EventArgs e)
        {
            FillItems();
            FillCourseComboBox();
            AddUserCourseGrid();
        }

        private void AddUserCourseGrid()
        {
            dataGridViewUserCourses.ReadOnly = true;
            var userCourses = _userCourseService.Get(_user.NationalId);
            dataGridViewUserCourses.DataSource = userCourses;
            dataGridViewUserCourses.Columns[4].HeaderText = "عنوان دوره";
            dataGridViewUserCourses.Columns[5].HeaderText = "توضیحات";

            dataGridViewUserCourses.Columns[0].Visible = false;
            dataGridViewUserCourses.Columns[1].Visible = false;
            dataGridViewUserCourses.Columns[2].Visible = false;
            dataGridViewUserCourses.Columns[3].Visible = false;
            dataGridViewUserCourses.Columns[6].Visible = false;
            dataGridViewUserCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUserCourses.SelectionChanged += new EventHandler(dgv_UserCourse_SelectionChanged);
        }
        private void dgv_UserCourse_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                textBoxUserCourseId.Text = Convert.ToString(row.Cells["Id"].Value);
                richTextBoxDescription.Text = Convert.ToString(row.Cells["Description"].Value); 
                comboBoxCourse.SelectedValue= row.Cells["CourseId"].Value;
            }
        }
        public void RefreshUserCourseGrid()
        {
            var userCourses = _userCourseService.Get(_user.NationalId);
            dataGridViewUserCourses.DataSource = userCourses;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var userCourse = new UserCourse()
                {
                    CourseId = Convert.ToInt32(comboBoxCourse.SelectedValue),
                    CourseTitle = comboBoxCourse.Text,
                    Description = richTextBoxDescription.Text,
                    IsDeleted = 0,
                    Id = 0,
                    UserId = _user.Id,
                    NationalId=_user.NationalId
                };
                _userCourseService.Add(userCourse);
                _context.SaveChanges();
                MessageBox.Show("افزودن دوره برای ایشان انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshUserCourseGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FillCourseComboBox()
        {
            var userCourses = _courseService.Get();
            comboBoxCourse.DataSource = userCourses;
            comboBoxCourse.DisplayMember = "Title";
            comboBoxCourse.ValueMember = "Id";
        }
        private void FillItems()
        {            
            textBoxFirstName.Text = _user.FirstName;
            textBoxSureName.Text = _user.SureName;
            textBoxPersonnelCode.Text = _user.PersonnelId;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserCourseId.Text))
            {
                MessageBox.Show("لطفا ابتدا روی سطر مد نظر خود کلیک فرمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var preCourse = _userCourseService.Get(Convert.ToInt32(textBoxUserCourseId.Text));
                    preCourse.IsDeleted = 1;
                    var userCourse = new UserCourse()
                    {
                        CourseId = Convert.ToInt32(comboBoxCourse.SelectedValue),
                        CourseTitle = comboBoxCourse.Text,
                        Description = richTextBoxDescription.Text,
                        IsDeleted = 0,
                        Id = 0,
                        UserId = _user.Id,
                        NationalId=_user.NationalId
                    };
                    _userCourseService.Add(userCourse);
                    _context.SaveChanges();
                    MessageBox.Show("ویرایش دوره انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUserCourseGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserCourseId.Text))
            {
                MessageBox.Show("لطفا ابتدا روی سطر مد نظر خود کلیک فرمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var preCourse = _userCourseService.Get(Convert.ToInt32(textBoxUserCourseId.Text));
                    preCourse.IsDeleted = 1;
                    _context.SaveChanges();
                    MessageBox.Show("حذف دوره انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUserCourseGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
