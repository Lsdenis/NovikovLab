using System.Collections.Generic;
using System.Linq;

namespace Lab6.Classes
{
	public class Block
	{
		public IList<Obrabotchik> Obrabotchiks { get; set; } = new List<Obrabotchik>();

		public Nakopitel Nakopitel { get; set; }

		public bool TryMaintainNewZayavka(Zayavka zayavka)
		{
			var obrabotchikToAddZayavka = Obrabotchiks.FirstOrDefault(obrabotchik => obrabotchik.Zayavka == null);

			if (obrabotchikToAddZayavka == null)
			{
				return Nakopitel.TryToAddZayavka(zayavka);
			}

			obrabotchikToAddZayavka.Zayavka = zayavka;
			return true;
		}

		public void MaintainNakopitel()
		{
			for (int i = 0; i < Obrabotchiks.Count(obrabotchik => obrabotchik.Zayavka == null); i++)
			{
				if (Nakopitel.Zayavki.Count == 0)
				{
					return;
				}

				var zayavka = Nakopitel.Zayavki.Peek();

				if (zayavka == null)
				{
					return;
				}

				if (TryMaintainNewZayavka(zayavka))
				{
					Nakopitel.Zayavki.Dequeue();
				}
			}
		}
	}
}
