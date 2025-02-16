using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class PrescriptionManagement
    {
        public static void showOptions(MyDBContext context)
        {
            Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. Issue Prescription  ");
            Console.WriteLine("2. View All Prescriptions");
            
            Console.WriteLine("3. Back");
            Console.Write("Select an option: ");


            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    IssuePrescription(context);
                    break;
                case "2":
                    GetAllPrescriptionss(context);

                    break;
                
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void GetAllPrescriptionss(MyDBContext context)
        {
            var Prescriptions = context.Prescriptions.ToList();
            foreach (var Prescription in Prescriptions)
            {
                Console.WriteLine($"PrescriptionID is {Prescription.PrescriptionId} DoctorName: {Prescription.doctor.Name} PatientName: {Prescription.doctor.Name} Date: {Prescription.PrescriptionId}  ");
            }
        }

        private static void IssuePrescription(MyDBContext context)
        {
            Console.Write("Enter Patient Id: ");
            var pId = int.Parse(Console.ReadLine());
            Console.Write("Enter Doctor Id: ");
            var dId = int.Parse(Console.ReadLine());
            Console.Write("Enter Medication Id: ");
            var mid = int.Parse(Console.ReadLine());
            var patient = context.Patients.FirstOrDefault(x => x.Id == pId);
            var doctor = context.Doctors.FirstOrDefault(x => x.Id == dId);

            var Prescription = new Prescription
            (
                 pId, dId,patient,doctor
            );
            var med = context.Medications.FirstOrDefault(x => x.MedicationId == mid);
            var bill = new Bill(pId, Prescription);

            var medpres = new MedicationPrespection(pId,Prescription,mid,med,bill.BillId,bill);
            Prescription.medicationPrespections.Add(medpres);
            med.medicationPrespections.Add(medpres);
            context.Bills.Add(bill);

            context.Prescriptions.Add(Prescription);
            foreach (var total in Prescription.medicationPrespections)
            {
                if (total.medication.MedicationQuantity > 0)
                {
                    bill.BillPrice = +total.medication.MedicationAmount;
                    total.medication.MedicationQuantity--;
                }
                else
                {
                    Console.WriteLine("This Medcate Not Exsist");
                }
            }
            context.SaveChanges();

            Console.WriteLine("Prescription Essued successfully.");
        }
    }
}
