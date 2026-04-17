namespace Myproject.Shader;

/// <summary>图形管线：多阶段着色器模块集合。</summary>
public sealed class ShaderPipeline
{
    public ShaderPipeline(IReadOnlyList<ShaderModule> modules, string? name = null)
    {
        Modules = modules ?? throw new ArgumentNullException(nameof(modules));
        Name = name;
        ValidateStages();
    }

    public string? Name { get; }
    public IReadOnlyList<ShaderModule> Modules { get; }

    public ShaderModule? GetStage(ShaderStageKind stage) =>
        Modules.FirstOrDefault(m => m.Stage == stage);

    void ValidateStages()
    {
        var dup = Modules.GroupBy(m => m.Stage).FirstOrDefault(g => g.Count() > 1);
        if (dup != null)
            throw new InvalidOperationException($"Duplicate shader stage: {dup.Key}");
    }
}
