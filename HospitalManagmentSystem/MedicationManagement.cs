using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
   public class MedicationManagement
    {
        public static void showOptions(MyDBContext context)
        {
            Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. Add Madication  ");
            Console.WriteLine("2. View All Madications");
            Console.WriteLine("3. Update Madication ");
            Console.WriteLine("4. Delete Madication");
            Console.WriteLine("5. Back");
            Console.Write("Select an option: ");


            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddMadication(context);
                    break;
                case "2":
                    GetAllMadication(context);

                    break;
                case "3":
                    UpdateMedication(context);
                    break;
                case "4":
                    DeleteMadication(context);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void DeleteMadication(MyDBContext context)
        {
            Console.Write("Enter Madication Id: ");
            var MedicationsId = Console.ReadLine();

            var Madication = context.Medications.FirstOrDefault
                (x => x.MedicationId == int.Parse(
       MedicationsId));
            if (Madication != null)
            {
                context.Medications.Remove(Madication);
                context.SaveChanges();
                Console.WriteLine("Medication Removed successfully.");
            }
        }

        private static void UpdateMedication(MyDBContext context)
        {
            Console.Write("Enter Madication Id: ");
            var MadicationId = Console.ReadLine();
            var Medication = context.Medications.FirstOrDefault(x => x.MedicationId == int.Parse(
           MadicationId));
            Console.Write("Enter Medication Name: ");
            var mName = (Console.ReadLine());
            Medication.MedicationName = mName;
            Console.Write("Enter Price: ");
            var price = int.Parse(Console.ReadLine());
            Medication.MedicationAmount = price;
            Console.Write("Enter Quantity: ");
            var quantity = int.Parse(Console.ReadLine());
            Medication.MedicationQuantity = quantity;
            context.SaveChanges();
            Console.WriteLine("Patient Updated successfully.");
        }

        private static void GetAllMadication(MyDBContext context)
        {
            var Medications = context.Medications.ToList();
            foreach (var Medication in Medications)
            {
                Console.WriteLine($"AppointmentID is {Medication.MedicationId} Name: {Medication.MedicationName} Quantity: {Medication.MedicationQuantity} Price: {Medication.MedicationAmount}");
            }
        }

        private static void AddMadication(MyDBContext context)
        {
            {
                Console.Write("Enter Medication Name: ");
                var mName = (Console.ReadLine());
                Console.Write("Enter Price: ");
                var price = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity: ");
                var quantity =int.Parse( Console.ReadLine());

                var Medication = new Medication
                (
                     mName, quantity, price
                );

                context.Medications.Add(Medication);
                context.SaveChanges();
                Console.WriteLine("Medication added successfully.");
            }
        }
    }
    }

