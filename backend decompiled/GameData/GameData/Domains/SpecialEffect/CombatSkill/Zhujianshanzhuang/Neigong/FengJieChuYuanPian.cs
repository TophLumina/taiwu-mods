using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Neigong;

public class FengJieChuYuanPian : ReduceMainAttributeCharacter
{
	private const int UnitAffect = 2;

	private int MaxAddValue => base.IsDirect ? 100 : 50;

	protected override bool DirectIsAlly => true;

	protected override IReadOnlyList<ushort> FieldIds { get; } = new ushort[2] { 313, 315 };

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	protected override int CurrAddValue => Math.Min(base.CurrMainAttribute / 2, MaxAddValue) * (base.IsDirect ? 1 : (-1));

	protected override sbyte MainAttributeType => 2;

	public FengJieChuYuanPian()
	{
	}

	public FengJieChuYuanPian(CombatSkillKey skillKey)
		: base(skillKey, 9005)
	{
	}

	protected override IEnumerable<DataUid> GetUpdateAffectingDataUids()
	{
		yield return ParseCombatCharacterDataUid(50);
		int[] characterList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		foreach (int charId in characterList)
		{
			if (charId >= 0)
			{
				yield return ParseCombatCharacterDataUid(charId, 50);
			}
		}
	}

	protected override bool IsTargetMatchAffect(CombatCharacter target)
	{
		return DomainManager.Combat.IsCharacterHalfFallen(target);
	}

	protected override void OnAffected()
	{
		ShowSpecialEffectTips(0);
		ShowSpecialEffectTips(1);
	}
}
