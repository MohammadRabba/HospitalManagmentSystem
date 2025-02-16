using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class DoctorManagement
    {
        public static void showOptions(MyDBContext context)
        {
            while (true)
            {
                Console.WriteLine("Hospital Management System");
                Console.WriteLine("1. Add New Doctor ");
                Console.WriteLine("2. View Doctor");
                Console.WriteLine("3. Update Doctor ");
                Console.WriteLine("4. Remove Doctor");
                Console.WriteLine("5. Back");
                Console.Write("Select an option: ");


                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddDoctor(context);
                        break;
                    case "2":
                        GetDoctor(context);

                        break;
                    case "3":
                        UpdateDoctor(context);
                        break;
                    case "4":
                        RemoveDoctor(context);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        public static void GetDoctor(MyDBContext context)


        {
            Console.WriteLine("Please Enter The Id For Doctor");
            var patId = Console.ReadLine();
            if (patId != null)
            {
                var patient = context.Doctors.Where(x => x.Id == int.Parse(
                patId));
                Console.WriteLine($"DoctorID is {context.Doctors.FirstOrDefault().Id} Name: {context.Doctors.FirstOrDefault().Name} Age: {context.Doctors.FirstOrDefault().Age} Gender: {context.Doctors.FirstOrDefault().Id} Email: {context.Doctors.FirstOrDefault().Email} ContcatNumber: {context.Doctors.FirstOrDefault().ContactNumber} Spetialist: {context.Doctors.FirstOrDefault().Specify}.");
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
        public static void UpdateDoctor(MyDBContext context)
        {

            {
                Console.Write("Enter Doctors Id: ");
                var DoctorId = Console.ReadLine();
                var Doctor = context.Doctors.FirstOrDefault(x => x.Id == int.Parse(
               DoctorId));
                Console.Write("Enter patient name: ");
                var name = Console.ReadLine();
                Doctor.Name = name;
                Console.Write("Enter patient age: ");
                var age = int.Parse(Console.ReadLine());
                Doctor.Age = age;
                Console.Write("Enter patient gender: ");
                var gender = Console.ReadLine();
                Doctor.Gender = gender;
                Console.Write("Enter contact number: ");
                var contactNumber = Console.ReadLine();
                Doctor.ContactNumber = contactNumber;
                Console.Write("Enter Email: ");
                var email = Console.ReadLine();
                Doctor.Email = email;
                Console.Write("Enter specify: ");
                var specify = Console.ReadLine();
                Doctor.Specify = specify;
                Console.Write("Enter Address: ");
                var address = Console.ReadLine();
                Doctor.Address  = address;

                context.SaveChanges();
                Console.WriteLine("Patient Updated successfully.");
            }
        }


        public static void RemoveDoctor(MyDBContext context)
        {

            {
                Console.Write("Enter Doctor Id: ");
                var DoctorId = Console.ReadLine();

                var Doctor = context.Doctors.FirstOrDefault
                    (x => x.Id == int.Parse(
           DoctorId));
                if (Doctor != null)
                {
                    context.Doctors.Remove(Doctor);
                    context.SaveChanges();
                    Console.WriteLine("Doctor Removed successfully.");
                }
            }
        }
        public static void AddDoctor(MyDBContext context)
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

                context.Doctors.Add(doctor);
                context.SaveChanges();
                Console.WriteLine("Doctor added successfully.");
            }
        }
    }
}
