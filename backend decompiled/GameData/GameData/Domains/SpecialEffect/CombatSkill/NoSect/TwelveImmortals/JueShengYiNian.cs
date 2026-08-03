using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class JueShengYiNian : TwelveImmortalsBase
{
	private const int ChangeDamagePerMark = 15;

	private const int ChangeDamageMax = 60;

	private const int ReverseRemoveMarkCount = 6;

	private const int AddDieMarkCount = 2;

	public JueShengYiNian()
	{
	}

	public JueShengYiNian(CombatSkillKey skillKey)
		: base(skillKey, 18009)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
		CreateAffectedData(102, EDataModifyType.AddPercent, -1);
		CombatDomain.RegisterHandler_CombatCharAboutToFall(OnCombatCharAboutToFall);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		CombatDomain.UnRegisterHandler_CombatCharAboutToFall(OnCombatCharAboutToFall);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (base.IsDirect)
		{
			ShowSpecialEffectTips(1);
			ShowSpecialEffectTips(2);
		}
	}

	private void OnCombatCharAboutToFall(DataContext context, CombatCharacter combatChar, ECombatCharAboutToFallType type)
	{
		if (combatChar != base.CombatChar || type != ECombatCharAboutToFallType.JueShengYiNian)
		{
			return;
		}
		ShowSpecialEffectTips(0);
		combatChar.AddDieMark(context, SkillKey, 2);
		if (base.IsDirect)
		{
			combatChar.SetInjuries(context, combatChar.GetOldInjuries());
			DomainManager.Combat.RemoveAllFlaw(context, combatChar);
			DomainManager.Combat.RemoveAllAcupoint(context, combatChar);
			combatChar.RemoveAllMindMark(context);
			combatChar.RemoveAllFatalMark(context);
			return;
		}
		ChangeBreathValue(context, combatChar, 30000);
		ChangeStanceValue(context, combatChar, 4000);
		ShowSpecialEffectTips(1);
		DefeatMarkCollection marks = combatChar.GetDefeatMarkCollection();
		int injuryCount = combatChar.GetInjuries().Subtract(combatChar.GetOldInjuries()).GetSum();
		int removeInjuryCount = Math.Min(injuryCount, 6);
		combatChar.RemoveRandomInjury(context, removeInjuryCount);
		int flawCount = marks.GetTotalFlawCount();
		int acupointCount = marks.GetTotalAcupointCount();
		int mindCount = marks.MindMarkList.Count;
		int impairCount = flawCount + acupointCount + mindCount;
		int removeImpairCount = Math.Min(impairCount, 6);
		for (int i = 0; i < removeImpairCount; i++)
		{
			if (flawCount + acupointCount == 0 || (mindCount > 0 && context.Random.CheckPercentProb(33)))
			{
				mindCount--;
				combatChar.RemoveMindMark(context, 1, random: true);
				continue;
			}
			bool flaw = context.Random.RandomIsInner(flawCount > 0, acupointCount > 0);
			if (flaw)
			{
				flawCount--;
			}
			else
			{
				acupointCount--;
			}
			combatChar.RemoveRandomFlawOrAcupoint(context, flaw);
		}
		combatChar.RemoveFatalMark(context, 6);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		bool flag = dataKey.CharId == base.CharacterId;
		bool flag2 = flag;
		if (flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = ((fieldId == 69 || fieldId == 102) ? true : false);
			flag2 = flag3;
		}
		if (flag2 && base.IsDirect)
		{
			return Math.Min(base.CombatChar.GetDefeatMarkCollection().DieMarkList.Count * 15, 60);
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
