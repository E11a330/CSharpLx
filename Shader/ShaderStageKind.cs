namespace Myproject.Shader;

/// <summary>着色器阶段（与 Vulkan/D3D12/Metal 阶段对齐）。</summary>
public enum ShaderStageKind
{
    Vertex,
    TessellationControl,
    TessellationEvaluation,
    Geometry,
    Fragment,
    Compute,
    Task,
    Mesh,
    RayGeneration,
    RayClosestHit,
    RayAnyHit,
    RayMiss,
    RayIntersection,
    Callable
}
