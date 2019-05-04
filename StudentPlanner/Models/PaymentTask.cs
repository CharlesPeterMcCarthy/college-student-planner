﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPlanner.Models {
    public class PaymentTask : Task {
        private decimal _amount;

        public decimal Amount {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged("Amount"); }
        }

        public PaymentTask() { }

        public PaymentTask(
            string title, string description, Priority priority, Status status,
            DateTime dueDatetime, DateTime createdDatetime, decimal amount
        ) : base(title, description, priority, status, dueDatetime, createdDatetime) {
            Amount = amount;
        }
        //referenced by AddTask.xaml.cs
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
