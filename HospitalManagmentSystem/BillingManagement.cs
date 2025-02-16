using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hospital.Appointment;
using static Hospital.Bill;

namespace Hospital
{
    public class BillingManagement
    {

        public static void showOptions(MyDBContext context)
        {
            Console.WriteLine("Hospital Management System");
            Console.WriteLine("1. View All Billings");
            Console.WriteLine("2. Update  Bills");

            Console.WriteLine("3. Back");


            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ViewAllBillings(context);
                    break;
                case "2":
                    updateBill(context);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        private static void updateBill(MyDBContext context)
        {
            Console.Write("Enter Bill Id: ");
            var BillId = Console.ReadLine();
            var Bill = context.Bills.FirstOrDefault(x => x.BillId == int.Parse(
           BillId));
            Console.Write("Enter Appointment Status: 0 for Unpaid / 1 for Paid");
            var status = int.Parse(Console.ReadLine());
            if (status == 0)
            {
                Bill.Status = BillStatus.Unpaid;
            }
            else if (status == 1)
            {
                Bill.Status = BillStatus.Paid;
            }
            
            else { Console.WriteLine("Invalid Input"); }
           

            context.SaveChanges();
            Console.WriteLine("Patient Updated successfully.");
        }

        private static void ViewAllBillings(MyDBContext context)
        {
           var Bills = context.Bills.ToList();
            foreach (var Bill in Bills)
            {
                Console.WriteLine($"PrescriptionID is {Bill.BillId} Bill Status: {Bill.Status} Amount: {Bill.BillPrice} Date: {Bill.BillDate}  ");
            }
        }
    }
}
