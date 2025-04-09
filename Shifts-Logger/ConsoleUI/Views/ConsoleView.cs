using Spectre.Console;

namespace ConsoleUI.Views;

internal class ConsoleView
{
    internal void DisplayMainMenu()
    {
        string mainMenuChoice = "";

        do
        {
            mainMenuChoice = AnsiConsole.Prompt(new SelectionPrompt<string>()
                                       .Title("Welcome! Choose below:")
                                       .AddChoices(new[]
                                       {
                                        "View Shifts",
                                        "View Workers",
                                        "Create New Worker",
                                        "Create New Shift",
                                        "Update Worker",
                                        "Update Shift",
                                        "Delete Worker",
                                        "Delete Shift",
                                        "Quit"
                                       })
                                       .PageSize(10));
            switch (mainMenuChoice)
            {
                case "View Shifts":
                    break;
                case "View Workers":
                    break;
                case "Create New Worker":
                    break;
                case "Create New Shift":
                    break;
                case "Update Worker":
                    break;
                case "Update Shift":
                    break;
                case "Delete Worker":
                    break;
                case "Delete Shift":
                    break;
                case "Quit":
                    break;
                default:
                    AnsiConsole.MarkupLine("[maroon]An unexpected error occurred. Please try again later.[/]");
                    break;
            }
        } while (mainMenuChoice != "Quit");
    }
}
