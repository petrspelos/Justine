using System.Threading.Tasks;

namespace Justine
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            // var a = InversonOfControl.Container.GetInstance<Dummy>();
            // var b = InversonOfControl.Container.GetInstance<Dummy>();
            await InversionOfControl.Container.GetInstance<Justine>().RunAsync();
            await Task.Delay(-1);
        }
    }
}
