
using Bai13.Certificates;


namespace Bai13.Employees
{
    
    abstract class Employee
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DOB { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public static int EmployeeCount = 0;

        private List<Certificate> certs;
        
        public Employee(int Id, string Name, string Email, string Phone, string DOB,EmployeeType EmployeeType) {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.DOB = DOB;
            this.EmployeeType = EmployeeType;
            EmployeeCount++;
            certs = new List<Certificate>();
        }
        public override string ToString()
        {
            return $"Employee: {Name}, Id: {Id}, Phone number: {Phone}, Email: {Email}, DOB: {DOB}, Employee Type: {EmployeeType}";
        }
        public abstract string ShowMyInfo();

        public List<Certificate> GetCerts()
        {
            return certs;
        }
        public void AddCert(Certificate cert)
        {
            certs.Add(cert);
        }
        
    }
}
