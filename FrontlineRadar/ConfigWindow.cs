using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace fr;

public class ConfigWindow : Window, IDisposable
{
    private Configuration Configuration;

    // We give this window a constant ID using ###
    // This allows for labels being dynamic, like "{FPS Counter}fps###XYZ counter window",
    // and the window ID will always be "###XYZ counter window" for ImGui
    public ConfigWindow(Plugin plugin) : base("FrontlineRadar")
    {
        Flags = ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse;

        SizeCondition = ImGuiCond.Always;

        Configuration = Plugin.Configuration;
    }

    public void Dispose() { }

    public override void PreDraw()
    {
        // Flags must be added or removed before Draw() is being called, or they won't apply
        Configuration.Save();
    }

    public override void Draw()
    {
        if (ImGui.Checkbox("开关", ref Configuration.Overlay2D_Enabled)) {
            Configuration.Save();
        }
        if (ImGui.Checkbox("显示加载范围圈", ref Configuration.Overlay2D_ShowAssist))
        {
            Configuration.Save();
        }
    }
}
