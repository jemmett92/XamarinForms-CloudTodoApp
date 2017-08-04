﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrismUnityToDolistMobile.Behaviours
{
    class NonNumericEntryBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            // Subscribe to the event that should be monitored in order to extend functionality
            bindable.TextChanged += TextChanged_Handler;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);

            // Make sure to unsubscribe or else a memory leak
            bindable.TextChanged -= TextChanged_Handler;
        }

        void TextChanged_Handler(object sender, TextChangedEventArgs e)
        {
            // Short circuit for no value
            if (string.IsNullOrEmpty(e.NewTextValue))
                return;

            double _;
            // If the new text value is a double, then keep the text of the control at the old value
            if (double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;
        }
    }
}