using System;
using System.Linq;
using System.Collections.Generic;

public class SelectionWithValidation 
{
    //List<> SelectionList = new 
	private string Header;
	private string subHeader;
    public delegate void ActionCon();
	struct ActionType
    {
        public ActionCon action;
		public string actionName;
		
    }
	 

    List<ActionType> ActionList = new List<ActionType>();
    public void InvokeSelection(int index)
    {
        ActionList[index].action.Invoke();
    }
    public void AddSelectionAction(ActionCon action, string actionName)
	{
        ActionType actionTemp = new ActionType();
		actionTemp.action = action;
		actionTemp.actionName = actionName;
        ActionList.Add(actionTemp);
    }  

    public void ShowSelection()
	{	
        int index = 0;
        int Selection_Size = ActionList.Count();
		Console.WriteLine("");
        Console.WriteLine($"Select Operation 1 - {Selection_Size}");
        foreach (var itemInAction in ActionList)
        {
            Console.WriteLine($"[{++index}] {itemInAction.actionName}");
        }
        ActionList[SelectOperation()].action.Invoke();
    }
	private  

    int SelectOperation()
	{
        string String_InputSelected;
		bool isSelectedAction = false;
        do
		{
            try
			{
                int Selection_Size = ActionList.Count();
                Console.WriteLine("Enter Action : ");
                String_InputSelected = Console.ReadLine();
                int parsedString = Int32.Parse(String_InputSelected);
				if(parsedString <= ActionList.Count() && parsedString > 0)
				{
                    isSelectedAction = true;
					return parsedString - 1;
                }
				else
				{
                    Console.WriteLine($"Select From 1 - {Selection_Size} ");
                }
				
            }
			catch(Exception err)
			{
                Console.WriteLine("Invalid Input");
            }
        }
        while(!isSelectedAction);
		return 0;
    }
}