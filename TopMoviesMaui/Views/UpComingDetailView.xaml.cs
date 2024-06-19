namespace TopMoviesMaui.Views;

public partial class UpComingDetailView : ContentPage
{
    #region Attributtes
    private double width = 0;
    private double height = 0;
    #endregion

    public UpComingDetailView()
    {
        InitializeComponent();
    }

    async void ShakeButton_Clicked(object sender, EventArgs e)
    {
        
    }

    #region Methods
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height); //must be called

        if (this.width != width || this.height != height)
        {
            this.width = width;
            this.height = height;

            UpdateLayout();
        }
    }

    void UpdateLayout()
    {
        if (width > height)
        {
            // Landscape;
            ContentView.Margin = new Thickness(0, 0, 0, 0);
            gridChildren.TranslationY = 10;
        }
        else
        {  // Portrait;
            gridChildren.TranslationY = -50;
            ContentView.Margin = new Thickness(0, -70, 0, 0);

        }
    }
    #endregion
}