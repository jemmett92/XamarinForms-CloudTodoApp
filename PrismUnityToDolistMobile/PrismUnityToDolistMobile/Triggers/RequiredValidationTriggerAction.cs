using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismUnityToDolistMobile.Triggers
{
    class RequiredValidationTriggerAction : TriggerAction<Entry>
    {
        // This is the function that gets called when the specified event occurs in the trigger definition
        protected override void Invoke(Entry sender)
        {
            sender.BackgroundColor = string.IsNullOrEmpty(sender.Text) ? Color.FromHex("#FFCDD2") : Color.Default;
        }
    }
}