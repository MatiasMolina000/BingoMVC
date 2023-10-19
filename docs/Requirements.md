<h2 align=center>📝 Requirements</h3>

<br>

<section>

### 👾 Game dynamics
- The game presents four differents bingo cards generated randomly.
- The aplication will have a single button called **_"Draw Ball"_** that will automatically generate a number from 1 to 90 and display it with the **_Ball_** text.
- After each draw, it should be checked wheter the new number exist on any of the bingo cards, and if it does, that number should be marked in red on the respective card.
- When one or more bingo cards reach the **_Full Card_** state, meaning that all the numbers on the card are maked in red, the game will end, and the winning card or cards will be displayed with the **Winning card** text.

</section>

<br>

<section>

### 🔨 Bingo card construction
- Card with 3 rows and 9 columns.
- The card must have 15 numbers and 12 blank spaces.
- Each row must contain 5 numbers.
- Each column must contain 1 or 2 numbers.
- No number can be repeated.
- The first column contains numbers from 1 to 9, the second from 10 to 19, the third from 20 to 29, and so on, until the last column, which contains numbers from 80 to 90.

</section>

<br>

<section>

### 💾 Storable information

- A table named __BallRecord__ that will store each generated number. It will store the date and time along with the ball number played.
- A table named __CardRecord__ where the winning card or cards will be recorded.
- The HistorialCartones table will have 5 fields: one for date and time, and then 4 fields (Card1, Card2, Card3, and Card4) that can accept null values to store the winning card or cards. For example: If cards 3 and 1 are winners, data will be saved in the Date and Time field with the current time, 3 in the Card1 field, and 1 in the Card2 field.

</section>

<br>

<footer align="center">
    <hr>

### ◀️ [Return](../README.md)

</footer>