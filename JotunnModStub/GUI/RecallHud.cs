using Jotunn.Managers;
using UnityEngine;
using UnityEngine.UI;

public static class RecallHud
{
    private static GameObject _panel;
    private static Image _fillImage;
    private static Text _label;

    public static void Init()
    {
        GUIManager.OnCustomGUIAvailable += CreateHud;
    }

    private static void CreateHud()
    {
        if (GUIManager.Instance == null || GUIManager.CustomGUIFront == null) return;

        _panel = GUIManager.Instance.CreateWoodpanel(
            parent: GUIManager.CustomGUIFront.transform,
            anchorMin: new Vector2(0.5f, 0.15f),
            anchorMax: new Vector2(0.5f, 0.15f),
            position: new Vector2(0, 10),
            width: 200,
            height: 40,
            draggable: false);

        GameObject fillObj = new GameObject("RecallFill", typeof(RectTransform), typeof(Image));
        fillObj.transform.SetParent(_panel.transform, false);

        GameObject textObj = new GameObject("RecallText", typeof(RectTransform), typeof(Text));
        textObj.transform.SetParent(_panel.transform, false);

        _label = textObj.GetComponent<Text>();
        _label.text = "Recalling...";
        _label.alignment = TextAnchor.MiddleCenter;
        _label.color = Color.white;
        _label.fontSize = 14;
        GUIManager.Instance.ApplyTextStyle(_label, 14);

        RectTransform rt = fillObj.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0f, 0f);
        rt.anchorMax = new Vector2(1f, 1f);
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        _fillImage = fillObj.GetComponent<Image>();
        _fillImage.sprite = GUIManager.Instance.GetSprite("button");
        _fillImage.color = GUIManager.Instance.ValheimOrange;
        _fillImage.type = Image.Type.Filled;
        _fillImage.fillMethod = Image.FillMethod.Horizontal;
        _fillImage.fillOrigin = (int)Image.OriginHorizontal.Left;
        _fillImage.fillAmount = 0f;


        _panel.SetActive(false);
    }

    public static void Show()
    {
        if (_panel == null) return;
        _fillImage.fillAmount = 0f;
        _panel.SetActive(true);
    }

    public static void SetProgress(float t)
    {
        if (_fillImage == null)
        {
            Jotunn.Logger.LogWarning("[RecallHud] _fillImage is null");
            return;
        }
        _fillImage.fillAmount = Mathf.Clamp01(t);
        Jotunn.Logger.LogInfo($"[RecallHud] fillAmount={_fillImage.fillAmount:F2}");
    }

    public static void Hide()
    {
        if (_panel == null) return;
        _panel.SetActive(false);
    }
    public static void SetText(string text)
    {
        if (_label == null) return;
        _label.text = text;
    }
}