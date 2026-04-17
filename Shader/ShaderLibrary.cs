namespace Myproject.Shader;

/// <summary>
/// 集中管理着色器源码（内存字符串），便于与 <see cref="ShaderPreprocessor"/> 配合做 include。
/// </summary>
public sealed class ShaderLibrary
{
    readonly Dictionary<string, string> _sources = new(StringComparer.OrdinalIgnoreCase);

    public ShaderLibrary Register(string virtualPath, string source)
    {
        _sources[virtualPath] = source;
        return this;
    }

    public bool TryGet(string virtualPath, out string source) =>
        _sources.TryGetValue(virtualPath, out source!);

    public string Get(string virtualPath) =>
        _sources.TryGetValue(virtualPath, out var s) ? s : throw new KeyNotFoundException(virtualPath);

    public ShaderPreprocessor CreatePreprocessor() =>
        new() { IncludeResolver = _sources };

    /// <summary>从库中取文件并预处理。</summary>
    public string LoadProcessed(string virtualPath)
    {
        var src = Get(virtualPath);
        return CreatePreprocessor().Process(src);
    }
}
