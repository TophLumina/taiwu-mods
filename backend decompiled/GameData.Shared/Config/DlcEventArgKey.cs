using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class DlcEventArgKey : ConfigData<DlcEventArgKeyItem, int>, IEventArgumentCollectionFormatter
{
	public static class DefKey
	{
		public const int PagodaofTheFallenEntered = 0;

		public const int PagodaofTheFallenDefeatYufu = 1;

		public const int PagodaofTheFallenDefeatWuxiao = 2;

		public const int PagodaofTheFallenDefeatRanchen = 3;

		public const int PagodaofTheFallenDefeatXiangshu = 4;

		public const int PagodaofTheFallenDefeatTiandi = 6;

		public const int TameLoongInteractFlag = 5;
	}

	public static class DefValue
	{
		public static DlcEventArgKeyItem PagodaofTheFallenEntered => Instance[0];

		public static DlcEventArgKeyItem PagodaofTheFallenDefeatYufu => Instance[1];

		public static DlcEventArgKeyItem PagodaofTheFallenDefeatWuxiao => Instance[2];

		public static DlcEventArgKeyItem PagodaofTheFallenDefeatRanchen => Instance[3];

		public static DlcEventArgKeyItem PagodaofTheFallenDefeatXiangshu => Instance[4];

		public static DlcEventArgKeyItem PagodaofTheFallenDefeatTiandi => Instance[6];

		public static DlcEventArgKeyItem TameLoongInteractFlag => Instance[5];
	}

	public static DlcEventArgKey Instance = new DlcEventArgKey();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Dlc", "TemplateId", "ArgBoxKey" };

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
		_dataArray.Add(new DlcEventArgKeyItem(0, 13, "ConchShip_PresetKey_PagodaofTheFallenEntered"));
		_dataArray.Add(new DlcEventArgKeyItem(1, 13, "ConchShip_PresetKey_PagodaofTheFallenDefeatYufu"));
		_dataArray.Add(new DlcEventArgKeyItem(2, 13, "ConchShip_PresetKey_PagodaofTheFallenDefeatWuxiao"));
		_dataArray.Add(new DlcEventArgKeyItem(3, 13, "ConchShip_PresetKey_PagodaofTheFallenDefeatRanchen"));
		_dataArray.Add(new DlcEventArgKeyItem(4, 13, "ConchShip_PresetKey_PagodaofTheFallenDefeatXiangshu"));
		_dataArray.Add(new DlcEventArgKeyItem(5, 14, "ConchShip_PresetKey_TameLoongInteractFlag1"));
		_dataArray.Add(new DlcEventArgKeyItem(6, 13, "ConchShip_PresetKey_PagodaofTheFallenDefeatTiandi"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<DlcEventArgKeyItem>(7);
		CreateItems0();
	}

	public int ToTemplateId(string str)
	{
		foreach (DlcEventArgKeyItem item in (IEnumerable<DlcEventArgKeyItem>)this)
		{
			if (item.ArgBoxKey == str)
			{
				return item.TemplateId;
			}
		}
		return -1;
	}

	public string ToArgString(int templateId)
	{
		return GetItem(templateId)?.ArgBoxKey;
	}
}
