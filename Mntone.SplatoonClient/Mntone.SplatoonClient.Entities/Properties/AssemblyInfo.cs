using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using Mntone.SplatoonClient.Entities.Internal;

[assembly: AssemblyTitle(AssemblyInfo.QualifiedName)]
[assembly: AssemblyDescription(AssemblyInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AssemblyInfo.Author)]
[assembly: AssemblyProduct(AssemblyInfo.QualifiedName)]
[assembly: AssemblyCopyright("Copyright (C) 2015- " + AssemblyInfo.Author)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("0.9.4.2")]
[assembly: AssemblyFileVersion("0.9.4.2")]

[assembly: InternalsVisibleTo("Mntone.SplatoonClient")]
[assembly: InternalsVisibleTo("Mntone.SplatoonClient.Windows")]

namespace Mntone.SplatoonClient.Entities.Internal
{
	internal static class AssemblyInfo
	{
		public const string Name = "Mntone.SplatoonClient.Entities";
		public const string QualifiedName = "SplatoonClient (Entities)";
		public const string Description = "Get friends and stages information from “SplatNet (JPN: イカリング)”";
        public const string Version = "0.9.4.2";
		public const string Author = "mntone";
	}
}