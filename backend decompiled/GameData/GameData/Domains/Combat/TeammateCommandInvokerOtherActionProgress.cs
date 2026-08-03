using System.Collections.Generic;
using GameData.Common;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class TeammateCommandInvokerOtherActionProgress : TeammateCommandInvokerBase
{
	private readonly List<DataUid> _dataUids = new List<DataUid>();

	private int _lastProgressOtherAction;

	private int _lastProgressUseItem;

	public TeammateCommandInvokerOtherActionProgress(int charId, int index)
		: base(charId, index)
	{
		int[] autoProgress = base.CmdConfig.AutoProgress;
		Tester.Assert(autoProgress != null && autoProgress.Length > 0, "CmdConfig.AutoProgress is { Length: > 0 }");
	}

	private DataUid Parse(ushort fieldId)
	{
		return new DataUid(8, 10, (ulong)MainCharId, fieldId);
	}

	private void Listen(ushort fieldId, DataModificationHandler handler)
	{
		DataUid uid = Parse(fieldId);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(uid, base.DataHandlerKey, handler);
		_dataUids.Add(uid);
	}

	public override void Setup()
	{
		Listen(70, OnOtherActionPreparePercentChanged);
		Listen(74, OnUseItemPreparePercentChanged);
	}

	public override void Close()
	{
		foreach (DataUid uid in _dataUids)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, base.DataHandlerKey);
		}
		_dataUids.Clear();
	}

	private void OnOtherActionPreparePercentChanged(DataContext context, DataUid arg2)
	{
		OnProgressChanged(context, ref _lastProgressOtherAction, base.MainChar.GetOtherActionPreparePercent());
	}

	private void OnUseItemPreparePercentChanged(DataContext context, DataUid arg2)
	{
		OnProgressChanged(context, ref _lastProgressUseItem, base.MainChar.GetUseItemPreparePercent());
	}

	private void OnProgressChanged(DataContext context, ref int lastProgress, int newProgress)
	{
		bool anyCheck = false;
		int[] autoProgress = base.CmdConfig.AutoProgress;
		foreach (int progress in autoProgress)
		{
			if (newProgress >= progress && lastProgress < progress)
			{
				anyCheck = true;
			}
		}
		if (anyCheck && context.Random.CheckPercentProb(base.CmdConfig.AutoProb))
		{
			Execute(context);
		}
		lastProgress = newProgress;
	}
}
