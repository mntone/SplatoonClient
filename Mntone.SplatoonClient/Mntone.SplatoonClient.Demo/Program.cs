using System;
using System.Collections.Generic;

namespace Mntone.SplatoonClient.Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Please input your NNID.");
			Console.Write("Username: ");
			var username = Console.ReadLine();
			Console.Write("Password: ");
			var password = GetPassword();
			Console.WriteLine("");
			Console.WriteLine("-----------");

			var ctx = SplatoonContextFactory.GetContextAsync(username, password).GetAwaiter().GetResult();
			ViewFriends(ctx);
			ViewStages(ctx);
			
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

		private static void ViewFriends(SplatoonContext ctx)
		{
			var friends = ctx.GetFriendsAsync().GetAwaiter().GetResult();
			foreach (var friend in friends)
			{
				Console.WriteLine($"{friend.Name}: {friend.Mode}");
			}
			Console.WriteLine("-----------");
		}

		private static void ViewStages(SplatoonContext ctx)
		{
			var stages = ctx.GetStagesAsync().GetAwaiter().GetResult();

			foreach (var s in stages.StageInformation)
			{
				Console.WriteLine($"{s.TimePeriod.BeginTime} ~ {s.TimePeriod.EndTime}");
				Console.WriteLine($"Regular Battle [Turf War]:\t{s.RegularBattleStages[0].Name} / {s.RegularBattleStages[1].Name}");
				Console.WriteLine($"Ranked Battle [{s.RankedBattleRule}]:\t{s.RankedBattleStages[0].Name} / {s.RankedBattleStages[1].Name}");
				Console.WriteLine();
			}
			Console.WriteLine("-----------");
		}

		private static string GetPassword()
		{
			var inputList = new List<char>();

			ConsoleKeyInfo info;
			while ((info = Console.ReadKey(true)).Key != ConsoleKey.Enter)
			{
				if (info.Key == ConsoleKey.Backspace)
				{
					if (inputList.Count != 0)
					{
						inputList.RemoveAt(inputList.Count - 1);

						var indexMinusOne = Console.CursorLeft - 1;
						Console.SetCursorPosition(indexMinusOne, Console.CursorTop);
						Console.Write(" ");
						Console.SetCursorPosition(indexMinusOne, Console.CursorTop);
					}
					continue;
				}

				Console.Write("*");
				inputList.Add(info.KeyChar);
			}

			return string.Concat(inputList);
		}
	}
}