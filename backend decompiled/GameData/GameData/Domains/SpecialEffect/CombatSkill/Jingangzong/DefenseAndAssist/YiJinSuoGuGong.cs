using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.DefenseAndAssist;

public class YiJinSuoGuGong : DefenseSkillBase
{
	private const sbyte AddAvoid = 40;

	private static readonly sbyte[] DirectParts = new sbyte[4] { 3, 4, 5, 6 };

	private static readonly sbyte[] ReverseParts = new sbyte[2] { 0, 1 };

	public YiJinSuoGuGong()
	{
	}

	public YiJinSuoGuGong(CombatSkillKey skillKey)
		: base(skillKey, 11602)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 126, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 131, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 234, -1), EDataModifyType.Custom);
		for (sbyte hitType = 0; hitType < 4; hitType++)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(94 + hitType), -1), EDataModifyType.TotalPercent);
		}
		ShowSpecialEffectTips(0);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || (base.IsDirect ? DirectParts : ReverseParts).IndexOf((sbyte)dataKey.CustomParam0) < 0)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 126 || fieldId == 131 || fieldId == 234) ? true : false)
		{
			return false;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || (base.IsDirect ? DirectParts : ReverseParts).IndexOf((sbyte)dataKey.CustomParam0) < 0)
		{
			return 0;
		}
		return 40;
	}
}
