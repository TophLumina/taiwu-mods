using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Leg;

public class XueYingTui : BuffByNeiliAllocation
{
	private const sbyte ReduceCostPercent = 75;

	public XueYingTui()
	{
	}

	public XueYingTui(CombatSkillKey skillKey)
		: base(skillKey, 15307)
	{
		RequireNeiliAllocationType = 0;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 204, base.SkillTemplateId), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 207, base.SkillTemplateId), EDataModifyType.TotalPercent);
	}

	protected override void OnInvalidCache(DataContext context)
	{
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 204);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 207);
		DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
	}

	protected override int GetAffectedModifyValue(AffectedDataKey dataKey)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 204 || fieldId == 207) ? true : false)
		{
			return -75;
		}
		return 0;
	}
}
