using System.Text;
using System.Text.RegularExpressions;

namespace Myproject.Shader;

/// <summary>
/// 轻量预处理器：#define、取消定义、条件编译、从字典解析 #include。
/// 不实现完整 GLSL 规范，仅用于开发与资源打包前的拼接。
/// </summary>
public sealed class ShaderPreprocessor
{
    readonly Dictionary<string, string?> _defines = new(StringComparer.Ordinal);

    public ShaderPreprocessor Define(string name, string? value = "1")
    {
        _defines[name] = value;
        return this;
    }

    public ShaderPreprocessor Undef(string name)
    {
        _defines.Remove(name);
        return this;
    }

    /// <summary>include 名 -> 源码。例如 "common.glsl" -> 文件内容。</summary>
    public IReadOnlyDictionary<string, string> IncludeResolver { get; init; } =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    public string Process(string source)
    {
        var sb = new StringBuilder();
        var lines = source.Replace("\r\n", "\n").Split('\n');
        var stack = new Stack<bool>();
        stack.Push(true);

        foreach (var raw in lines)
        {
            var line = raw.TrimStart();
            if (line.StartsWith("#if ", StringComparison.Ordinal))
            {
                var cond = line[4..].Trim();
                stack.Push(stack.Peek() && EvaluateIf(cond));
                continue;
            }
            if (line.StartsWith("#ifdef ", StringComparison.Ordinal))
            {
                var name = line[7..].Trim();
                stack.Push(stack.Peek() && _defines.ContainsKey(name));
                continue;
            }
            if (line.StartsWith("#ifndef ", StringComparison.Ordinal))
            {
                var name = line[8..].Trim();
                stack.Push(stack.Peek() && !_defines.ContainsKey(name));
                continue;
            }
            if (line.StartsWith("#else", StringComparison.Ordinal))
            {
                if (stack.Count < 2) throw new InvalidOperationException("#else without #if");
                var wasActive = stack.Pop();
                var parent = stack.Peek();
                stack.Push(parent && !wasActive);
                continue;
            }
            if (line.StartsWith("#endif", StringComparison.Ordinal))
            {
                if (stack.Count < 2) throw new InvalidOperationException("#endif without #if");
                stack.Pop();
                continue;
            }
            if (!stack.Peek())
                continue;

            if (line.StartsWith("#define ", StringComparison.Ordinal))
            {
                ParseDefine(line[8..]);
                continue;
            }
            if (line.StartsWith("#undef ", StringComparison.Ordinal))
            {
                _defines.Remove(line[7..].Trim());
                continue;
            }
            if (line.StartsWith("#include ", StringComparison.Ordinal))
            {
                var path = Unquote(line[9..].Trim());
                if (!IncludeResolver.TryGetValue(path, out var inc))
                    throw new FileNotFoundException($"Include not found: {path}");
                sb.Append(Process(inc));
                sb.Append('\n');
                continue;
            }

            sb.AppendLine(ApplyDefines(raw));
        }

        if (stack.Count != 1)
            throw new InvalidOperationException("Unclosed #if / #ifdef");

        return sb.ToString();
    }

    static string Unquote(string s)
    {
        if (s.Length >= 2 && ((s[0] == '"' && s[^1] == '"') || (s[0] == '<' && s[^1] == '>')))
            return s[1..^1];
        return s;
    }

    void ParseDefine(string rest)
    {
        rest = rest.Trim();
        var space = rest.IndexOf(' ');
        if (space < 0)
        {
            _defines[rest] = "";
            return;
        }
        var name = rest[..space];
        _defines[name] = rest[(space + 1)..].Trim();
    }

    bool EvaluateIf(string expr)
    {
        expr = expr.Trim();
        if (int.TryParse(expr, out var n))
            return n != 0;
        return _defines.ContainsKey(expr);
    }

    string ApplyDefines(string line)
    {
        var result = line;
        foreach (var kv in _defines.OrderByDescending(x => x.Key.Length))
        {
            if (string.IsNullOrEmpty(kv.Key))
                continue;
            result = Regex.Replace(result, $@"\b{Regex.Escape(kv.Key)}\b", kv.Value ?? "");
        }
        return result;
    }
}
