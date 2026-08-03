using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

public class TrickAddHitOrAvoid : AssistSkillBase
{
	private const sbyte AddPropertyUnit = 5;

	protected sbyte[] RequireTrickTypes;

	private DataUid _tricksUid;

	private int[] _trickCounts;

	protected TrickAddHitOrAvoid()
	{
	}

	protected TrickAddHitOrAvoid(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_trickCounts = new int[3];
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		for (sbyte hitType = 0; hitType < 3; hitType++)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)((base.IsDirect ? 32 : 38) + hitType), -1), EDataModifyType.AddPercent);
		}
		_tricksUid = new DataUid(8, 10, (ulong)base.CharacterId, 28u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_tricksUid, base.DataHandlerKey, UpdateEffect);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_tricksUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		for (sbyte hitType = 0; hitType < 3; hitType++)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)((base.IsDirect ? 32 : 38) + hitType));
		}
	}

	private void UpdateEffect(DataContext context, DataUid dataUid)
	{
		if (base.CombatChar.NeedUseSkillId < 0 && base.CombatChar.GetPreparingSkillId() < 0)
		{
			UpdateEffect(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			UpdateEffect(context);
		}
	}

	private void UpdateEffect(DataContext context)
	{
		for (sbyte hitType = 0; hitType < 3; hitType++)
		{
			int trickCount = base.CombatChar.GetTrickCount(RequireTrickTypes[hitType]);
			if (_trickCounts[hitType] != trickCount)
			{
				_trickCounts[hitType] = trickCount;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)((base.IsDirect ? 32 : 38) + hitType));
			}
			SetConstAffecting(context, _trickCounts.Sum() > 0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		int hitType = dataKey.FieldId - (base.IsDirect ? 32 : 38);
		return 5 * _trickCounts[hitType];
	}
}
