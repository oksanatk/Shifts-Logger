using ConsoleUI.Services;
using Spectre.Console;

namespace ConsoleUI.Views;

internal class ConsoleView
{
    private readonly WorkerShiftService _workerShiftService;
    public ConsoleView(WorkerShiftService workerShiftService)
    {
        _workerShiftService = workerShiftService;
    }
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
                    // view all shifts
                    break;
                case "View Workers":
                    // view all workers
                    break;
                case "Create New Worker":
                    // create - input form
                    break;
                case "Create New Shift":
                    // create - input form
                    break;
                case "Update Worker":
                    // view all workers
                    break;
                case "Update Shift":
                    // view all workers, view shifts per worker
                    // or just view all shifts by id
                    break;
                case "Delete Worker":
                    // view all workers with id
                    break;
                case "Delete Shift":
                    // view all shifts per worker, view all shifts by id
                    break;
                case "Quit":
                    break;
                default:
                    AnsiConsole.MarkupLine("[maroon]An unexpected error occurred. Please try again later.[/]");
                    break;
            }
        } while (mainMenuChoice != "Quit");
    }

    private void DisplayAllShiftsById() { }

    private void DisplayAllWorkers() { }

    private void DisplayAllWorkerShifts(int workerId) { }
}
