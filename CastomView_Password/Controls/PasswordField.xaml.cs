using System.ComponentModel;
using System.Windows.Input;
using System.Xml.Linq;

namespace CastomView_Password.Controls
{
    public partial class PasswordField : ContentView, INotifyPropertyChanged
    {

        public static readonly BindableProperty PasswordProperty = BindableProperty.Create(
            nameof(Password),
            typeof(string),
            typeof(PasswordField),
            propertyChanged: (bindable, oldValue, newValue) => {}
        );

        public static readonly BindableProperty IsPasswordVisibleProperty = BindableProperty.Create(
            nameof(IsPasswordVisible),
            typeof(bool),
            typeof(PasswordField),
            true, //ѕытаюсь задать значение по умолчанию - не работает
            propertyChanged: (bindable, oldValue, newValue) => {}
        );

        public static readonly BindableProperty ImageSourceChangedProperty = BindableProperty.Create(
            nameof(ImageSourceChanged),
            typeof(ImageSource),
            typeof(ImageSource),
            default(ImageSource),
            propertyChanged: OnImageSourceChanged);

        public static readonly BindableProperty HideImageSourceProperty = BindableProperty.Create(
            nameof(HideImageSource),
            typeof(ImageSource),
            typeof(PasswordField),
            default(ImageSource),
            propertyChanged: OnImageSourceChanged);

        public static readonly BindableProperty ShowImageSourceProperty = BindableProperty.Create(
            nameof(ShowImageSource),
            typeof(ImageSource),
            typeof(PasswordField),
            default(ImageSource),
            propertyChanged: OnImageSourceChanged);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(PasswordField),
            propertyChanged: OnTextColorChanged);

        public static readonly BindableProperty IconTintColorProperty = BindableProperty.Create(
            nameof(IconTintColor),
            typeof(Color),
            typeof(PasswordField),
            default(Color),
            propertyChanged: OnIconTintColorChanged);

        
        public static readonly BindableProperty TogglePasswordCommandProperty = BindableProperty.Create(
            nameof(TogglePasswordCommand),
            typeof(ICommand),
            typeof(PasswordField));



        public PasswordField()
        {
            InitializeComponent();
            //ћожно ли это тут оставл€ть?
            TogglePasswordCommand = new Command(TogglePasswordVisibility);
        }

        public string Password
        {
            get => GetValue(PasswordProperty) as string;
            set => SetValue(PasswordProperty, value);
        }

        public bool IsPasswordVisible
        {
            get => (bool)GetValue(IsPasswordVisibleProperty);
            set => SetValue(IsPasswordVisibleProperty, value);
        }

        public ImageSource ImageSourceChanged
        {
            get => (ImageSource)GetValue(ImageSourceChangedProperty);
            set => SetValue(ImageSourceChangedProperty, value);
        }

        public ImageSource HideImageSource
        {
            get => (ImageSource)GetValue(HideImageSourceProperty);
            set => SetValue(HideImageSourceProperty, value);
        }

        public ImageSource ShowImageSource
        {
            get => (ImageSource)GetValue(ShowImageSourceProperty);
            set => SetValue(ShowImageSourceProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public Color IconTintColor
        {
            get => (Color)GetValue(IconTintColorProperty);
            set => SetValue(IconTintColorProperty, value);
        }

        public ICommand TogglePasswordCommand
        {
            get { return (ICommand)GetValue(TogglePasswordCommandProperty); }
            set { SetValue(TogglePasswordCommandProperty, value); }
        }

        public void ChangeTogglePasswordCommand(Command newCommand)
        {
            SetValue(TogglePasswordCommandProperty, newCommand);
        }


        public static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        private static void OnIconTintColorChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        private void TogglePasswordVisibility()
        {
            IsPasswordVisible = !IsPasswordVisible;

            ImageSourceChanged = IsPasswordVisible ? ShowImageSource : HideImageSource;
        }

        private void ToggleButton_Clicked(object sender, System.EventArgs e)
        {
        }
    }
}
