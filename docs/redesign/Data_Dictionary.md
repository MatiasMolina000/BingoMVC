### 📕 Data Dictionary
<hr>
In this section, the metadata of the proposed model is documented, classified by entities.

<br>


<section align=center>Glosary
    <div align=center>

| Id | Description |
|:--:|:-----------:|
|**PK**|Primary Key|
|**FK**|Foreign Key|
|**N/A**|Non-Aplicable|
|**AI**|Auto-Incremental|
|**CDT**|Currend date and time|

<div>
</section>

<br><br>

<section>

#### dbo Scheme

<article>

- Data Dictionary from **BingoCage** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | bigint | 8 bytes | No | Si | AI | PK of the BingoCage entity |
| GameId | int | 4 bytes | No | N/A | N/A | FK of the Game entity |
| Number | int | 4 bytes | No | N/A | N/A | Number of the draw ball |
| Creatd | datetime | 8 bytes | No | N/A | N/A | CDT of the a draw ball |


</article>
<br>
<article>

- Data Dictionary from **BingoCard** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | bigint | 8 bytes | No | Si | AI | PK of the BingoCage entity |
| GameId | int | 4 bytes | No | N/A | N/A |FK of the Game entity |
| Card | tinyint | 1 bytes | No | N/A | N/A | Number of the bingo card |
| Numbers | varchar | 100 bytes | No | N/A | N/A | String with the numbers of the bingo card |
| OrderedN | varchar | 100 bytes | No | N/A | N/A | String with the numbers and the blanks of the bingo card |
| Completed | bit | 1 bytes | No | N/A | N/A | CDT of the a bingo card |

</article>
<br>
<article>

- Data Dictionary from **GStatus** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | tinyint | 1 bytes | No | Si | AI | PK of the GStatus entity |
| Status | varchar | 25 bytes | No | N/A | N/A | Name of the game status |

</article>
<br>
<article>

- Data Dictionary from **Role** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | tinyint | 1 bytes | No | Si | AI | PK of the Role entity |
| Role | varchar | 25 bytes | No | N/A | N/A | Name of the role |

</article>
<br>
<article>

- Data Dictionary from **UStatus** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | tinyint | 1 bytes | No | Si | AI | PK of the UStatus entity |
| Status | varchar | 25 bytes | No | N/A | N/A | Name of the user status |

</article>
<br>
<article>

- Data Dictionary from **User** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | int | 4 bytes | No | Si | AI | PK of the GState entity |
| StatusId | tinyint | 1 bytes | No | N/A | N/A | FK of the UStatus entity |
| User | varchar | 25 bytes | No | N/A | N/A | Name of the user |
| Email | varchar | 50 bytes | No | N/A | N/A | Name of the user's email |
| Password | varchar | 64 bytes | No | N/A | N/A | User's password |
| Created | datetime | 8 bytes | No | N/A | N/A | CDT of the a user |

</article>
<br>
<article>

- Data Dictionary from **UserRole** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | int | 4 bytes | No | Si | AI | PK of the UserRole entity |
| UserId | int | 4 bytes | No | N/A | N/A | FK of the User entity |
| RoleId | tinyint | 1 bytes | No | N/A | N/A | FK of the Role entity |

</article>
<br>
<article>

- Data Dictionary from **Game** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | int | 1 bytes | No | Si | AI | PK of the Game entity |
| UserId | int | 4 bytes | No | N/A | N/A | FK of the User entity |
| StatusId | tinyint | 1 bytes | No | N/A | N/A | FK of the GStatus entity |
| Start | datetime | 8 bytes | No | N/A | N/A | CDT of the game |
| End | datetime | 8 bytes | Yes | N/A | N/A | Date and time of the game ends |
| Status | tinyint | 1 bytes | No | N/A | N/A | Number of the migrated status |

</article>
</section>

<br>

<section>

#### Replica Scheme

<article>

- Data Dictionary from **BingoCage** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | bigint | 8 bytes | No | Si | AI | PK of the BingoCage entity |
| GameId | int | 4 bytes | No | N/A | N/A | FK of the Game entity |
| Number | int | 4 bytes | No | N/A | N/A | Number of the draw ball |
| Creatd | datetime | 8 bytes | No | N/A | N/A | CDT of the a draw ball |


</article>
<br>
<article>

- Data Dictionary from **BingoCard** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | bigint | 8 bytes | No | Si | AI | PK of the BingoCage entity |
| GameId | int | 4 bytes | No | N/A | N/A |FK of the Game entity |
| Card | tinyint | 1 bytes | No | N/A | N/A | Number of the bingo card |
| Numbers | varchar | 100 bytes | No | N/A | N/A | String with the numbers of the bingo card |
| OrderedN | varchar | 100 bytes | No | N/A | N/A | String with the numbers and the blanks of the bingo card |
| Completed | bit | 1 bytes | No | N/A | N/A | CDT of the a bingo card |

</article>
<br>
<article>

- Data Dictionary from **Game** entity

| Name | Type of field | Length | Allows Null | Deffautlt value | Constrain | Description | 
|:----:|:-------------:|:------:|:-----------:|:---------------:|:---------:|:------------|
| Id | int | 1 bytes | No | Si | AI | PK of the Game entity |
| UserId | int | 4 bytes | No | N/A | N/A | FK of the User entity |
| StatusId | tinyint | 1 bytes | No | N/A | N/A | FK of the GStatus entity |
| Start | datetime | 8 bytes | No | N/A | N/A | CDT of the game |
| End | datetime | 8 bytes | Yes | N/A | N/A | Date and time of the game ends |
| Winners | varchar | 25 bytes | No | N/A | N/A | Card Number of the completed bingo cards |

</article>
</section>


<br><br>

<footer align="center">
    <hr>

### ◀️ [Return](../../README.md)

</footer>