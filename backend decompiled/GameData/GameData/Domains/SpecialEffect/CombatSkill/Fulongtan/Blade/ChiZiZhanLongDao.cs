using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Blade;

public class ChiZiZhanLongDao : CombatSkillEffectBase
{
	private int AddPower => base.IsDirect ? 40 : 20;

	private int AddHitOdds => base.IsDirect ? 300 : 150;

	public ChiZiZhanLongDao()
	{
	}

	public ChiZiZhanLongDao(CombatSkillKey skillKey)
		: base(skillKey, 14206, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (CharObj.HasVirginity() == base.IsDirect)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
			CreateAffectedData(74, EDataModifyType.AddPercent, base.SkillTemplateId);
			CreateAffectedData(325, EDataModifyType.Custom, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			199 => AddPower, 
			74 => AddHitOdds, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 325 && dataKey.CustomParam2 == 1)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
