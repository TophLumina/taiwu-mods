namespace GameData.Adventure;

public interface IAdventureExternalBridge
{
	string Tr(AdventureLocalStringRef @ref);

	string TrFormat(AdventureLocalStringRef @ref, params object[] args)
	{
		return string.Format(Tr(@ref), args);
	}

	void LogException(string message);
}
