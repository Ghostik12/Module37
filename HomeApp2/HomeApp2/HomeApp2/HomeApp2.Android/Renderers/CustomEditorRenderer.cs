using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using HomeApp2.Droid.Renderers;

[assembly: ExportRenderer(typeof(Editor), typeof(CustomEditorRenderer))]
namespace HomeApp2.Droid.Renderers
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}