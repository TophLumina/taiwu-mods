using System.IO;

namespace GameData.Domains.TaiwuEvent;

public readonly ref struct EventPackagePathInfo
{
	public readonly string DllDirPath;

	public readonly string LanguageDirPath;

	public readonly string ScriptDirPath;

	public EventPackagePathInfo(string dllDirPath, string languageDirPath, string scriptDirPath)
	{
		DllDirPath = dllDirPath;
		LanguageDirPath = languageDirPath;
		ScriptDirPath = scriptDirPath;
	}

	public EventPackagePathInfo(string rootPath)
	{
		DllDirPath = Path.Combine(rootPath, "EventLib");
		LanguageDirPath = Path.Combine(rootPath, "EventLanguages");
		ScriptDirPath = Path.Combine(rootPath, "EventScript");
	}
}
