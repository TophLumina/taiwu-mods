using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;

public class WuHuangBiDuShu : DefenseSkillBase
{
	private CombatCharacter _poisonChar;

	private readonly Dictionary<sbyte, int> _changePoisonDict = new Dictionary<sbyte, int>();

	public WuHuangBiDuShu()
	{
	}

	public WuHuangBiDuShu(CombatSkillKey skillKey)
		: base(skillKey, 10603)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 159, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 106 : 247), -1), EDataModifyType.Custom);
		ShowSpecialEffectTips(0);
	}

	private void OnStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		foreach (KeyValuePair<sbyte, int> poison in _changePoisonDict)
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.ReducePoison(context, _poisonChar, poison.Key, poison.Value);
			}
			else
			{
				DomainManager.Combat.AddPoison(context, _poisonChar, _poisonChar, poison.Key, (sbyte)_poisonChar.GetDefeatMarkCollection().PoisonMarkList[poison.Key], poison.Value, -1);
			}
		}
		_changePoisonDict.Clear();
		ShowSpecialEffectTips(1);
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (base.CharacterId != dataKey.CharId || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 159)
		{
			return false;
		}
		return dataValue;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (base.CharacterId != dataKey.CharId || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 106 && dataValue > 0)
		{
			sbyte poisonType = (sbyte)dataKey.CustomParam0;
			_poisonChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
			if (_changePoisonDict.Count == 0)
			{
				Events.RegisterHandler_CombatStateMachineUpdateEnd(OnStateMachineUpdateEnd);
			}
			if (!_changePoisonDict.ContainsKey(poisonType))
			{
				_changePoisonDict.Add(poisonType, dataValue);
			}
			else
			{
				_changePoisonDict[poisonType] += dataValue;
			}
			return 0;
		}
		return dataValue;
	}

	public override CombatCharacter GetModifiedValue(AffectedDataKey dataKey, CombatCharacter dataValue)
	{
		if (dataKey.FieldId == 247 && dataKey.CharId == base.CharacterId && base.CanAffect)
		{
			ShowSpecialEffectTips(1);
			return base.CurrEnemyChar;
		}
		return dataValue;
	}
}
