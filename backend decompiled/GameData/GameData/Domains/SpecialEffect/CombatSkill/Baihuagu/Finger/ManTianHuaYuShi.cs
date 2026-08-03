using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class ManTianHuaYuShi : CombatSkillEffectBase
{
	private const int FlawOrAcupointLevel = 1;

	private const sbyte AffectOdds = 30;

	public ManTianHuaYuShi()
	{
	}

	public ManTianHuaYuShi(CombatSkillKey skillKey)
		: base(skillKey, 3104, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		int addCount = 0;
		int randomCount = power / GetAffectRequirePower();
		for (int i = 0; i < randomCount; i++)
		{
			if (context.Random.CheckPercentProb(30))
			{
				addCount++;
			}
		}
		if (addCount > 0)
		{
			for (int j = 0; j < addCount; j++)
			{
				if (base.IsDirect)
				{
					DomainManager.Combat.AddAcupoint(context, base.CurrEnemyChar, 1, SkillKey, -1);
				}
				else
				{
					DomainManager.Combat.AddFlaw(context, base.CurrEnemyChar, 1, SkillKey, -1);
				}
			}
			ShowSpecialEffectTips(0);
		}
		RemoveSelf(context);
	}
}
