using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Music;

public class YuFeiYin : CombatSkillEffectBase
{
	private const sbyte StartCastNeiliAllocation = 3;

	private const sbyte FullPowerNeiliAllocation = 6;

	public YuFeiYin()
	{
	}

	public YuFeiYin(CombatSkillKey skillKey)
		: base(skillKey, 3303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		ChangeAllNeiliAllocation(context, 3);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (PowerMatchAffectRequire(power))
			{
				ChangeAllNeiliAllocation(context, 6);
			}
			RemoveSelf(context);
		}
	}

	private unsafe void ChangeAllNeiliAllocation(DataContext context, sbyte changeValue)
	{
		CombatCharacter changeChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
		NeiliAllocation currNeiliAllocation = changeChar.GetNeiliAllocation();
		NeiliAllocation originNeiliAllocation = changeChar.GetOriginNeiliAllocation();
		bool affected = false;
		for (byte type = 0; type < 4; type++)
		{
			if (base.IsDirect ? (currNeiliAllocation.Items[(int)type] < originNeiliAllocation.Items[(int)type]) : (currNeiliAllocation.Items[(int)type] > originNeiliAllocation.Items[(int)type]))
			{
				changeChar.ChangeNeiliAllocation(context, type, base.IsDirect ? changeValue : (-changeValue));
				affected = true;
			}
		}
		if (affected)
		{
			ShowSpecialEffectTips(0);
		}
	}
}
