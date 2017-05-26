//Nearest task is to create a repository for the project on GitHub
using System;
using System.IO;
class TextFromSubTitles{
static void Main()
{
    
	FindAStringWithAPattern findALine = new FindAStringWithAPattern();
	ReWriteToAnotherFile rew =new ReWriteToAnotherFile();
	int lineNumber1,lineNumber2;
	while(true)
	{
		if(!findALine.endOfFileReached)
		if((lineNumber1 = findALine.numberOfTheStringFound())!=-1)
			if((lineNumber2 = findALine.numberOfTheStringFound())!=-1)
				rew.ReadAndWrite(lineNumber1,lineNumber2);
			else
				rew.ReadAndWrite(lineNumber1,findALine.amountOfStrings);
	}	
	
}	

}
class FindAStringWithAPattern
{
	public int  amountOfStrings;
	public bool endOfFileReached=false;
	
	private string readLine;
	private int currentPosition = 0;
	private int foundNumber = -1;
	
	StreamReader sr = File.OpenText("Мышиная возня.srt");

	public int numberOfTheStringFound()
	{
		while((readLine = sr.ReadLine())!=null)
		{	
			
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
		if(readLine==null)
		{
			amountOfStrings=currentPosition;
			endOfFileReached=true;
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