using Godot;

[Tool]
public class LaTeXButton : TextureButton {
	// The following wordy declarations ensure that changing the properties 
	// inside the editor causes the expression to re-render.
	
	public string LatexExpression;
	[Export(PropertyHint.MultilineText)]
	private string _latexExpression {
		get {return LatexExpression;}
		set {
			// This runs when LatexExpression is set in the editor.
			
			LatexExpression = value;
			Render();
		}
	}
	
	public float FontSize = 40f;
	[Export(PropertyHint.Range, "10,60,1,or_greater,or_lesser")]
	private float _fontSize {
		get {return FontSize;}
		set {
			FontSize = value;
			Render();
		}
	} 
	
	public Color MathColor = new Color(0,0,0,1);
	[Export]
	private Color _mathColor {
		get {return MathColor;}
		set {
			MathColor = value;
			Render();
		}
	} 
	
	public bool AntiAliasing = true;
	[Export]
	private bool _antiAliasing {
		get {return AntiAliasing;}
		set {
			AntiAliasing = value;
			Render();
		}
	}
	
	public bool ShowError = true;
	[Export]
	private bool _showError {
		get {return ShowError;}
		set {
			ShowError = value;
			Render();
		}
	}
	
	public void Render() {
		var texture = new LaTeXture();
		texture.LatexExpression = this.LatexExpression;
		texture.FontSize = this.FontSize;
		texture.AntiAliasing = this.AntiAliasing;
		texture.Fill = false;
		texture.MathColor = this.MathColor;
		texture.ShowError = this.ShowError;
		texture.Render();
		
		this.TextureNormal = texture;
		
		var texture2 = new LaTeXture();
		texture2.LatexExpression = this.LatexExpression;
		texture2.FontSize = this.FontSize;
		texture2.AntiAliasing = this.AntiAliasing;
		texture2.Fill = true;
		texture2.MathColor = this.MathColor;
		texture2.ShowError = this.ShowError;
		texture2.Render();
		
		this.TextureHover = texture2;
		
		// A bit of a hack, we increase the top spacing in the LaTeX expression
		// to give a 'pressed down' effect.
		var texture3 = new LaTeXture();
		texture3.LatexExpression = @"\raisebox{41mu}{}" + this.LatexExpression;
		texture3.FontSize = this.FontSize;
		texture3.AntiAliasing = this.AntiAliasing;
		texture3.Fill = true;
		texture3.MathColor = this.MathColor;
		texture3.ShowError = this.ShowError;
		texture3.Render();
		
		this.TexturePressed = texture3;
		
		var clickMask = new BitMap();
		clickMask.Create(new Vector2(texture.Width, texture.Height));
		clickMask.SetBitRect(new Rect2(0, 35, texture.Width, texture.Height - 70), true);
		this.TextureClickMask = clickMask;
	}
	
	public override void _Ready() {
		Render();
	}
}
