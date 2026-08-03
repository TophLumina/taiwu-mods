using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;

public class YaoTuQiShu : CombatSkillEffectBase
{
	public YaoTuQiShu()
	{
	}

	public YaoTuQiShu(CombatSkillKey skillKey)
		: base(skillKey, 13305, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(317, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_ShaTrickInsteadCostTricks(OnShaTrickInsteadCostTricks);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_CastSkillTrickCosted(OnCastSkillTrickCosted);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ShaTrickInsteadCostTricks(OnShaTrickInsteadCostTricks);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_CastSkillTrickCosted(OnCastSkillTrickCosted);
	}

	private void OnShaTrickInsteadCostTricks(DataContext context, CombatCharacter character, short skillId)
	{
		if (SkillKey.IsMatch(character.GetId(), skillId))
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
			DomainManager.Combat.UpdateSkillCostTrickCanUse(context, base.CombatChar);
		}
	}

	private void OnCastSkillTrickCosted(DataContext context, CombatCharacter combatChar, short skillId, List<NeedTrick> costTricks)
	{
		if (combatChar.GetId() == base.CharacterId && base.EffectCount > 0)
		{
			int count = costTricks.Sum((NeedTrick x) => (x.TrickType != 19) ? x.NeedCount : 0);
			if (count > 0)
			{
				ReduceEffectCount();
				ShowSpecialEffectTips(1);
				DomainManager.Combat.AddTrick(context, base.IsDirect ? base.CombatChar : base.EnemyChar, 19, count);
			}
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 317)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		bool costSelfShaTrick = dataKey.CustomParam0 == 1;
		return costSelfShaTrick == base.IsDirect;
	}
}
