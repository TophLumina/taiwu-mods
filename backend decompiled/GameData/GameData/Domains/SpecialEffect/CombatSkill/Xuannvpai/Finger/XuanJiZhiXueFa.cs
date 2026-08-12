using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Finger;

public class XuanJiZhiXueFa : CombatSkillEffectBase
{
	private sbyte[] _maxLevel = new sbyte[7];

	public XuanJiZhiXueFa()
	{
	}

	public XuanJiZhiXueFa(CombatSkillKey skillKey)
		: base(skillKey, 8206, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		FlawOrAcupointCollection srcCollection = (base.IsDirect ? base.CurrEnemyChar.GetFlawCollection() : base.CurrEnemyChar.GetAcupointCollection());
		for (sbyte part = 0; part < 7; part++)
		{
			_maxLevel[part] = -1;
			foreach (FlawOrAcupointEntry entry in srcCollection.BodyPartDict[part])
			{
				if (entry.Level > _maxLevel[part])
				{
					_maxLevel[part] = entry.Level;
				}
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			bool affected = false;
			for (sbyte part = 0; part < 7; part++)
			{
				sbyte level = _maxLevel[part];
				if (level >= 0)
				{
					if (base.IsDirect)
					{
						DomainManager.Combat.AddAcupoint(context, base.CurrEnemyChar, level, SkillKey, part);
					}
					else
					{
						DomainManager.Combat.AddFlaw(context, base.CurrEnemyChar, level, SkillKey, part);
					}
					affected = true;
				}
			}
			if (affected)
			{
				ShowSpecialEffectTips(0);
				DomainManager.Combat.AddToCheckFallenSet(base.CurrEnemyChar.GetId());
			}
		}
		RemoveSelf(context);
	}
}
