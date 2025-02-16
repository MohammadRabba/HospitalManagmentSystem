using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class PatientManagement
    {
        public static void showOptions(MyDBContext context)
        {
            while (true)
            {
                Console.WriteLine("Hospital Management System");
                Console.WriteLine("1. Add New Patient ");
                Console.WriteLine("2. View Patient");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Remove Patient");
                Console.WriteLine("5. View All Patient");

                Console.WriteLine("6. Back");
                Console.Write("Select an option: ");


                var choice2 = Console.ReadLine();
                switch (choice2)
                {
                    case "1":
                        AddPatient(context);
                        break;
                    case "2":
                        GetPatient(context);

                        break;
                    case "3":
                        UpdatePatient(context);
                        break;
                    case "4":
                        RemovePatient(context);
                        break;
                    case "5":
                        GetAllPatient(context);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        public static void GetAllPatient(MyDBContext context)


        { 
            var patients = context.Patients.ToList();
            foreach (var patient in patients) {
                Console.WriteLine($"PatientID is {patient.Id} Name: {patient.Name} Age: {patient.Age} Gender: {patient.Id} Address: {patient.Address} ContcatNumber: {patient.ContactNumber}.");
            }
        }
        public static void GetPatient(MyDBContext context)


        {
            Console.WriteLine("Please Enter The Id For Patient");
            var patId = Console.ReadLine();
            if (patId != null)
            {
                var patient = context.Patients.Where(x => x.Id == int.Parse(
                patId));
                Console.WriteLine($"PatientID is {context.Patients.First().Id} Name: {context.Patients.First().Name} Age: {context.Patients.First().Age} Gender: {context.Patients.First().Id} Address: {context.Patients.First().Address} ContcatNumber: {context.Patients.First().ContactNumber}.");
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
        public static void UpdatePatient(MyDBContext context)
        {

            {
                Console.Write("Enter patient Id: ");
                var PatientId=Console.ReadLine();
                var patient = context.Patients.FirstOrDefault(x => x.Id == int.Parse(
               PatientId));
                Console.Write("Enter patient name: ");
                var name = Console.ReadLine();
                patient.Name = name;
                Console.Write("Enter patient age: ");
                var age = int.Parse(Console.ReadLine());
                patient.Age = age;
                Console.Write("Enter patient gender: ");
                var gender = Console.ReadLine();
                patient.Gender = gender;
                Console.Write("Enter contact number: ");
                var contactNumber = Console.ReadLine();
                patient.ContactNumber = contactNumber;
                Console.Write("Enter address: ");
                var address = Console.ReadLine();
                patient.Address = address;

                context.SaveChanges();
                Console.WriteLine("Patient Updated successfully.");
            }
        }


        public static void RemovePatient(MyDBContext context)
        {

            {
                Console.Write("Enter patient Id: ");
                var patId = Console.ReadLine();
                
                    var patient = context.Patients.FirstOrDefault
                        (x => x.Id == int.Parse(
               patId));
                if (patient != null)
                {
                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    Console.WriteLine("Patient Removed successfully.");
                }
            }
        }
        public static void AddPatient(MyDBContext context)
        {
            
            {
                Console.Write("Enter patient name: ");
                var name = Console.ReadLine();
                Console.Write("Enter patient age: ");
                var age = int.Parse(Console.ReadLine());
                Console.Write("Enter patient gender: ");
                var gender = Console.ReadLine();
                Console.Write("Enter contact number: ");
                var contactNumber = Console.ReadLine();
                Console.Write("Enter address: ");
                var address = Console.ReadLine();

                var patient = new Patient
                (
                     name,
                     age,
                     gender,
                     contactNumber,
                     address
                );

                context.Patients.Add(patient);
                context.SaveChanges();
                Console.WriteLine("Patient added successfully.");
            }
        }
    }
}
