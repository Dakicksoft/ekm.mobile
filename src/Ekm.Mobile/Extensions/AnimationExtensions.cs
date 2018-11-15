using Ekm.Mobile.Animations.Base;
using System;
using Xamarin.Forms;

namespace Ekm.Mobile.Extensions
{
  public static class AnimationExtensions
  {
    public static async void Animate(this VisualElement visualElement, AnimationBase animation, Action onFinishedCallback = null)
    {
      animation.Target = visualElement;

      await animation.Begin();

      onFinishedCallback?.Invoke();
    }
  }
}
