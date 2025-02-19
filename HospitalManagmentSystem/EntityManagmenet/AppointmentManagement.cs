using Hospital;
using HospitalManagmentSystem.Entities;
using System.Globalization;
using System.Security.Cryptography;
using static HospitalManagmentSystem.Entities.Appointment;

namespace HospitalManagmentSystem.EntityManagmenet
{
    public class AppointmentManagement
    {
        public AppointmentLogic appointmentLogic = new AppointmentLogic();
        
        public  void showOptions()
        {
            while (true)
            {
                Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. Schedule Appointment  ");
            Console.WriteLine("2. View All Appointments");
            Console.WriteLine("3. View Appointment by Id");

            Console.WriteLine("4. Update Appointment ");
            Console.WriteLine("5. Cancel Appointment");
            Console.WriteLine("6. Remove Appointment");

            Console.WriteLine("7. Back");

           
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SceduleAppointment();
                        break;
                    case "2":
                        GetAllAppointment();

                        break;
                    case "3":
                        GetAppointmentByID();
                        break;
                    case "4":
                        UpdateAppointment();
                        break;
                    case "5":
                        CancelAppointment();
                        break;
                    case "6":
                        RemoveAppointment();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        public void GetAppointmentByID()
        {
            Console.Write("1) Search By Patient Id");
            Console.Write("2) Search By Doctor Id");
            Console.Write("3) Search By Patient & Doctor Id");

            Console.Write("Enter Search Type Id: ");
            var search = Console.Read();
            if (search == 1)
            {
                Console.Write("Enter Patient Id: ");
                var pId = int.Parse(Console.ReadLine());
                appointmentLogic.GetAppointmentByID(search, pId, null);
            }
            else if (search == 2)
            {
                Console.Write("Enter Doctor Id: ");
                var dId = int.Parse(Console.ReadLine());
                appointmentLogic.GetAppointmentByID(search, null,dId);

            }
            else if (search == 3)
            {
                Console.Write("Enter Patient Id: ");
                var pId = int.Parse(Console.ReadLine());
                Console.Write("Enter Doctor Id: ");
                var dId = int.Parse(Console.ReadLine());
                appointmentLogic.GetAppointmentByID(search, pId, dId);

            }
        }

        private  void CancelAppointment()
        {
            Console.Write("Enter Appointment Id: ");
            var AppointmentId = int.Parse(Console.ReadLine());
            appointmentLogic.CancelAppointment(AppointmentId);
           
        }
        private  void RemoveAppointment()
        {
            Console.Write("Enter Appointment Id: ");
            var AppointmentId = int.Parse(Console.ReadLine());

            appointmentLogic.RemoveAppointment(AppointmentId);
        }
        private  void UpdateAppointment()
        {
            {
                
                Console.Write("Enter Appointment Id: ");
                var AppointmentId = Console.ReadLine();
                
                Console.Write("Enter patient Id: ");
                var pid = int.Parse(Console.ReadLine());
                Console.Write("Enter Doctor Id: ");
                var did = int.Parse(Console.ReadLine());
                Console.Write("Enter Appointment Date (as format dd MM yyyy): ");
                var appdate = Console.ReadLine();
                if (DateTime.TryParseExact(appdate, "dd MM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime appDate))
                {

                    Console.Write("Enter Appointment Status: 0 for Scheduled / 1 for Completed / 2 for Cancelled");
                    var status = int.Parse(Console.ReadLine());
                    if (status == 0)
                    {
                        Appointment appointment = new Appointment(pid, did, DateTime.Parse(appdate), AppointmentStatus.Scheduled);
                        appointmentLogic.UpdateAppointment(appointment);

                    }
                    else if (status == 1)
                    {
                        Appointment appointment = new Appointment(pid, did, appDate, AppointmentStatus.Completed);
                        appointmentLogic.UpdateAppointment(appointment);

                    }
                    if (status == 2)
                    {
                        Appointment appointment = new Appointment(pid, did, appDate, AppointmentStatus.Cancelled);
                        appointmentLogic.UpdateAppointment(appointment);

                    }
                    else { Console.WriteLine("Invalid Input"); }


                    Console.WriteLine("Patient Updated successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the correct format (e.g.,  25 12 2023).");
                }
            }
        }

        private  void GetAllAppointment()
        {
            appointmentLogic.GetAllAppointment();
        }

        public  void SceduleAppointment()
        {


            
                Console.Write("Enter Patient Id: ");
                var pId = int.Parse(Console.ReadLine());
                Console.Write("Enter Doctor Id: ");
                var dId = int.Parse(Console.ReadLine());
            Console.Write("Enter Appointment Date (as format dd MM yyyy): ");
            var appDateInput = Console.ReadLine();

            if (DateTime.TryParseExact(appDateInput, "dd MM yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime appDate))
            {

                var appointment = new Appointment(pId, dId, appDate);
                appointmentLogic.SceduleAppointment(appointment);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in the correct format (e.g.,  25 12 2023).");
            }

            
            
        }
    }
}
    

