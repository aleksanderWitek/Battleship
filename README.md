# Battleship
Battleship boardgame ( C#, .NET 4.72, Windows Forms App .Net Framework, SQL )

### What my program does?

My program simulates Battleship board game.   
When the program is turned on 1st Player have to place his 2 blue ships and 2 red ships by clicking on the active board on the left.   
After that 1st Player have to press "finished" button and then his board will disappear and 2nd Player turn for placing ships will start but first he have to press the button which will appear under the board on the left side.   
Now 2nd Player have to place his 2 blue and red ships and press the "finished" button.  
Now starts 2nd part of the game. Which is shooting to ships.  
This part starts with 2 boards with one showing Player ships on his board (board on the left) and enemy board on the right.  
To make a shot Player have to click on random field on enemy board, after that board gets disabled and only thing which player can do is to press "Done" button which finishes his round.  
Then boards disappears and some kind of waiting room will appear which is empty boards and 1 button "Go" button in the middle and after pressing it 2nd Player starts his round and does same thing as 1st Player.  
When Player hits the enemy ship he gets 1 point in the score next to his name above left board. When someone get 10 ponits and press "done" button he will win the game.

### Architecture

In App.config i have created connection string for my data base created in Microsoft SQL Server Managment.
My model folder contains a representation of the database.   
Folder Functions have clasess where i check or update date in database and return some data back to main class Form1.  
In main class Form1 i tried to use only functions which changes some buttons background or board view or text on the board.  

### What i would change in my program if i have more time (or better PC)

I would add for sure some text explaining how it works in each stage and create better view.  
Another thing would be deleting some sapces between code lines and i would try to reduce number of if statements.
One more thing i would add is showing on Players board where enemy have already shooted.