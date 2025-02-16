using Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
class Program
{
    public static void Main(string[] args)
    {
        MyDBContext context = new MyDBContext();
        while (true)
        {
            Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. Patient Management");
            Console.WriteLine("2. Doctor Management");
            Console.WriteLine("3. Appointment Management");
            Console.WriteLine("4. Prescription Management");
            Console.WriteLine("5. Medication Management");
            Console.WriteLine("6. Billing Management");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PatientManagement.showOptions(context);
                    break;
                case "2":
                    DoctorManagement.showOptions(context);
                    break;
                case "3":
                    AppointmentManagement.showOptions(context);
                    break;
                case "4":
                    PrescriptionManagement.showOptions(context);
                    break;
                case "5":
                    MedicationManagement.showOptions(context);
                    break;
                case "6":
                    BillingManagement.showOptions(context);
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }


}