namespace GameData.GameDataBridge.VnPipe;

public interface IPipe
{
	int Read(byte[] buf, int off, int len);

	int Write(byte[] buf, int off, int len);

	bool Flush();
}
