using Godot;
using System.IO;
using CSharpMath.SkiaSharp;
using CSharpMath.Rendering;
using SkiaSharp;

[Tool]
public class LaTeX : Sprite {
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
	
	private MathPainter Painter = new MathPainter{};
	
	// These are the measures of the generated image.
	public float Width;
	public float Height;
	public float OffsetX;
	public float OffsetY;
	
	// You may call this from outside to re-render the expression.
	// This is not done automatically so that you can change the values very
	// often, say multiple times a millisecond, without significant slowdown.
	public void Render() {
		if (Godot.OS.GetName() == "X11") {
			InitSkia.Init();
		}
		
		var r = (byte)(255*this.MathColor.r);
		var g = (byte)(255*this.MathColor.g);
		var b = (byte)(255*this.MathColor.b);
		var a = (byte)(255*this.MathColor.a);
		
		this.Painter = new MathPainter {AntiAlias = this.AntiAliasing, TextColor = new SKColor(r, g, b, a), FontSize = this._fontSize, LaTeX = @"\raisebox{50mu}{}\raisebox{-50mu}{}" + this._latexExpression + @"\:\raisebox{1mu}"};
		
		var measure = this.Painter.Measure();
		this.Width = measure.Width;
		this.Height = measure.Height;
		this.OffsetX = measure.X;
		this.OffsetY = measure.Y;
		
		using (var png = this.Painter.DrawAsStream()) {
			var image = new Godot.Image();
			
			using (var memoryStream = new MemoryStream()) {
			  png.CopyTo(memoryStream);
			  image.LoadPngFromBuffer(memoryStream.ToArray());
			}
			
			var texture = new Godot.ImageTexture();
			texture.CreateFromImage(image);
			this.Texture = texture;
		};
	}
	
	public override void _Ready() {
		Render();
	}
}
