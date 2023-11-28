<style>.bolded{font-weight:bold;}table{border:4px solid;}</style>

<h3 align=center>📌 Email Validation</h3>
<hr>
<br>

<table>
    <thead">
        <tr>
            <td class="bolded">Use Case:</strong></td>
            <td>Email Validation</td>
            <td class="bolded">Identifier:</strong></td>
            <td>UC_4</td>
        </tr>
        <tr>
            <td colspan="2" class="bolded">Use Case Level:</strong></td>
            <td colspan="2">End User</td>
        </tr>
        <tr>
            <td class="bolded">Priority:</strong></td>
            <td>Medium</td>
            <td class="bolded">Complexity:</strong></td>
            <td>Medium</td>
        </tr>
        <tr>
            <td class="bolded">Primary Actor:</strong></td>
            <td>Player User</td>
            <td class="bolded">Secondary Actor:</strong></td>
            <td>Admin User</td>
        </tr>
        <tr>
            <td class="bolded">Objective:</strong></td>
            <td colspan="3">The user can log in nomraly after a password lock or sing up.</td>
        </tr>
        <tr>
            <td class="bolded">Precondition:</strong></td>
            <td colspan="3">The user's password is in a locked state.</td>
        </tr>
        <tr>
            <td rowspan="2" class="bolded">Post-condition</strong></td>
            <td colspan="1">Success:</td>
            <td colspan="3">The player user's password changes from locked state to active state or the admin user recieves his password by email.</td>
        </tr>
        <tr>
            <td colspan="1">Failure:</td>
            <td colspan="3"></td>
        </tr>
    </thead>
    <tbody style="border-bottom: 2px solid;border-top: 2px solid">
        <tr>
            <td align="center" colspan="2" class="bolded">Normal Course</strong></td>
            <td align="center" colspan="2" class="bolded">Alternative Course</strong></td>
        </tr>
        <tr>
            <td colspan="2">1. The use case begins when the user recieves the email.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="1">2.a.1. The user is a player user. The system redirect to unlocked password view.</td>
            <td colspan="1">2.a.2. The user is a admin user. The system display an info message: "We send you an email with the password. Look at into your email and rreturn to the login vew."</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="1">3. The user inserts the code that recieves.</td>
            <td colspan="1">__________</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="1">4.a. The code is valid. The user is redirected to changes password form view.</td>
            <td colspan="1">__________</td>
            <td colspan="1">4.b. The code is not valid. The system displays an error message: "The code inserted is not valid."</td>
            <td colspan="1">__________</td>
        </tr>
            <tr>
            <td colspan="1">5. The user insert their new password twice.</td>
            <td colspan="1">__________</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="1">6.a. The two passowrds match. The system displays a success message: "Your new password was saved successfully."</td>
            <td colspan="1">__________</td>
            <td colspan="1">6.b. The two passwords do not match. The system displays an error message: "The passwords do not match."</td>
            <td colspan="1">__________</td>
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
            <td colspan="4">__________</td>
        </tr>
    </tfoot>
</table>

<br><br>

<footer align="center">
    <hr>

### ◀️ [Return](../../General_process_definition.md)

</footer>