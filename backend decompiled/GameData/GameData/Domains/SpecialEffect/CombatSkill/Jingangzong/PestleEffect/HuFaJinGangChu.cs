using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.PestleEffect;

public class HuFaJinGangChu : PestleEffectBase
{
	public HuFaJinGangChu()
	{
	}

	public HuFaJinGangChu(int charId)
		: base(charId, 11401)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 116, -1), EDataModifyType.Add);
		base.OnEnable(context);
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
