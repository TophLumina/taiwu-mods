using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Neutral;

public class BiENiWan : MysteryEffectBase
{
	private const int ImmunityOdds = 33;

	protected override short SpecialEffectId => 1762;

	public BiENiWan()
	{
	}

	public BiENiWan(int charId, int itemId)
		: base(charId, itemId, 50009)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(303, EDataModifyType.Custom, -1);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 303)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Direct)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		int prevValue = dataValue;
		DataContext context = DomainManager.Combat.Context;
		for (int i = 0; i < dataValue; i++)
		{
			if (context.Random.CheckPercentProb(33))
			{
				dataValue--;
			}
		}
		if (prevValue > dataValue)
		{
			ShowSpecialEffect(0);
		}
		return dataValue;
	}
}
