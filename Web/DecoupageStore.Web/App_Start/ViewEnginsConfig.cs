namespace DecoupageStore.Web
{ 
    using System.Web.Mvc;

    public class ViewEnginsConfig
    {
        internal static void RegisterViewEngine(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}