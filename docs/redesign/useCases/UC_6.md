<style>.bolded{font-weight:bold;}table{border:4px solid;}</style>

<h3 align=center>📌 Load Game</h3>
<hr>
<br>

<table>
    <thead">
        <tr>
            <td class="bolded">Use Case:</strong></td>
            <td>Load Game</td>
            <td class="bolded">Identifier:</strong></td>
            <td>UC_6</td>
        </tr>
        <tr>
            <td colspan="2" class="bolded">Use Case Level:</strong></td>
            <td colspan="2">Player User</td>
        </tr>
        <tr>
            <td class="bolded">Priority:</strong></td>
            <td>High</td>
            <td class="bolded">Complexity:</strong></td>
            <td>Medium</td>
        </tr>
        <tr>
            <td class="bolded">Primary Actor:</strong></td>
            <td>Player User</td>
            <td class="bolded">Secondary Actor:</strong></td>
            <td>N/A</td>
        </tr>
        <tr>
            <td class="bolded">Objective:</strong></td>
            <td colspan="3">The user can restore a previous game.</td>
        </tr>
        <tr>
            <td class="bolded">Precondition:</strong></td>
            <td colspan="3">The user has an unfinished game in pending state.</td>
        </tr>
        <tr>
            <td rowspan="2" class="bolded">Post-condition</strong></td>
            <td colspan="1">Success:</td>
            <td colspan="3">The game loads successfully.</td>
        </tr>
        <tr>
            <td colspan="1">Failure:</td>
            <td colspan="3">There are no unfinished games in pending state.</td>
        </tr>
    </thead>
    <tbody style="border-bottom: 2px solid;border-top: 2px solid">
        <tr>
            <td align="center" colspan="2" class="bolded">Normal Course</strong></td>
            <td align="center" colspan="2" class="bolded">Alternative Course</strong></td>
        </tr>
        <tr>
            <td colspan="2">1. The use case begins when the user clicks "Load Game" button.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">2. The system search for any user's game in pending state.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">3.a. Exist one game without being finished. The system dispalys all bingo cards on the game view, show all numbers calleds and marked the matched numbers in the bingo cards.</td>
            <td colspan="2">3.b. Does not exist any game in pending state. The system displays a warning message: You do not have any unfinished game.</td>
        </tr>
        <tr>
            <td align="center" colspan="4">End of use case</td>
        </tr>
    </tbody>
    <tfoot>
        <tr>
            <td colspan="4" class="bolded">Observations:</strong></td>
        </tr>
        <tr>
            <td colspan="4">This use case uses the UC_7.</td>
        </tr>
    </tfoot>
</table>

<br><br>

<footer align="center">
    <hr>

### ◀️ [Return](../../General_process_definition.md)

</footer>