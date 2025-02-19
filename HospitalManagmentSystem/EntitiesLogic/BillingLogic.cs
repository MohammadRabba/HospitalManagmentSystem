using HospitalManagmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HospitalManagmentSystem.Entities.Bill;


namespace Hospital
{
    public class BillingLogic
    {
        private readonly MyDBContext context = new MyDBContext();


        public void updateBill(int billId, decimal price, int status)
        {
            // Find the bill
            var bill = context.Bills.FirstOrDefault(x => x.BillId == billId);

            if (bill == null)
            {
                Console.WriteLine($"Bill with ID {billId} not found.");
                return; // Exit the method if the bill is not found
            }

            // Update the bill properties
            bill.BillPrice = price;

            if (status == 0)
            {
                bill.Status = BillStatus.Unpaid;
            }
            else if (status == 1)
            {
                bill.Status = BillStatus.Paid;
            }
            else
            {
                Console.WriteLine("Invalid status input. Status must be 0 (Unpaid) or 1 (Paid).");
                return; // Exit the method if the status is invalid
            }

            // Save changes to the database
            context.SaveChanges();
            Console.WriteLine("Bill updated successfully.");
        }

        public  void ViewAllBillings()
        {
           var Bills = context.Bills.ToList();
            foreach (var Bill in Bills)
            {
                Console.WriteLine($"BillID is {Bill.BillId} Bill Status: {Bill.Status} Amount: {Bill.BillPrice} Date: {Bill.BillDate}  ");
            }
        }
    }
}
