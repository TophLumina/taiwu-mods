using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class FengShenZhaoMing : DefenseSkillBase
{
	private readonly List<(sbyte, bool)> _injuryRandomPool = new List<(sbyte, bool)>();

	public FengShenZhaoMing()
	{
	}

	public FengShenZhaoMing(CombatSkillKey skillKey)
		: base(skillKey, 16307)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 116, -1), EDataModifyType.Custom);
	}

	public override OuterAndInnerInts GetModifiedValue(AffectedDataKey dataKey, OuterAndInnerInts dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		DataContext context = DomainManager.Combat.Context;
		Injuries newInjuries = base.CombatChar.GetInjuries().Subtract(base.CombatChar.GetOldInjuries());
		if (dataValue.Outer + dataValue.Inner <= 0 || newInjuries.GetSum() <= 0)
		{
			return dataValue;
		}
		_injuryRandomPool.Clear();
		for (sbyte part = 0; part < 7; part++)
		{
			(sbyte, sbyte) injury = newInjuries.Get(part);
			for (int i = 0; i < injury.Item1; i++)
			{
				_injuryRandomPool.Add((part, false));
			}
			for (int j = 0; j < injury.Item2; j++)
			{
				_injuryRandomPool.Add((part, true));
			}
		}
		while (dataValue.Outer + dataValue.Inner > 0 && _injuryRandomPool.Count > 0)
		{
			int index = context.Random.Next(0, _injuryRandomPool.Count);
			(sbyte, bool) injuryInfo = _injuryRandomPool[index];
			_injuryRandomPool.RemoveAt(index);
			base.CombatChar.ChangeToOldInjury(context, injuryInfo.Item1, injuryInfo.Item2, 1);
			if (dataValue.Inner <= 0 || (dataValue.Outer > 0 && context.Random.CheckPercentProb(50)))
			{
				dataValue.Outer--;
			}
			else
			{
				dataValue.Inner--;
			}
		}
		ShowSpecialEffectTips(0);
		return dataValue;
	}
}
