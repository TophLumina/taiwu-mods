using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class LiuShenWeiDao : BuffByNeiliAllocation
{
	private int _directDamageAddPercent;

	protected override bool ShowTipsOnAffecting => false;

	public LiuShenWeiDao()
	{
	}

	public LiuShenWeiDao(CombatSkillKey skillKey)
		: base(skillKey, 11207)
	{
		RequireNeiliAllocationType = 2;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 69, -1), EDataModifyType.AddPercent);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.Affecting)
		{
			short selfNeiliAllocation = base.CombatChar.GetNeiliAllocation()[RequireNeiliAllocationType];
			short enemyNeiliAllocation = base.CurrEnemyChar.GetNeiliAllocation()[RequireNeiliAllocationType];
			_directDamageAddPercent = (base.IsDirect ? (selfNeiliAllocation - enemyNeiliAllocation) : (enemyNeiliAllocation - selfNeiliAllocation));
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_directDamageAddPercent = 0;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.CombatSkillId == base.SkillTemplateId && dataKey.FieldId == 69)
		{
			return _directDamageAddPercent;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
