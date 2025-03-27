

class MainController
{
    public static void Start()
    {
        SessionDBModel.CreateDB(); // REQUIRED TO MAKE DB

        var startInput = UserInterface.GetStartUIInput();
        switch (startInput)
        {
            case Enums.MenuOption.CREATE:
                break;
            case Enums.MenuOption.FIND:
                break;
            case Enums.MenuOption.FINDALL:
                var dataSet = SessionDBModel.SelectLog();
                UserInterface.DisplaySessionData(dataSet);
                break;
            case Enums.MenuOption.UPDATE:
                break;
            case Enums.MenuOption.DELETE:
                break;
            case Enums.MenuOption.EXIT:
                break;
        }

        SessionDBModel.ExitDB(); // REQUIRED TO CLOSE DB
    }
}
