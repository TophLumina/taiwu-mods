using GameData.Common;
using GameData.Domains.SpecialEffect;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class TeammateCommandInvokerFrame : TeammateCommandInvokerBase, IFrameCounterHandler
{
	private readonly FrameCounter _counter;

	public int CharacterId => MainCharId;

	public TeammateCommandInvokerFrame(int charId, int index)
		: base(charId, index)
	{
		Tester.Assert(base.CmdConfig.AutoFrame > 0, "CmdConfig?.AutoFrame > 0");
		_counter = new FrameCounter(this, base.CmdConfig.AutoFrame);
	}

	public override void Setup()
	{
		_counter.Setup();
	}

	public override void Close()
	{
		_counter.Close();
	}

	public void OnProcess(DataContext context, int counterType)
	{
		if (context.Random.CheckPercentProb(base.CmdConfig.AutoProb))
		{
			Execute(context);
		}
	}
}
