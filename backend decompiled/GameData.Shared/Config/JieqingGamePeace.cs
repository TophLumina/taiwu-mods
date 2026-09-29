using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class JieqingGamePeace : ConfigData<JieqingGamePeaceItem, short>
{
	public static JieqingGamePeace Instance = new JieqingGamePeace();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId", "Name", "Color", "Width", "Height", "Shape", "ArtResourceIndex" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new JieqingGamePeaceItem(0, "斗", null, 2, 2, new bool[16]
		{
			true, true, true, true, false, false, true, true, true, true,
			true, true, false, false, false, false
		}, 4));
		_dataArray.Add(new JieqingGamePeaceItem(1, "牛", null, 2, 2, new bool[16]
		{
			true, true, true, true, true, false, false, true, true, false,
			false, true, false, false, false, false
		}, 0));
		_dataArray.Add(new JieqingGamePeaceItem(2, "女", null, 2, 2, new bool[16]
		{
			true, true, true, true, false, false, true, true, true, true,
			false, false, false, false, true, true
		}, 3));
		_dataArray.Add(new JieqingGamePeaceItem(3, "虚", null, 1, 2, new bool[8] { false, false, true, true, true, false, false, true }, 5));
		_dataArray.Add(new JieqingGamePeaceItem(4, "危", null, 2, 2, new bool[16]
		{
			false, true, true, false, false, false, true, true, true, true,
			false, false, true, false, false, true
		}, 2));
		_dataArray.Add(new JieqingGamePeaceItem(5, "室", null, 3, 3, new bool[36]
		{
			false, true, true, false, true, true, true, true, true, false,
			false, true, true, true, true, true, true, false, false, true,
			false, false, false, false, true, false, false, true, false, false,
			false, false, false, false, false, false
		}, 1));
		_dataArray.Add(new JieqingGamePeaceItem(6, "壁", null, 3, 1, new bool[12]
		{
			false, true, true, false, true, true, true, true, true, false,
			false, true
		}, 6));
		_dataArray.Add(new JieqingGamePeaceItem(7, "星", null, 1, 1, new bool[4] { false, false, true, true }, 7));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<JieqingGamePeaceItem>(8);
		CreateItems0();
	}
}
