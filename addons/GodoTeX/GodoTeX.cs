#if TOOLS
using Godot;
using System;

[Tool]
public class GodoTeX : EditorPlugin {
	public override void _EnterTree() {
		var texture_grey = GD.Load<Texture>("addons/GodoTeX/iconGrey.svg");
		var texture_script = GD.Load<Script>("addons/GodoTeX/LaTeXture.cs");
		AddCustomType("LaTeXture", "ImageTexture", texture_script, texture_grey);
		
		var texture_red = GD.Load<Texture>("addons/GodoTeX/iconRed.svg");
		var spatial_script = GD.Load<Script>("addons/GodoTeX/LaTeX3D.cs");
		AddCustomType("LaTeX3D", "Sprite3D", spatial_script, texture_red);
		
		var texture = GD.Load<Texture>("addons/GodoTeX/icon.svg");
		var script = GD.Load<Script>("addons/GodoTeX/LaTeX.cs");
		AddCustomType("LaTeX", "Sprite", script, texture);
		
		var texture_button = GD.Load<Texture>("addons/GodoTeX/iconButton.svg");
		var button_script = GD.Load<Script>("addons/GodoTeX/LaTeXButton.cs");
		AddCustomType("LaTeXButton", "TextureButton", button_script, texture_button);
	}

	public override void _ExitTree() {
		RemoveCustomType("LaTeX");
		RemoveCustomType("LaTeX3D");
		RemoveCustomType("LaTeXture");
		RemoveCustomType("LaTeXButton");
	}
}
#endif

