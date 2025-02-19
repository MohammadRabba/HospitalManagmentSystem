using HospitalManagmentSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.EntityManagmenet
{
   public class MedicationLogic
    {
        private readonly MyDBContext context = new MyDBContext();
      

        public void DeleteMadication(int medId)
        {
            Console.Write("Enter Madication Id: ");

            var Madication = context.Medications.FirstOrDefault
                (x => x.MedicationId == medId);
            if (Madication != null)
            {
                context.Medications.Remove(Madication);
                context.SaveChanges();
                Console.WriteLine("Medication Removed successfully.");
            }
        }

        public void UpdateMedication(Medication medication)
        {
            
            var Medication = context.Medications.FirstOrDefault(x => x.MedicationId == medication.MedicationId);
            context.Medications.Remove(Medication);
            context.Medications.Add(medication);
            context.SaveChanges();
            Console.WriteLine("Medication Updated successfully.");
        }

        public void GetAllMadication()
        {
            var Medications = context.Medications.ToList();
            foreach (var Medication in Medications)
            {
                Console.WriteLine($"MedicationID is {Medication.MedicationId} Name: {Medication.MedicationName} Quantity: {Medication.MedicationQuantity} Price: {Medication.MedicationAmount}");
            }
        }
        public void searchMadication(int medId)
        {
              var medicationPrescriptions = context.MedicationPrespections
    
      .Where(x => x.medicationId == medId)
     
      .ToList();


            if (medicationPrescriptions.Count == 0)
            {
                Console.WriteLine($"No prescriptions found for Medication ID {medId}.");
                return;
            }
            foreach (var Medication in medicationPrescriptions)
            {
                var pres = context.Prescriptions.FirstOrDefault(x => x.PrescriptionId == Medication.PrespectionId);
                var pat = context.Patients.FirstOrDefault(x => x.Id == pres.PatientId);
                var doc = context.Patients.FirstOrDefault(x => x.Id == pres.DoctorId);
                var med = context.Medications.FirstOrDefault(x => x.MedicationId == Medication.medicationId);

                Console.WriteLine($"MedicationID is {med.MedicationId} Name: {med.MedicationName} Quantity: {med.MedicationQuantity} Price: {med.MedicationAmount} PresprictionId: {Medication.prescription.PrescriptionId} PatientId: {pat.Id} PatientName: {pat.Name} DoctorId: {doc.Id} DoctorName: {doc.Name}");
            }
        }
        public void AddMadication(Medication medication)
        {
            {
                

                context.Medications.Add(medication);
                context.SaveChanges();
                Console.WriteLine("Medication added successfully.");
            }
        }
    }
    }

