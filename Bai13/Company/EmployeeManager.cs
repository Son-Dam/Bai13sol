

using Bai13.Employees;
using Bai13.Enums;
using Bai13.Exceptions;

using System.Globalization;
using System.Net.Mail;

namespace Bai13.Company
{
    class EmployeeManager
    {
        public delegate void ValidateFuncString(string input, out string output);
        public delegate void ValidateFuncInt(string input, out int output);
        
        
        public List<Employee> Employees;
        public EmployeeManager() 
        {
            Employees = new List<Employee>(); 
        }
        
        public void Run()
        {
            Console.WriteLine("Hello, this is the employee manager.\n" +
                "Please choose one of the folllowing actions to continue:\n" +
                "Type Add or 0 to add a new employee into the database\n" +
                "Type Find or 1 to search for employee by employee type\n" +
                "Type Quit or 2 to quit the program.");

            string input;
            
        ReadUserAction:
            UserAction action;

            try
            {
                input = Console.ReadLine();
                if (!Enum.TryParse(input, true, out action))
                    throw new Exception("Invalid User Action");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Employee Type must be Add,Find or Quit. Please re-enter valid action:");
                goto ReadUserAction;
            }
            switch (action)
            {
                case UserAction.Add:
                    AddEmployee();
                    break;
                
                
                case UserAction.Find:
                ReadEmployeeType:
                    EmployeeType employeeType;

                    try
                    {
                        input = Console.ReadLine();
                        if (!Enum.TryParse(input, true, out employeeType))
                            throw new Exception("Invalid Employee Type");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Employee Type must be Experience, Fresher or Intern. Please re-enter valid employee type:");
                        goto ReadEmployeeType;
                    }
                    switch (employeeType)
                    {
                        case EmployeeType.Experience:
                            Print(FindExperience());
                            break;
                        case EmployeeType.Fresher:
                            Print(FindFresher());
                            break;
                        case EmployeeType.Intern:
                            Print(FindIntern());
                            break;
                    }
                    break;
                case UserAction.Quit:
                    Console.WriteLine("Exitting program...");
                    return;
                    
            }
        }

        public void AddEmployee()
        {
            string input;

            Console.WriteLine("Enter employee ID:");

        // Read ID
            int ID;
            ReadData(new ValidateFuncInt(ValidateId), out ID, "ID must be number only. Please re-enter ID:"); 
        // Remove old employee info if exist ID  
            RemoveEmployee(ID);

        // Read name
            Console.WriteLine("Please enter your name (10-50 characters):");       
            string Name;
            ReadData(new ValidateFuncString(ValidateName),out Name,"Name must be 10-50 characters long. Please re-enter valid name:");

        // Read Birthday
            Console.WriteLine("Enter employee's birthday:");
            string BirthDay;
            ReadData(new ValidateFuncString(ValidateDateTime), out BirthDay,"Please re-enter birthday in (dd/mm/yyyy) format:");

        //Read Phone Number
            Console.WriteLine("Enter Employee's Phone number:");
            string PhoneNumber;
            ReadData(new ValidateFuncString(ValidatePhoneNumber), out PhoneNumber, "Phone number must be number-only. Please reenter valid phone number:");

        //Read Email
            Console.WriteLine("Enter Employee's email:");
            string Email;
            ReadData(new ValidateFuncString(ValidateEmail), out Email,"Please re-enter a valid email:");



            Console.WriteLine("Enter Employee's Type (Experience, Fresher, Intern):");
        ReadEmployeeType:
            EmployeeType employeeType;
            
            try
            {
                input = Console.ReadLine();
                if (!Enum.TryParse(input, true, out employeeType))
                    throw new Exception("Invalid Employee Type");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Employee Type must be Experience, Fresher or Intern. Please re-enter valid employee type:");
                goto ReadEmployeeType;
            }
            
            switch(employeeType)
            {
                case EmployeeType.Experience:
                    Console.WriteLine("Enter year of experience:");
                    int yearOfExp;
                    ReadData(new ValidateFuncInt(ValidateYearOfExp), out yearOfExp, "Please re-enter valid number for year of experience:");

                    Console.WriteLine("Enter Eployee's most prominent skill:");
                    string skill = Console.ReadLine();
                    
                    Employees.Add(new ExperienceEmployee(ID, Name, Email, PhoneNumber, BirthDay, employeeType, yearOfExp, skill));
                    break;
                case EmployeeType.Fresher:
                    Console.WriteLine("Enter employee's recent university name:");
                    string university = Console.ReadLine();
                    
                    Console.WriteLine("Please enter graduation date (dd/mm/yyyy):");
                    string graduationDate;
                    ReadData(new ValidateFuncString(ValidateDateTime), out graduationDate, "Please re-enter graduation in (dd/mm/yyyy) format:");



                    Console.WriteLine("Please enter graduation rank (Excellent, Good, Average):");
                    string graduationRank;
                    ReadData(new ValidateFuncString(ValidateGraduationRank), out graduationRank, "Please enter valid graduation rank (Excellent, Good, Average):");
                    Employees.Add(new FresherEmployee(ID, Name, Email, PhoneNumber, BirthDay, employeeType, graduationDate, university,graduationRank));
                    break;
                case EmployeeType.Intern:
                    Console.WriteLine("Enter employee's university name:");
                    string universityName = Console.ReadLine();
                    Console.WriteLine("Enter employee's current semester:");
                    string currentSem = Console.ReadLine();
                    Console.WriteLine("Enter employee's major:");
                    string major = Console.ReadLine();
                    Employees.Add(new InternEmployee(ID, Name, Email, PhoneNumber, BirthDay, employeeType,major,currentSem,universityName));

                    break;


            }
            Console.WriteLine("Employee added successfully!");
            Console.WriteLine();
        }
        public void RemoveEmployee(int Id)
        {
            Employee emp = Employees.FirstOrDefault(x => x.Id == Id, null);
            if (emp != null)
            {
                Employees.Remove(emp);
                Employee.EmployeeCount--;
            }
        }

