//Nearest task is to create a repository for the project on GitHub
using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
class TextFromSubTitles{
//static Form form = null;	
static public string fileNameWithSubtitles;
[STAThread]
static void Main()
{
	Form form = new Form();
	Button btn = new Button();
	TextBox tbx = new TextBox();
	tbx.Location = new System.Drawing.Point(76, 79);
	btn.Location = new System.Drawing.Point(76, 99);
	FlowLayoutPanel panel = new FlowLayoutPanel();
	panel.Controls.Add(btn);
	panel.Controls.Add(tbx);	
	
	form.Controls.Add(panel);
	btn.Click += (x,y)=> 
	{
	   fileNameWithSubtitles = tbx.Text;
	   doConversion();
	   
	};	
	//System.ComponentModel.IContainer components = new System.ComponentModel.Container();
	
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
	
	StreamReader sr = File.OpenText(TextFromSubTitles.fileNameWithSubtitles);

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

	StreamReader sr = File.OpenText(TextFromSubTitles.fileNameWithSubtitles);
	 static  string fileNameWithSubtitles = TextFromSubTitles.fileNameWithSubtitles.Substring(0,TextFromSubTitles.fileNameWithSubtitles.Length-3)+"txt";
	StreamWriter  sw = File.CreateText(fileNameWithSubtitles);
    
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