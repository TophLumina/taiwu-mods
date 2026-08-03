using System;
using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Agile;

public class TaiYiJiuGongBu : AgileSkillBase
{
	private const sbyte ChangeInnerRatio = 50;

	private const int MaxChangePower = 40;

	private bool _affecting;

	private CombatSkillKey _changePowerSkill;

	private int _changePower;

	public TaiYiJiuGongBu()
	{
	}

	public TaiYiJiuGongBu(CombatSkillKey skillKey)
		: base(skillKey, 4404)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 15, -1), EDataModifyType.Add);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.AddPercent);
		}
		else
		{
			int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
			foreach (int enemyCharId in charList)
			{
				if (enemyCharId >= 0)
				{
					AffectDatas.Add(new AffectedDataKey(enemyCharId, 15, -1), EDataModifyType.Add);
					AffectDatas.Add(new AffectedDataKey(enemyCharId, 199, -1), EDataModifyType.AddPercent);
				}
			}
		}
		_affecting = false;
		_changePowerSkill.CharId = -1;
		_changePower = -1;
		UpdateCanAffect(context, default(DataUid));
		if (_affecting)
		{
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context, default(DataUid));
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (_affecting && Config.CombatSkill.Instance[skillId].EquipType == 1 && (base.IsDirect ? (charId == base.CharacterId) : (base.CombatChar.IsAlly != isAlly)))
		{
			CombatSkillKey skillKey = new CombatSkillKey(charId, skillId);
			int skillInnerRatio = DomainManager.CombatSkill.GetElement_CombatSkills(skillKey).GetCurrInnerRatio();
			_changePower = (base.IsDirect ? Math.Max(40 - Math.Abs(skillInnerRatio - 50), 0) : (-Math.Min(Math.Abs(skillInnerRatio - 50), 40)));
			if (_changePower != 0)
			{
				_changePowerSkill = skillKey;
				DomainManager.SpecialEffect.InvalidateCache(context, charId, 199);
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == _changePowerSkill.CharId && skillId == _changePowerSkill.SkillTemplateId)
		{
			_changePowerSkill.CharId = -1;
			DomainManager.SpecialEffect.InvalidateCache(context, charId, 199);
		}
	}

	private void UpdateCanAffect(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting == canAffect)
		{
			return;
		}
		_affecting = canAffect;
		if (base.IsDirect)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 15);
			return;
		}
		int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		for (int i = 0; i < charList.Length; i++)
		{
			if (charList[i] >= 0)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, charList[i], 15);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_affecting)
		{
			return 0;
		}
		if (dataKey.FieldId == 15)
		{
			return base.IsDirect ? 50 : (-50);
		}
		if (dataKey.FieldId == 199 && dataKey.CharId == _changePowerSkill.CharId && dataKey.CombatSkillId == _changePowerSkill.SkillTemplateId)
		{
			return _changePower;
		}
		return 0;
	}
}
