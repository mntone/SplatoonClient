using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using Mntone.SplatoonClient.Entities.Internal;

[assembly: AssemblyTitle(AssemblyInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AssemblyInfo.Author)]
[assembly: AssemblyProduct(AssemblyInfo.Name)]
[assembly: AssemblyCopyright("Copyright (C) 2015- " + AssemblyInfo.Author)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion(AssemblyInfo.Version)]
[assembly: AssemblyFileVersion(AssemblyInfo.Version)]

[assembly: InternalsVisibleTo("Mntone.SplatoonClient")]

namespace Mntone.SplatoonClient.Entities.Internal
{
	internal static class AssemblyInfo
	{
		public const string Name = "Mntone.SplatoonClient.Entities";
		public const string QualifiedName = "SplatoonClient (Entities)";
		public const string Version = "0.9.2.0";
		public const string Author = "mntone";
	}
}