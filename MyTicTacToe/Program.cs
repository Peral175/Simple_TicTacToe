/* 
    Alex Perrard
    Simple TicTacToe game to familiarize with C# 
*/

using System.Net.NetworkInformation;

class TicTacToe {

    public string[] Field = ["_","_","_","_","_","_","_","_","_"];
    public int currentPlayer = 1;

    public static void Main(){
        var game = new TicTacToe();
        game.Game();
    }

    public void Game(){
        Console.WriteLine("Hello to TicTacToe!\nStarting game...");
        displayField();

        bool isOver = false;    // continue until the game is over

        while (!isOver) {
            Console.WriteLine($"Player {currentPlayer}'s turn. Please select a field (1-9):");
            bool done = false;
            // get the current players input
            while (!done) {
                string userInput = Console.ReadLine();
                var res = isValidMove(userInput);   // verify input
                bool b = res.Item1;
                int i = res.Item2;
                if (b == false) {
                    Console.WriteLine("Invalid choice. Please try again!");
                }
                else {
                    Console.WriteLine("Choice accepted.");
                    done = true;
                    makeMove(i);    // update field if input is accepted
                    displayField(); // display updated field
                    this.currentPlayer = ((this.currentPlayer)%2)+1;    // next players turn
                    // check whether game is over
                }
            }
        }
    }

    public void displayField(){
        Console.WriteLine("Current Field:\n");
        for (int i=0;i<3;i++){
            Console.Write(this.Field[i*3+0]);
            Console.Write(" | ");
            Console.Write(this.Field[i*3+1]);
            Console.Write(" | ");
            Console.Write(this.Field[i*3+2]);
            Console.Write("\n");
        }
        Console.WriteLine("\n");
    }

    public (bool, int) isValidMove(string input){
        // verify if input is correct integer
        int i = 0;
        bool b = Int32.TryParse(input, out i);
        if (b == true && (1 <= i) && (9 >= i))
        {
            // verify if input field is already taken
            if (this.Field[i-1] == "_") {
                return (true, i-1);
            }
            return (false, 0);
        }
        return (false, 0);
    }

    public void makeMove(int verifiedInptut){
        string mark;
        if (this.currentPlayer == 1) {
            mark = "X";
        }
        else{
            mark = "O";
        }
        this.Field[verifiedInptut] = mark;
    }

}