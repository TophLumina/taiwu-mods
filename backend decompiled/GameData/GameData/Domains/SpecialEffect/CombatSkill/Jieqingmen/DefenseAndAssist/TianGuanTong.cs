using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.DefenseAndAssist;

public class TianGuanTong : AssistSkillBase
{
	private const sbyte RequireCount = 7;

	private DataUid _flawOrAcupointUid;

	public TianGuanTong()
	{
	}

	public TianGuanTong(CombatSkillKey skillKey)
		: base(skillKey, 13600)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_flawOrAcupointUid = new DataUid(8, 10, (ulong)base.CharacterId, base.IsDirect ? 43u : 41u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_flawOrAcupointUid, base.DataHandlerKey, TryAffect);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_flawOrAcupointUid, base.DataHandlerKey);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		if (base.CanAffect)
		{
			TryAffect(context, default(DataUid));
		}
	}

	private void TryAffect(DataContext context, DataUid dataUid)
	{
		if (!base.CanAffect || (base.IsDirect ? base.CombatChar.GetAcupointCount() : base.CombatChar.GetFlawCount()).Sum() < 7)
		{
			return;
		}
		byte[] countList = (base.IsDirect ? base.CombatChar.GetAcupointCount() : base.CombatChar.GetFlawCount());
		for (sbyte part = 0; part < 7; part++)
		{
			byte count = countList[part];
			for (int i = 0; i < count; i++)
			{
				if (base.IsDirect)
				{
					DomainManager.Combat.RemoveAcupoint(context, base.CombatChar, part, 0, raiseEvent: false, updateMark: false);
				}
				else
				{
					DomainManager.Combat.RemoveFlaw(context, base.CombatChar, part, 0, raiseEvent: false, updateMark: false);
				}
			}
		}
		DomainManager.Combat.UpdateBodyDefeatMark(context, base.CombatChar);
		ShowEffectTips(context);
		ShowSpecialEffectTips(0);
	}
}
