using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class YuanYangLianHuanJiao : CombatSkillEffectBase
{
	private const int ReduceCostUnit = -25;

	private const int MaxReduceCost = -75;

	private int _reduceCost;

	public YuanYangLianHuanJiao()
	{
	}

	public YuanYangLianHuanJiao(CombatSkillKey skillKey)
		: base(skillKey, 5101, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 206 : 205), base.SkillTemplateId), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 207, base.SkillTemplateId), EDataModifyType.TotalPercent);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power) && _reduceCost != -75)
		{
			_reduceCost += -25;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 206 : 205));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 207);
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 205) <= 2u)
		{
			return _reduceCost;
		}
		return 0;
	}
}
