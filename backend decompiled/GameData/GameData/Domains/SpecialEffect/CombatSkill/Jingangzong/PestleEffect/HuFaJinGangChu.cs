using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.PestleEffect;

public class HuFaJinGangChu : PestleEffectBase
{
	public HuFaJinGangChu(int charId, SkillEffectKey effectKey)
		: base(charId, effectKey)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(116, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 116 && dataKey.CustomParam1 == ((!base.IsDirect) ? 1 : 0))
		{
			return (dataKey.CustomParam2 > 1) ? (-1) : 0;
		}
		return 0;
	}
}
