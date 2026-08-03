using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.DefenseAndAssist;

public class QianNianZui : AssistSkillBase
{
	private static readonly sbyte[] ChangePursueOdds = new sbyte[5] { 40, 30, 20, 10, 10 };

	private const sbyte ChangeHitOdds = 50;

	private static readonly CValuePercent NoWineEffectPercent = 50;

	private DataUid _eatingItemsUid;

	private bool _eatingWine;

	private CValuePercent EffectPercent => _eatingWine ? ((CValuePercent)100) : NoWineEffectPercent;

	public QianNianZui()
	{
	}

	public QianNianZui(CombatSkillKey skillKey)
		: base(skillKey, 14606)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_eatingWine = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 109 : 76), -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 107 : 74), -1), EDataModifyType.TotalPercent);
		_eatingItemsUid = new DataUid(4, 0, (ulong)base.CharacterId, 58u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_eatingItemsUid, base.DataHandlerKey, UpdateCanAffect);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_eatingItemsUid, base.DataHandlerKey);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateCanAffect(context, default(DataUid));
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context, default(DataUid));
	}

	private void UpdateCanAffect(DataContext context, DataUid dataUid)
	{
		_eatingWine = CharObj.GetEatingItems().ContainsWine();
		SetConstAffecting(context, base.CanAffect);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == (base.IsDirect ? 109 : 76))
		{
			return ChangePursueOdds[dataKey.CustomParam0] * ((!base.IsDirect) ? 1 : (-1)) * EffectPercent;
		}
		if (dataKey.FieldId == (base.IsDirect ? 107 : 74))
		{
			return (base.IsDirect ? (-50) : 50) * EffectPercent;
		}
		return 0;
	}
}
