using Hospital;
using HospitalManagmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HospitalManagmentSystem.Entities.Appointment;
using static HospitalManagmentSystem.Entities.Bill;

namespace HospitalManagmentSystem.EntityManagmenet
{
    public class BillingManagement
    {
        public BillingLogic billingLogic = new BillingLogic();

        public  void showOptions()
        {
            while (true)
            {
                Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. View All Billings");
            Console.WriteLine("2. Update  Bills");

            Console.WriteLine("3. Back");


            var choice = Console.ReadLine();
           
                switch (choice)
                {
                    case "1":
                        ViewAllBillings();
                        break;
                    case "2":
                        updateBill();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        public void updateBill()
        {
            Console.Write("Enter Bill Id: ");
            var BillId = int.Parse(Console.ReadLine());

            Console.Write("Enter Price: ");
            var BillPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Bill Status: 0 for Unpaid / 1 for Paid");
            var status = int.Parse(Console.ReadLine());
       
            
            billingLogic.updateBill(BillId,BillPrice,status);
            
        }

        public void ViewAllBillings()
        {
            billingLogic.ViewAllBillings();
        }
    }
}
