using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.LegendaryBook.NpcEffect;

public class Neigong : FeatureEffectBase
{
	private const sbyte SameAddPower = 80;

	private const sbyte ProduceAddPower = 40;

	private const sbyte CounterReducePower = -40;

	private sbyte _neiliFiveElementsType;

	private DataUid _neiliTypeUid;

	public Neigong()
	{
	}

	public Neigong(int charId, short featureId)
		: base(charId, featureId, 41400)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_neiliTypeUid = new DataUid(4, 0, (ulong)base.CharacterId, 111u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_neiliTypeUid, base.DataHandlerKey, OnNeiliTypeChanged);
		OnNeiliTypeChanged(context, default(DataUid));
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.Add);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_neiliTypeUid, base.DataHandlerKey);
	}

	private void OnNeiliTypeChanged(DataContext context, DataUid dataUid)
	{
		_neiliFiveElementsType = (sbyte)NeiliType.Instance[CharObj.GetNeiliType()].FiveElements;
		if (AffectDatas != null)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		sbyte otherSkillType = Config.CombatSkill.Instance[dataKey.CombatSkillId].FiveElements;
		if (dataKey.FieldId == 199)
		{
			if (_neiliFiveElementsType == 5)
			{
				return (_neiliFiveElementsType == otherSkillType) ? 80 : 0;
			}
			if (otherSkillType != 5)
			{
				return (_neiliFiveElementsType == otherSkillType) ? 80 : ((_neiliFiveElementsType == FiveElementsType.Producing[otherSkillType] || _neiliFiveElementsType == FiveElementsType.Produced[otherSkillType]) ? 40 : (-40));
			}
		}
		return 0;
	}
}
