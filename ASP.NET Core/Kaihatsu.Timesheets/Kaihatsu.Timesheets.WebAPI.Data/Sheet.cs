using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
	public class Sheet : ItemBase
	{
		public DateTime ApproveDate { get; private set; }
		public bool IsApproved { get; private set; }
		public int SpentHours { get; private set; }

		public void Create(int spentHours)
        {
			SpentHours = spentHours;
		}

		public void Approve()
		{
			IsApproved = true;
			ApproveDate = DateTime.Now;
		}
	}
}
