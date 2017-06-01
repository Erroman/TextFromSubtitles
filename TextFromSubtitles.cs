//Nearest task is to create a repository for the project on GitHub
using System;
using System.IO;
using System.Windows.Forms;
class TextFromSubTitles{
//static Form form = null;	
static void Main()
{
	Form form = new Form();
	Button btn = new Button();
	form.Controls.Add(btn);
	btn.Click+=(x,y)=>MessageBox.Show("I am clicked !");
   Application.Run(form);
}
static void doConversion()
{
 
	FindAStringWithAPattern findALine = new FindAStringWithAPattern();
	ReWriteToAnotherFile rew =new ReWriteToAnotherFile();
	int startPosition= -1;
	int endPosition  = -1;
	while(true)
	{
		endPosition = findALine.numberOfTheStringFound();
		if(endPosition == -1) endPosition = findALine.amountOfStrings-1;
		if(findALine.endOfFileReached)
		{
			if(startPosition==-1)
				break;
			else
			{
				rew.ReadAndWrite(startPosition+1,endPosition-2);
				break;
			}
			
				
		}
		else
		{
			rew.ReadAndWrite(startPosition+1,endPosition-2);
			startPosition=endPosition;
		}
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
			
			if(readLine.IndexOf("-->")>-1)
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
				Console.WriteLine(readLine);
			}
		} 
		sw.Flush();
		return endTransfer - startTransfer;
	}
	
}