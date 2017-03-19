using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloPrism.CustomControl
{
    public class BindableEntry : Entry
    {
        public static readonly BindableProperty EntryTypeProperty =
            BindableProperty.Create("EntryType",
                typeof(string),
                typeof(BindableProperty),
                defaultValue: "none",
                propertyChanged: OnEntryTypeChanged
                );

        public string EntryType
        {
            get
            {
                return (string)GetValue(EntryTypeProperty);
            }
            set
            {
                SetValue(EntryTypeProperty, value);
            }
        }

        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entry = bindable as BindableEntry;
            var oldStr = (oldValue as string).ToLower();
            var newStr = (newValue as string).ToLower();

            switch (newStr)
            {
                case "none":
                    break;
                case "email":
                    entry.SetValue(PlaceholderProperty, "please enter e-mail");
                    entry.Keyboard = Keyboard.Email;
                    entry.FontSize = 20;
                    break;
                case "phone":
                    entry.SetValue(PlaceholderProperty, "please type phone number");
                    entry.Keyboard = Keyboard.Telephone;
                    entry.FontSize = 20;
                    break;
                case "number":
                    entry.SetValue(PlaceholderProperty, "please enter numeric value");
                    entry.Keyboard = Keyboard.Numeric;
                    entry.FontSize = 20;
                    break;
                default:
                    break;
            }
        }
    }
}
