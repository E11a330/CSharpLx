namespace Myproject.Shader;

/// <summary>统一缓冲/纹理等绑定描述，供反射或后端填槽位。</summary>
public sealed class ShaderResourceBinding
{
    public required string Name { get; init; }
    public int Set { get; init; }
    public int Binding { get; init; }
    public ShaderResourceKind Kind { get; init; }
}

public enum ShaderResourceKind
{
    UniformBuffer,
    StorageBuffer,
    SampledImage,
    StorageImage,
    Sampler,
    AccelerationStructure
}
