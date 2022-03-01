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
		public int SpentHours { get; private set; }

		public virtual Contract Contract { get; private set; }

		public void Create(int spentHours, Contract contract)
        {
			Contract = contract;
			SpentHours = spentHours;
		}
	}
}
