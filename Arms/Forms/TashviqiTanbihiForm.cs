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
    public partial class TashviqiTanbihiForm : Form
    {
        private readonly User _user;
        private readonly ArmsDbContext _context;
        private IUserService _userService;
        private ITanbihiTashviqiService _tashviqiTanbihiService;
        private readonly bool _isTanbihi;
        public TashviqiTanbihiForm(User user, bool isTanbihi)
        {
            InitializeComponent();
            _context = new ArmsDbContext();
            _userService = new UserService(_context);
            _tashviqiTanbihiService = new TanbihiTashviqiService(_context);
            _user = user;
            _isTanbihi = isTanbihi;
            FillItems();
        }
        private void FillItems()
        {
            textBoxFirstName.Text = _user.FirstName;
            textBoxSureName.Text = _user.SureName;
            textBoxPersonnelCode.Text = _user.PersonnelId;
            checkBoxIsUsed.Visible = !_isTanbihi;
            this.Text = _isTanbihi ? "فرم ثبت تنبیهی" : "فرم ثبت تشویقی";
            textBoxFirstName.BackColor = _isTanbihi ? Color.PaleVioletRed : Color.LightGreen;
            textBoxSureName.BackColor = _isTanbihi ? Color.PaleVioletRed : Color.LightGreen;
            textBoxPersonnelCode.BackColor = _isTanbihi ? Color.PaleVioletRed : Color.LightGreen;

            AddTashTanGrid();
        }

        private void AddTashTanGrid()
        {
            dataGridViewTashviqiTanbihi.ReadOnly = true;
            var tashTans = _tashviqiTanbihiService.Get(_user.PersonnelId, _isTanbihi);
            dataGridViewTashviqiTanbihi.DataSource = tashTans;
            dataGridViewTashviqiTanbihi.Columns[3].HeaderText = "کد امریه";
            dataGridViewTashviqiTanbihi.Columns[4].HeaderText = "تاریخ امریه";
            dataGridViewTashviqiTanbihi.Columns[5].HeaderText = "توضیحات";


            dataGridViewTashviqiTanbihi.Columns[0].Visible = false;
            dataGridViewTashviqiTanbihi.Columns[1].Visible = false;
            dataGridViewTashviqiTanbihi.Columns[2].Visible = false;
            dataGridViewTashviqiTanbihi.Columns[6].Visible = false;
            dataGridViewTashviqiTanbihi.Columns[7].Visible = false;
            dataGridViewTashviqiTanbihi.Columns[8].Visible = false;
            dataGridViewTashviqiTanbihi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTashviqiTanbihi.SelectionChanged += new EventHandler(dgv_TashTan_SelectionChanged);
        }
        private void dgv_TashTan_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                textBoxUserTashTand.Text = Convert.ToString(row.Cells["Id"].Value);
                richTextBoxDescription.Text = Convert.ToString(row.Cells["Description"].Value);
                textBoxAmrieInfo.Text = Convert.ToString(row.Cells["AmrieCode"].Value);
                textBoxAmrieDay.Text = Convert.ToString(row.Cells["AmrieDay"].Value);
                checkBoxIsUsed.Checked = Convert.ToBoolean(row.Cells["IsUsed"].Value);
            }
        }
        public void RefreshGrid()
        {
            var tashTans = _tashviqiTanbihiService.Get(_user.PersonnelId,_isTanbihi);
            dataGridViewTashviqiTanbihi.DataSource = tashTans;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var tashTan = CreateTashTan();
                _tashviqiTanbihiService.Add(tashTan);
                _context.SaveChanges();
                var tashTanText = _isTanbihi ? "تنبیهی" : "تشویقی";
                MessageBox.Show($"افزودن {tashTanText} برای ایشان انجام شد",
                    "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserTashTand.Text))
            {
                MessageBox.Show("لطفا ابتدا روی سطر مد نظر خود کلیک فرمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var preTashTan = _tashviqiTanbihiService.Get(Convert.ToInt32(textBoxUserTashTand.Text));
                    preTashTan.IsDeleted = 1;
                    var tashTan = CreateTashTan();
                    _tashviqiTanbihiService.Add(tashTan);
                    _context.SaveChanges();
                    var tashTanText = _isTanbihi ? "تنبیهی" : "تشویقی";
                    MessageBox.Show($"ویرایش {tashTanText} انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserTashTand.Text))
            {
                MessageBox.Show("لطفا ابتدا روی سطر مد نظر خود کلیک فرمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var preTashTan = _tashviqiTanbihiService.Get(Convert.ToInt32(textBoxUserTashTand.Text));
                    preTashTan.IsDeleted = 1;
                    _context.SaveChanges();
                    var tashTanText = _isTanbihi ? "تنبیهی" : "تشویقی";
                    MessageBox.Show($"حذف {tashTanText} انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private TanbihiTashviqi CreateTashTan()
        {
            var tashTan = new TanbihiTashviqi()
            {
                Description = richTextBoxDescription.Text,
                PersonnelId = textBoxPersonnelCode.Text,
                UserTitle = textBoxFirstName.Text + " " + textBoxSureName.Text,
                AmrieCode = textBoxAmrieInfo.Text,
                AmrieDay = textBoxAmrieDay.Text,
                IsTanbihi = _isTanbihi?1:0 ,
                IsUsed= checkBoxIsUsed.Checked ? 1 : 0                
            };
            return tashTan;
        }
    }
}
