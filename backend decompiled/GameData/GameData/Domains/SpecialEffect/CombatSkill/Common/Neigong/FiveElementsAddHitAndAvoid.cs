using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class FiveElementsAddHitAndAvoid : CombatSkillEffectBase
{
	private const sbyte AddValueRatio = 5;

	protected sbyte RequireFiveElementsType;

	private DataUid _neiliPortionUid;

	protected FiveElementsAddHitAndAvoid()
	{
	}

	protected FiveElementsAddHitAndAvoid(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 38, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 39, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 40, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 41, -1), EDataModifyType.AddPercent);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 32, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 33, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 34, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 35, -1), EDataModifyType.AddPercent);
		}
		_neiliPortionUid = new DataUid(4, 0, (ulong)base.CharacterId, 110u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_neiliPortionUid, base.DataHandlerKey, OnNeiliProportionOfFiveElementsChanged);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_neiliPortionUid, base.DataHandlerKey);
	}

	private void OnNeiliProportionOfFiveElementsChanged(DataContext context, DataUid dataUid)
	{
		if (base.IsDirect)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 38);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 39);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 40);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 41);
		}
		else
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 32);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 33);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 34);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 35);
		}
	}

	public unsafe override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		NeiliProportionOfFiveElements neiliProportion = CharObj.GetNeiliProportionOfFiveElements();
		sbyte neiliPercent = neiliProportion.Items[RequireFiveElementsType];
		return neiliPercent / 5;
	}

	protected override int GetSubClassSerializedSize()
	{
		return base.GetSubClassSerializedSize() + 1 + 1;
	}

	protected unsafe override int SerializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.SerializeSubClass(pData);
		*pCurrData = (byte)RequireFiveElementsType;
		return GetSubClassSerializedSize();
	}

	protected unsafe override int DeserializeSubClass(byte* pData)
	{
		byte* pCurrData = pData + base.DeserializeSubClass(pData);
		RequireFiveElementsType = (sbyte)(*pCurrData);
		return GetSubClassSerializedSize();
	}
}
