<h1>Contact Management Web application</h1>
<h4>Develop an ASP.NET web application to manage contacts</h4>
<h3>Application Features</h2>
The web application should have 5 features:
<ol>
 <li>An index page with a list of existing contacts.</li>
<li>A page with a form for adding new contacts.</li>
<li>A page for showing contact details.</li>
<li>Allow editing an existing record.</li>
<li>Allow deletion of an existing record.</li>
</ol>
Considerations:
<br/><br/>
A contact is an entity with 4 fields: ID, Name, Contact and email address. Name should be a string of any size greater than 5, contact should be 9 digits, and email should be a valid email.
<br/><br/>
Each row in the index page should have a link to the contact details page, a link to edit the contact, and a button to delete the contact. The delete should perform a soft delete of the record, using Laravel features.
<br/><br/>
The contact details page should show all the fields of the contact plus the edit link and the delete button.
<br/><br/>
Contact and email address should be unique, two contacts cannot have the same.
<br/><br/>
Any needed database structure information or data should be added using migrations and / or seeds.
<br/><br/>
Always use native features when possible, including routes, controllers, form validation rules, soft deletes and other features.
<h3>Additional Requirements</h3>
The following requirements should be implemented if within test execution time:
<br/><br/>
Allow viewing the list of contacts by anyone, but the other features should only be accessed by an authenticated user. This can be a static user previously created. Implement tests for checking form validation errors when adding or editing contacts.
<ul>
  <li>Docker</li>
  <li>MariaDB 10.6</li>
  <li>Microsoft Identity</li>
  <li>.NET 6</li>
  <li>Razor Pages</li>
  <li>EF Core</li>
  <li>MVC</li>
  <li>Microsoft Visual Studio</li>
</ul>
