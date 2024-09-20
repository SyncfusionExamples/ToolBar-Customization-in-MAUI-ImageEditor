using Syncfusion.Maui.ImageEditor;

namespace ToolBarSample
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();

            imageEditor.ToolbarSettings.ColorPalette.Add(Colors.Yellow);
            imageEditor.ToolbarSettings.ColorPalette.Add(Colors.Pink);
            imageEditor.ToolbarSettings.ColorPalette.Add(Colors.Violet);

            Image browseImage = new Image()
            {
                Source = ImageSource.FromFile("browse.png"),
                HeightRequest = 30,
                WidthRequest = 30
            };

            ImageEditorToolbar headerToolbar = imageEditor.Toolbars[0];
            ImageEditorToolbarGroupItem toolbarGroup = (ImageEditorToolbarGroupItem)headerToolbar.ToolbarItems[0];
            ImageEditorToolbarItem browseItem = toolbarGroup.Items.FirstOrDefault(i => i.Name == "Browse");
            browseItem.View = browseImage;
            
            Image textImage = new Image()
            {
                Source = ImageSource.FromFile("text.png"),
                HeightRequest = 30,
                WidthRequest = 30
            };

            ImageEditorToolbar footerToolbar = imageEditor.Toolbars[1];
            ImageEditorToolbarItem textItem = (ImageEditorToolbarItem)footerToolbar.ToolbarItems.FirstOrDefault(i => i.Name == "Text");
            textItem.IsEnabled = false;

            Image shareImage = new Image()
            {
                Source = ImageSource.FromFile("share.png"),
                HeightRequest = 30,
                WidthRequest = 30
            };

            ImageEditorToolbar headerToolbarItem = imageEditor.Toolbars[0];
            ImageEditorToolbarGroupItem shareGroup = (ImageEditorToolbarGroupItem)headerToolbarItem.ToolbarItems[1];
            shareGroup.Items.Add(new ImageEditorToolbarItem()
            {
                Name = "Share",
                View = shareImage
            });

            ImageEditorToolbar footerToolbarItem = this.imageEditor.Toolbars[1];
            ImageEditorToolbarItem cropItem = (ImageEditorToolbarItem)footerToolbarItem.ToolbarItems.FirstOrDefault(i => i.Name == "Crop");
            cropItem.SubToolbarOverlay = false;
            cropItem.SubToolbars = new List<ImageEditorToolbar>()
            {
                new ImageEditorToolbar()
                {
                    ToolbarItems = new List<IImageEditorToolbarItem>()
                    {
                        new ImageEditorToolbarItem(){ Name = "original"},
                        new ImageEditorToolbarItem(){ Name = "square"},
                        new ImageEditorToolbarItem(){ Name = "custom"}
                    }
                }
            };
        }

        private void OnToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            DisplayAlert("Message", "Selected ToolbarItem is  " + e.ToolbarItem.Name, "Cancel", "Ok");
        }

    }
}
