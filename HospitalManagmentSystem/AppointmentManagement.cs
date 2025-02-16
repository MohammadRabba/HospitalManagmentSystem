using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hospital.Appointment;

namespace Hospital
{
    public class AppointmentManagement
    {
        public static void showOptions(MyDBContext context)
        {
            Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. Schedule Appointment  ");
            Console.WriteLine("2. View All Appointments");
            Console.WriteLine("3. Update Appointment ");
            Console.WriteLine("4. Cancel Appointment");
            Console.WriteLine("5. Remove Appointment");

            Console.WriteLine("6. Back");


            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SceduleAppointment(context);
                    break;
                case "2":
                    GetAllAppointment(context);

                    break;
                case "3":
                    UpdateAppointment(context);
                    break;
                case "4":
                    CancelAppointment(context);
                    break;
                case "5":
                    RemoveAppointment(context);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void CancelAppointment(MyDBContext context)
        {
            Console.Write("Enter Appointment Id: ");
            var AppointmentId = Console.ReadLine();

            var Appointment = context.Appointments.FirstOrDefault
                (x => x.AppointmentId== int.Parse(
       AppointmentId));
            if (Appointment != null)
            {
                Appointment.Status = AppointmentStatus.Cancelled;
                context.SaveChanges();
                Console.WriteLine("Appointment Removed successfully.");
            }
        }
        private static void RemoveAppointment(MyDBContext context)
        {
            Console.Write("Enter Appointment Id: ");
            var AppointmentId = Console.ReadLine();

            var Appointment = context.Appointments.FirstOrDefault
                (x => x.AppointmentId == int.Parse(
       AppointmentId));
            if (Appointment != null)
            {
                context.Appointments.Remove(Appointment);
                context.SaveChanges();
                Console.WriteLine("Appointment Removed successfully.");
            }
        }
        private static void UpdateAppointment(MyDBContext context)
        {
            {
                Console.Write("Enter Appointment Id: ");
                var AppointmentId = Console.ReadLine();
                var Appointment = context.Appointments.FirstOrDefault(x => x.AppointmentId == int.Parse(
               AppointmentId));
                Console.Write("Enter patient Id: ");
                var pid = int.Parse(Console.ReadLine());
                Appointment.PatientId = pid;
                Console.Write("Enter Doctor Id: ");
                var did = int.Parse(Console.ReadLine());
                Appointment.DoctorId = did;
                Console.Write("Enter Appointment Date (as format dd MMMM yyyy): ");
                var appdate = Console.ReadLine();
                if (DateTime.TryParseExact(appdate, "dd MM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime appDate))
                {
                    Appointment.AppoitmentDate = DateTime.Parse(appdate);

                    Console.Write("Enter Appointment Status: 0 for Scheduled / 1 for Completed / 2 for Cancelled");
                    var status = int.Parse(Console.ReadLine());
                    if (status == 0)
                    {
                        Appointment.Status = AppointmentStatus.Scheduled;
                    }
                    else if (status == 1)
                    {
                        Appointment.Status = AppointmentStatus.Completed;
                    }
                    if (status == 2)
                    {
                        Appointment.Status = AppointmentStatus.Cancelled;
                    }
                    else { Console.WriteLine("Invalid Input"); }


                    context.SaveChanges();
                    Console.WriteLine("Patient Updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the correct format (e.g.,  25 12 2023).");
                }
            }
        }

        private static void GetAllAppointment(MyDBContext context)
        {
            var Appointments = context.Appointments.ToList();
            foreach (var Appointment in Appointments)
            {
                Console.WriteLine($"AppointmentID is {Appointment.AppointmentId} DoctorId: {Appointment.DoctorId} Date: {Appointment.AppoitmentDate} Patient Name: {Appointment.patient.Name} Doctor Name: {Appointment.doctor.Name} ");
            }
        }

        public static void SceduleAppointment(MyDBContext context)
        {


            
                Console.Write("Enter Patient Id: ");
                var pId = int.Parse(Console.ReadLine());
                Console.Write("Enter Doctor Id: ");
                var dId = int.Parse(Console.ReadLine());
            Console.Write("Enter Appointment Date (as format dd MMMM yyyy): ");
            var appDateInput = Console.ReadLine();

            if (DateTime.TryParseExact(appDateInput, "dd MM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime appDate))
            {
                var appointment = new Appointment(pId, dId, appDate);
                context.Appointments.Add(appointment);
                context.SaveChanges();
                Console.WriteLine("Appointment created successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in the correct format (e.g.,  25 12 2023).");
            }

            
            
        }
    }
}
    

