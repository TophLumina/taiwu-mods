using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;

public class HunTianYiXingGong : AgileSkillBase
{
	private const sbyte DirectDistance = 90;

	private const sbyte ReverseDistance = 50;

	public HunTianYiXingGong()
	{
	}

	public HunTianYiXingGong(CombatSkillKey skillKey)
		: base(skillKey, 13408)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AppendAffectedData(context, base.CharacterId, 157, EDataModifyType.Custom, -1);
		sbyte targetDistance = (sbyte)(base.IsDirect ? 90 : 50);
		if (targetDistance != DomainManager.Combat.GetCurrentDistance())
		{
			DomainManager.Combat.ChangeDistance(context, base.CombatChar, targetDistance - DomainManager.Combat.GetCurrentDistance());
		}
		ClearAffectedData(context);
	}

	public override void OnDataAdded(DataContext context)
	{
		AppendAffectedAllEnemyData(context, 151, EDataModifyType.Custom, -1);
		ShowSpecialEffectTips(0);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 157)
		{
			return false;
		}
		return dataValue;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (base.CombatChar.GetAffectingMoveSkillId() != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 151 && dataKey.CustomParam0 == (base.IsDirect ? 1 : 0))
		{
			return 0;
		}
		return dataValue;
	}
}
