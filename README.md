# Modalonia
[![NuGet Count](https://img.shields.io/nuget/dt/Modalonia.svg?style=flat-square)](https://www.nuget.org/packages/Modalonia/)  
Simple yet customizable modal for Avalonia. Show modal to the Avalonia's main window.  
![Modalonia](https://i.ibb.co/Vjn6HF8/modalonia.gif "Modalonia")

## Basic usage
```csharp
// you can attach any control as a modal's content..
var content =  new TextBlock
{
   TextWrapping = TextWrapping.Wrap,
   Text = "Lorem ipsum dolor si amet orem ipsum dolor si amet orem ipsum dolor si amet orem ipsum dolor si amet"
};

var result = await Modal.Show("Modal Title", content, ModalButtons.YesNo);
if (result == ModalResult.Yes)
{
   // do something..
}
```

## Styling
Add default style to your App.xaml file;
```xaml
<Application.Styles>
   <StyleInclude Source="avares://Modalonia/Styles/Default.xaml"/>
</Application.Styles>
```

### Modal style selectors
- Grid.modalonia_container
- Border.modalonia_border
- ContentControl.modalonia_header
- TextBlock.modalonia_header_title
- Button.modalonia_header_close
- ContentControl.modalonia_content
- ContentControl.modalonia_buttons_container
- StackPanel.modalonia_buttons
- Button.modalonia_button
- Button.modalonia_button_yes
- Button.modalonia_button_no
- Button.modalonia_button_ok
- Button.modalonia_button_cancel

## License
MIT