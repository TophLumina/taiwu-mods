using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Neigong;

public class LiHunGong : ReduceMainAttributeCharacter
{
	private const int NeedCount = 2;

	private const int AddValueUnit = 10;

	private const int MaxAddValue = 1000;

	protected override sbyte MainAttributeType => 3;

	protected override bool DirectIsAlly => false;

	protected override IReadOnlyList<ushort> FieldIds { get; } = new ushort[1] { 245 };

	protected override EDataModifyType ModifyType => EDataModifyType.Add;

	protected override int CurrAddValue => Math.Min(base.CurrMainAttribute * 10, 1000) * ((!base.IsDirect) ? 1 : (-1));

	public LiHunGong()
	{
	}

	public LiHunGong(CombatSkillKey skillKey)
		: base(skillKey, 12005)
	{
	}

	protected override IEnumerable<DataUid> GetUpdateAffectingDataUids()
	{
		yield return ParseCharDataUid(58);
		int[] characterList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		foreach (int charId in characterList)
		{
			if (charId >= 0)
			{
				yield return ParseCharDataUid(charId, 58);
			}
		}
	}

	protected override bool IsTargetMatchAffect(CombatCharacter target)
	{
		int wugCount = 0;
		EatingItems eatingItems = target.GetCharacter().GetEatingItems();
		for (int i = 0; i < 9; i++)
		{
			ItemKey key = eatingItems.Get(i);
			if (EatingItems.IsWug(key))
			{
				wugCount++;
			}
		}
		return wugCount >= 2;
	}

	protected override void OnAffected()
	{
		ShowSpecialEffectTips(0);
	}
}
