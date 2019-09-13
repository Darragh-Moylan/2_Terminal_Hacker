using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game config data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = {"twirl", "oreo", "durex", "paper", "phone" };
    string[] level2Passwords = {"american", "complicate", "radiator", "paracetamol", "diarrhoea" };
    string[] level3Passwords = {"information", "celebration", "inhibitor", "occasional", "darragh" };


    // GAME STATE
    int level;
    string password;
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;


    // Use this for initialization
    void Start ()
    {
        ShowMainMenu();
	}

    void ShowMainMenu ()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to CIT's hacker society, choose a location to hack");
        Terminal.WriteLine("Press 1 to hack your mom's pc");
        Terminal.WriteLine("Press 2 to hack the CIT college");
        Terminal.WriteLine("Press 3 to hack your grades (WARNING - ADVANCED)");
        Terminal.WriteLine("Choose your victim: ");
    }


    void OnUserInput (string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            level = 0;
            Terminal.ClearScreen();
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "yurt") // easter egg
        {
            Terminal.WriteLine("YURTY SQUIRTY");
        }
        else
        {
            Terminal.WriteLine("Choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            WinScreen();
        }
        else
        {
            AskForPassword();
        }
    }
    void WinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);

    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
"
                );
                break;
            case 2:
                Terminal.WriteLine("Have a car...");
                Terminal.WriteLine(@"
       .---;-,
    __/_,{)|__;._ 
 .'` _: _  `.  .:::;. .::'
'--(_)------(_)--' ` '::'
"               );
                break;
            case 3:
                Terminal.WriteLine("A true hackerman");
                Terminal.WriteLine(@"
( ͡°( ͡° ͜ʖ( ͡° ͜ʖ ͡°)ʖ ͡°) ͡°)
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }

    // Update is called once per frame
    void Update ()
    {

    }
}
