using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class PaymentTask : Task {
        //properties
        public decimal Amount { get; private set; }

        public PaymentTask(
            string title, string description, Priority priority, Status status,
            DateTime dueDatetime, DateTime createdDatetime, decimal amount
        ) : base(title, description, priority, status, dueDatetime, createdDatetime) {
            Amount = amount;
        }

        public PaymentTask(
            string title, string description, Priority priority,
            DateTime dueDatetime, DateTime createdDatetime, decimal amount
        ) : base(title, description, priority, dueDatetime, createdDatetime)
        {
            Amount = amount;
        }

        //methods
        public void UpdatePaymentAmount(decimal amount)
        {
            Amount = amount;
        }     
    }
}
