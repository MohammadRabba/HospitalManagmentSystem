using Hospital;
using HospitalManagmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagmentSystem.EntityManagmenet
{
    public class PrescriptionManagement
    {
        public PrescriptionLogic prescriptionLogic = new PrescriptionLogic();
        public void showOptions()
        {
            while (true)
            {
                Console.WriteLine("Hospital Management System");
                Console.WriteLine("1. Issue Prescription  ");
                Console.WriteLine("2. View All Prescriptions");
                Console.WriteLine("3. Update Prescription");
                Console.WriteLine("4. Back");
                Console.Write("Select an option: ");


                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        IssuePrescription();
                        break;
                    case "2":
                        GetAllPrescriptionss();

                        break;
                    case "3":
                        UpdatePrescription();

                        break;

                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        public void UpdatePrescription()
        {
            Console.Write("Enter Prespection Id: ");
            var preId = int.Parse(Console.ReadLine());
    
            Console.Write("Enter Patient Id: ");
            var pId = int.Parse(Console.ReadLine());
            Console.Write("Enter Doctor Id: ");
            var dId = int.Parse(Console.ReadLine());

            Console.Write("Enter Medication Id: ");
            var mid = int.Parse(Console.ReadLine());
            List<int> med = new List<int>();
            while (mid != -1)
            {
                med.Add(mid);
                mid = 0;
                Console.Write("Enter Medication Id: (-1 to to finish)");
                mid = int.Parse(Console.ReadLine());


            }
            prescriptionLogic.UpdatePrescription(preId,pId,dId, med);

        }

        public void GetAllPrescriptionss()
        {
            prescriptionLogic.GetAllPrescriptionss();
        }

         public void IssuePrescription()
        {
            Console.Write("Enter Patient Id: ");
            var pId = int.Parse(Console.ReadLine());
            Console.Write("Enter Doctor Id: ");
            var dId = int.Parse(Console.ReadLine());
            Console.Write("Enter Medication Id: ");
            var mid = int.Parse(Console.ReadLine());
            List<int> med = new List<int>();
            while (mid != -1)
            {
                med.Add(mid);
                mid = 0;
                Console.Write("Enter Medication Id: (-1 to to finish)");
                mid = int.Parse(Console.ReadLine());


            }

           
            prescriptionLogic.IssuePrescription(pId, dId, med);

        }
    }
}
