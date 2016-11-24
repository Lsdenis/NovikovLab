using System;
using System.Collections.Generic;
using System.Linq;
using Lab6.Classes;
using Lab6.Enums;

namespace Lab6
{
	internal class Program
	{
		#region Task

		public static IList<Block> Blocks = new List<Block>
		{
			new Block
			{
				Obrabotchiks = new List<Obrabotchik>
				{
					new Obrabotchik {GeneraterType = GeneraterType.Gause, FirstValue = 5, SecondValue = 1},
					new Obrabotchik {GeneraterType = GeneraterType.Gause, FirstValue = 5, SecondValue = 1},
					new Obrabotchik {GeneraterType = GeneraterType.Gause, FirstValue = 5, SecondValue = 1}
				},
				Nakopitel = new Nakopitel {CountOfMaximumZayavok = 2}
			},
			new Block
			{
				Obrabotchiks = new List<Obrabotchik>
				{
					new Obrabotchik {GeneraterType = GeneraterType.Treangelr, FirstValue = 3, SecondValue = 8},
					new Obrabotchik {GeneraterType = GeneraterType.Treangelr, FirstValue = 3, SecondValue = 8},
					new Obrabotchik {GeneraterType = GeneraterType.Treangelr, FirstValue = 3, SecondValue = 8},
					new Obrabotchik {GeneraterType = GeneraterType.Treangelr, FirstValue = 3, SecondValue = 8}
				},
				Nakopitel = new Nakopitel {CountOfMaximumZayavok = 3}
			},
			new Block
			{
				Obrabotchiks = new List<Obrabotchik>
				{
					new Obrabotchik {GeneraterType = GeneraterType.Gause, FirstValue = 7, SecondValue = 2},
					new Obrabotchik {GeneraterType = GeneraterType.Gause, FirstValue = 7, SecondValue = 2},
					new Obrabotchik {GeneraterType = GeneraterType.Gause, FirstValue = 7, SecondValue = 2},
					new Obrabotchik {GeneraterType = GeneraterType.Gause, FirstValue = 7, SecondValue = 2}
				},
				Nakopitel = new Nakopitel {CountOfMaximumZayavok = 3}
			},
			new Block
			{
				Obrabotchiks = new List<Obrabotchik>
				{
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 3, SecondValue = 9},
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 3, SecondValue = 9},
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 3, SecondValue = 9},
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 3, SecondValue = 9}
				},
				Nakopitel = new Nakopitel {CountOfMaximumZayavok = 4}
			},
			new Block
			{
				Obrabotchiks = new List<Obrabotchik>
				{
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 2, SecondValue = 5},
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 2, SecondValue = 5},
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 2, SecondValue = 5},
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 2, SecondValue = 5},
					new Obrabotchik {GeneraterType = GeneraterType.Simple, FirstValue = 2, SecondValue = 5}
				},
				Nakopitel = new Nakopitel {CountOfMaximumZayavok = 2}
			}
		};

		#endregion

		public static int CountOfMaintainedZayavok = 0;
		public static int NumberOfTacts = 0;

		private static void Main(string[] args)
		{
			while (true)
			{
				var zayavka = GeneratorZayavok.GetZayavka();

				Block nextBlock = null;
				foreach (var block in Blocks.Reverse())
				{
					block.Obrabotchiks.ToList().ForEach(obrabotchik => obrabotchik.OperateZayavka());

					var obrabotchiks =
						block.Obrabotchiks.Where(obrabotchik => obrabotchik.Zayavka != null && obrabotchik.Zayavka.TimeToOperate == 0)
							.ToList();

					foreach (var obrabotchik in obrabotchiks)
					{
						var hasZayavkaBeenAdded = nextBlock?.TryMaintainNewZayavka(obrabotchik.Zayavka);

						if (nextBlock == null || hasZayavkaBeenAdded.Value)
						{
							obrabotchik.Zayavka = null;
						}

						if (nextBlock == null)
						{
							CountOfMaintainedZayavok++;
						}
					}

					block.MaintainNakopitel();

					if (block == Blocks.First())
					{
						block.TryMaintainNewZayavka(zayavka);
					}

					nextBlock = block;
				}

				NumberOfTacts++;

				Console.Clear();

				for (int index = 0; index < Blocks.Count; index++)
				{
					var block = Blocks[index];
					Console.WriteLine(string.Format("Block number {0}", index+1));

					for (int i = 0; i < block.Obrabotchiks.Count; i++)
					{
						var blockObrabotchik = block.Obrabotchiks[i];
						Console.WriteLine(string.Format("Obrabotchik number {0}, zayavka {1}, time to operate {2}", i+1, blockObrabotchik.Zayavka != null, blockObrabotchik.Zayavka?.TimeToOperate));
					}

					Console.WriteLine(string.Format("Nakopitel: {0}", block.Nakopitel.Zayavki.Count));
					Console.WriteLine(string.Format("*********************************************"));
				}
			}
		}
	}
}
