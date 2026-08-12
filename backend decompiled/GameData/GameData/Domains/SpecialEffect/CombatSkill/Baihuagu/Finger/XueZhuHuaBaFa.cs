using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class XueZhuHuaBaFa : CombatSkillEffectBase
{
	private const int PerFatalMarkCostEffectCount = 4;

	private const int AbsorbsHealthUnit = 12;

	private sbyte _effectCount;

	private readonly List<int> _affectingCharIds = new List<int>();

	private CValuePercent AbsorbsHealthPercent => base.IsDirect ? 20 : 40;

	public XueZhuHuaBaFa()
	{
	}

	public XueZhuHuaBaFa(CombatSkillKey skillKey, sbyte direction)
		: base(skillKey, 3108, direction)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(53, EDataModifyType.Add, -1);
		CreateAffectedData(210, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(222, EDataModifyType.Custom, base.SkillTemplateId);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (!DomainManager.Combat.IsCharInCombat(base.CharacterId) || !base.CombatChar.GetAttackSkillList().Exist(base.SkillTemplateId))
		{
			return;
		}
		if (_effectCount > 0)
		{
			UpdateEffectCount(context);
		}
		if (base.IsDirect)
		{
			_affectingCharIds.Add(base.CharacterId);
		}
		else
		{
			_affectingCharIds.AddRange(from x in DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly)
				where x >= 0
				select x);
		}
		foreach (int charId in _affectingCharIds)
		{
			AppendAffectedData(context, charId, 303, EDataModifyType.Custom, -1);
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (!DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			return;
		}
		foreach (int charId in _affectingCharIds)
		{
			RemoveAffectedData(context, charId, 303);
		}
		_affectingCharIds.Clear();
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power) && _effectCount < base.MaxEffectCount && !base.EnemyChar.CheckHealthImmunity(context))
		{
			short health = base.EnemyChar.GetCharacter().GetHealth();
			int unit = Math.Min(health * AbsorbsHealthPercent / 12, base.MaxEffectCount - _effectCount);
			int absorbs = unit * 12;
			if (absorbs > 0)
			{
				base.EnemyChar.GetCharacter().ChangeHealth(context, -absorbs);
				ChangeEffectCount(context, unit);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void ChangeEffectCount(DataContext context, int deltaValue)
	{
		if (deltaValue != 0)
		{
			_effectCount = (sbyte)Math.Clamp(_effectCount + deltaValue, 0, 127);
			UpdateEffectCount(context);
			DomainManager.SpecialEffect.SaveEffect(context, Id);
			InvalidateCache(context, 53);
		}
	}

	private void UpdateEffectCount(DataContext context)
	{
		DomainManager.Combat.AddSkillEffect(context, base.CombatChar, base.EffectKey, _effectCount, base.MaxEffectCount, autoRemoveOnNoCount: true);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 53)
		{
			return 12 * _effectCount;
		}
		return 0;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.FieldId != 303)
		{
			return dataValue;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Direct)
		{
			return dataValue;
		}
		int maxUnit = Math.Min(_effectCount / 4, dataValue);
		if (maxUnit <= 0)
		{
			return dataValue;
		}
		dataValue = ((!base.IsDirect) ? (dataValue + maxUnit) : (dataValue - maxUnit));
		ChangeEffectCount(base.CombatChar.GetDataContext(), -maxUnit * 4);
		return dataValue;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 210 || fieldId == 222) ? true : false)
		{
			return false;
		}
		return dataValue;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = (byte)_effectCount;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		_effectCount = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
