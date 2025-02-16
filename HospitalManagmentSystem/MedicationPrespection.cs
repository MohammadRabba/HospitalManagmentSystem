using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    [PrimaryKey("PrespectionId", "MedicationId")]
    public class MedicationPrespection
    {

        public int PrespectionId;
        public Prescription prescription;
        public int MedicationId;
        public Medication medication;
        public int BillsId;
        public Bill bill;
        public MedicationPrespection()
        {
        }
        public MedicationPrespection(int prespectionId, Prescription prescription, int medicationId, Medication medication, int billsId, Bill bill)
        {
            this.PrespectionId = prespectionId;
            this.prescription = prescription;
            MedicationId = medicationId;
            this.medication = medication;
            BillsId = billsId;
            this.bill = bill;
            
        }
    }
}