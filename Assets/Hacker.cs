using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

	private enum Screen { MainMenu, Password, Win};
	
	private Screen currentScreen = Screen.MainMenu;
	
	private string password = "";
	private string[] level1Passwords = {"table", "apple", "boy", "shop", "green"};
	private string[] level2Passwords = {"virus", "serum", "frog", "blood", "cell"};
	private string[] level3Passwords = {"conscious", "saturn", "galaxy", "quantum", "particles"};
	private string[] level1Hints = {"needed with a chair", "first fruit", "opposite of girl", "where shopkeeper works", "grass is"};
	private string[] level2Hints = {"infected by", "serum", "first disection", "type group", "you are mad up of"};
	private string[] level3Hints = {"only humans possess", "rings in solar system", "galaxy", "stream of physics to complicated to understand", "light is a"};


	private int level, index = 0;

    // Start is called before the first frame update
    void Start()
    {
    	showMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void showMainMenu() {

    	currentScreen = Screen.MainMenu;

    	Terminal.ClearScreen();

        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for bio chemistry lab");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("\nEnter your selection: ");

    }

    void OnUserInput(string input) {
    	print(input);

    	if (input == "menu") {
    		showMainMenu();
    	}
	    else if (currentScreen == Screen.MainMenu) {
    		
	    	RunMainMenu(input);

    	} else if (currentScreen == Screen.Password) {
    		checkPassword(input);
    	} else if (currentScreen == Screen.Win) {
    		RunMainMenu(input);
    	}
    }


	 private void RunMainMenu(string input) {

	    	
	    	
	    	bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
	    	
	    	if (isValidLevelNumber) {
	    		
	    		level = int.Parse(input);
	    		StartGame();

	    	} else {
	    		
	    		showMainMenu();
	    		Terminal.WriteLine("Enter a valid number");

	    	}
	    }


    


    private void StartGame() {
    	
    	Terminal.ClearScreen();
    	Terminal.WriteLine("Welcome to level " + level);
    	Terminal.WriteLine("Enter your password :" );

    	currentScreen = Screen.Password;

    	
    	switch(level) {

    		case 1 :
    		
    		SetLevel(1);
    		

    		break;

    		case 2 : 

    		SetLevel(2);
    		
    		
    		break;

    		case 3 : 
    		
    		SetLevel(3);
    		
    		
    		break;

    		default : Debug.LogError("Invalid level number");
    		break;

    	}

    }


    private void checkPassword(string enteredPassword) {

    	if (password == enteredPassword) {
    		
    		
    		ShowReward();
    		currentScreen = Screen.Win;
    	
    	} else {
    		
    		Terminal.WriteLine("Wrong password");
    		Terminal.WriteLine("Enter your password :" );
    		
    		if (index < 4) {index++;}
    		else {index = 0;}
    		
    		SetLevel(level);
    		
    	}

    	
    }
   

    private void ShowHint() {

    	switch(level) {

    		case 1 :
    		Terminal.WriteLine("hint: " + level1Hints[index]);
    		break;

    		case 2 : Terminal.WriteLine("hint: " + level2Hints[index]);
    		break;

    		case 3 : Terminal.WriteLine("hint: " + level3Hints[index]);
    		break;
    	}
    }



    private void SetLevel(int currentLevel) {


    	if (currentLevel == 1) {

    		level = 1;
    		ShowHint();
    		password = level1Passwords[index];

    	} else if (currentLevel == 2) {
				
			level = 2;
			ShowHint();
			password = level2Passwords[index];
    		
		} else if (currentLevel == 3) {
			level = 3;
			ShowHint();
			password = level3Passwords[index];
		}

    	
    }


    private void ShowReward() {

    	Terminal.ClearScreen();

    	switch(level) {
    		case 1 :
    		Terminal.WriteLine("CONGRATULATIONS YOU HAVE BROKED INTO LIBRARY"); 
    		Terminal.WriteLine(@"
    -------
   /      //
  /      //
 /______//
(______(/");
    		break;


    		case 2 :
    		Terminal.WriteLine("CONGRATULATIONS YOU HAVE BROKED INTO BIO CHEMIST LAB"); 
    		Terminal.WriteLine(@"
        
  `MMMMMM/   /   \   _   ,    
   MMM|  __  / __/  ( |_|
   YMM/_/# \__/# \    | |_)arry
   (.   \__/  \__/     ___  
     )       _,  |    '_|_)
_____/\     _   /       | otter
    \  `._____,'
     `..___(__");
    		break;



    		case 3 :
    		Terminal.WriteLine("CONGRATULATIONS YOU HAVE BROKED INTO NASA"); 
    		Terminal.WriteLine(@"
   |||||
 ||. .||
|||\=/|||
|.-- --.|
/(.) (.)\
\ ) . ( /
'(  v  )`
  \ | /
  ( | )
  '- -`");
    		break;
    	}
    }
	
   
}
