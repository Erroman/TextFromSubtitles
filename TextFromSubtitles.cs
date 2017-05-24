using System;
using System.IO;
class TextFromSubTitles{
static void Main()
{


    ReWriteToAnotherFile rew =new ReWriteToAnotherFile();
    rew.ReadAndWrite(2,3);
	rew.ReadAndWrite(7,8);
	rew.ReadAndWrite(12,13);
	rew.ReadAndWrite(17,17);
	// Find a line with a pattern and return its number or null
	// if ir isn't found


}	
	
}
class ReWriteToAnotherFile{
	
	private string readLine;
	private int currentPosition = 0;

	StreamReader sr = File.OpenText("Мышиная возня.srt");
	StreamWriter  sw = File.CreateText("Мышиная возня.txt");
    
	public int ReadAndWrite(int startTransfer,int endTransfer)
	{
	for ( ; currentPosition <= endTransfer; currentPosition++)
		{
			readLine = sr.ReadLine();
			if (currentPosition < startTransfer)
			{
				Console.WriteLine("--pass--  {0}",readLine);
				continue;
			
			}
			else
			{
				Console.WriteLine("--write-- {0}",readLine);
				sw.WriteLine(readLine);
			}
		} 
		sw.Flush();
		return endTransfer - startTransfer;
	}
	
}