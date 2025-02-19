using HospitalManagmentSystem.Entities;
using HospitalManagmentSystem.EntityManagmenet;
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
                    PatientManagement patientManagement = new PatientManagement();
                    patientManagement.showOptions();
                    break;
                case "2":
                    DoctorManagement doctorManagement = new DoctorManagement();
                    doctorManagement.showOptions();
                    break;
                case "3":
                    AppointmentManagement appointmentManagement = new AppointmentManagement();
                    appointmentManagement.showOptions();
                    break;
                case "4":
                    PrescriptionManagement prescriptionManagement = new PrescriptionManagement();
                    prescriptionManagement.showOptions();
                    break;
                case "5":
                    MedicationManagement medicationManagement = new MedicationManagement();
                    medicationManagement.showOptions();
                    break;
                case "6":
                    BillingManagement billingManagement = new BillingManagement();
                    billingManagement.showOptions();
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