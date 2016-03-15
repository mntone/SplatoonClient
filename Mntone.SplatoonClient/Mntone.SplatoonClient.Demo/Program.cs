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
			ViewMyId(ctx);
			ViewFriends(ctx);
			ViewRanking(ctx);
			ViewProfile(ctx);
			ViewSchedule(ctx);
			ctx.SignOutAsync().GetAwaiter().GetResult();

			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
		}

		private static void ViewMyId(SplatoonContext ctx)
		{
			var id = ctx.GetMyIdAsync().GetAwaiter().GetResult();
			Console.WriteLine($"My ID: {id}");
			Console.WriteLine("-----------");
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

		private static void ViewRanking(SplatoonContext ctx)
		{
			var ranking = ctx.GetRankingAsync().GetAwaiter().GetResult();

			Console.WriteLine("---[ Regular Battle ]--------");
			foreach (var user in ranking.Regular)
			{
				Console.WriteLine($"{user.Rank}: {user.Name} ({user.Score})");
			}

			Console.WriteLine("---[ Ranked Battle ]--------");
			foreach (var user in ranking.Gachi)
			{
				Console.WriteLine($"{user.Rank}: {user.Name} ({user.Score})");
			}

			Console.WriteLine("---[ Splatfest ]--------");
			foreach (var user in ranking.Festival)
			{
				var mark = user.Top100 ? "★" : "";
				Console.WriteLine($"{user.Rank}{mark}: {user.Name} ({user.Score})");
			}
			Console.WriteLine("-----------");
		}

		private static void ViewProfile(SplatoonContext ctx)
		{
			var profile = ctx.GetProfileAsync().GetAwaiter().GetResult();

			Console.WriteLine("---[ Your profile ]--------");
			Console.WriteLine($"Name:\t{profile.Name}");
			Console.WriteLine($"Rank:\t{profile.Rank}");
			Console.WriteLine($"Udemae:\t{profile.Udemae}");
			Console.WriteLine("-----------");
		}

		private static void ViewSchedule(SplatoonContext ctx)
		{
			var scheduleResponse = ctx.GetScheduleAsync().GetAwaiter().GetResult();

			if (scheduleResponse.IsFestival)
			{
				foreach (var schedule in scheduleResponse.Schedule)
				{
					Console.WriteLine($"{schedule.BeginDateTime} ~ {schedule.EndDateTime}");

					Console.Write($"Splatfest [Turf War]:\t{schedule.Stages.Regular[0].Name}");
					foreach (var stage in schedule.Stages.Regular.Skip(1)) Console.Write($" / {stage.Name}");
					Console.WriteLine();
				}
			}
			else
			{
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