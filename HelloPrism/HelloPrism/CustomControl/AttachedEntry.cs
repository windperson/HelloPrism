using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloPrism.CustomControl
{
    public class AttachedEntry
    {
        public static readonly BindableProperty EntryTypeProperty =
            BindableProperty.CreateAttached(
                propertyName: "",
                returnType: typeof(string),
                declaringType: typeof(Entry),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay,
                validateValue: null,
                propertyChanged: OnEntryTypeChanged);

        #region for code behind invocation
        public static string GetEntryType(BindableObject bindable)
        {
            return (string)bindable.GetValue(EntryTypeProperty);
        }

        public static void SetEntryType(BindableObject bindable, string entryType)
        {
            bindable.SetValue(EntryTypeProperty, entryType);
        }
        #endregion

        private static void OnEntryTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var entry = bindable as Entry;
            if (entry == null)
            {
                return;
            }

            var oldVal = (oldValue as string)?.ToLower();
            var newVal = (newValue as string)?.ToLower();

            if (newVal == null) { return; }

            switch (newVal)
            {
                case "none":
                    break;
                case "email":
                    entry.SetValue(Entry.PlaceholderProperty, "please type e-mail");
                    entry.Keyboard = Keyboard.Email;
                    entry.FontSize = 20;
                    break;
                case "phone":
                    entry.SetValue(Entry.PlaceholderProperty, "dial phone No");
                    entry.Keyboard = Keyboard.Telephone;
                    entry.FontSize = 20;
                    break;
                case "number":
                    entry.SetValue(Entry.PlaceholderProperty, "enter number");
                    entry.Keyboard = Keyboard.Numeric;
                    entry.FontSize = 20;
                    break;
                default:
                    break;
            }
        }
    }
}
