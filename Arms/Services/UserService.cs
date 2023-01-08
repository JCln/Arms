using Arms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Arms.Dtos;
using System.Data.Entity;
using Arms.Data;
using DNTPersianUtils.Core;

namespace Arms.Services
{
    public interface IUserService
    {
        ICollection<User> Get();
        User Get(int id);
        void Add(User user);
        void Remove(int id);
        ColumnSetting[] GetColumnSettings();
    }
    public class UserService: IUserService
    {
        private readonly DbSet<User> _users;
        private readonly ArmsDbContext _context;

        public UserService(ArmsDbContext context)
        {
            _context = context;
            _users = _context.Users;            
        }   
        public ICollection<User> Get()
        {
            var users= _users.Where(u => u.IsDeleted==0).ToList();
            foreach (var user in users)
            {
                try
                {
                    var elevationGregorianDay = user.LastElevationDate.ToGregorianDateTime();
                    var dayDiff = (DateTime.Now - elevationGregorianDay.Value).TotalDays;
                    if (dayDiff >= 1410)
                    {
                        user.NotifChar = $"{(int)(dayDiff - 1410)} روز ";
                    }
                    else
                    {
                        user.NotifChar = "-";
                    }
                }
                catch
                {
                    user.NotifChar = "X";
                }

            }
            return users;

            return new List<User>()
            {
                new User() {AddedDays=0,BadgeId=1,BadgeTitle="ستوان",BirthDate="1350/01/01",Bounes=10,
                Description="توضیحات یکم",FatherName="مصطفی",FirstName="عباس",SureName="دوران",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=60,
                NationalId="12036599",PersonnelId="123657"},
                new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                 new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="تقی",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="120365100",PersonnelId="123657"
                },
                  new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="کیوان",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                   new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="مهرداد",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="2365",PersonnelId="123657"
                },
                    new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="رضا",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="6589",PersonnelId="123657"
                },
                     new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="",FirstName="نادر",SureName="جهانبانی",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="1365",PersonnelId="123657"
                },
                      new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="6532",PersonnelId="123657"
                },
                       new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="9871",PersonnelId="123657"
                },
                        new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                         new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                          new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                           new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                            new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                             new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                              new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                               new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                 new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                  new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                   new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                    new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                     new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                      new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                       new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
                                        new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },

                                         new User() {
                    AddedDays =0,BadgeId=2,BadgeTitle="سرتیپ",BirthDate="1319/02/19",Bounes=100,
                Description="توضیحات دوم",FatherName="عباس",FirstName="حسن",SureName="آبشناسان",
                Id=1,IsDeleted=0,IsSoldier=0,LastElevationDate="1398/01/12",MonthOfService=600,
                NationalId="12036599",PersonnelId="123657"
                },
            };
        }
        public User Get(int id)
        {
            return _users.First(u => u.Id == id);
        } 
        public void Add(User user)
        {
            _users.Add(user);
        }
        public void Remove(int id)
        {
            var user = Get(id);
            user.IsDeleted = 1;
        }
        public ColumnSetting[] GetColumnSettings()
        {
            var settings = new ColumnSetting[]{
                new ColumnSetting() { ColumnHeader= "Id",ColumnName="شناسه",Order=0,Show=true},
                new ColumnSetting() { ColumnHeader= "AddedDays",ColumnName="اضافه خدمت",Order=1,Show=false},
                new ColumnSetting() { ColumnHeader= "BadgeTitle",ColumnName="درجه",Order=2,Show=true},
                new ColumnSetting() { ColumnHeader= "FirstName",ColumnName="نام",Order=3,Show=true},
                new ColumnSetting() { ColumnHeader= "SureName",ColumnName="نشان",Order=4,Show=true},
                new ColumnSetting() { ColumnHeader= "PersonnelId",ColumnName="کد پرسنلی",Order=5,Show=true},
                new ColumnSetting() { ColumnHeader= "FatherName",ColumnName="نام پدر",Order=6,Show=true},
                new ColumnSetting() { ColumnHeader= "NationalId",ColumnName="کد ملی",Order=7,Show=true},
                new ColumnSetting() { ColumnHeader= "BirthDate",ColumnName="تاریخ تولد",Order=8,Show=true},
                new ColumnSetting() { ColumnHeader= "Bounes",ColumnName="امتیازات",Order=4,Show=false},
                new ColumnSetting() { ColumnHeader= "IsSoldier",ColumnName="سرباز وظیفه",Order=8,Show=false},
                new ColumnSetting() { ColumnHeader= "LastElevationDate",ColumnName="تاریخ آخرین ترفیع",Order=9,Show=false},
                new ColumnSetting() { ColumnHeader= "MonthOfService",ColumnName="مدت خدمت",Order=10,Show=false}, 
                new ColumnSetting() { ColumnHeader= "BadgeId",ColumnName="کد درجه",Order=13,Show=false},
                new ColumnSetting() { ColumnHeader= "Description",ColumnName="توضیحات",Order=14,Show=false},
                new ColumnSetting() { ColumnHeader= "NotifChar",ColumnName="ارتقا",Order=15,Show=true}
            };
            return settings;
        }
    }
}
