using Arms.Data;
using Arms.Dtos;
using Arms.Services;
using Stimulsoft.Base;
using Stimulsoft.Report;
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
using System.Globalization;
using Arms.Constansts;
using Arms.Models;
using System.Configuration;

namespace Arms.Forms
{
    public partial class OffForm : Form
    {       
        private IBadgeService _badgeService;
        private IUserService _userService;
        private IProficiencyService _proficiencyService;
        private IJobService _jobService;
        private IOffTypeService _offTypeService;
        private ICollection<User> _users;
        int janeshinId=-1, farmandeId = -1;

        private StiReport report = new StiReport();
        private int _userId;
        public OffForm(
            int userId,
            IBadgeService badgeService,
            IUserService userService,
            IProficiencyService proficiencyService,
            IJobService jobService,
            IOffTypeService offTypeService)
        {
            InitializeComponent();

            _userId = userId;
            _badgeService = badgeService;
            _userService = userService;
            _proficiencyService = proficiencyService;
            _jobService = jobService;
            _offTypeService = offTypeService;

            StiLicense.Key = StimulsoftUtil.License;
            //report.GlobalizationManager = new StiNullGlobalizationManager("Globalizing_Reports.MyResources",
            //        new CultureInfo(cultureName));
            _users = _userService.Get();
        }

        private void OffForm_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
        }

        private void buttonViewReport_Click(object sender, EventArgs e)
        {
            if(janeshinId<0 || farmandeId < 0)
            {
                MessageBox.Show("لطفا جانشین و فرمانده را انتخاب فرمایید");
                return;
            }
            FillJaneshinAndFarmandeId();
            var user = _users.First(u=>u.Id== _userId);
            var janeshin = _users.First(u => u.Id == janeshinId);
            var farmande = _users.First(u => u.Id == farmandeId);                        

            var offIInput = new OffInput()
            {
                Modat = textBoxModat.Text,
                Address=user.Address,
                BadgeTitle=user.BadgeTitle,
                DayOfPrint= DateTime.Now.ToShortPersianDateString(),
                Destination=textBoxDestination.Text,
                FromDay=textBoxFromDay.Text,
                ModatRaft=textBoxMoatRaft.Text,
                OffType=comboBoxOffType.Text,
                Phone=user.PhoneNumber,
                UsedOff=textBoxUsedDays.Text,
                NameAndFamily=user.FirstName+" "+user.SureName,
                PersonnelCode=user.PersonnelId,
                PresenceDay=textBoxPresenceDay.Text,
                Today = DateTime.Now.ToShortPersianDateString(),
                ProficiencyTitle=user.ProficiencyTitle,
                UnusedOff=textBoxUnUsedDays.Text,
                EdariBadge= ConfigurationManager.AppSettings["EdariBadge"],
                EdariNameAndFamily= ConfigurationManager.AppSettings["EdariNameAndFamily"],
                FarmandeBadge= farmande.BadgeTitle,
                FarmandeNameAndFamily= farmande.FirstName+ " " +farmande.SureName,
                FarmandeSemat= ConfigurationManager.AppSettings["FarmandeSemat"],                
                GoroohBadge = ConfigurationManager.AppSettings["GoroohBadge"],
                GoroohNameAndFamily= ConfigurationManager.AppSettings["GoroohNameAndFamily"],
                GoroohSemat= ConfigurationManager.AppSettings["GoroohSemat"],
                JaneshinBadgeTitle= janeshin.BadgeTitle,
                JaneshinPersonnelCode= janeshin.PersonnelId,
                JaneshinNameAndFamily = janeshin.FirstName + " " + janeshin.SureName,
                JaneshinProficiencyTitle= janeshin.ProficiencyTitle,
                JaneshinYegan= janeshin.LocationOfService,
                NirooEnsaniBadge= ConfigurationManager.AppSettings["NirooEnsaniBadge"],
                NirooEnsaniNameAndFamily= ConfigurationManager.AppSettings["NirooEnsaniNameAndFamily"],
                NirooEnsaniSemat= ConfigurationManager.AppSettings["NirooEnsaniSemat"],
                Serial= textBoxSerial.Text,
                Yegan= user.LocationOfService,
                PayeshPlanDate = checkBoxPayesh.Checked,
                ShootingDate = checkBoxShootingDate.Checked,
                FitnessDate = checkBoxFitnessTest.Checked,

            };
            report.RegBusinessObject("OffIInfo", "OffIInfo", offIInput);
            report.Load("Reports\\off.mrt");
            report.Show();
        }

        private void FillComboBoxes()
        {
            // payesh & shooting & health
            var user = _users.First(u => u.Id == _userId);
            textBoxPayeshPlanDate.Text = user.PayeshPlanDate;
            textBoxShootingTest.Text = user.ShootingDate;
            textBoxFitnessTest.Text = user.FitnessTestDate;

            //offType
            var offTypes = _offTypeService.Get();
            comboBoxOffType.DataSource = offTypes;
            comboBoxOffType.DisplayMember = "Title";
            comboBoxOffType.ValueMember = "Id";

            //janeshin
            var userSummary= _users.Select(u => new ComboBoxSource() { Id = u.Id, Title = u.FirstName + " " + u.SureName }).ToList();
            comboBoxJaneshin.DataSource = userSummary;
            comboBoxJaneshin.DisplayMember = "Title";
            comboBoxJaneshin.ValueMember = "Id";

            //farmandeBadge
            var badges = _badgeService.Get();
            comboBoxFarmandeBadge.DataSource = badges;
            comboBoxFarmandeBadge.DisplayMember = "Title";
            comboBoxFarmandeBadge.ValueMember = "Id";

            try
            {
                janeshinId = userSummary.First().Id;
            }
            catch
            {
                MessageBox.Show("لطفا ابتدا کاربران را تعریف فرمایید");
                this.Close();
            }
        }

        private void comboBoxFarmandeBadge_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedValue = Convert.ToInt32(comboBoxFarmandeBadge.SelectedValue);
            var usersWithBadge = _users.Where(u => u.BadgeId == selectedValue)
                .Select(u=> new ComboBoxSource() { Id=u.Id,Title=u.FirstName+" "+u.SureName}).ToList();
            comboBoxFarmande.DataSource = usersWithBadge;
            comboBoxFarmande.DisplayMember = "Title";
            comboBoxFarmande.ValueMember = "Id";

            try
            {
                farmandeId = usersWithBadge.First().Id;
            }
            catch
            {
                MessageBox.Show("هیچ کاربری با درجه انتخابی شما پیدا نشد");
            }
        }

        private void richTextBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBoxJaneshin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFarmande_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFarmandeBadge_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxIsHardToCure_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FillJaneshinAndFarmandeId()
        {
            janeshinId = Convert.ToInt32(comboBoxJaneshin.SelectedValue);
            farmandeId = Convert.ToInt32(comboBoxFarmande.SelectedValue);
        }
    }
}
