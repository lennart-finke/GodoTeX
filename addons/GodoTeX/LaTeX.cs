using Godot;

[Tool]
public partial class LaTeX : Sprite2D {
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
	
	public bool Fill = true;
	[Export]
	private bool _fill {
		get {return Fill;}
		set {
			Fill = value;
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
	
	// These are the measures of the generated image.
	public float Width;
	public float Height;
	public float OffsetX;
	public float OffsetY;
	
	// You may call this from outside to re-render the expression.
	// This is not done automatically so that you can change the values very
	// often, say multiple times a millisecond, without significant slowdown.
	public void Render() {
		var texture = new LaTeXture();
		texture.LatexExpression = this.LatexExpression;
		texture.FontSize = this.FontSize;
		texture.AntiAliasing = this.AntiAliasing;
		texture.Fill = this.Fill;
		texture.MathColor = this.MathColor;
		texture.ShowError = this.ShowError;
		
		this.Texture = texture.Render();
		this.Width = texture.Width;
		this.Height = texture.Height;
		this.OffsetX = texture.OffsetX;
		this.OffsetY = texture.OffsetY;
	}
	
	public override void _Ready() {
		Render();
	}
}
