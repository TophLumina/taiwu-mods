using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;

public class DingYingShenZhen : CombatSkillEffectBase
{
	private const sbyte AcupointLevel = 3;

	private const sbyte AcupointCount = 3;

	private static readonly CValuePercent ReduceMobilityPercent = 50;

	public DingYingShenZhen()
	{
	}

	public DingYingShenZhen(CombatSkillKey skillKey)
		: base(skillKey, 13307, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_GetShaTrick(OnGetShaTrick);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_GetShaTrick(OnGetShaTrick);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnGetShaTrick(DataContext context, int charId, bool isAlly, bool real)
	{
		if (!base.IsCurrent || base.EffectCount <= 0 || (base.IsDirect ? (charId != base.CharacterId) : (base.CombatChar.IsAlly == isAlly)))
		{
			return;
		}
		ReduceEffectCount();
		int reduceValue = GlobalConfig.Instance.MaxMobility * ReduceMobilityPercent;
		ChangeMobilityValue(context, base.EnemyChar, -reduceValue);
		ShowSpecialEffectTips(0);
		if (base.EnemyChar.GetMobilityValue() <= 0)
		{
			ShowSpecialEffectTips(1);
			for (int i = 0; i < 3; i++)
			{
				DomainManager.Combat.AddAcupoint(context, base.EnemyChar, 3, SkillKey, -1);
			}
		}
	}
}
