using CourseApp.Controllers;
using Repository.Repositories.Interfaces;
using Repository.Repositories;
using Service.Services.Interfaces;
using Service.Services;
using Service.Enums;
using Service.Helpers.Extensions;


EducationController educationController = new EducationController();
GroupController groupController = new GroupController();




while (true)
{
    GetMenues();
Operation: string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);
    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.EducationCreate:
                await educationController.CreateAsync();
                break;
            case (int)OperationType.EducationDelete:
                await educationController.DeleteAsync();
                break;
            case (int)OperationType.EducationUpdate:
                await educationController.UpdateAsync();
                break;

            case (int)OperationType.EducationGetAll:
                await educationController.GetAllAsync();
                break;
            case (int)OperationType.EducationGetAllWithGroup:
                await educationController.GetAllWithGroupAsync();
                break;
            case (int)OperationType.EducationGetById:
                await educationController.GetByIdAsync();
                break;

            case (int)OperationType.EducationSortWithCreatedDate:
                await educationController.SortWithCreatedDateAsync();
                break;
            case (int)OperationType.EducationSearchByName:
                await educationController.SearchByNameAsync();
                break;
            case (int)OperationType.GroupCreate:
                await groupController.CreateAsync();
                break;
            case (int)OperationType.GroupDelete:
                await groupController.DeleteAsync();
                break;
            case (int)OperationType.GroupUpdate:
                await groupController.UpdateAsync();
                break;
            case (int)OperationType.GroupGetAll:
                await groupController.GetAllAsync();
                break;
            case (int)OperationType.GroupSortWithCapacity:
                await groupController.SortWithCapacityAsync();
                break;
            case (int)OperationType.GroupGetById:
                await groupController.GetByIdAsync();
                break;
            case (int)OperationType.GetAllGroupWithEducationId:
                await groupController.GetAllGroupWithEducationAsync();
                break;
            case (int)OperationType.GroupSearchByName:
                await groupController.SearchByNameAsync();
                break;
            case (int)OperationType.FilterByEducationName:
                await groupController.FilterByEducationNameAsync();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong, please choose again");
                goto Operation;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong, please add operation again");
        goto Operation;
    }
}
static void GetMenues()
{
    ConsoleExtension.WriteConsole(ConsoleColor.Green, "                                                      ☑ Education");
    ConsoleExtension.WriteConsole(ConsoleColor.DarkRed, "                                                      ~~~~~~~~~~~~");
    ConsoleExtension.WriteConsole(ConsoleColor.Yellow, "                                     1 - Create Education |~| 2 - Delete Education\n                                     3 - Update Education |~| 4 - Get All Education\n" +

      "                           5-Get All With Group Education |~| 6 - Get By Id Education\n                      7 - Sort With CreatedDate Education |~| 8 - Search By Name Education\n");
    ConsoleExtension.WriteConsole(ConsoleColor.Green, "                                                       ☑ Group");
    ConsoleExtension.WriteConsole(ConsoleColor.DarkRed, "                                                       ~~~~~~~~");
    ConsoleExtension.WriteConsole(ConsoleColor.Yellow, "                                         9 - Create Group |~| 10 - Group Delete\n" +
        "                                        11 - Update Group |~| 12 - Get All Group\n" +
    "                             13- Sort With Capacity Group |~| 14 - Get By Id Group\n" +
    "                           15- GetAllGroupWithEducationId |~| 16 - SearchGroupByName\n" +
    "                                                17-FilterByEducationName                       ");
}

