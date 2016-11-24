using System;

namespace Lab6.Generators
{
	public static class Generators
	{
		public static int Gause(int M, double q)
		{
			var n = 6;
			double result = 0;
			for (var i = 0; i < n; i++)
				result += new Random().NextDouble();
			result -= n/2;
			result *= Math.Pow(12/n, 1/2)*q;
			result += M;
			return (int) Math.Round(result);
		}

		public static int Triangle(int a, int b)
		{
			return (int) Math.Round(a + (b - a)*Math.Max(new Random().NextDouble(), new Random().NextDouble()));
		}

		public static int Simpson(int a, int b)
		{
			//double X = Simple(a/2,b/2) + Simple(a / 2, b / 2);
			//if (X <= (a + b) / 2)
			//    return (int)((4 * (X - a)) / Math.Pow(b - a, 2));
			//else
			//    return (int)((4 * (b - X)) / Math.Pow(b - a, 2));
			return (int) Math.Round(a + (new Random().NextDouble() + new Random().NextDouble())/2.0*(b - a));
		}

		public static int Simple(int a, int b)
		{
			return (int) Math.Round(a + new Random().NextDouble()*(b - a));
		}
	}
}
