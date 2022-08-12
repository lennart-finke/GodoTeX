using System.Linq;

// Kind courtesy of Matt Leibow
// See https://github.com/mono/SkiaSharp/issues/2200

// This fixes the build configuration on Linux and will become obsolete in 
// part by depending on a future version of SkiaSharp.

static class InitSkia
{
	static InitSkia()
	{
		var assembly = typeof(SkiaSharp.SkiaSharpVersion).Assembly;
		var config = assembly.DefinedTypes.FirstOrDefault(t => t.Name == "PlatformConfiguration");
		var overrideProp = config.GetProperty("LinuxFlavor");
		overrideProp.SetValue(null, "linux");
	}
	
	public static void Init() {}
}
