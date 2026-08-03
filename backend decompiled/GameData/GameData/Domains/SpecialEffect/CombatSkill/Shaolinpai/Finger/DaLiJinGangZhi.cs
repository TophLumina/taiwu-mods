using System;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Finger;

public class DaLiJinGangZhi : AddWeaponEquipAttackOnAttack
{
	private const int ChangeCount = 3;

	private int _flawCount;

	private int _acupointCount;

	protected override short AddWeaponEquipAttack => 1000;

	public DaLiJinGangZhi()
	{
	}

	public DaLiJinGangZhi(CombatSkillKey skillKey)
		: base(skillKey, 1203)
	{
	}

	protected override void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			sbyte bodyPart = base.CombatChar.SkillAttackBodyPart;
			CombatCharacter enemyChar = base.CurrEnemyChar;
			FlawOrAcupointCollection flaws = enemyChar.GetFlawCollection();
			FlawOrAcupointCollection acupoints = enemyChar.GetAcupointCollection();
			_flawCount = flaws.BodyPartDict[bodyPart].Count;
			_acupointCount = acupoints.BodyPartDict[bodyPart].Count;
			base.OnPrepareSkillEnd(context, charId, isAlly, skillId);
		}
	}

	protected override void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			sbyte bodyPart = base.CombatChar.SkillAttackBodyPart;
			CombatCharacter enemyChar = base.CurrEnemyChar;
			Injuries injuries = enemyChar.GetInjuries();
			if (_flawCount > 0 || _acupointCount > 0)
			{
				if (_flawCount > 0)
				{
					int removedCount = Math.Min(3, _flawCount);
					int injuryCount = Math.Min(removedCount, 6 - injuries.Get(bodyPart, !base.IsDirect));
					enemyChar.RemoveRandomFlawOrAcupoint(context, isFlaw: true, removedCount);
					enemyChar.AddInjury(context, bodyPart, !base.IsDirect, (sbyte)injuryCount);
					enemyChar.AddFatalMark(context, removedCount - injuryCount, (!base.IsDirect) ? ((sbyte)1) : ((sbyte)0), bodyPart);
				}
				if (_acupointCount > 0)
				{
					int removedCount2 = Math.Min(3, _acupointCount);
					int injuryCount2 = Math.Min(removedCount2, 6 - injuries.Get(bodyPart, !base.IsDirect));
					enemyChar.RemoveRandomFlawOrAcupoint(context, isFlaw: false, removedCount2);
					enemyChar.AddInjury(context, bodyPart, !base.IsDirect, (sbyte)injuryCount2);
					enemyChar.AddFatalMark(context, removedCount2 - injuryCount2, (!base.IsDirect) ? ((sbyte)1) : ((sbyte)0), bodyPart);
				}
				DomainManager.Combat.UpdateBodyDefeatMark(context, enemyChar, bodyPart);
				ShowSpecialEffectTips(1);
			}
		}
		base.OnCastSkillEnd(context, charId, isAlly, skillId, power, interrupted);
	}
}
