namespace GameData.Domains.Building;

public interface IBuildingEffectValue
{
	void Change(int delta);

	void Change(int index, int delta);

	int Get();

	int Get(int index);

	void Clear();
}
