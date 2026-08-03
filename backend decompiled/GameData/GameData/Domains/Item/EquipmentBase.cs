using System;
using Config;
using GameData.Common;
using GameData.Domains.Map;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Item;

public abstract class EquipmentBase : ItemBase
{
	[CollectionObjectField(false, true, false, false, false)]
	protected int EquippedCharId;

	[CollectionObjectField(true, true, false, false, false)]
	protected short EquipmentEffectId;

	[CollectionObjectField(false, true, false, true, false)]
	protected MaterialResources MaterialResources;

	[CollectionObjectField(false, false, true, false, false)]
	protected short EquippedPower;

	[CollectionObjectField(true, false, false, false, false)]
	public abstract sbyte GetEquipmentType();

	[CollectionObjectField(true, false, false, false, false)]
	public abstract bool GetDetachable();

	protected EquipmentBase()
	{
		EquippedCharId = -1;
	}

	public void OfflineSetEquippedCharId(int charId)
	{
		EquippedCharId = charId;
	}

	public override bool ChangeCurrDurability(DataContext context, int delta)
	{
		if (!base.ChangeCurrDurability(context, delta))
		{
			return false;
		}
		if (EquippedCharId == DomainManager.Taiwu.GetTaiwuCharId() && delta < 0 && CurrDurability < MaxDurability * GuidingChapterTrigger.DefValue.Trigger235.Int1 / 100)
		{
			DomainManager.Global.InvokeGuidingTrigger(context, 233);
		}
		return true;
	}

	public override int GetWeight()
	{
		int value = GetBaseWeight();
		return DomainManager.Item.GetEquipmentEffects(this).ModifyValue(value, (EquipmentEffectItem x) => x.WeightChange);
	}

	public override int GetValue()
	{
		int value = base.GetValue();
		if (EquipmentEffectId >= 0)
		{
			EquipmentEffectItem equipmentEffect = EquipmentEffect.Instance[EquipmentEffectId];
			value += value * equipmentEffect.ValueChange / 100;
		}
		return value;
	}

	public void OfflineGenerateEquipmentEffect(IRandomSource random)
	{
		short itemSubType = GetItemSubType();
		if (itemSubType == 104 || itemSubType == 17 || itemSubType == 16)
		{
			return;
		}
		if (EquipmentEffectId < 0)
		{
			EquipmentEffectId = ItemDomain.GetRandomEquipmentEffect(random, GetItemType());
		}
		if (EquipmentEffectId >= 0)
		{
			EquipmentEffectItem equipmentEffectCfg = EquipmentEffect.Instance[EquipmentEffectId];
			if (equipmentEffectCfg.MaxDurabilityChange != 0)
			{
				MaxDurability = (short)(MaxDurability * (100 + equipmentEffectCfg.MaxDurabilityChange) / 100);
				CurrDurability = MaxDurability;
			}
		}
	}

	public void ApplyDurabilityEquipmentEffectChange(DataContext context, int oldId, int newId)
	{
		int oldChange = 0;
		int newChange = 0;
		if (oldId > -1)
		{
			EquipmentEffectItem oldConfig = EquipmentEffect.Instance[oldId];
			oldChange = oldConfig.MaxDurabilityChange;
		}
		if (newId > -1)
		{
			EquipmentEffectItem newConfig = EquipmentEffect.Instance[newId];
			newChange = newConfig.MaxDurabilityChange;
		}
		if (newChange - oldChange != 0)
		{
			int baseDurability = MaxDurability * 100 / (100 + oldChange);
			MaxDurability = (short)(baseDurability * (100 + newChange) / 100);
			CurrDurability = Math.Min(CurrDurability, MaxDurability);
			SetMaxDurability(MaxDurability, context);
			SetCurrDurability(CurrDurability, context);
		}
	}

	public unsafe void OfflineGenerateMaterialResources(IRandomSource random)
	{
		short makeItemSubType = ItemTemplateHelper.GetEquipmentMakeItemSubType(GetItemType(), TemplateId);
		if (makeItemSubType < 0)
		{
			return;
		}
		MakeItemSubTypeItem makeItemSubTypeCfg = MakeItemSubType.Instance[makeItemSubType];
		short totalResourceCount = makeItemSubTypeCfg.ResourceTotalCount;
		MaterialResources remainingValidSlots = default(MaterialResources);
		remainingValidSlots.Initialize();
		sbyte* validResTypes = stackalloc sbyte[6];
		int validCount = 0;
		for (sbyte resourceType = 0; resourceType < 6; resourceType++)
		{
			short maxMaterialResourceCount = makeItemSubTypeCfg.MaxMaterialResources.Items[resourceType];
			if (maxMaterialResourceCount > 0)
			{
				short resCount = (short)random.Next(Math.Min(maxMaterialResourceCount, totalResourceCount) + 1);
				totalResourceCount -= resCount;
				MaterialResources.Items[resourceType] = resCount;
				remainingValidSlots.Items[resourceType] = (short)(maxMaterialResourceCount - resCount);
				validResTypes[validCount] = resourceType;
				validCount++;
			}
		}
		if (validCount <= 0)
		{
			return;
		}
		CollectionUtils.Shuffle(random, validResTypes, validCount);
		for (int i = 0; i < validCount; i++)
		{
			if (totalResourceCount <= 0)
			{
				break;
			}
			sbyte resType = validResTypes[i];
			short resCount2 = remainingValidSlots.Items[resType];
			if (resCount2 >= totalResourceCount)
			{
				ref short reference = ref MaterialResources.Items[resType];
				reference += totalResourceCount;
			}
			else
			{
				ref short reference2 = ref MaterialResources.Items[resType];
				reference2 += resCount2;
			}
			totalResourceCount -= resCount2;
		}
	}

	protected int GetMaterialResourceBonusValuePercentage(sbyte equipmentBonusType)
	{
		return ItemTemplateHelper.GetMaterialResourceBonusValuePercentage(GetItemType(), TemplateId, equipmentBonusType, MaterialResources);
	}

	public short GetEquipmentEffectId()
	{
		return EquipmentEffectId;
	}

	public abstract void SetEquipmentEffectId(short equipmentEffectId, DataContext context);

	public int GetEquippedCharId()
	{
		return EquippedCharId;
	}

	public abstract void SetEquippedCharId(int equippedCharId, DataContext context);

	public MaterialResources GetMaterialResources()
	{
		return MaterialResources;
	}

	public abstract void SetMaterialResources(MaterialResources materialResources, DataContext context);

	public abstract short GetEquippedPower();
}
