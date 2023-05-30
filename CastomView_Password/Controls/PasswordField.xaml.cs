namespace CastomView_Password.Controls
{
    public partial class PasswordField : ContentView
    {
        private ImageSource _defaultImageSource;

        public static readonly BindableProperty PasswordProperty = BindableProperty.Create(nameof(Password), typeof(string), typeof(PasswordField), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (PasswordField)bindable;
            control.PasswordEntry.Text = newValue as string;
        });

        public static readonly BindableProperty IsPasswordVisibleProperty = BindableProperty.Create(nameof(IsPasswordVisible), typeof(bool), typeof(PasswordField), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var control = (PasswordField)bindable;
            control.PasswordEntry.IsPassword = !(bool)newValue;
            control.ToggleButton.Source = (bool)newValue ? control.ShowImageSource : control.HideImageSource;
        });

        public static readonly BindableProperty HideImageSourceProperty = BindableProperty.Create(nameof(HideImageSource), typeof(ImageSource), typeof(PasswordField), default(ImageSource), propertyChanged: OnImageSourceChanged);
        public static readonly BindableProperty ShowImageSourceProperty = BindableProperty.Create(nameof(ShowImageSource), typeof(ImageSource), typeof(PasswordField), default(ImageSource), propertyChanged: OnImageSourceChanged);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(PasswordField), propertyChanged: OnTextColorChanged);

        public PasswordField()
        {
            InitializeComponent();

            _defaultImageSource = ToggleButton.Source;
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

        private static void OnImageSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PasswordField)bindable;
            control.ToggleButton.Source = control.IsPasswordVisible ? control.ShowImageSource : control.HideImageSource;
        }

        private static void OnTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (PasswordField)bindable;
            control.PasswordEntry.TextColor = (Color)newValue;
        }

        private void TogglePasswordVisibility()
        {
            IsPasswordVisible = !IsPasswordVisible;
        }

        private void ToggleButton_Clicked(object sender, System.EventArgs e)
        {
            TogglePasswordVisibility();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Parent != null)
                ToggleButton.Source = IsPasswordVisible ? _defaultImageSource : HideImageSource;
        }
    }
}
