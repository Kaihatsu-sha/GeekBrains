using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    public class Invoice : ItemBase
    {
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public float Sum { get; private set; }
        public DateTime ApproveDate { get; private set; }
        public bool IsApproved { get; private set; }
        public List<Sheet> Sheets { get; set; } = new List<Sheet>();
        public virtual Contract Contract { get; private set; }


        public void Create(Contract contract)
        {
            Contract = contract;
            DateStart = DateTime.Now;
        }

        public void IncludeSheets(IEnumerable<Sheet> sheets)
        {
            Sheets.AddRange(sheets);
        }

        public void CalculateSum()
        {
            long spentHours = 0;
            Sheets.ForEach(sheet => spentHours += sheet.SpentHours);

            _ = Contract?.CostHourWork ?? throw new NullReferenceException($"{nameof(Contract.CostHourWork)}");
            Sum = Contract.CostHourWork * spentHours;
        }

        public void Approve()
        {
            IsApproved = true;
            ApproveDate = DateTime.Now;
        }
    }
}
