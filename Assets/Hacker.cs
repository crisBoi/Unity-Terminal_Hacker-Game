using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

	private enum Screen { MainMenu, Password, Win};
	private Screen currentScreen = Screen.MainMenu;


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
    	} 
    }


    private void RunMainMenu(string input) {
    	if (input == "1") {
    		
	    	StartGame(input);
    		

    	} else if (input == "2") {

    		StartGame(input);
    		

    	} else if (input == "3") {
    		
    		StartGame(input);
    	
    		
    	} else {
    		showMainMenu();
    		Terminal.WriteLine("Enter a valid number");
    	}
    }


    private void StartGame(string level) {
    	Terminal.ClearScreen();
    	Terminal.WriteLine("You have entered " + level);
    	Terminal.WriteLine("Enter your password :" );

    	currentScreen = Screen.Password;
    }
}
