using System;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Shot;

public class ShenGongRuYiTa : CombatSkillEffectBase
{
	private const int AddPowerPercentPerEffectCount = 10;

	private bool _affected;

	private short _addingPowerSkill;

	private int _addingPowerPercent;

	public ShenGongRuYiTa()
	{
	}

	public ShenGongRuYiTa(CombatSkillKey skillKey)
		: base(skillKey, 9408, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affected = false;
		_addingPowerSkill = -1;
		_addingPowerPercent = 0;
		CreateAffectedData(199, EDataModifyType.AddPercent, -1);
		CreateAffectedData((ushort)(base.IsDirect ? 311 : 312), EDataModifyType.Custom, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.RegisterHandler_WisdomCosted(OnWisdomCosted);
		Events.RegisterHandler_JiTrickInsteadCostTricks(OnInsteadTrick);
		Events.RegisterHandler_UselessTrickInsteadJiTricks(OnInsteadTrick);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.UnRegisterHandler_WisdomCosted(OnWisdomCosted);
		Events.UnRegisterHandler_JiTrickInsteadCostTricks(OnInsteadTrick);
		Events.UnRegisterHandler_UselessTrickInsteadJiTricks(OnInsteadTrick);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AddMaxEffectCount();
		UpdateAffected(context);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && base.EffectCount > 0 && Boss.Instance.Any((BossItem x) => x.PlayerCastSkills.Contains(skillId)))
		{
			_addingPowerSkill = skillId;
			_addingPowerPercent = base.EffectCount * 10;
			ReduceEffectCountAndWisdom(context, base.EffectCount);
			InvalidateCache(context, 199);
			ShowSpecialEffectTips(2);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			bool prevAffected = _affected;
			int prevEffectCount = base.EffectCount;
			AddMaxEffectCount();
			UpdateAffected(context);
			if (prevAffected && _affected)
			{
				TryAddWisdom(context, prevEffectCount);
			}
		}
		else if (charId == base.CharacterId && skillId == _addingPowerSkill)
		{
			_addingPowerSkill = -1;
			_addingPowerPercent = 0;
			InvalidateCache(context, 199);
		}
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly == base.CombatChar.IsAlly)
		{
			UpdateAffected(context);
		}
	}

	private void OnWisdomCosted(DataContext context, bool isAlly, int value)
	{
		if (isAlly == base.CombatChar.IsAlly && _affected)
		{
			ReduceEffectCount(Math.Min(base.EffectCount, value));
			UpdateAffected(context);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnInsteadTrick(DataContext context, CombatCharacter character, int count)
	{
		if (character.GetId() == base.CharacterId && count > 0)
		{
			ReduceEffectCountAndWisdom(context, count);
			ShowSpecialEffectTips(0);
		}
	}

	private void ReduceEffectCountAndWisdom(DataContext context, int count)
	{
		if (_affected)
		{
			DomainManager.Combat.ChangeWisdom(context, base.CombatChar.IsAlly, -count);
		}
		ReduceEffectCount(count);
		UpdateAffected(context);
	}

	private void UpdateAffected(DataContext context)
	{
		bool affected = base.IsCurrent && base.EffectCount > 0;
		if (affected != _affected)
		{
			_affected = affected;
			if (affected)
			{
				DomainManager.Combat.ChangeWisdom(context, base.CombatChar.IsAlly, base.EffectCount);
			}
			else
			{
				DomainManager.Combat.ChangeWisdom(context, base.CombatChar.IsAlly, -base.EffectCount);
			}
		}
	}

	private void TryAddWisdom(DataContext context, int prevEffectCount)
	{
		int delta = base.EffectCount - prevEffectCount;
		if (delta != 0)
		{
			DomainManager.Combat.ChangeWisdom(context, base.CombatChar.IsAlly, delta);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 199 && dataKey.CharId == base.CharacterId && dataKey.CombatSkillId == _addingPowerSkill)
		{
			return _addingPowerPercent;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 311) <= 1u)
		{
			return dataValue + base.EffectCount;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
