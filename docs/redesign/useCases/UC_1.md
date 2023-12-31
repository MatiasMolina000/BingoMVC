<style>.bolded{font-weight:bold;}table{border:4px solid;}</style>

<h3 align=center>📌 Sing In</h3>
<hr>
<br>

<table>
    <thead">
        <tr>
            <td class="bolded">Use Case:</strong></td>
            <td>Sign In</td>
            <td class="bolded">Identifier:</strong></td>
            <td>UC_1</td>
        </tr>
        <tr>
            <td colspan="2" class="bolded">Use Case Level:</strong></td>
            <td colspan="2">End User</td>
        </tr>
        <tr>
            <td class="bolded">Priority:</strong></td>
            <td>High</td>
            <td class="bolded">Complexity:</strong></td>
            <td>Low</td>
        </tr>
        <tr>
            <td class="bolded">Primary Actor:</strong></td>
            <td>End User</td>
            <td class="bolded">Secondary Actor:</strong></td>
            <td>N/A</td>
        </tr>
        <tr>
            <td class="bolded">Objective:</strong></td>
            <td colspan="3">User authentication and access to the web application.</td>
        </tr>
        <tr>
            <td class="bolded">Precondition:</strong></td>
            <td colspan="3">The user must be registered in the database and must have his email validated.</td>
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
            <td colspan="2">1. The use case begins when the user enters the address of the solution in their web browser.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">2. The system displays the login screen.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">3. The user enters their "email" or "username" and their "password".</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">4. The user selects the "Sign In" option.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">5. The system searches for matches by password and either name or email in the database.</td>
            <td colspan="2">__________</td>
        </tr>
        <tr>
            <td colspan="2">6.a. "Valid credentials." The System controls that the email are validated.</td>
            <td colspan="2">6.b. "Invalid credentials." The System displays a error message: "Invalid credentials."</td>
        </tr>
        <tr>
            <td colspan="2">7.a. "Validated email." The System redirects the user to the main menu and retun an autentication token.</td>
            <td colspan="2">6.b. "Email pending validation." The System displays a info message: "Email pending validation."</td>
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