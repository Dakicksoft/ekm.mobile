using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Ekm.Mobile.Controls
{
    public class ExtendedWebView : WebView
    {

        public static readonly BindableProperty NavigatingCommandProperty =
            BindableProperty.Create(nameof(NavigatingCommand), typeof(ICommand), typeof(ExtendedWebView), null);

        public static readonly BindableProperty NavigatedCommandProperty =
            BindableProperty.Create(nameof(NavigatedCommand), typeof(ICommand), typeof(ExtendedWebView), null);

        public static BindableProperty IsGoBackProperty =
            BindableProperty.Create(nameof(IsGoBack), typeof(bool), typeof(ExtendedWebView), propertyChanged: (bindable, oldValue, newValue) =>
            {
                var webView = bindable as ExtendedWebView;
                webView.GoBack();
            });

        public ExtendedWebView()
        {
            Navigating += (s, e) =>
            {
                if (NavigatingCommand?.CanExecute(e) ?? false)
                    NavigatingCommand.Execute(e);
            };

            Navigated += (s, e) =>
            {
                if (NavigatedCommand?.CanExecute(e) ?? false)
                    NavigatedCommand.Execute(e);
            };
        }

        public ICommand NavigatingCommand
        {
            get { return (ICommand)GetValue(NavigatingCommandProperty); }
            set { SetValue(NavigatingCommandProperty, value); }
        }

        public ICommand NavigatedCommand
        {
            get { return (ICommand)GetValue(NavigatedCommandProperty); }
            set { SetValue(NavigatedCommandProperty, value); }
        }

        public bool IsGoBack
        {
            get { return (bool)GetValue(IsGoBackProperty); }
            set { SetValue(IsGoBackProperty, value); }
        }


    }
}
