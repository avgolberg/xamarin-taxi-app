using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApp.MarkupExtensions
{
    [ContentProperty("ResourseId")]
    class EmbeddedImage : IMarkupExtension
    {
        public string ResourseId { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResourseId))
                return null;
            return ImageSource.FromResource(ResourseId);
        }
    }
}
