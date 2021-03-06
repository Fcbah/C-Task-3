﻿using System;

namespace Number_Guessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************************************************************************");
            Console.WriteLine("--------------------NUMBER GUESSING GAME----------------------------------------------");
            
            bool invalid = true;
            
            //Selecting the difficulty level
            string raw;
            int guess_upper_range = 0;
            int max_guess_trials =0;
            Console.WriteLine(return_intro_and_menu());
            Console.Write("Select Your Level of Difficulty: ");

            while(invalid){
                
                raw = Console.ReadLine();
                invalid = false;

                if(raw == "EASY"){
                    guess_upper_range= 10;
                    max_guess_trials= 6;
                }//end if
                else if(raw == "MED"){
                    guess_upper_range= 20;
                    max_guess_trials= 4;
                }else if (raw == "HARD"){
                    guess_upper_range= 50;
                    max_guess_trials= 3;
                }
                else{
                    invalid = true;
                    Console.WriteLine("Invalid Input, Enter a valid difficulty level");
                    Console.WriteLine(return_intro_and_menu());
                    Console.Write("Once again: Select Your Level of Difficulty: ");
                }

                
            }//end while
            
            bool win_out = game(guess_upper_range, max_guess_trials);
            

            if(win_out){
                Console.WriteLine("YOU WIN - COMPUTER LOST");
            }//end if
            else{
                Console.WriteLine("COMPUTER WIN GAME OVER");
            }//end if/else win out
            
        }//end static void main()

        static string return_intro_and_menu(){
            string outt = "This game has three difficulty levels below\n";
            outt += "Enter the text in the <> brackets to select your difficulty level \n\n";
            outt += "<EASY> The easy level \n";
            outt += "<MED> The Medium level \n";
            outt += "<HARD> The Hard level \n";
            return outt;
        }
        
        static bool game(int max_guess_val, int max_guess_trial){
            Random generator = new Random();

            string[] positions = { "1st", "2nd", "3rd", "4th", "5th", "6th", "7th" };

            Random rand = new Random();
            int answer = rand.Next(1, 1+max_guess_val);
            int guess;
            int i = 0;
            Console.WriteLine("******************************GAME STARTS*********************************\n");
            Console.WriteLine("There is a whole number between [1, {0}], which I am keeping, If you guess it right before {1} trials, you win: otherwise you loose.",max_guess_val,max_guess_trial);

            while (i < max_guess_trial)
            {
                //Validating the input
                Console.WriteLine("Make your {0} guess:", positions[i]);
                while (true)
                {
                    
                    try
                    {
                        guess = Convert.ToInt16(Console.ReadLine());

                        if (1 <= guess && guess <= max_guess_val)
                        {
                            break;
                        }//end if

                        Console.WriteLine("\tPlease Enter a number within the valid range");
                    }//end try
                    catch (Exception gh)
                    {
                        Console.WriteLine("\tInvalid Input, You cant enter an alphabet");
                    }//end catch

                    Console.WriteLine("Repeat your {0} guess:", positions[i]);
                }//End while the input is invalid

                //incrementing the guess.
                i++;
                //test for correctness
                if (guess == answer)
                {
                    Console.WriteLine("Hurray !!! You got it right after {0} trials, the correct answer is {1}", i, answer);
                    return true;
                }
                else
                {
                    Console.WriteLine("\t That was wrong");
                }
            }//end while game is not over
            Console.WriteLine("The right answer was: {0}",answer);
            return false;
            // }//end while bool game
        }
    }//end class
}//end namespace
