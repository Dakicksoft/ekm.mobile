﻿using System.Linq;
using Xamarin.Forms;

namespace Ekm.Mobile.Effects
{
    public class ViewStyleEffect : RoutingEffect
    {
        public static readonly string Name = $"Silly.{nameof(ViewStyleEffect)}";

        public ViewStyleEffect()
            : base(Name)
        {
        }
    }

    public static class ViewEffect
    {
        public static readonly BindableProperty TouchFeedbackColorProperty =
            BindableProperty.CreateAttached(
                "TouchFeedbackColor",
                typeof(Color),
                typeof(ViewEffect),
                Color.Default,
                propertyChanged: AttachEffect
            );

        public static Color GetTouchFeedbackColor(BindableObject view)
        {
            return (Color)view.GetValue(TouchFeedbackColorProperty);
        }

        public static void SetTouchFeedbackColor(BindableObject view, Color value)
        {
            view.SetValue(TouchFeedbackColorProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.CreateAttached(
            "BorderWidth",
            typeof(double),
            typeof(ViewEffect),
            default(double),
            BindingMode.TwoWay, propertyChanged: AttachEffect);

        public static double GetBorderWidth(BindableObject element)
        {
            return (double)element.GetValue(BorderWidthProperty);
        }

        public static void SetBorderWidth(BindableObject element, double value)
        {
            element.SetValue(BorderWidthProperty, value);
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.CreateAttached(
            "BorderColor",
            typeof(Color),
            typeof(ViewEffect),
            Color.Default,
            BindingMode.TwoWay, propertyChanged: AttachEffect);

        public static Color GetBorderColor(BindableObject element)
        {
            return (Color)element.GetValue(BorderColorProperty);
        }

        public static void SetBorderColor(BindableObject element, Color value)
        {
            element.SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.CreateAttached(
            "CornerRadius",
            typeof(double),
            typeof(ViewEffect),
            default(double),
            BindingMode.TwoWay, propertyChanged: AttachEffect);

        public static double GetCornerRadius(BindableObject element)
        {
            return (double)element.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(BindableObject element, double value)
        {
            element.SetValue(CornerRadiusProperty, value);
        }

        public static readonly BindableProperty ShadowRadiusProperty = BindableProperty.CreateAttached(
            "ShadowRadius",
            typeof(double),
            typeof(ViewEffect),
            default(double),
            BindingMode.TwoWay, propertyChanged: AttachEffect);

        public static double GetShadowRadius(BindableObject element)
        {
            return (double)element.GetValue(ShadowRadiusProperty);
        }

        public static void SetShadowRadius(BindableObject element, double value)
        {
            element.SetValue(ShadowRadiusProperty, value);
        }

        public static readonly BindableProperty ShadowColorProperty = BindableProperty.CreateAttached(
            "ShadowColor",
            typeof(Color),
            typeof(ViewEffect),
            Color.Default,
            BindingMode.TwoWay, propertyChanged: AttachEffect);

        public static Color GetShadowColor(BindableObject element)
        {
            return (Color)element.GetValue(ShadowColorProperty);
        }

        public static void SetShadowColor(BindableObject element, Color value)
        {
            element.SetValue(ShadowColorProperty, value);
        }

        public static readonly BindableProperty ShadowOpacityProperty = BindableProperty.CreateAttached(
            "ShadowOpacity",
            typeof(float),
            typeof(ViewEffect),
            default(float),
            BindingMode.TwoWay, propertyChanged: AttachEffect);

        public static float GetShadowOpacity(BindableObject element)
        {
            return (float)element.GetValue(ShadowOpacityProperty);
        }

        public static void SetShadowOpacity(BindableObject element, float value)
        {
            element.SetValue(ShadowOpacityProperty, value);
        }

        public static readonly BindableProperty ShadowOffsetXProperty = BindableProperty.CreateAttached(
            "ShadowOffsetX",
            typeof(double),
            typeof(ViewEffect),
            default(double),
            BindingMode.TwoWay,
            propertyChanged: AttachEffect
        );

        public static double GetShadowOffsetX(BindableObject element)
        {
            return (double)element.GetValue(ShadowOffsetXProperty);
        }

        public static void SetShadowOffsetX(BindableObject element, double value)
        {
            element.SetValue(ShadowOffsetXProperty, value);
        }

        public static readonly BindableProperty ShadowOffsetYProperty = BindableProperty.CreateAttached(
            "ShadowOffsetY",
            typeof(double),
            typeof(ViewEffect),
            default(double),
            BindingMode.TwoWay,
            propertyChanged: AttachEffect
        );

        public static double GetShadowOffsetY(BindableObject element)
        {
            return (double)element.GetValue(ShadowOffsetYProperty);
        }

        public static void SetShadowOffsetY(BindableObject element, double value)
        {
            element.SetValue(ShadowOffsetYProperty, value);
        }

        public static bool IsStyleSet(BindableObject element)
        {
            return ViewEffect.GetBorderColor(element) != Color.Default
                || ViewEffect.GetBorderWidth(element) != default(double)
                || ViewEffect.GetCornerRadius(element) != default(double)
                || ViewEffect.GetShadowColor(element) != Color.Default
                || ViewEffect.GetShadowOffsetX(element) != default(double)
                || ViewEffect.GetShadowOffsetY(element) != default(double)
                || ViewEffect.GetShadowOpacity(element) != default(float)
                || ViewEffect.GetShadowRadius(element) != default(double);
        }

        public static bool IsTapFeedbackColorSet(BindableObject element)
        {
            return ViewEffect.GetTouchFeedbackColor(element) != Color.Default;
        }

        private static void AttachEffect(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
            {
                System.Diagnostics.Debug.WriteLine($"Cannot apply ViewEffect to {bindable.GetType().Name} object");
                return;
            }

            var frame = bindable as Frame;
            if (frame != null)
            {
                System.Diagnostics.Debug.WriteLine($"Frame not supported for android, attaching it to its content {frame.Content?.GetType().Name}");

                view = frame.Content;

                if (view == null)
                {
                    System.Diagnostics.Debug.WriteLine("Frame content is null: cannot apply effect");
                    return;
                }
            }

            if (newValue != null && GetTouchFeedbackColor(bindable) == (Color)newValue && frame != null)
            {
                SetTouchFeedbackColor(view, (Color)newValue);
            }

            var effect = view.Effects.FirstOrDefault(x => x is ViewStyleEffect);
            if (frame == null && effect == null)
            {
                var resolvedEffect = Effect.Resolve(ViewStyleEffect.Name);
                view.Effects.Add(resolvedEffect);
            }
        }
    }
}
