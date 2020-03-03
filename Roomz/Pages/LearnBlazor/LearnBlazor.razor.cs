using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomz.Pages.LearnBlazor
{
    public class LearnBlazorBase : ComponentBase
    {
        protected string name = "Blazing Records";
        protected string WelcomeText = "We have all your favorite records!";

        protected void getName()
        {
            name = "Blazing Vinyls";

        }
    }
}
