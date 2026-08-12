using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class ShengShenFa : CombatSkillEffectBase
{
	private const sbyte MaxAddPower = 20;

	private sbyte _currAddPower;

	private int AddPower => base.IsDirect ? 4 : 2;

	private int ReducePower => base.IsDirect ? 12 : 2;

	public ShengShenFa()
	{
	}

	public ShengShenFa(CombatSkillKey skillKey, sbyte direction)
		: base(skillKey, 7004, direction)
	{
		_currAddPower = 0;
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.Add);
		Events.RegisterHandler_PostAdvanceMonthBegin(OnAdvanceMonthBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PostAdvanceMonthBegin(OnAdvanceMonthBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	private void OnAdvanceMonthBegin(DataContext context)
	{
		if (CharObj.IsCombatSkillEquipped(base.SkillTemplateId) && CharObj.GetCombatSkillCanAffect(base.SkillTemplateId))
		{
			if (base.IsDirect)
			{
				_currAddPower = (sbyte)Math.Min(_currAddPower + AddPower, 20);
			}
			else
			{
				_currAddPower = (sbyte)Math.Max(_currAddPower - ReducePower, 0);
			}
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
		else if (_currAddPower > 0)
		{
			_currAddPower = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			if (base.CharacterId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				DomainManager.World.GetMonthlyNotificationCollection().AddAccumulatedSkillPowerLost(base.SkillTemplateId);
			}
		}
		DomainManager.SpecialEffect.SaveEffect(context, Id);
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId, checkCombatStatus: false) && CharObj.GetCombatSkillEquipment().IsCombatSkillEquipped(base.SkillTemplateId) && CharObj.GetCombatSkillCanAffect(base.SkillTemplateId))
		{
			if (base.IsDirect)
			{
				_currAddPower = (sbyte)Math.Max(_currAddPower - ReducePower, 0);
			}
			else
			{
				_currAddPower = (sbyte)Math.Min(_currAddPower + AddPower, 20);
			}
			DomainManager.SpecialEffect.SaveEffect(context, Id);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _currAddPower;
		}
		return 0;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = (byte)_currAddPower;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		_currAddPower = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
