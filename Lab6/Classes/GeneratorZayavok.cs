using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Classes
{
	public static class GeneratorZayavok
	{
		private static readonly Random Random = new Random(DateTime.Now.Millisecond);
		private static int _currentValue;
		private static int _numberOfCurrentZayavok;

		public static Zayavka GetZayavka()
		{
			if (_numberOfCurrentZayavok == 10000)
			{
				return null;
			}

			if (_currentValue <= 0)
			{
				var randomNumber = Math.Log(1 - Random.NextDouble()) / -1;
				_currentValue = Convert.ToInt32(randomNumber * 10);
				_numberOfCurrentZayavok++;
				return new Zayavka();
			}

			_currentValue--;
			return null;
		}
	}
}
