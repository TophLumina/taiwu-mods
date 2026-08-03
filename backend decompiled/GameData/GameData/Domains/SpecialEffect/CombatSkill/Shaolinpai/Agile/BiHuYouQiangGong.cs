using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Agile;

public class BiHuYouQiangGong : AgileSkillBase
{
	private const sbyte ChangePower = 20;

	private bool _affecting;

	private bool _firstMoveSkillChanged = true;

	private DataUid _directDefendSkillUid;

	private short _directAffectingDefendSkill;

	private Dictionary<int, DataUid> _reverseDefendSkillUidDict;

	private Dictionary<int, short> _reverseAffectingDefendSkillDict;

	public BiHuYouQiangGong()
	{
	}

	public BiHuYouQiangGong(CombatSkillKey skillKey)
		: base(skillKey, 1401)
	{
		AutoRemove = false;
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affecting = false;
		OnMoveSkillCanAffectChanged(context, default(DataUid));
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.AddPercent);
			_directAffectingDefendSkill = base.CombatChar.GetAffectingDefendSkillId();
			_directDefendSkillUid = new DataUid(8, 10, (ulong)base.CharacterId, 63u);
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_directDefendSkillUid, base.DataHandlerKey, OnDefendSkillChanged);
		}
		else
		{
			_reverseDefendSkillUidDict = new Dictionary<int, DataUid>();
			_reverseAffectingDefendSkillDict = new Dictionary<int, short>();
			int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
			foreach (int enemyId in charList)
			{
				if (enemyId >= 0)
				{
					AffectDatas.Add(new AffectedDataKey(enemyId, 199, -1), EDataModifyType.AddPercent);
					short defendSkillId = DomainManager.Combat.GetElement_CombatCharacterDict(enemyId).GetAffectingDefendSkillId();
					if (defendSkillId >= 0)
					{
						_reverseAffectingDefendSkillDict.Add(enemyId, defendSkillId);
					}
					DataUid defendSkillUid = new DataUid(8, 10, (ulong)enemyId, 63u);
					_reverseDefendSkillUidDict.Add(enemyId, defendSkillUid);
					GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(defendSkillUid, base.DataHandlerKey, OnDefendSkillChanged);
				}
			}
		}
		ShowSpecialEffectTips(0);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.IsDirect)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_directDefendSkillUid, base.DataHandlerKey);
			return;
		}
		foreach (DataUid uid in _reverseDefendSkillUidDict.Values)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, base.DataHandlerKey);
		}
	}

	private void OnDefendSkillChanged(DataContext context, DataUid dataUid)
	{
		if (base.IsDirect)
		{
			_directAffectingDefendSkill = base.CombatChar.GetAffectingDefendSkillId();
		}
		else
		{
			int enemyId = (int)dataUid.SubId0;
			short defendSkillId = DomainManager.Combat.GetElement_CombatCharacterDict(enemyId).GetAffectingDefendSkillId();
			if (defendSkillId >= 0)
			{
				_reverseAffectingDefendSkillDict.Add(enemyId, defendSkillId);
			}
			else
			{
				_reverseAffectingDefendSkillDict.Remove(enemyId);
			}
		}
		if (AgileSkillChanged && (base.IsDirect ? (_directAffectingDefendSkill < 0) : (_reverseAffectingDefendSkillDict.Count <= 0)))
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
		else if (base.IsDirect ? (_directAffectingDefendSkill < 0) : (_reverseAffectingDefendSkillDict.Count <= 0))
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
		if (_affecting == canAffect)
		{
			return;
		}
		_affecting = canAffect;
		if (base.IsDirect)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			return;
		}
		int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		for (int i = 0; i < charList.Length; i++)
		{
			if (charList[i] >= 0)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, charList[i], 199);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_affecting || Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType != 3)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return base.IsDirect ? 20 : (-20);
		}
		return 0;
	}
}
