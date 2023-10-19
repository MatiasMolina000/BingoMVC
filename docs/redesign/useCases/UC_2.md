<style>.bolded{font-weight:bold;}table{border:4px solid;}</style>

<h3 align=center>📌 Sing Up</h3>
<hr>
<br>

<table>
    <thead">
        <tr>
            <td class="bolded">Use Case:</strong></td>
            <td>Sing Up</td>
            <td class="bolded">Identifier:</strong></td>
            <td>UC_2</td>
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
            <td colspan="3">User registration in the database.</td>
        </tr>
        <tr>
            <td class="bolded">Precondition:</strong></td>
            <td colspan="3">The name an email that the user inserted do not exist in the database.</td>
        </tr>
        <tr>
            <td rowspan="2" class="bolded">Post-condition</strong></td>
            <td colspan="1">Success:</td>
            <td colspan="3">The user accesses the web application with their credentials.</td>
        </tr>
        <tr>
            <td colspan="1">Failure:</td>
            <td colspan="3">The user does not exist in the database, the credentials are invalid ot his email are not validated</td>
        </tr>
    </thead>
    <tbody style="border-bottom: 2px solid;border-top: 2px solid">
        <tr>
            <td align="center" colspan="2" class="bolded">Normal Course</strong></td>
            <td align="center" colspan="2" class="bolded">Alternative Course</strong></td>
        </tr>
        <tr>
            <td colspan="2">1. The use case begins when the user enters in the "Sing Up" in "Sing In" view.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">2. The system displays the login screen.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">3. The user enters their "email", "username" and their "password".</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">4. The user selects the "Sign up" button.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">5. The system searches for matches by password and either name or email in the database.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">6.a. "Registration successfull." The System displays a info message: "User already registered. We have sent you an email with a validaton code."</td>
            <td colspan="2">6.b. "The user already exist." The system checks if the email is validated.</td>
        </tr>
        <tr>
            <td colspan="2">__________</td>
            <td colspan="1">6.b.1. "The email are validated." The System displays a info message: "The user is already registered. If you forgot your user or password, click on the Password Restore option."</td>
            <td colspan="1">6.b.2. "The email is not validated." The System displays a info message: "Email pendint validation. Look in your email for the message with the validation code or click on the Resend code button."</td>
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