using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ZhujianCombatSkillToWeapon : ConfigData<ZhujianCombatSkillToWeaponItem, int>
{
	public static ZhujianCombatSkillToWeapon Instance = new ZhujianCombatSkillToWeapon();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "CombatSkillId", "WeaponId", "EffectId", "TemplateId" };

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
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(0, 567, 467, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(1, 568, 440, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(2, 569, 477, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(3, 570, 450, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(4, 571, 487, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(5, 572, 460, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(6, 573, 470, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(7, 574, 443, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(8, 607, 538, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(9, 608, 565, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(10, 609, 548, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(11, 610, 575, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(12, 611, 531, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(13, 612, 558, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(14, 613, 532, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(15, 614, 559, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(16, 650, 619, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(17, 651, 673, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(18, 652, 638, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(19, 653, 692, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(20, 654, 656, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(21, 655, 666, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(22, 656, 640, 55));
		_dataArray.Add(new ZhujianCombatSkillToWeaponItem(23, 657, 623, 55));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ZhujianCombatSkillToWeaponItem>(24);
		CreateItems0();
	}
}
