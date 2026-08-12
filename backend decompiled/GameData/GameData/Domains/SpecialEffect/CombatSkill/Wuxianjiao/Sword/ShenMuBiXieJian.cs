using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Sword;

public class ShenMuBiXieJian : CombatSkillEffectBase
{
	private const sbyte AffectSkillCount = 2;

	private const sbyte TransferPower = 10;

	private readonly List<short> _transferPowerSkillList = new List<short>();

	private DataUid _addPowerUid;

	private bool _affectInCast;

	public ShenMuBiXieJian()
	{
	}

	public ShenMuBiXieJian(CombatSkillKey skillKey)
		: base(skillKey, 12303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (base.IsDirect)
		{
			_addPowerUid = new DataUid(8, 6, ulong.MaxValue);
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_addPowerUid, base.DataHandlerKey, OnAddPowerChanged);
		}
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_AttackSkillAttackBegin(OnAttackSkillAttackBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		if (base.IsDirect)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_addPowerUid, base.DataHandlerKey);
		}
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_AttackSkillAttackBegin(OnAttackSkillAttackBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_affectInCast = false;
		}
	}

	private void OnAttackSkillAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId, int index, bool hit)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId && hit)
		{
			_affectInCast = true;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!(charId != base.CharacterId || skillId != base.SkillTemplateId || interrupted) && _affectInCast)
		{
			if (base.IsDirect == !PowerMatchAffectRequire(power))
			{
				DoTransferPower(context);
			}
			else if (_transferPowerSkillList.Count > 0)
			{
				DoReturnPower(context);
			}
		}
	}

	private void DoTransferPower(DataContext context)
	{
		SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
		int needMinPower = 20;
		if (!base.IsDirect && base.SkillInstance.GetPower() < needMinPower)
		{
			return;
		}
		List<short> otherAttackSkills = ObjectPool<List<short>>.Instance.Get();
		otherAttackSkills.Clear();
		IEnumerable<short> attackSkills = from x in base.CombatChar.GetAttackSkillList()
			where x >= 0 && x != base.SkillTemplateId
			select x;
		if (base.IsDirect)
		{
			attackSkills = from x in attackSkills
				select DomainManager.CombatSkill.GetElement_CombatSkills(new CombatSkillKey(base.CharacterId, x)) into x
				where x.GetPower() >= needMinPower
				select x.GetId().SkillTemplateId;
		}
		otherAttackSkills.AddRange(attackSkills);
		if (otherAttackSkills.Count > 0)
		{
			int transferCount = Math.Min(2, otherAttackSkills.Count);
			if (!base.IsDirect)
			{
				transferCount = Math.Min(transferCount, (base.SkillInstance.GetPower() - 10) / 10);
			}
			if (transferCount > 0)
			{
				CollectionUtils.Shuffle(context.Random, otherAttackSkills);
				for (int i = 0; i < transferCount; i++)
				{
					short attackSkillId = otherAttackSkills[i];
					CombatSkillKey attackSkillKey = new CombatSkillKey(base.CharacterId, attackSkillId);
					_transferPowerSkillList.Add(attackSkillId);
					DomainManager.Combat.ReduceSkillPowerInCombat(context, base.IsDirect ? attackSkillKey : SkillKey, effectKey, -10);
					DomainManager.Combat.AddSkillPowerInCombat(context, base.IsDirect ? SkillKey : attackSkillKey, effectKey, 10);
				}
				ShowSpecialEffectTips(0);
			}
		}
		ObjectPool<List<short>>.Instance.Return(otherAttackSkills);
	}

	private void DoReturnPower(DataContext context)
	{
		SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
		int totalPower = 0;
		for (int i = 0; i < _transferPowerSkillList.Count; i++)
		{
			CombatSkillKey attackSkillKey = new CombatSkillKey(base.CharacterId, _transferPowerSkillList[i]);
			if (base.IsDirect)
			{
				DomainManager.Combat.RemoveSkillPowerReduceInCombat(context, attackSkillKey, effectKey);
				DomainManager.Combat.AddSkillPowerInCombat(context, attackSkillKey, effectKey, 20);
			}
			else
			{
				totalPower += DomainManager.Combat.RemoveSkillPowerAddInCombat(context, attackSkillKey, effectKey);
			}
		}
		_transferPowerSkillList.Clear();
		if (base.IsDirect)
		{
			DomainManager.Combat.RemoveSkillPowerAddInCombat(context, SkillKey, effectKey);
		}
		else if (totalPower > 0)
		{
			DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, effectKey, totalPower * 2);
		}
		if (base.IsDirect || totalPower > 0)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnAddPowerChanged(DataContext context, DataUid dataUid)
	{
		if (!DomainManager.Combat.GetAllSkillPowerAddInCombat().ContainsKey(SkillKey))
		{
			_transferPowerSkillList.Clear();
		}
	}
}
