using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Common;

public class ReduceGridCost : CombatSkillEffectBase
{
	private const sbyte AddRequirementPercent = 50;

	protected ReduceGridCost()
	{
		IsLegendaryBookEffect = true;
	}

	protected ReduceGridCost(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		short skillTemplateId = base.SkillTemplateId;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 211, skillTemplateId), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 202, skillTemplateId), EDataModifyType.Add);
		DomainManager.Extra.RemoveCharacterMasteredCombatSkill(context, base.CharacterId, skillTemplateId);
	}

	public override void OnDataAdded(DataContext context)
	{
		if (DomainManager.Global.GetLoadedAllArchiveData())
		{
			DomainManager.Taiwu.GetTaiwu().UpdateAllocatedGenericGrids(context);
		}
	}

	public override void OnDisable(DataContext context)
	{
		if (DomainManager.Taiwu.GetTaiwu().IsCombatSkillEquipped(base.SkillTemplateId))
		{
			DomainManager.Taiwu.GetTaiwu().UpdateAllocatedGenericGrids(context);
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 211)
		{
			return 1;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 202)
		{
			return 50;
		}
		return 0;
	}
}
