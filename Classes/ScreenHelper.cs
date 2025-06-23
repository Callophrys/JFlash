using System.Text.Json;

namespace JFlash.Classes;

public static class ScreenHelper
{
    public static void SetFormDimensions(Form form)
    {
        Screen screen = Screen.FromControl(form);
        Size size = new Size(); // fetch from registry
        if (screen.WorkingArea.Size == size)
        {
            Rectangle rect = new Rectangle(); // fetch from registry
            form.Size = rect.Size;
            form.Location = rect.Location;
        }
    }

    public static void SaveScreenSize(Form form)
    {
        Screen screen = Screen.FromControl(form);
        string value = JsonSerializer.Serialize(screen.WorkingArea.Size);
        RegistryHelper.SaveSetting("screensize", value);
    }

    public static void SaveFormDimensions(Form form)
    {
        string value = JsonSerializer.Serialize(form.DisplayRectangle);
        RegistryHelper.SaveSetting($"form.{form.Name}", value);
    }

    public static Rectangle GetFormDimensions(Form form)
    {
        string formDimensionsJson = RegistryHelper.LoadSetting($"form.{form.Name}", string.Empty);
        object? fd = JsonSerializer.Deserialize(formDimensionsJson, typeof(Rectangle));
        if (fd != null)
        {
            return (Rectangle)fd;
        }

        return new Rectangle(0, 0, 0, 0);
    }

    public static void SetChildLocation(
        ContainerControl targetForm,
        ContainerControl referenceForm)
    {
        int x = referenceForm.Location.X + (referenceForm.Width - targetForm.Width) / 2;
        int y = referenceForm.Location.Y + (referenceForm.Height - targetForm.Height) / 2;
        targetForm.Location = new Point(x, y);
    }
}
