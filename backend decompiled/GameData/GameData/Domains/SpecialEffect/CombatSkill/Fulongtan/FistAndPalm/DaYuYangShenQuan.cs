using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;

public class DaYuYangShenQuan : PowerUpOnCast
{
	private CValuePercent AddPowerPercent => base.IsDirect ? 40 : 80;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	public DaYuYangShenQuan()
	{
	}

	public DaYuYangShenQuan(CombatSkillKey skillKey)
		: base(skillKey, 14107)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true);
		SkillEffectCollection effectCollection = (base.IsDirect ? base.CombatChar : enemyChar).GetSkillEffectCollection();
		Dictionary<SkillEffectKey, short> effectDict = effectCollection.EffectDict;
		if (effectDict != null && effectDict.Count > 0)
		{
			int totalPercent = 0;
			int effectCount = 0;
			foreach (KeyValuePair<SkillEffectKey, short> effect in effectDict)
			{
				int percent = effect.Value * 100 / effectCollection.MaxEffectCountDict[effect.Key];
				totalPercent += (base.IsDirect ? percent : (100 - percent)) * AddPowerPercent;
				effectCount++;
			}
			if (effectCount == 0)
			{
				PowerUpValue = 0;
			}
			else
			{
				PowerUpValue = totalPercent / effectCount;
			}
		}
		base.OnEnable(context);
	}
}
