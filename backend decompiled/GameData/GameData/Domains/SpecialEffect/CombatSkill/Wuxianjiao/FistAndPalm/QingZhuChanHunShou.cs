using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;

public class QingZhuChanHunShou : CombatSkillEffectBase
{
	private const sbyte PrepareProgressPercent = 50;

	private readonly List<CombatSkillKey> _enemySkillKey = new List<CombatSkillKey>();

	private bool _enemyCasting;

	private int _addPower;

	public QingZhuChanHunShou()
	{
	}

	public QingZhuChanHunShou(CombatSkillKey skillKey)
		: base(skillKey, 12104, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		ClearKey();
		_enemyCasting = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 154, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (!IsSrcSkillPerformed)
		{
			return;
		}
		if (IsEnemyKey(charId, skillId))
		{
			_enemyCasting = true;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 154);
			DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
			ShowSpecialEffectTips(1);
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_addPower = GetKeyPower();
			if (_addPower > 0)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
				ShowSpecialEffectTips(2);
			}
			if (_enemyCasting)
			{
				DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId != base.CharacterId || skillId != base.SkillTemplateId)
			{
				return;
			}
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				int enemyId = base.CurrEnemyChar.GetId();
				List<short> skillRandomPool = ObjectPool<List<short>>.Instance.Get();
				skillRandomPool.Clear();
				skillRandomPool.AddRange(base.CurrEnemyChar.GetAttackSkillList());
				skillRandomPool.RemoveAll((short id) => id < 0);
				if (skillRandomPool.Count > 0)
				{
					SelectKey(enemyId, skillRandomPool);
					ShowSpecialEffectTips(0);
				}
				ObjectPool<List<short>>.Instance.Return(skillRandomPool);
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (_enemyCasting && IsEnemyKey(charId, skillId))
		{
			_enemyCasting = false;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 154);
			DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private int GetEnemySkillPowerChange(int enemyId, short skillId)
	{
		CombatSkillKey skillKey = new CombatSkillKey(enemyId, skillId);
		SkillPowerChangeCollection powerCollection;
		return (base.IsDirect ? DomainManager.Combat.TryGetElement_SkillPowerAddInCombat(skillKey, out powerCollection) : DomainManager.Combat.TryGetElement_SkillPowerReduceInCombat(skillKey, out powerCollection)) ? Math.Abs(powerCollection.GetTotalChangeValue()) : 0;
	}

	private void ClearKey()
	{
		_enemySkillKey.Clear();
	}

	private void SelectKey(int enemyId, List<short> skillRandomPool)
	{
		if (skillRandomPool.Count != 0)
		{
			if (skillRandomPool.Count > 2)
			{
				skillRandomPool.Sort(Comparison);
			}
			_enemySkillKey.Clear();
			_enemySkillKey.Add(new CombatSkillKey(enemyId, skillRandomPool[skillRandomPool.Count - 1]));
			if (skillRandomPool.Count > 1)
			{
				_enemySkillKey.Add(new CombatSkillKey(enemyId, skillRandomPool[skillRandomPool.Count - 2]));
			}
		}
		int Comparison(short l, short r)
		{
			int lChange = GetEnemySkillPowerChange(enemyId, l);
			int rChange = GetEnemySkillPowerChange(enemyId, r);
			if (lChange != rChange)
			{
				return lChange.CompareTo(rChange);
			}
			short lPower = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(enemyId, l)).GetPower();
			short rPower = DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(enemyId, r)).GetPower();
			return lPower.CompareTo(rPower);
		}
	}

	private int GetKeyPower()
	{
		return _enemySkillKey.Select((CombatSkillKey x) => GetEnemySkillPowerChange(x.CharId, x.SkillTemplateId)).Sum();
	}

	private bool IsEnemyKey(int charId, short skillId)
	{
		return _enemySkillKey.Any((CombatSkillKey x) => x.CharId == charId && x.SkillTemplateId == skillId);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || !_enemyCasting)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 154)
		{
			return false;
		}
		return dataValue;
	}
}
