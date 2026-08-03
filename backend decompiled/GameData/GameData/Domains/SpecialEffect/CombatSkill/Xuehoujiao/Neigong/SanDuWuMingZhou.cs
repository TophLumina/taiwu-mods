using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class SanDuWuMingZhou : CombatSkillEffectBase
{
	private static readonly sbyte[] AddPower = new sbyte[3] { 5, 10, 15 };

	private sbyte _addPower;

	private DataUid _happinessUid;

	public SanDuWuMingZhou()
	{
	}

	public SanDuWuMingZhou(CombatSkillKey skillKey)
		: base(skillKey, 15003, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_happinessUid = new DataUid(4, 0, (ulong)base.CharacterId, 6u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_happinessUid, base.DataHandlerKey, OnHappinessChange);
		UpdateAddPower();
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.Add);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_happinessUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_happinessUid, base.DataHandlerKey);
			_happinessUid = new DataUid(8, 10, (ulong)base.CharacterId, 139u);
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_happinessUid, base.DataHandlerKey, OnHappinessChange);
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (_happinessUid.DomainId == 8)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_happinessUid, base.DataHandlerKey);
			_happinessUid = new DataUid(4, 0, (ulong)base.CharacterId, 6u);
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_happinessUid, base.DataHandlerKey, OnHappinessChange);
			OnHappinessChange(context, _happinessUid);
		}
	}

	private void OnHappinessChange(DataContext context, DataUid dataUid)
	{
		UpdateAddPower();
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
	}

	private void UpdateAddPower()
	{
		sbyte happinessType = (DomainManager.Combat.IsCharInCombat(base.CharacterId) ? HappinessType.GetHappinessType(base.CombatChar.GetHappiness()) : CharObj.GetHappinessType());
		sbyte happinessThreshold = (sbyte)(base.IsDirect ? 4 : 2);
		if (happinessType >= 0 && (base.IsDirect ? (happinessType >= happinessThreshold) : (happinessType <= happinessThreshold)))
		{
			_addPower = AddPower[base.IsDirect ? (happinessType - happinessThreshold) : (happinessThreshold - happinessType)];
		}
		else
		{
			_addPower = 0;
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
			return _addPower;
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
		*pCurrData = (byte)_addPower;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		_addPower = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
