using HospitalManagmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.EntityManagmenet
{
   public class MedicationManagement
    {
        public MedicationLogic medicationLogic = new MedicationLogic();
        public  void showOptions()
        {
            while (true)
            {
                Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. Add Madication  ");
            Console.WriteLine("2. View All Madications");
                Console.WriteLine("3. Track Madication");

                Console.WriteLine("4. Update Madication ");
            Console.WriteLine("5. Delete Madication");
            Console.WriteLine("6. Back");
            Console.Write("Select an option: ");


            var choice = Console.ReadLine();
         
                switch (choice)
                {
                    case "1":
                        AddMadication();
                        break;
                    case "2":
                        GetAllMadication();
                        break;
                    case "3":
                        TrackMedication();
                        break;
                    case "4":
                        UpdateMedication();
                        break;
                    case "5":
                        DeleteMadication();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void TrackMedication()
        {
            Console.Write("Enter Madication Id: ");
            var MedicationsId = int.Parse(Console.ReadLine());
            medicationLogic.searchMadication(MedicationsId);
        }

        public  void DeleteMadication()
        {
            Console.Write("Enter Madication Id: ");
            var MedicationsId = int.Parse(Console.ReadLine());

            medicationLogic.DeleteMadication(MedicationsId);
        }

        public void UpdateMedication()
        {
            Console.Write("Enter Madication Id: ");
            var MadicationId = Console.ReadLine();
            
            Console.Write("Enter Medication Name: ");
            var mName = Console.ReadLine();
            Console.Write("Enter Price: ");
            var price = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            var quantity = int.Parse(Console.ReadLine());
            var Medication = new Medication
             (
                  mName, quantity, price
             );
            medicationLogic.UpdateMedication(Medication);
        }

        public void GetAllMadication()
        {
            medicationLogic.GetAllMadication();
        }

        public  void AddMadication()
        {
            {
                Console.Write("Enter Medication Name: ");
                var mName = Console.ReadLine();
                Console.Write("Enter Price: ");
                var price = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity: ");
                var quantity =int.Parse( Console.ReadLine());

                var Medication = new Medication
                (
                     mName, quantity, price
                );
                medicationLogic.AddMadication(Medication);
            }
        }
    }
    }

