using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Neigong;

public class NeiJingLingShuPian : CombatSkillEffectBase
{
	private const sbyte HealCountChangePercent = 50;

	public NeiJingLingShuPian()
	{
	}

	public NeiJingLingShuPian(CombatSkillKey skillKey)
		: base(skillKey, 3003, -1)
	{
		if (base.IsDirect)
		{
			CreateAffectedData(119, EDataModifyType.AddPercent, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(120, EDataModifyType.AddPercent, -1);
		}
	}

	public override void OnEnable(DataContext context)
	{
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 119) > 1u)
		{
			return 0;
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		if (dataKey.CustomParam0 == 0)
		{
			ShowSpecialEffectTipsOnceInFrame(0);
		}
		ushort fieldId2 = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId2 switch
		{
			119 => 50, 
			120 => -50, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
