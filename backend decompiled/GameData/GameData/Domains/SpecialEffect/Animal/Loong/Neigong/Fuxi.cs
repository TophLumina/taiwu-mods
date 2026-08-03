using System;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class Fuxi : AnimalEffectBase
{
	private static readonly sbyte[] HitOrAvoidLifeSkillTypes = new sbyte[4] { 0, 1, 2, 3 };

	private static readonly sbyte[] PenetrateOrResistLifeSkillTypes = new sbyte[4] { 7, 6, 10, 11 };

	private static readonly ushort[] HitAvoidFieldIds = new ushort[8] { 60, 61, 62, 63, 90, 91, 92, 93 };

	private static readonly ushort[] PenetrateOrResistFieldIds = new ushort[4] { 66, 67, 98, 99 };

	public Fuxi()
	{
	}

	public Fuxi(CombatSkillKey skillKey)
		: base(skillKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		ushort[] hitAvoidFieldIds = HitAvoidFieldIds;
		foreach (ushort fieldId in hitAvoidFieldIds)
		{
			CreateAffectedData(fieldId, EDataModifyType.Custom, -1);
		}
		ushort[] penetrateOrResistFieldIds = PenetrateOrResistFieldIds;
		foreach (ushort fieldId2 in penetrateOrResistFieldIds)
		{
			CreateAffectedData(fieldId2, EDataModifyType.Custom, -1);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.IsCurrent)
		{
			return dataValue;
		}
		int maxValue = GetMaxValue(dataKey.FieldId);
		return Math.Min(dataValue, maxValue);
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.IsCurrent)
		{
			return dataValue;
		}
		int maxValue = GetMaxValue(dataKey.FieldId);
		return Math.Min(dataValue, maxValue);
	}

	private int GetMaxValue(ushort fieldId)
	{
		GameData.Domains.Character.Character character = base.CurrEnemyChar.GetCharacter();
		sbyte[] lifeSkillTypes = Array.Empty<sbyte>();
		if (Enumerable.Contains(HitAvoidFieldIds, fieldId))
		{
			lifeSkillTypes = HitOrAvoidLifeSkillTypes;
		}
		if (Enumerable.Contains(PenetrateOrResistFieldIds, fieldId))
		{
			lifeSkillTypes = PenetrateOrResistLifeSkillTypes;
		}
		return lifeSkillTypes.Sum((sbyte x) => character.GetLifeSkillAttainment(x));
	}
}
