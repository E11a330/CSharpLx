namespace Myproject.Shader;

/// <summary>流式构建 <see cref="ShaderPipeline"/>。</summary>
public sealed class ShaderPipelineBuilder
{
    readonly List<ShaderModule> _modules = new();
    string? _name;

    public ShaderPipelineBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ShaderPipelineBuilder AddStage(ShaderStageKind stage, string source, ShaderLanguage language, string entryPoint = "main")
    {
        _modules.Add(new ShaderModule(stage, source, language, entryPoint));
        return this;
    }

    public ShaderPipelineBuilder AddStage(ShaderModule module)
    {
        _modules.Add(module);
        return this;
    }

    public ShaderPipeline Build() => new(_modules, _name);
}
