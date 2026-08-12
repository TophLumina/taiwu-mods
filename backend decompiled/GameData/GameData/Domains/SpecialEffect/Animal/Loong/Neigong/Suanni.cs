using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class Suanni : AnimalEffectBase
{
	private const int FatalDamageTotalPercent = 100;

	public Suanni()
	{
	}

	public Suanni(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(89, EDataModifyType.Custom, -1);
		CreateAffectedAllEnemyData(191, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId || dataKey.FieldId != 191 || !base.IsCurrent)
		{
			return 0;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam1;
		if (damageType != EDamageType.Direct)
		{
			return 0;
		}
		return 100;
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 89 || dataValue <= 0)
		{
			return dataValue;
		}
		bool isInner = dataKey.CustomParam1 == 1;
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		CombatCharacter enemyChar = base.CurrEnemyChar;
		int value = (int)Math.Clamp(dataValue, 0L, 2147483647L);
		enemyChar.AddFatalDamage(base.CombatChar.GetDataContext(), value, isInner ? 1 : 0, bodyPart, dataKey.CombatSkillId);
		ShowSpecialEffectTipsOnceInFrame(0);
		return 0L;
	}
}
