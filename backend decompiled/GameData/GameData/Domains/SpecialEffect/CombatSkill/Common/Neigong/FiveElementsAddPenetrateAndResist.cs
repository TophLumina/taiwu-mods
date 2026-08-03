using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class FiveElementsAddPenetrateAndResist : CombatSkillEffectBase
{
	private const sbyte AddValueRatio = 5;

	protected sbyte RequireFiveElementsType;

	private DataUid _neiliPortionUid;

	protected FiveElementsAddPenetrateAndResist()
	{
	}

	protected FiveElementsAddPenetrateAndResist(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 46, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 47, -1), EDataModifyType.AddPercent);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 44, -1), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 45, -1), EDataModifyType.AddPercent);
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
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 46);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 47);
		}
		else
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 44);
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 45);
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
