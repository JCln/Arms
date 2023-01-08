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
    public partial class LoanForm : Form
    {
        private readonly ArmsDbContext _context;
        private ILoanService _loanService;
        private IUserService _userService;
        private readonly User _user;

        public LoanForm(User user)
        {
            InitializeComponent();
            _context = new ArmsDbContext();
            _userService = new UserService(_context);
            _loanService = new LoanService(_context);
            _user = user;
        }
        private void LoanForm_Load(object sender, EventArgs e)
        {
            FillItems();
            AddLoansGrid();
        }

        private void FillItems()
        {
            textBoxFirstName.Text = _user.FirstName;
            textBoxSureName.Text = _user.SureName;
            textBoxPersonnelCode.Text = _user.PersonnelId;
        }
        private void AddLoansGrid()
        {
            dataGridViewLoans.ReadOnly = true;
            var loans = _loanService.Get(_user.PersonnelId);
            dataGridViewLoans.DataSource = loans;
            dataGridViewLoans.Columns[0].HeaderText = "شناسه";
            dataGridViewLoans.Columns[1].HeaderText = "کد وام";
            dataGridViewLoans.Columns[4].HeaderText = "مبلغ";
            dataGridViewLoans.Columns[5].HeaderText = "تاریخ ثبت";
            dataGridViewLoans.Columns[6].HeaderText = "تاریخ دریافت";

            dataGridViewLoans.Columns[2].Visible = false;
            dataGridViewLoans.Columns[3].Visible = false;
            dataGridViewLoans.Columns[7].Visible = false;
            dataGridViewLoans.Columns[8].Visible = false;
            dataGridViewLoans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLoans.SelectionChanged += new EventHandler(dgv_Loan_SelectionChanged);
        }
        private void dgv_Loan_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dvg = (DataGridView)sender;
            if (dvg.Rows.Count >= 0 && dvg.CurrentCell.RowIndex >= 0)
            {
                int index = dvg.CurrentCell.RowIndex;

                DataGridViewRow row = dvg.Rows[index];
                textBoxUserLoanId.Text = Convert.ToString(row.Cells["Id"].Value);
                richTextBoxDescription.Text = Convert.ToString(row.Cells["Description"].Value);
                textBoxAmount.Text = Convert.ToString(row.Cells["Amount"].Value);
                textBoxDayReceive.Text = Convert.ToString(row.Cells["DayReceive"].Value);
                textBoxDayRegister.Text = Convert.ToString(row.Cells["DayRegister"].Value);
                textBoxCode.Text = Convert.ToString(row.Cells["Code"].Value);
            }
        }
        public void RefreshLoanGrid()
        {
            var loans = _loanService.Get(_user.PersonnelId);
            dataGridViewLoans.DataSource = loans;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var loan = CreateLoan();
                _loanService.Add(loan);
                _context.SaveChanges();
                MessageBox.Show("افزودن وام برای ایشان انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshLoanGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserLoanId.Text))
            {
                MessageBox.Show("لطفا ابتدا روی سطر مد نظر خود کلیک فرمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var preLoan = _loanService.Get(Convert.ToInt32(textBoxUserLoanId.Text));
                    preLoan.IsDeleted = 1;
                    var loan = CreateLoan();
                    _loanService.Add(loan);
                    _context.SaveChanges();
                    MessageBox.Show("ویرایش وام انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshLoanGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxUserLoanId.Text))
            {
                MessageBox.Show("لطفا ابتدا روی سطر مد نظر خود کلیک فرمایید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var preCourse = _loanService.Get(Convert.ToInt32(textBoxUserLoanId.Text));
                    preCourse.IsDeleted = 1;
                    _context.SaveChanges();
                    MessageBox.Show("حذف وام انجام شد", "انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshLoanGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private Loan CreateLoan()
        {
            var loan = new Loan()
            {
                Amount = Convert.ToInt32(textBoxAmount.Text),
                Code = textBoxCode.Text,
                DayReceive = textBoxDayReceive.Text,
                DayRegister = textBoxDayRegister.Text,
                Description = richTextBoxDescription.Text,
                PersonnelId = textBoxPersonnelCode.Text,
                UserTitle = textBoxFirstName.Text + " " + textBoxSureName.Text
            };
            return loan;
        }
    }
}
 