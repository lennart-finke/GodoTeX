# $\text{Godo}\TeX$


$\text{Godo}\TeX$ is an add-on to Godot Mono that renders LaTeX expressions - in the editor and at runtime!
<p align="center">
  <img src="https://github.com/file-acomplaint/file-acomplaint/blob/main/assets/latex.gif" />
</p>

![](?raw=true)

## Features
- It's pretty fast!
- Editor Integration
- Inherits all Functionality from [`Sprite`](https://docs.godotengine.org/en/stable/classes/class_sprite.html?highlight=sprite)
- Adjustable Font Size
- Adjustable Font Color
- Anti-Aliasing (with Toggle)

## Compatibility
The add-on is tested for Godot 4.1.x and is expected to run on > 4.1. There is also a branch for Godot 3, which was tested for 3.5.x and is expected to run on 3.x. It supports Windows and Linux. MacOS is tested by the community and pull requests are welcome.

## Usage
<p align="center">
  <img src="https://github.com/file-acomplaint/file-acomplaint/blob/main/assets/latexDemo.gif" />
</p>

A custom node `LaTeX`(![](https://github.com/file-acomplaint/GodoTeX/blob/main/addons/GodoTeX/icon.svg?raw=true)) inheriting from `Sprite` is provided and may be instanced like any other. It has the following properties, which may be updated in the editor or programmatically at runtime

- **LatexExpression**: A `string` containing the expression to be rendered. If invalid, the corresponding error message will be rendered instead.
- **FontSize**: A `float`, the font size in points. It essentially controls the resolution of the rendered image. Decrease for better performance, increase for higher fidelity.
- **MathColor**: A Godot `Color`, the typeface's color.
- **AntiAliasing**: A `bool`. The renderer may or may not be instructed to anti-aliase the rendered typeface. Note that this is distinct from Godot's own anti-aliasing.

When updating these in the editor, the expression is automatically rendered anew. When updating properties programmatically, you decide yourself when to render by calling the `.Render()` method - to save ressources. Rendering very often (several times a millisecond) may result in errors.

***

There is also a `LaTeXButton`(![](https://github.com/file-acomplaint/GodoTeX/blob/main/addons/GodoTeX/iconButton.svg?raw=true)) node for clickable expressions. This behaves like a `TextureButton`.

<p align="center">
  <img src="https://github.com/file-acomplaint/file-acomplaint/blob/main/assets/button.gif" />
</p>

***

Further, a special node for usage in 3D is provided - `LaTeX3D`(![](https://github.com/file-acomplaint/GodoTeX/blob/main/addons/GodoTeX/iconRed.svg?raw=true)).

<p align="center">
  <img src="https://github.com/file-acomplaint/file-acomplaint/blob/main/assets/3D.png" />
</p>

***

For a list of LaTeX examples that can be rendered, see [here](https://github.com/kostub/iosMath/blob/master/EXAMPLES.md).

A demo is available [here](https://github.com/file-acomplaint/Emmy-s-Adventure).

## Installation
1. Create a Godot Mono project and build a C#-script.
2. Install from the Godot Asset Store from inside the Engine or by cloning. When including in an existing project, you won't need the `*.godot` and `*.sln`.
3. The add-on depends on [`CSharpMath.SkiaSharp`](https://github.com/verybadcat/CSharpMath), licensed under MIT, as a nuget package. You integrate this into your existing Godot Mono project by copying the `<ItemGroup>`-tags into your project's `.csproj`-file from `GodoTeX.csproj`.
4. Enable the addon in the settings, as usual. You can now create a `LaTeX` node and start your math excapades!

## Disclosure of Funding
$\text{Godo}\TeX$ was initially funded by the German Government, specifically the Bundesnachrichtendienst, as part of the BND Summer of Code. It is featured on the program's website [here](https://www.bnd.bund.de/DE/Karriere/SummerOfCode/SummerOfCode_node.html).
## License
Licensed under MIT. © 2022-2023 fi-le


