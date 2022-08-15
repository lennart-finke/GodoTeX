using Godot;
using System.IO;
using CSharpMath.SkiaSharp;
using CSharpMath.Rendering;
using SkiaSharp;

[Tool]
public class LaTeXture : ImageTexture {
	public string LatexExpression;
	public float FontSize = 40f;
	public Color MathColor = new Color(0,0,0,1);
	public bool AntiAliasing = true;
	public bool Fill = true;
	public bool ShowError = true;
	
	private MathPainter Painter = new MathPainter{};
	
	public float Width;
	public float Height;
	public float OffsetX;
	public float OffsetY;
	
	public void Render() {
		var r = (byte)(255*this.MathColor.r);
		var g = (byte)(255*this.MathColor.g);
		var b = (byte)(255*this.MathColor.b);
		var a = (byte)(255*this.MathColor.a);
		
		var paintStyle = CSharpMath.Rendering.FrontEnd.PaintStyle.Stroke;
		if (this.Fill) {
			paintStyle = CSharpMath.Rendering.FrontEnd.PaintStyle.Fill;
		}
		
		this.Painter = new MathPainter {AntiAlias = this.AntiAliasing, TextColor = new SKColor(r, g, b, a), FontSize = this.FontSize, LaTeX = @"\raisebox{40mu}{}\raisebox{-40mu}{}" + this.LatexExpression + @"\:\raisebox{1mu}", DisplayErrorInline = this.ShowError, PaintStyle = paintStyle};
		
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
			
			this.CreateFromImage(image);
		};
	}
}
