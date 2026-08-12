namespace GameData.Domains.SpecialEffect;

public interface ISpecialEffectModifier
{
	int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		return 0;
	}

	bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		return dataValue;
	}

	int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		return dataValue;
	}
}
