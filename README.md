# Blazor Web App with Identity and PostgreSQL

This is a template Blazor Web App project you can use to get your identity setup with PostgreSQL and snake-case naming convention.

### Tech

Blazor, .NET 9.0.4, EF Core 9, Identity

### Rename Project to Your Own

- Open the solution file
- Rename project name to <your-project-name>
- Using "Replace in Files" tool change all occurences of MyAppName to <your-project-name>
- Rebuild All (REBUILD! not just build..)
- Remove project from solution
- Exit Visual Studio

- Rename solution and project folder name to <your-solution-name> and <your-project-name>
- Open Visual Studio
- Add the project to solution

- From command line run `dotnet ef database update`, considering you have set up your postgres cluster before

### Issues

- Classic annoying `NavigationException` on login, register etc. in debug mode just continue when debugging or deselect `Break when this exception type is user-unhandled` in exception window

### Links

[Blazor Web App with Identity, PostgreSQL and MudBlazor](https://github.com/netspie/mudblazor-webapp-identity-postgres)  
[Blazor Web App with Identity, PostgreSQL, MudBlazor and Tailwind v4](https://github.com/netspie/mudblazor-webapp-identity-postgres-tailwind4)
