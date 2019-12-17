using System.Windows.Forms;

namespace TJFrameworkExample
{
  internal class CxManagerFactory
  {
    private static CxManager Manager = null;
    public static CxManager Create()
    {
      if (Manager == null)
      {
        Manager = new CxManager();
        InitSomePartsDependingOfManager(Manager);
      }
      return Manager;
    }

    private static void InitSomePartsDependingOfManager(CxManager manager)
    {
      //manager.LoginForm = new TTLoginForm(manager);
      //manager.Query = new TTQueryExecutor(manager);
      //manager.EditorClassificator = new TTEditorClassificator(manager);
      //manager.ContainerClassificator = new TTContainerClassificator(manager);
      //manager.EditorUser = new TTEditorUser(manager);
    }
  }
}
