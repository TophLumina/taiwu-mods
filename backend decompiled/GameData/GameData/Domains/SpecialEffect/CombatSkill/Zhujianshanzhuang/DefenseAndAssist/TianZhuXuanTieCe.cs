using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.DefenseAndAssist;

public class TianZhuXuanTieCe : AssistSkillBase
{
	private const int MaxAddPower = 100;

	private const int GodRequirePower = 50;

	private static readonly sbyte[] RequireLifeSkillTypes = new sbyte[4] { 6, 7, 11, 10 };

	private static readonly int[] RequireAttainments = new int[9] { 80, 120, 160, 200, 240, 280, 320, 360, 400 };

	private readonly Dictionary<int, int> _itemAddedPower = new Dictionary<int, int>();

	private bool _affecting;

	private DataUid _dataUid;

	public TianZhuXuanTieCe()
	{
	}

	public TianZhuXuanTieCe(CombatSkillKey skillKey)
		: base(skillKey, 9706)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(313, EDataModifyType.Add, -1);
		CreateAffectedData((ushort)(base.IsDirect ? 181 : 182), EDataModifyType.Custom, -1);
		_dataUid = ParseCharDataUid(56);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_dataUid, base.DataHandlerKey, OnEquipmentChanged);
		_affecting = false;
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_dataUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateCanAffect(context);
		UpdateAddedPower(context);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context);
	}

	private void OnEquipmentChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context);
		UpdateAddedPower(context);
	}

	private bool IsItemAffected(int itemId)
	{
		int power;
		return _itemAddedPower.TryGetValue(itemId, out power) && power >= 50;
	}

	private void UpdateCanAffect(DataContext context)
	{
		bool canAffect = base.CanAffect;
		if (canAffect != _affecting)
		{
			_affecting = canAffect;
			SetConstAffecting(context, canAffect);
			if (canAffect)
			{
				ShowEffectTips(context);
			}
		}
	}

	private void UpdateAddedPower(DataContext context)
	{
		bool anyChanged = false;
		ItemKey[] equipment = CharObj.GetEquipment();
		for (int i = 0; i < equipment.Length; i++)
		{
			ItemKey key = equipment[i];
			if (key.IsValid())
			{
				bool prevIsAffected = IsItemAffected(key.Id);
				int addPower = CalcAddPowerValue(key);
				anyChanged = anyChanged || addPower != _itemAddedPower.GetOrDefault(key.Id);
				_itemAddedPower[key.Id] = addPower;
				bool currIsAffected = IsItemAffected(key.Id);
				if (!prevIsAffected && currIsAffected && _affecting)
				{
					ShowSpecialEffectTipsOnceInFrame(0);
				}
			}
		}
		if (anyChanged)
		{
			InvalidateCache(context, 313);
		}
	}

	private int CalcAddPowerValue(ItemKey key)
	{
		if ((int)key.ItemType != ((!base.IsDirect) ? 1 : 0))
		{
			return 0;
		}
		sbyte grade = ItemTemplateHelper.GetGrade(key.ItemType, key.TemplateId);
		int requireValue = RequireAttainments[grade];
		int power = 0;
		sbyte[] requireLifeSkillTypes = RequireLifeSkillTypes;
		foreach (sbyte lifeSkillType in requireLifeSkillTypes)
		{
			short attainment = CharObj.GetLifeSkillAttainment(lifeSkillType);
			power += Math.Min(attainment * 100 / requireValue, 100);
		}
		return power / RequireLifeSkillTypes.Length;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_affecting)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = ((fieldId == 313) ? _itemAddedPower.GetOrDefault(dataKey.CustomParam0) : 0);
		if (1 == 0)
		{
		}
		return result;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		bool flag = !_affecting;
		bool flag2 = flag;
		if (!flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (uint)(fieldId - 181) <= 1u;
			flag2 = !flag3;
		}
		if (flag2)
		{
			return dataValue;
		}
		return IsItemAffected(dataKey.CustomParam0);
	}
}
