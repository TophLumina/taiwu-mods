using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class BaoPingQiGongFa : ReduceMainAttributeCharacter
{
	private const int NeedCount = 3;

	private const int UnitAffect = 2;

	private int MaxAddValue => base.IsDirect ? 50 : 100;

	protected override sbyte MainAttributeType => 5;

	protected override bool DirectIsAlly => false;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	protected override int CurrAddValue => Math.Min(base.CurrMainAttribute / 2, MaxAddValue) * ((!base.IsDirect) ? 1 : (-1));

	protected override IReadOnlyList<ushort> FieldIds { get; } = new ushort[4] { 38, 39, 40, 41 };

	public BaoPingQiGongFa()
	{
	}

	public BaoPingQiGongFa(CombatSkillKey skillKey)
		: base(skillKey, 11003)
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
		DefeatMarkCollection marks = target.GetDefeatMarkCollection();
		return marks.NeiliAllocationMarkCount.scatter + marks.NeiliAllocationMarkCount.bulge >= 3;
	}

	protected override void OnAffected()
	{
		ShowSpecialEffectTips(0);
	}
}
