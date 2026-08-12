using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Stunt : FeatureEffectBase
{
	private const short AddPowerPercent = 100;

	public Stunt()
	{
	}

	public Stunt(int charId, short featureId)
		: base(charId, featureId, 41402)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		sbyte equipType = Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType;
		if (equipType != 3 && equipType != 4)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 100;
		}
		return 0;
	}
}
