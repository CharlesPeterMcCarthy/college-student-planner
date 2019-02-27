using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    class PaymentTask : Task {
        //properties
        public decimal Amount { get; private set; }

        //methods
        public void UpdatePaymentAmount(decimal amount)
        {
            Amount = amount;
        }//end of update payment amount       
    }//end of the payment class
}
