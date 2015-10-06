using System;
using System.Collections.Generic;
using System.Linq;

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
			ViewSchedule(ctx);

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

		private static void ViewSchedule(SplatoonContext ctx)
		{
			var scheduleResponse = ctx.GetScheduleAsync().GetAwaiter().GetResult();

			foreach (var schedule in scheduleResponse.Schedule)
			{
				Console.WriteLine($"{schedule.BeginDateTime} ~ {schedule.EndDateTime}");

				Console.Write($"Regular Battle [Turf War]:\t{schedule.Stages.Regular[0].Name}");
				foreach (var stage in schedule.Stages.Regular.Skip(1)) Console.Write($" / {stage.Name}");
				Console.WriteLine();

				Console.Write($"Ranked Battle [{schedule.GachiRule}]:\t{schedule.Stages.Gachi[0].Name}");
				foreach (var stage in schedule.Stages.Gachi.Skip(1)) Console.Write($" / {stage.Name}");
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