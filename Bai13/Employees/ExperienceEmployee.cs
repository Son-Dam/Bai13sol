using Bai13.Certificates;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;

namespace Bai13.Employees
{
    internal class ExperienceEmployee : Employee
    {
        public int YearofExp { get; set; }
        public string ProSkill { get; set; }
        public ExperienceEmployee(int Id, string Name, string Email, string Phone, string DOB,EmployeeType employeeType, int yearofExp, string proSkill) : base(Id, Name, Email, Phone, DOB,employeeType)
        {
            YearofExp = yearofExp;
            ProSkill = proSkill;
        }

        public override string ToString()
        {
            return base.ToString() + $"Year of Experience: {YearofExp}, Skill: {ProSkill}";
        }
        
        public override string ShowMyInfo()
        {
            return ToString();
        }
    }
}
