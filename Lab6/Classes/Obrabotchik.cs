using System;
using Lab6.Enums;

namespace Lab6.Classes
{
	public class Obrabotchik
	{
		private Zayavka _zayavka;

		public Zayavka Zayavka
		{
			get { return _zayavka; }
			set
			{
				_zayavka = value;

				if (value != null)
				{
					value.TimeToOperate = GetTimeToOperateForZayavka();
				}
			}
		}

		public GeneraterType GeneraterType { get; set; }

		public int FirstValue { get; set; }

		public int SecondValue { get; set; }

		private int GetTimeToOperateForZayavka()
		{
			switch (GeneraterType)
			{
				case GeneraterType.Gause:
					return Generators.Generators.Gause(FirstValue, SecondValue);
				case GeneraterType.Treangelr:
					return Generators.Generators.Triangle(FirstValue, SecondValue);
				case GeneraterType.Simpson:
					return Generators.Generators.Simpson(FirstValue, SecondValue);
				case GeneraterType.Simple:
					return Generators.Generators.Simple(FirstValue, SecondValue);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void OperateZayavka()
		{
			if (Zayavka != null && Zayavka.TimeToOperate > 0)
			{
				Zayavka.TimeToOperate--;
			}
		}
	}
}
