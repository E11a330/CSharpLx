namespace Myproject.Shader;

/// <summary>
/// 对接真实 GPU 时实现：编译/链接着色器、创建管线对象等。
/// 控制台项目可先做 Mock 或留空，接入 OpenGL/Vulkan/D3D 时再填。
/// </summary>
public interface IShaderBackend
{
    /// <summary>由 <see cref="ShaderPipeline"/> 生成后端可用的句柄或字节码（由具体实现定义）。</summary>
    object Compile(ShaderPipeline pipeline, ShaderCompileOptions? options = null);
}

/// <summary>编译选项占位，各后端扩展自己的字段时可继承或换为 record。</summary>
public sealed class ShaderCompileOptions
{
    public bool Debug { get; init; }
    public bool Optimize { get; init; } = true;
    public string? TargetProfile { get; init; }
}
