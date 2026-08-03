using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class XinHuaLiaoMeng : DefenseSkillBase
{
	public XinHuaLiaoMeng()
	{
	}

	public XinHuaLiaoMeng(CombatSkillKey skillKey)
		: base(skillKey, 16304)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(126, EDataModifyType.Custom, -1);
		CreateAffectedData(131, EDataModifyType.Custom, -1);
		CreateAffectedData(287, EDataModifyType.Custom, -1);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 126 || fieldId == 131) ? true : false)
		{
			return false;
		}
		if (dataKey.FieldId == 287)
		{
			return true;
		}
		return dataValue;
	}
}
