MVC application with .net core

1. User enters first and last name into the form.
2. Form sends a POST request to the backend.
3. ASP.NET Core automatically binds form data to a `User` object.
4. Existing users are read from `users.json`.
5. New user is added to the list.
6. Updated list is saved back into `users.json`.

Chose port8080 as its primarily for web traffic and application development. I thought this would be approiate considering this web application is under development.
