using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class RongChenHuaYu : BossNeigongBase
{
	private DataUid _mobilityLevelUid;

	private int _addPercent;

	public RongChenHuaYu()
	{
	}

	public RongChenHuaYu(CombatSkillKey skillKey)
		: base(skillKey, 16106)
	{
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_mobilityLevelUid, base.DataHandlerKey);
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 38, EDataModifyType.TotalPercent, -1);
		AppendAffectedData(context, base.CharacterId, 39, EDataModifyType.TotalPercent, -1);
		AppendAffectedData(context, base.CharacterId, 40, EDataModifyType.TotalPercent, -1);
		AppendAffectedData(context, base.CharacterId, 41, EDataModifyType.TotalPercent, -1);
		_mobilityLevelUid = new DataUid(8, 10, (ulong)base.CharacterId, 135u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_mobilityLevelUid, base.DataHandlerKey, UpdateAddPercent);
		UpdateAddPercent(context, default(DataUid));
	}

	private void UpdateAddPercent(DataContext context, DataUid dataUid)
	{
		_addPercent = base.CombatChar.GetMobilityLevel() * 100;
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 38);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 39);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 40);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 41);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		return _addPercent;
	}
}
