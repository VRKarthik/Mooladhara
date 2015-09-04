﻿//
// Parago Media GmbH & Co. KG, Jürgen Bäurle (jbaurle@parago.de)
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
//

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace ProjectMooladhara
{
    public class WindowSettings
    {
        #region public bool HideCloseButton (attached)

        public static readonly DependencyProperty HideCloseButtonProperty =
             DependencyProperty.RegisterAttached("HideCloseButton", typeof(bool), typeof(WindowSettings), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnHideCloseButtonPropertyChanged)));

        public static bool GetHideCloseButton(FrameworkElement element)
        {
            return (bool)element.GetValue(HideCloseButtonProperty);
        }

        public static void SetHideCloseButton(FrameworkElement element, bool hideCloseButton)
        {
            element.SetValue(HideCloseButtonProperty, hideCloseButton);
        }

        private static void OnHideCloseButtonPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = d as Window;

            if (window != null)
            {
                var hideCloseButton = (bool)e.NewValue;

                if (hideCloseButton && !GetIsCloseButtonHidden(window))
                {
                    if (!window.IsLoaded)
                        window.Loaded += OnWindowLoaded;
                    else
                        HideCloseButton(window);

                    SetIsCloseButtonHidden(window, true);
                }
                else if (!hideCloseButton && GetIsCloseButtonHidden(window))
                {
                    if (!window.IsLoaded)
                        window.Loaded -= OnWindowLoaded;
                    else
                        ShowCloseButton(window);

                    SetIsCloseButtonHidden(window, false);
                }
            }
        }

        private static readonly RoutedEventHandler OnWindowLoaded = (s, e) =>
        {
            if (s is Window)
            {
                Window window = s as Window;
                HideCloseButton(window);
                window.Loaded -= OnWindowLoaded;
            }
        };

        #endregion public bool HideCloseButton (attached)

        #region public bool IsCloseButtonHidden (readonly attached)

        private static readonly DependencyPropertyKey IsHiddenCloseButtonKey =
            DependencyProperty.RegisterAttachedReadOnly("IsCloseButtonHidden", typeof(bool), typeof(WindowSettings), new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty IsCloseButtonHiddenProperty =
             IsHiddenCloseButtonKey.DependencyProperty;

        public static bool GetIsCloseButtonHidden(FrameworkElement element)
        {
            return (bool)element.GetValue(IsCloseButtonHiddenProperty);
        }

        private static void SetIsCloseButtonHidden(FrameworkElement element, bool isCloseButtonHidden)
        {
            element.SetValue(IsHiddenCloseButtonKey, isCloseButtonHidden);
        }

        #endregion public bool IsCloseButtonHidden (readonly attached)

        #region Helper Methods

        private static void HideCloseButton(Window w)
        {
            IntPtr hWnd = new WindowInteropHelper(w).Handle;
            SetWindowLong(hWnd, GWL_STYLE, GetWindowLong(hWnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private static void ShowCloseButton(Window w)
        {
            IntPtr hWnd = new WindowInteropHelper(w).Handle;
            SetWindowLong(hWnd, GWL_STYLE, GetWindowLong(hWnd, GWL_STYLE) | WS_SYSMENU);
        }

        #endregion Helper Methods

        #region Win32 Native Methods And Constants

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        #endregion Win32 Native Methods And Constants
    }
}