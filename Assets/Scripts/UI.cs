using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{  
    //UI variables
    public Button checkButton;
    public Button resetButton;

    public Text guessesLeftText;
    public Text numberInOrderText;
    public Text numbersCorrectText;
    public Text numbersWrongCollection;
    public Text winningCounterText;
    public Text losingCounterText;

    public GameObject bg1;
    public GameObject bg2;

    public InputField inputField;

    //Declare an empty string for the number generator
    public string answer = "";
    
    //Winning counter
    public int winningCounter = 0;
    //Loisng counter
    public int losingCounter = 0;
    //Takes count of the amount of duplicate numbers there are in the generated answer
    public int dupe = 0;
    //The amount of guesses left before the game ends
    public int guessesLeft = 10;
    //Counter of how many numbers are correct
    public int numbersCorrect;
    //Counter of how many numbers are in the right order
    public int numberOrder;

    //Keeps the game going until boolean is changed to 
    public bool endGame = false;
    //Bool to reset the game 
    public bool resetGame = false;
    void Start()
    {
       

        //Show the winning text at 0
        winningCounterText.text = "Won: " + winningCounter;
        //Show the losing counter at 0
        losingCounterText.text = "Lost: " + losingCounter;
        //sets answer to returned random number
        RandomNum(answer);
        //feature to always set up a button
        checkButton.onClick.AddListener(ButtonClicked);
        resetButton.onClick.AddListener(GameReset);
        //Set answer equal to random number 
        //answer = RandomNum(answer);
        //Displays numbers of guesses left at 10
        guessesLeftText.text = ("Enter a 4-digit number");
        //Displays numbers in order
        numberInOrderText.text = ("Numbers in order: 0");
        //Display numbers correct
        numbersCorrectText.text = ("Numbers correct: 0");
        //Display for all wrong answers
        numbersWrongCollection.text = ("");

        
    }
    void GameReset() 
    {
        RandomNum(answer);
         //Takes count of the amount of duplicate numbers there are in the generated answer
        dupe = 0;
        //The amount of guesses left before the game ends
        guessesLeft = 10;
        //Sets display text back to black
        guessesLeftText.color = Color.black;
        //Displays the input directions
        guessesLeftText.text = ("Enter a 4-digit number");
        //Displays numbers in order
        numberInOrderText.text = ("Numbers in order: 0");
        //Display numbers correct
        numbersCorrectText.text = ("Numbers correct: 0");
        //Display for all wrong answers
        numbersWrongCollection.text = ("");
        //Sets the game to play again.
        endGame = false;
    }
    void ButtonClicked() 
    {
        GameMech();
    }
    
    private string RandomNum(string value) 
    {
        do
        {
            dupe = 0;
            answer = "";
            for (int i = 0; i < 4; ++i) 
            {
                answer += Random.Range(0, 10);
            }
            
            for(int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j) 
                {
                    if(answer[i] == answer[j] && i != j) 
                    {
                        dupe++;
                        break;
                    }
                }
            }
        } while (dupe > 0);
        return value;

    }
    public void GameMech() 
    {
        //Have the game working from the start
        if (endGame == false)
        {
            //Takes the input of the player
            string inputText = inputField.text;
            //Checks if the input text is a duplicate

            int dupeWord = 0;
            bool dupeWordCheck = false;
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (inputText[i] == inputText[j] && i != j)
                    {
                        dupeWord++;
                        dupeWordCheck = true;
                        break;
                    }
                }
            }

            //Set numbers in order to 0
            numberOrder = 0;
            //Set numbers correct to 0
            numbersCorrect = 0;
            //Create a big if statement
            // if input text equals secret text 1
            //Upscale background1
            if (inputText == "SBRJ10") 
            {
                bg1.transform.position = new Vector3(211f, 220f, 0f);
            }
            if (inputText == "PSGT98")
            {
                bg2.transform.position = new Vector3(133f, 278f, 0f);
            }
            else if (inputText == "DFLT") 
            {
                bg1.transform.position = new Vector3(211f, 220f, 6969f);
                bg2.transform.position = new Vector3(133f, 278f, 6969f);
                //Display error message
                guessesLeftText.text = "Enter a 4-digit number";
            }
            else if(dupeWordCheck == true)
            {
                guessesLeftText.text = "Duplicate numbers not allowed";
            }
            else 
            {
                if (inputText.Length < 4 || inputText.Length > 4)
                {
                    //Display error message
                    guessesLeftText.text = "Enter a 4-digit number";
                }
                else
                {   //Create a for loop that loops 3 times
                    for (int i = 0; i < 4; i++)
                    {
                        //If numbers in input are in answer
                        if (answer.Contains(inputText[i].ToString()))
                        {
                            //add 1 for each number correct
                            numbersCorrect++;
                        }
                        //If index of the answer matches index of the input
                        if (inputText[i] == answer[i])
                        {
                            //add 1 for each number in order
                            numberOrder++;
                        }
                    }
                    //Checks if the player still has 0 guesses
                    if (guessesLeft == 1)
                    {
                        //Change the color of the answer displayed to red
                        guessesLeftText.color = Color.red;
                        //Display the answer
                        guessesLeftText.text = "Answer is: " + answer;
                        //add 1 to the losing counter
                        losingCounter++;
                        //Update the losing text display
                        losingCounterText.text = "Lost: " + losingCounter;
                        //set end game to true to end the game loop
                        endGame = true;

                    }
                    //else game continues
                    else
                    {

                        //if the user gets the answer right
                        if (answer == inputText)
                        {
                            //Change color of winning text to blue
                            guessesLeftText.color = Color.blue;
                            //using the guess counter, display the player won with the guesses left
                            guessesLeftText.text = "You won! Answer is: " + answer + " with " + guessesLeft + " guesses left.";
                            //Add 1 to the winning counter
                            winningCounter++;
                            //Update the win counter
                            winningCounterText.text = "Won: " + winningCounter;
                            //end the game loop
                            endGame = true;
                        }
                        //else if the user is wrong
                        else
                        {
                            //Subtract 1 from guesses player has left
                            guessesLeft--;
                            //Add to the collection of wrong inputs
                            numbersWrongCollection.text += " " + inputText + " Numbers correct: " + numbersCorrect + " Numbers in order: " + numberOrder + " ";
                            //Change the guess display text to the guesses left
                            guessesLeftText.text = ("Tries Left: " + guessesLeft);
                            //Displays the amount of numbers in order
                            numberInOrderText.text = ("Numbers in order: " + numberOrder);
                            //Display the amount of numbers correct
                            numbersCorrectText.text = ("Numbers correct: " + numbersCorrect);


                        }

                    }
                }
            }
            
            

           
           
        }
    }
    


}
