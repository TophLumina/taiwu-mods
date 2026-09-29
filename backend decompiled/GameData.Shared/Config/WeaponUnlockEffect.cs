using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class WeaponUnlockEffect : ConfigData<WeaponUnlockEffectItem, int>
{
	public static WeaponUnlockEffect Instance = new WeaponUnlockEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Desc", "EffectId", "TemplateId", "Animation", "Particle", "Sound", "DisplayPosition" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new WeaponUnlockEffectItem(0, ignoreAttackRange: false, clearAgile: false, clearDefense: false, changeToOld: false, 1, new sbyte[0], new sbyte[0], 20, 0, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_0"), "J_001", "Particle_J_001", "se_j_001", new sbyte[4] { 12, 20, 30, 30 }, 1718));
		_dataArray.Add(new WeaponUnlockEffectItem(1, ignoreAttackRange: false, clearAgile: false, clearDefense: false, changeToOld: false, 1, new sbyte[0], new sbyte[0], 0, 300, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_1"), "J_002", "Particle_J_002", "se_j_002", new sbyte[4] { 20, 30, 30, 30 }, 1719));
		_dataArray.Add(new WeaponUnlockEffectItem(2, ignoreAttackRange: false, clearAgile: false, clearDefense: false, changeToOld: true, 1, new sbyte[0], new sbyte[0], 0, 0, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_2"), "J_003", "Particle_J_003", "se_j_003", new sbyte[4] { 20, 30, 30, 30 }, 1720));
		_dataArray.Add(new WeaponUnlockEffectItem(3, ignoreAttackRange: true, clearAgile: false, clearDefense: false, changeToOld: false, 1, new sbyte[0], new sbyte[0], 0, 0, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_3"), "J_004", "Particle_J_004", "se_j_004", new sbyte[4] { 30, 40, 50, 50 }, 1721));
		_dataArray.Add(new WeaponUnlockEffectItem(4, ignoreAttackRange: false, clearAgile: false, clearDefense: false, changeToOld: false, 1, new sbyte[3] { 0, 1, 2 }, new sbyte[0], 0, 0, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_4"), "J_005", "Particle_J_005", "se_j_005", new sbyte[4] { 50, 50, 50, 50 }, 1722));
		_dataArray.Add(new WeaponUnlockEffectItem(5, ignoreAttackRange: false, clearAgile: false, clearDefense: false, changeToOld: false, 10, new sbyte[0], new sbyte[0], 0, 0, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_5"), "J_006", "Particle_J_006", "se_j_006", new sbyte[4] { 35, 35, 35, 35 }, 1723));
		_dataArray.Add(new WeaponUnlockEffectItem(6, ignoreAttackRange: false, clearAgile: false, clearDefense: false, changeToOld: false, 1, new sbyte[0], new sbyte[3] { 0, 1, 2 }, 0, 0, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_6"), "J_007", "Particle_J_007", "se_j_007", new sbyte[4] { 50, 50, 50, 50 }, 1724));
		_dataArray.Add(new WeaponUnlockEffectItem(7, ignoreAttackRange: false, clearAgile: true, clearDefense: false, changeToOld: false, 1, new sbyte[0], new sbyte[0], 0, 0, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_7"), "J_008", "Particle_J_008", "se_j_008", new sbyte[4] { 35, 35, 35, 35 }, 1725));
		_dataArray.Add(new WeaponUnlockEffectItem(8, ignoreAttackRange: false, clearAgile: false, clearDefense: true, changeToOld: false, 1, new sbyte[0], new sbyte[0], 0, 0, 0, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_8"), "J_009", "Particle_J_009", "se_j_009", new sbyte[4] { 30, 30, 30, 30 }, 1726));
		_dataArray.Add(new WeaponUnlockEffectItem(9, ignoreAttackRange: false, clearAgile: false, clearDefense: false, changeToOld: false, 1, new sbyte[0], new sbyte[0], 0, 0, 300, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_9"), "J_010_B", "Particle_J_010_B", "se_j_010_b", new sbyte[4] { 55, 55, 55, 55 }, 1727));
		_dataArray.Add(new WeaponUnlockEffectItem(10, ignoreAttackRange: false, clearAgile: false, clearDefense: false, changeToOld: false, 1, new sbyte[0], new sbyte[0], 0, 0, 300, LocalStringManager.GetConfig("WeaponUnlockEffect_language", "Desc_10"), "J_010_A", "Particle_J_010_A", "se_j_010_a", new sbyte[4] { 55, 55, 55, 55 }, 1727));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<WeaponUnlockEffectItem>(11);
		CreateItems0();
	}
}
