using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class Expenses
    {
        public int ExpensesId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public int AdminId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
