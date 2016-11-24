using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Classes
{
	public class Nakopitel
	{
		public int CountOfMaximumZayavok { get; set; }

		public Queue<Zayavka> Zayavki { get; set; } = new Queue<Zayavka>();

		public bool TryToAddZayavka(Zayavka zayavka)
		{
			if (Zayavki.Count >= CountOfMaximumZayavok)
			{
				return false;
			}

			Zayavki.Enqueue(zayavka);
			return true;
		}
	}
}
