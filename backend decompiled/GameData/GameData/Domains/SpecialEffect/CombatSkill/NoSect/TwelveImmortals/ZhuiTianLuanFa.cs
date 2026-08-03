using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class ZhuiTianLuanFa : TwelveImmortalsBase
{
	private static CValuePercent FatalDamagePercent => 50;

	private sbyte FlawOrAcupointLevel => (sbyte)((!base.IsDirect) ? 1 : 2);

	public ZhuiTianLuanFa()
	{
	}

	public ZhuiTianLuanFa(CombatSkillKey skillKey)
		: base(skillKey, 18002)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AddDirectFatalDamage(OnAddDirectFatalDamage);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectFatalDamage(OnAddDirectFatalDamage);
		base.OnDisable(context);
	}

	private void OnAddDirectFatalDamage(CombatContext context, OuterAndInnerInts damage, OuterAndInnerInts markCounts)
	{
		int markCount = markCounts.Sum;
		CombatCharacter defender = context.Defender;
		if (context.AttackerId != base.CharacterId || defender.IsAlly == base.CombatChar.IsAlly || markCount <= 0)
		{
			return;
		}
		sbyte level = FlawOrAcupointLevel;
		for (int i = 0; i < markCount; i++)
		{
			bool inner = context.Random.CheckPercentProb(50);
			if (inner)
			{
				DomainManager.Combat.AddAcupoint(context, defender, level, CombatSkillKey.Invalid, -1);
			}
			else
			{
				DomainManager.Combat.AddFlaw(context, defender, level, CombatSkillKey.Invalid, -1);
			}
			ShowSpecialEffectTipsOnceInFrame(inner, 1, 0);
		}
		if (!base.IsDirect)
		{
			base.CombatChar.AddFatalDamage(context, damage.Sum * FatalDamagePercent, -1, -1, -1);
		}
	}
}
