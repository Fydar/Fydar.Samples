namespace Fydar.Samples;

public static class IRenderExporterDestinationBuilderExtensions
{
	public static void Directory(this IRenderExporterDestinationBuilder destinationBuilder, string directory)
	{
		destinationBuilder.Destination(new DirectoryDestination(directory));
	}

	public static void GitRepositoryRootDirectory(this IRenderExporterDestinationBuilder destinationBuilder, string directory)
	{

	}
}
