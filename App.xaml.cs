using Empyreum.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Empyreum
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (ItemContext itemContext = new ItemContext())
            {
                itemContext.Database.Migrate();
            }
            base.OnStartup(e);
        }

    }

}
