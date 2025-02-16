using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Medication
    {
        public int MedicationId {  get; set; }
        public string MedicationName { get; set; }
        public int MedicationQuantity { get; set; }
        public decimal MedicationAmount { get; set; }
        public virtual ICollection<MedicationPrespection> medicationPrespections { get; set; } = new List<MedicationPrespection>();

        public Medication() { }
        public Medication( string medicationName, int medicationQuantity, decimal medicationAmount)
        {
            MedicationName = medicationName;
            MedicationQuantity = medicationQuantity;
            MedicationAmount = medicationAmount;
        }
    }
}
