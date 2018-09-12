using System.Threading.Tasks;

namespace Justine
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await InversionOfControl.Container.GetInstance<Justine>().RunAsync();
            await Task.Delay(-1).ConfigureAwait(false);
        }
    }
}
