namespace Myproject.Shader;

/// <summary>单个着色器阶段：源码 + 入口（HLSL 等需要）。</summary>
public sealed class ShaderModule
{
    public ShaderModule(ShaderStageKind stage, string source, ShaderLanguage language, string entryPoint = "main")
    {
        Stage = stage;
        Source = source ?? throw new ArgumentNullException(nameof(source));
        Language = language;
        EntryPoint = entryPoint;
    }

    public ShaderStageKind Stage { get; }
    public string Source { get; }
    public ShaderLanguage Language { get; }
    public string EntryPoint { get; }

    /// <summary>可选：该阶段用到的资源绑定（可由手写或工具生成）。</summary>
    public IReadOnlyList<ShaderResourceBinding>? Resources { get; init; }
}
