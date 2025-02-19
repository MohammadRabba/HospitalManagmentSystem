using Hospital;
using HospitalManagmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.EntityManagmenet
{
    class PatientManagement
    {
        public PatientLogic patientLogic = new PatientLogic();
        public  void showOptions()
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
                        AddPatient();
                        break;
                    case "2":
                        GetPatient();

                        break;
                    case "3":
                        UpdatePatient();
                        break;
                    case "4":
                        RemovePatient();
                        break;
                    case "5":
                        GetAllPatient();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        public  void GetAllPatient()


        {
            patientLogic.GetAllPatient();
        }
        public  void GetPatient()


        {
            Console.WriteLine("Please Enter The Id For Patient");
            var patId = int.Parse(Console.ReadLine());
            patientLogic.GetPatient(patId);
        }
        public  void UpdatePatient()
        {

            {
                Console.Write("Enter patient Id: ");
                var PatientId=int.Parse(Console.ReadLine());
               
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
                var pat = new Patient(
                    name, age, gender, contactNumber, address);
                pat.Id = PatientId;
                patientLogic.UpdatePatient(pat);

            }
        }


        public  void RemovePatient()
        {

            {
                Console.Write("Enter patient Id: ");
                var patId = int.Parse(Console.ReadLine());

                patientLogic.RemovePatient(patId);
            }
        }
        public  void AddPatient()
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

                patientLogic.AddPatient(patient);
            }
        }
    }
}
