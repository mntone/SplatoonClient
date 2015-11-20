using System.Resources;
using System.Reflection;
using Mntone.SplatoonClient.Internal;

[assembly: AssemblyTitle(AssemblyInfo.QualifiedName)]
[assembly: AssemblyDescription(AssemblyInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AssemblyInfo.Author)]
[assembly: AssemblyProduct(AssemblyInfo.QualifiedName)]
[assembly: AssemblyCopyright("Copyright (C) 2015- " + AssemblyInfo.Author)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: NeutralResourcesLanguage("en")]

[assembly: AssemblyVersion("0.9.4.1")]
[assembly: AssemblyFileVersion("0.9.4.1")]

namespace Mntone.SplatoonClient.Internal
{
	internal static class AssemblyInfo
	{
		public const string Name = "Mntone.SplatoonClient";
		public const string QualifiedName = "SplatoonClient";
		public const string Description = Entities.Internal.AssemblyInfo.Description;
		public const string Version = Entities.Internal.AssemblyInfo.Version;
		public const string Author = Entities.Internal.AssemblyInfo.Author;
	}
}