

namespace Bai13.Employees
{
    class FresherEmployee : Employee
    {
        public string GraduationDate { get; set; }
        public string University { get; set; }
        public string GraduationRank { get; set; }
        public FresherEmployee(int Id, string Name, string Email, string Phone, string DOB, EmployeeType EmployeeType,
                                string GraduationDate,string University, string GraduationRank)
            : base(Id, Name, Email, Phone, DOB, EmployeeType)
        {
            this.GraduationDate = GraduationDate;
            this.University = University;
            this.GraduationRank = GraduationRank;
        }

        public override string ToString()
        {
            return base.ToString() + $"University: {University}, Graduation Date: {GraduationDate}, Graduation Rank: {GraduationRank}";
        }
        public override string ShowMyInfo()
        {
            return ToString() ;
        }
    }
}
