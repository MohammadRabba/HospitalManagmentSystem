using HospitalManagmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.EntityManagmenet
{
    public class DoctorLogic
    {
        private readonly MyDBContext context = new MyDBContext();
       
        public  void GetDoctor(int did)


        {
           
            if (did != null)
            {
                var patient = context.Doctors.Where(x => x.Id == 
                did);
                Console.WriteLine($"DoctorID is {context.Doctors.FirstOrDefault().Id} Name: {context.Doctors.FirstOrDefault().Name} Age: {context.Doctors.FirstOrDefault().Age} Gender: {context.Doctors.FirstOrDefault().Id} Email: {context.Doctors.FirstOrDefault().Email} ContcatNumber: {context.Doctors.FirstOrDefault().ContactNumber} Spetialist: {context.Doctors.FirstOrDefault().Specify}.");
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
        public  void UpdateDoctor(Doctor doctor)
        {

            {
           
                var Doctor = context.Doctors.FirstOrDefault(x => x.Id == doctor.Id);
                context.Doctors.Remove(Doctor);
                context.Doctors.Add(doctor);
                context.SaveChanges();
                Console.WriteLine("Patient Updated successfully.");
            }
        }


        public  void RemoveDoctor(int DoctorId)
        {

            {
               

                var Doctor = context.Doctors.FirstOrDefault
                    (x => x.Id == DoctorId);
                if (Doctor != null)
                {
                    context.Doctors.Remove(Doctor);
                    context.SaveChanges();
                    Console.WriteLine("Doctor Removed successfully.");
                }
            }
        }
        public  void AddDoctor(Doctor doctor)
        {

           

                context.Doctors.Add(doctor);
                context.SaveChanges();
                Console.WriteLine("Doctor added successfully.");
            }

        internal void GetAllDoctors()
        {
            foreach (var doctor in context.Doctors) {
                Console.WriteLine($"DoctorID is {doctor.Id} Name: {doctor.Name} Age: {doctor.Age} Gender: {doctor.Id} Email: {doctor.Email} ContcatNumber: {doctor.ContactNumber} Spetialist: {doctor.Specify}.");
            }
        }
    }
}
