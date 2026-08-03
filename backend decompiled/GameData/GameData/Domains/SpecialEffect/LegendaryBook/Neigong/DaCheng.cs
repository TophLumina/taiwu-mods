using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Neigong;

public class DaCheng : CombatSkillEffectBase
{
	private const sbyte ChangeSpecificGrid = 1;

	private const sbyte ChangeGenericGrid = -3;

	public DaCheng()
	{
		IsLegendaryBookEffect = true;
	}

	public DaCheng(CombatSkillKey skillKey)
		: base(skillKey, 40004, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 213, base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 214, base.SkillTemplateId), EDataModifyType.Add);
	}

	public override void OnDataAdded(DataContext context)
	{
		if (DomainManager.Global.GetLoadedAllArchiveData() && DomainManager.Taiwu.GetTaiwu().IsCombatSkillEquipped(base.SkillTemplateId))
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

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 213)
		{
			return 1;
		}
		if (dataKey.FieldId == 214)
		{
			return -3;
		}
		return 0;
	}
}
