#if TOOLS
using Godot;
using System;

[Tool]
public class GodoTeXPlugin : EditorPlugin {
	public override void _EnterTree() {
		var script = GD.Load<Script>("addons/GodoTeX/LaTeX.cs");
		var texture = GD.Load<Texture>("addons/GodoTeX/icon.svg");
		AddCustomType("LaTeX", "Sprite", script, texture);
	}

	public override void _ExitTree() {
		RemoveCustomType("LaTeX");
	}
}
#endif

