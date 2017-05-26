//Nearest task is to create a repository for the project on GitHub
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
	// if it isn't found
	FindAStringWithAPattern findALine = new FindAStringWithAPattern();
	Console.WriteLine("----------{0}-----------",findALine.numberOfStringFound());
	Console.WriteLine("----------{0}-----------",findALine.numberOfStringFound());
	Console.WriteLine("----------{0}-----------",findALine.numberOfStringFound());
	Console.WriteLine("----------{0}-----------",findALine.numberOfStringFound());

}	

}
class FindAStringWithAPattern
{
	private string readLine;
	private int currentPosition = 0;
	private int foundNumber = -1;
	StreamReader sr = File.OpenText("Мышиная возня.srt");

	public int numberOfStringFound()
	{
		while((readLine = sr.ReadLine())!=null)
		{	
			Console.WriteLine(readLine);
			if(readLine.IndexOf("-->")==13)
			{
				foundNumber = currentPosition;
				currentPosition++;
				break;
			}
			else		
			{
				currentPosition++;
			}	
		}
		return foundNumber;	
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
				continue;
			}
			else
			{
				sw.WriteLine(readLine);
			}
		} 
		sw.Flush();
		return endTransfer - startTransfer;
	}
	
}