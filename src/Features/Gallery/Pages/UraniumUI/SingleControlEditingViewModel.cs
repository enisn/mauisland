using DynamicData.Binding;
using ReactiveUI;
using System.Xml.Linq;

namespace MAUIsland.Features.Gallery.Pages.UraniumUI;

public partial class SingleControlEditingViewModel<T> : NavigationAwareBaseViewModel
    where T : View, new()
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private T control;

    [ObservableProperty]
    List<BindableProperty> editingProperties;

    public string XamlSourceCode => SourceCode.ToString();
    protected XDocument SourceCode { get; }

    protected virtual string InitialXDocumentCode => $"""<ContentPage xmlns:material="http://schemas.enisn-projects.io/dotnet/maui/uraniumui/material"><material:{typeof(T).Name}/></ContentPage>""";
    protected readonly Dictionary<string, object> defaultValues = new Dictionary<string, object>();

    protected IDisposable controlPropertyChangedDisposable;

    public SingleControlEditingViewModel(IAppNavigator appNavigator) : base(appNavigator)
    {
        Control = InitializeControl();
        Title = typeof(T).Name;
        SourceCode = XDocument.Parse(InitialXDocumentCode);

        InitializeDefaultValues(defaultValues);

        this.WhenAnyValue(x => x.EditingProperties)
            .Subscribe(InitializeProperties);
    }

    protected virtual T InitializeControl()
    {
        return new T();
    }

    protected virtual void InitializeDefaultValues(Dictionary<string, object> values)
    {
    }

    protected void InitializeProperties(List<BindableProperty> list)
    {
        controlPropertyChangedDisposable?.Dispose();

        if (list != null)
        {
            controlPropertyChangedDisposable = Control
                .WhenAnyPropertyChanged(list.Select(s => s.PropertyName).ToArray())
                .Subscribe(GenerateSourceCode);

            GenerateSourceCode();
        }
    }

    protected virtual void GenerateSourceCode(object parameter = null)
    {
        var contentPage = SourceCode.Descendants().First();

        var material = contentPage.GetNamespaceOfPrefix("material");

        var control = contentPage.Descendants(material + Control.GetType().Name).First();

        foreach (var property in EditingProperties)
        {
            var value = Control.GetValue(property);

            if (value is null)
            {
                control.SetAttributeValue(property.PropertyName, null);
                continue;
            }

            if (defaultValues.TryGetValue(property.PropertyName, out var predefinedDefaultValue)
                && (value.Equals(predefinedDefaultValue)))
            {
                value = null;
            }
            else if (value is string str && string.IsNullOrEmpty(str))
            {
                value = null;
            }
            else if (value.Equals(property.DefaultValue))
            {
                value = null;
            }

            control.SetAttributeValue(property.PropertyName, FormatValue(value));
        }

        PostGenerateSourceCode(control);

        this.OnPropertyChanged(nameof(XamlSourceCode));
    }

    protected virtual void PostGenerateSourceCode(XElement control)
    {
    }

    protected virtual string FormatValue(object value)
    {
        if (value is null)
        {
            return null;
        }

        if (value is Color color)
        {
            return color.ToArgbHex();
        }

        if (value is Microsoft.Maui.Keyboard keyboard)
        {
            return keyboard.GetType().Name.Replace("Keyboard", string.Empty);
        }

        return value.ToString();
    }
}
