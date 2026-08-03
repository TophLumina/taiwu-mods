using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class WuHuaBaMen : AssistSkillBase
{
	private sbyte TrickTypeCount = 3;

	private sbyte AddProperty = 15;

	private DataUid _tricksUid;

	private DataUid _weaponUid;

	private bool _affecting;

	public WuHuaBaMen()
	{
	}

	public WuHuaBaMen(CombatSkillKey skillKey)
		: base(skillKey, 2702)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		for (sbyte hitType = 0; hitType < 4; hitType++)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)((base.IsDirect ? 32 : 38) + hitType), -1), EDataModifyType.AddPercent);
		}
		_tricksUid = new DataUid(8, 10, (ulong)base.CharacterId, 28u);
		_weaponUid = new DataUid(8, 10, (ulong)base.CharacterId, 16u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_tricksUid, base.DataHandlerKey, UpdateCanAffect);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_weaponUid, base.DataHandlerKey, UpdateCanAffect);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_tricksUid, base.DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_weaponUid, base.DataHandlerKey);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context, default(DataUid));
	}

	private void UpdateCanAffect(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (canAffect)
		{
			IReadOnlyDictionary<int, sbyte> trickDict = base.CombatChar.GetTricks().Tricks;
			if (trickDict.Count >= TrickTypeCount)
			{
				List<sbyte> typeList = ObjectPool<List<sbyte>>.Instance.Get();
				typeList.Clear();
				foreach (sbyte type in trickDict.Values)
				{
					if (!typeList.Contains(type) && base.CombatChar.IsTrickUsable(type))
					{
						typeList.Add(type);
					}
				}
				canAffect = typeList.Count >= TrickTypeCount;
				ObjectPool<List<sbyte>>.Instance.Return(typeList);
			}
			else
			{
				canAffect = false;
			}
		}
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			SetConstAffecting(context, _affecting);
			for (sbyte hitType = 0; hitType < 3; hitType++)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)((base.IsDirect ? 32 : 38) + hitType));
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || !_affecting)
		{
			return 0;
		}
		return AddProperty;
	}
}
