using System.Text.Json;

namespace JFlash.Classes;

public static class ScreenHelper
{
    public static void SetChildLocation(
        ContainerControl targetForm,
        ContainerControl referenceForm)
    {
        int x = referenceForm.Location.X + (referenceForm.Width - targetForm.Width) / 2;
        int y = referenceForm.Location.Y + (referenceForm.Height - targetForm.Height) / 2;
        targetForm.Location = new Point(x, y);
    }

    public static void LoadWindowState(Form form, FormInfo defaultFormInfo)
    {
        if (!TryGetFormInfo(form.Name, out FormInfo formInfo))
        {
            // Just let the designer values direct things.
            return;
        }

        form.Size = formInfo.Rectangle.Size;

        if (IsOnScreen(formInfo))
        {
            form.StartPosition = formInfo.StartPosition;
            form.Location = new Point(Math.Max(formInfo.Rectangle.Location.X, 0), Math.Max(formInfo.Rectangle.Location.Y, 0));
        }
        else
        {
            // fallback to default if off-screen
            form.StartPosition = defaultFormInfo.StartPosition;
        }

        if (formInfo.IsMaximized)
            form.WindowState = FormWindowState.Maximized;
    }

    public static void SaveWindowState(Form form)
    {
        FormInfo formInfo = new FormInfo()
        {
            StartPosition = form.StartPosition,
        };

        if (form.WindowState == FormWindowState.Normal)
        {
            formInfo.Rectangle = new()
            {
                Location = form.Location,
                Size = form.Size,
            };
            formInfo.IsMaximized = false;
        }
        else if (form.WindowState == FormWindowState.Maximized)
        {
            // Save normal bounds even if maximized
            formInfo.Rectangle = new()
            {
                Location = form.RestoreBounds.Location,
                Size = form.RestoreBounds.Size,
            };
            formInfo.IsMaximized = true;
        }

        string value = JsonSerializer.Serialize(formInfo, typeof(FormInfo));
        RegistryHelper.SaveSetting($"form.{form.Name}", value);
    }

    #region Private Methods

    private static bool IsOnScreen(FormInfo winInf)
    {
        return Screen.AllScreens.Any(s => s.WorkingArea.IntersectsWith(winInf.Rectangle));
    }

    private static bool IsValidWinInfJson(string json)
    {
        try
        {
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;

            return root.TryGetProperty("Rectangle", out var rect) && rect.ValueKind == JsonValueKind.Object
                && root.TryGetProperty("IsMaximized", out var isMax) && (isMax.ValueKind == JsonValueKind.False || isMax.ValueKind == JsonValueKind.True)
                && root.TryGetProperty("StartPosition", out var startPos) && startPos.ValueKind == JsonValueKind.Number;
        }
        catch (JsonException ex)
        {
            JfHelper.LogError($"IsValidWinInfJson: {json},\n  ex: {ex.Message}");
            return false;
        }
    }

    private static bool TryGetFormInfo(string formName, out FormInfo formInfo)
    {
        string formInfoJson = RegistryHelper.LoadSetting($"form.{formName}", string.Empty);
        if (string.IsNullOrEmpty(formInfoJson) ||
            formInfoJson == "{}" ||
            !IsValidWinInfJson(formInfoJson))
        {
            formInfo = new FormInfo();
            return false;
        }

        try
        {
            formInfo = JsonSerializer.Deserialize<FormInfo>(formInfoJson);
            return true;
        }
        catch (JsonException ex)
        {
            JfHelper.LogError($"TryGetFormInfo: {formName},\n  ex: {ex.Message}");
        }

        formInfo = new FormInfo();
        return false;
    }

    #endregion Private Methods
}
