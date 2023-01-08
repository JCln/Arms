using Arms.Data;
using Arms.Models;
using Arms.Services;
using System;
using System.Windows.Forms;

namespace Arms.Forms
{
    public partial class FamilyForm : Form
    {
        string userFamilyGrid = "عائله تحت تکفل";
        private ArmsDbContext _context;
        private IUserFamilyService _userFamilyService;
        private User _user;
        private MasterForm _parentForm;
        public FamilyForm(User user, ArmsDbContext context, MasterForm masterForm)
        {
            InitializeComponent();
            _context = context;
            _userFamilyService = new UserFamilyService(_context);
            _user = user;
            _parentForm = masterForm;
        }

        private void AddUserFamilyGrid()
        {
            dataGridViewUserFamily.ReadOnly = true;
            var userFamilies = _userFamilyService.Get(_user.NationalId);
            dataGridViewUserFamily.DataSource = userFamilies;
            dataGridViewUserFamily.Columns[0].HeaderText = "شناسه";
            dataGridViewUserFamily.Columns[1].Visible = false;
            dataGridViewUserFamily.Columns[2].Visible = false;
            dataGridViewUserFamily.Columns[3].HeaderText = "کد ملی";
            dataGridViewUserFamily.Columns[4].HeaderText = "نام و نشان";
            dataGridViewUserFamily.Columns[5].Visible = false;
            dataGridViewUserFamily.Columns[6].HeaderText = "نسبت";
            dataGridViewUserFamily.Columns[7].Visible = false;
            dataGridViewUserFamily.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewUserFamily.SelectionChanged += new EventHandler(dgv_UserFamily_SelectionChanged);
        }
        private void dgv_UserFamily_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                textBoxUserFamilyId.Text = Convert.ToString(row.Cells["Id"].Value);
                textBoxNationalId.Text = Convert.ToString(row.Cells["NationalId"].Value);
                textBoxFirstSureName.Text = Convert.ToString(row.Cells["FirstSureName"].Value);
                var ralationId= Convert.ToInt32(row.Cells["RelationId"].Value);
                comboBoxRelation.SelectedValue = ralationId;
            }
        }
        private void buttonUserFamilyAdd_Click(object sender, EventArgs e)
        {
            if (!CheckItemIsFull(textBoxFirstSureName,"نام و نشان"))
            {
                return;
            }
            if (!CheckItemIsFull(textBoxNationalId, "کد ملی"))
            {
                return;
            }            
            try
            {
                var userFamily = CreateUserFamily();
                _userFamilyService.Add(userFamily);
                _context.SaveChanges();
                _parentForm.AddSuccess(userFamilyGrid);
                RefreshUserFamily();
            }
            catch (Exception ex)
            {
               _parentForm.ShowErrorMessage(userFamilyGrid, "افزودن");
            }
        }
        private void buttonUserFamilyEdit_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxUserFamilyId))
            {
                return;
            }
            if (!CheckItemIsFull(textBoxFirstSureName, "نام و نشان"))
            {
                return;
            }
            if (!CheckItemIsFull(textBoxNationalId, "کد ملی"))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxUserFamilyId.Text);
            var userFamily = _userFamilyService.Get(id);
            userFamily.IsDeleted = 1;
            var newUserFamily = CreateUserFamily();
            _userFamilyService.Add(newUserFamily);

            _context.SaveChanges();
            RefreshUserFamily();
            _parentForm.EditSuccess(userFamilyGrid);
        }
        private void buttonUserFamilyDelete_Click(object sender, EventArgs e)
        {
            if (!CheckIdIsFull(textBoxUserFamilyId))
            {
                return;
            }
            var id = Convert.ToInt32(textBoxUserFamilyId.Text);
            _userFamilyService.Remove(id);
            _context.SaveChanges();
            RefreshUserFamily();
            _parentForm.RemoveSuccess(userFamilyGrid);
        }
        private void RefreshUserFamily()
        {
            var userFamilies = _userFamilyService.Get();
            dataGridViewUserFamily.DataSource = userFamilies;
        }

        private UserFamily CreateUserFamily()
        {
            var userFamily = new UserFamily
            {
                FirstSureName = textBoxFirstSureName.Text,
                NationalId=textBoxNationalId.Text,
                RelationId=Convert.ToInt32(comboBoxRelation.SelectedValue),
                RelationTitle=comboBoxRelation.Text,
                UserId=_user.Id,
                UserNationalId=_user.NationalId,
                IsDeleted=0
            };
            return userFamily;
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
        private bool CheckItemIsFull(TextBox textBox,string itemTitle)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show($"لطفا {itemTitle} را وارد فرمایید");
                return false;
            }
            return true;
        }

        private void FamilyForm_Load(object sender, EventArgs e)
        {
            labelUserId.Text = _user.Id.ToString();
            labelUserFirstSureName.Text = _user.FirstName + " " + _user.SureName;
            labelNationalId.Text = _user.NationalId;
            var relationComboItems = new[]
            {
                new {Title="همسر",Id=1 },
                new {Title="فرزند دختر",Id=2 },
                new {Title="فرزند پسر",Id=3 },
                new {Title="مادر",Id=4 },
                new {Title="پدر",Id=5 },
            };
            comboBoxRelation.DataSource = relationComboItems;
            comboBoxRelation.DisplayMember = "Title";
            comboBoxRelation.ValueMember = "Id";
            AddUserFamilyGrid();
        }
    }
}