        public List<Employee> FindIntern()
        {
            return Employees.FindAll(e=>e.EmployeeType == EmployeeType.Intern);
        }
        public List<Employee> FindFresher()
        {
            return Employees.FindAll(e => e.EmployeeType == EmployeeType.Fresher);
        }
        public List<Employee> FindExperience()
        {
            return Employees.FindAll(e => e.EmployeeType == EmployeeType.Experience);
        }


        public void Print(List<Employee> list)
        {
            foreach(var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }



        public void ReadData(ValidateFuncString validateFunc, out string output,string exceptionMessage)
        {

        start:
            try
            {
                string input = Console.ReadLine();
                validateFunc(input, out output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(exceptionMessage);
                goto start;
            }
        }
        
        public void ReadData(ValidateFuncInt validateFunc, out int output,string exceptionMessage)
        {

        start:
            try
            {
                string input = Console.ReadLine();
                validateFunc(input, out output);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(exceptionMessage);
                goto start;
            }
        }
        
        

        
        void ValidateName(string input, out string Name)
        {
            if (input.Length < 10) throw new FullNameException("Name too short (less than 10 character)!");
            if (input.Length > 50) throw new FullNameException("Name too long (more than 50 characters)!");
            Name = input;
        }

        void ValidateDateTime(string input, out string DOB)
        {
            if (!DateTime.TryParse(input, CultureInfo.CreateSpecificCulture("fr-FR"), out DateTime datetime))
                throw new BirthDayException("The date time must be enter with (dd/mm/yyyy) format. Please re-enter:");
            DOB = input;
        }

        void ValidatePhoneNumber(string input, out string number)
        {
            int n;
            if (!int.TryParse(input, out n)) throw new PhoneException("Only type number for phone number!");
            number = input;
        }
        void ValidateEmail(string input, out string email)
        {
            if (!MailAddress.TryCreate(input, out MailAddress mailAddress))
                throw new EmailException();
            email = input;

        }
        void ValidateGraduationRank(string input, out string graduationRank)
        {
            if(input!= "Good" && input != "Excellent" && input!= "Average") throw new Exception("Invalid graduation rank");
            graduationRank = input;
        }
        void ValidateId(string input, out int Id)
        {
            if (!int.TryParse(input, out Id)) throw new Exception("Invalid ID!");     
        }
        void ValidateYearOfExp(string input, out int yearOfEXP)
        {
            
            if (!Enum.TryParse(input, true, out yearOfEXP))
                throw new Exception("Invalid number!");
        }
    }
}
