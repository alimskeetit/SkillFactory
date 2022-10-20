internal class Pult
{

    Command command;

    public void SetAction(Command command)
    {
        this.command = command;    
    }

    public void CloseButton()
    {
        command.Close();
    }

    public void OpenButton()
    {
        command.Open();
    }
}