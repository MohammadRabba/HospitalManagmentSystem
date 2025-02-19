using HospitalManagmentSystem.Entities;
using HospitalManagmentSystem.EntityManagmenet;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HospitalManagmentSystem.Entities.Appointment;

namespace Hospital
{
    public class AppointmentLogic
    {
        public readonly MyDBContext context ;
        public AppointmentLogic()
        {
            context = new MyDBContext();
        }
        public  void CancelAppointment(int id)
        {
          
            var Appointment = context.Appointments.FirstOrDefault
                (x => x.AppointmentId== 
       id);
            if (Appointment != null)
            {
                Appointment.Status = AppointmentStatus.Cancelled;
                context.SaveChanges();
                Console.WriteLine("Appointment Cancelled successfully.");
            }
        }
        public void RemoveAppointment(int Id)
        {
            

            var Appointment = context.Appointments.FirstOrDefault
                (x => x.AppointmentId == 
       Id);
            if (Appointment != null)
            {
                context.Appointments.Remove(Appointment);
                context.SaveChanges();
                Console.WriteLine("Appointment Removed successfully.");
            }
        }
        public  void UpdateAppointment(Appointment appointment)
        {
            {
              
                var Appointment = context.Appointments.FirstOrDefault(x => x.AppointmentId == 
               appointment.AppointmentId);
                if (Appointment != null) { 
                context.Appointments.Remove(Appointment);
                context.Appointments.Add(appointment);

                    context.SaveChanges();
                    Console.WriteLine("Appointment Updated successfully.");
                }
                else
                {
                    Console.WriteLine("Appointment not exsist");
                }
            }
        }

        public void GetAppointmentByID(int search,int? pId,int? dId)
        {
          

           
            if (search == 1)
            {
               
                var Appointments = context.Appointments.Where(x => x.PatientId == pId).ToList();
                foreach (var Appointment in Appointments)
                {
                    Console.WriteLine($"AppointmentID is {Appointment.AppointmentId} DoctorId: {Appointment.DoctorId} Date: {Appointment.AppoitmentDate} Patient Name: {Appointment.patient.Name} Doctor Name: {Appointment.doctor.Name} ");
                }
            }
            else if (search == 2)
            {
             
                var Appointments = context.Appointments.Where(x => x.DoctorId == dId).ToList();
                foreach (var Appointment in Appointments)
                {
                    Console.WriteLine($"AppointmentID is {Appointment.AppointmentId} DoctorId: {Appointment.DoctorId} Date: {Appointment.AppoitmentDate} Patient Name: {Appointment.patient.Name} Doctor Name: {Appointment.doctor.Name} ");
                }
            }
            else if (search == 3)
            {
                
                var Appointments = context.Appointments.Where(x => x.PatientId == pId).Where(x =>x.DoctorId==dId).ToList();
                foreach (var Appointment in Appointments)
                {
                    Console.WriteLine($"AppointmentID is {Appointment.AppointmentId} DoctorId: {Appointment.DoctorId} Date: {Appointment.AppoitmentDate} Patient Name: {Appointment.patient.Name} Doctor Name: {Appointment.doctor.Name} ");
                }
            }
            else
            {
                Console.WriteLine("Invaalid Search Type");
            }
        }
        public  void GetAllAppointment()
        {
            var Appointments = context.Appointments.ToList();
            foreach (var Appointment in Appointments)
            {
                Console.WriteLine($"AppointmentID is {Appointment.AppointmentId} DoctorId: {Appointment.DoctorId} Date: {Appointment.AppoitmentDate}  ");
            }
        }

        public  void SceduleAppointment(Appointment appointment)
        {


            
                context.Appointments.Add(appointment);
                context.SaveChanges();
                Console.WriteLine("Appointment created successfully.");
            

            
            
        }
    }
}
    

