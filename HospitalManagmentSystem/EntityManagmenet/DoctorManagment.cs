using HospitalManagmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.EntityManagmenet
{
    public class DoctorManagement
    {
        public DoctorLogic doctorLogic = new DoctorLogic();
        public  void showOptions()
        {
            while (true)
            {
                Console.WriteLine("Hospital Management System");
                Console.WriteLine("1. Add New Doctor ");
                Console.WriteLine("2. View Doctor");
                Console.WriteLine("3. View All Doctors");

                Console.WriteLine("4. Update Doctor ");
                Console.WriteLine("5. Remove Doctor");

                Console.WriteLine("6. Back");
                Console.Write("Select an option: ");


                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddDoctor();
                        break;
                    case "2":
                        GetDoctor();

                        break;
                    case "3":
                        GetAllDoctors();

                        break;
                    case "4":
                        UpdateDoctor();
                        break;
                    case "5":
                        RemoveDoctor();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void GetAllDoctors()
        {
            doctorLogic.GetAllDoctors();        }

        public  void GetDoctor()


        {
            Console.WriteLine("Please Enter The Id For Doctor");
            var dId = int.Parse(Console.ReadLine());
            doctorLogic.GetDoctor(dId);
        }
        public  void UpdateDoctor()
        {

            {
                Console.Write("Enter Doctors Id: ");
                var DoctorId = int.Parse(Console.ReadLine());
                Console.Write("Enter patient name: ");
                var name = Console.ReadLine();
                Console.Write("Enter patient age: ");
                var age = int.Parse(Console.ReadLine());
                Console.Write("Enter patient gender: ");
                var gender = Console.ReadLine();
                Console.Write("Enter contact number: ");
                var contactNumber = Console.ReadLine();
                Console.Write("Enter Email: ");
                var email = Console.ReadLine();
                Console.Write("Enter specify: ");
                var specify = Console.ReadLine();
                Console.Write("Enter Address: ");
                var address = Console.ReadLine();
                var doc = new Doctor(name,age,gender,contactNumber,email,specify,address);
                doc.Id = DoctorId;
                doctorLogic.UpdateDoctor(doc);
            }
        }


        public  void RemoveDoctor()
        {

            {
                Console.Write("Enter Doctor Id: ");
                var DoctorId = int.Parse(Console.ReadLine());

                doctorLogic.RemoveDoctor(DoctorId);
            }
        }
        public  void AddDoctor()
        {

            {
                Console.Write("Enter Doctor name: ");
                var name = Console.ReadLine();
                Console.Write("Enter Doctor age: ");
                var age = int.Parse(Console.ReadLine());
                Console.Write("Enter Doctor gender: ");
                var gender = Console.ReadLine();
                Console.Write("Enter contact number: ");
                var contactNumber = Console.ReadLine();
                Console.Write("Enter Email: ");
                var email = Console.ReadLine();
                Console.Write("Enter specification: ");
                var specify = Console.ReadLine();
                Console.Write("Enter Address: ");
                var address = Console.ReadLine();
                var doctor = new Doctor
                (
                     name,
                     age,
                     gender,
                     contactNumber,
                     email,specify,address
                );
                doctorLogic.AddDoctor(doctor);
            }
        }
    }
}
