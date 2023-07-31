namespace Protocol.Generator
{
	using System;
	using System.IO;
	using System.Reflection;

	internal class Program
	{
		private static void Main(string[] args)
		{
			string solutionDir = String.Join(" ", args);

			var assemblyConfigurationAttribute = typeof(ModelGenerator).Assembly.GetCustomAttribute<AssemblyConfigurationAttribute>();
			var buildConfigurationName = assemblyConfigurationAttribute?.Configuration;

			string code;

			try
			{
				code = ModelGenerator.GenerateCode(Path.Combine(solutionDir, "Protocol.Generator", "bin", buildConfigurationName, "net472",
					"Skyline", "XSD", "protocol.xsd"));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				Environment.Exit(-1);
				return;
			}

			try
			{
				File.WriteAllText(Path.Combine(solutionDir, "Protocol", "GeneratedCode.g.cs"), code);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				Environment.Exit(-2);
			}
		}
	}
}