using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Agile;

public class JiuTuLiuZuoXiang : AgileSkillBase
{
	private const sbyte ChangeKeepFrames = 50;

	private const sbyte ChangePower = 50;

	private bool _affecting;

	private bool _firstMoveSkillChanged = true;

	private DataUid _defendSkillUid;

	private short _affectingDefendSkill;

	public JiuTuLiuZuoXiang()
	{
	}

	public JiuTuLiuZuoXiang(CombatSkillKey skillKey)
		: base(skillKey, 1404)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 176, -1), EDataModifyType.TotalPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.TotalPercent);
		_affectingDefendSkill = base.CombatChar.GetAffectingDefendSkillId();
		_defendSkillUid = new DataUid(8, 10, (ulong)base.CharacterId, 63u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defendSkillUid, base.DataHandlerKey, OnDefendSkillChanged);
		ShowSpecialEffectTips(0);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defendSkillUid, base.DataHandlerKey);
	}

	private void OnDefendSkillChanged(DataContext context, DataUid dataUid)
	{
		_affectingDefendSkill = base.CombatChar.GetAffectingDefendSkillId();
		if (AgileSkillChanged && _affectingDefendSkill < 0)
		{
			RemoveSelf(context);
		}
	}

	protected override void OnMoveSkillChanged(DataContext context, DataUid dataUid)
	{
		if (_firstMoveSkillChanged)
		{
			_firstMoveSkillChanged = false;
		}
		else if (_affectingDefendSkill < 0)
		{
			RemoveSelf(context);
		}
		else
		{
			AgileSkillChanged = true;
		}
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !_affecting)
		{
			return 0;
		}
		if (dataKey.FieldId == 176)
		{
			return base.IsDirect ? 50 : (-50);
		}
		if (dataKey.FieldId == 199 && Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType == 3)
		{
			return base.IsDirect ? (-50) : 50;
		}
		return 0;
	}
}
