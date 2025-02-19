using HospitalManagmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class PatientLogic
    {
        public readonly MyDBContext context = new MyDBContext();
        
        public  void GetAllPatient()


        { 
            var patients = context.Patients.ToList();
            foreach (var patient in patients) {
                Console.WriteLine($"PatientID is {patient.Id} Name: {patient.Name} Age: {patient.Age} Gender: {patient.Id} Address: {patient.Address} ContcatNumber: {patient.ContactNumber}.");
            }
        }
        public  void GetPatient(int patId)


        {

            if (patId != null)
            {
                var patient = context.Patients.FirstOrDefault(x => x.Id ==
                patId);
                if (patient != null)
                {
                    Console.WriteLine($"PatientID is {context.Patients.FirstOrDefault().Id} Name: {context.Patients.FirstOrDefault().Name} Age: {context.Patients.FirstOrDefault().Age} Gender: {context.Patients.FirstOrDefault().Gender} Address: {context.Patients.FirstOrDefault().Address} ContcatNumber: {context.Patients.FirstOrDefault().ContactNumber}.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Id");
            }
        }
        public  void UpdatePatient(Patient patient)
        {

            {
             
                var temp = context.Patients.FirstOrDefault(x => x.Id ==patient.Id);
                context.Patients.Remove(temp);
                context.Patients.Add(patient);

                context.SaveChanges();
                Console.WriteLine("Patient Updated successfully.");
            }
        }


        public  void RemovePatient(int patId)
        {

            
              
                    var patient = context.Patients.FirstOrDefault
                        (x => x.Id == 
               patId);
                if (patient != null)
                {
                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    Console.WriteLine("Patient Removed successfully.");
                
            }
        }
        public  void AddPatient(Patient patient)
        {
            
          
                context.Patients.Add(patient);
                context.SaveChanges();
                Console.WriteLine("Patient added successfully.");
            
        }
    }
}
