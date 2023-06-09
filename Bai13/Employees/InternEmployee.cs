

namespace Bai13.Employees
{
    class InternEmployee : Employee
    {
        public string Major { get; set; }
        public string UnderGraduateYear { get; set; }
        public string University { get; set; }
        public InternEmployee(int Id, string Name, string Email, string Phone, string DOB, EmployeeType EmployeeType, string major, string undergraduateYear, string university) : base(Id, Name, Email, Phone, DOB, EmployeeType)
        {
            Major = major;
            UnderGraduateYear = undergraduateYear;
            University = university;
        }

        public override string ToString()
        {
            return base.ToString() + $"Major: {Major}, Undergraduate Year: {UnderGraduateYear}, University: {University}" ;
        }
        public override string ShowMyInfo()
        {
            return ToString();
        }
    }
}
