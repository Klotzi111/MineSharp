﻿using System.Text;

namespace MineSharp.SourceGenerator.Code;

public class CodeWriter
{
    private const string Indent = "    ";
    private readonly StringBuilder sb = new();

    private int level;

    private string CurrentIndent => string.Concat(Enumerable.Repeat(Indent, level));

    public CodeWriter Write(string str)
    {
        sb.Append(CurrentIndent);
        sb.Append(str);
        return this;
    }

    public CodeWriter WriteLine(string str)
    {
        Write(str);
        sb.AppendLine();
        return this;
    }

    public CodeWriter WriteLine()
    {
        sb.AppendLine();
        return this;
    }

    public CodeWriter Disclaimer()
    {
        var comment = "This File is generated by MineSharp.SourceGenerator and should not be modified.";
        var str = $"//{Indent}{comment}{Indent}//";
        var slashes = new string('/', str.Length);
        WriteLine(slashes);
        WriteLine(str);
        WriteLine(slashes);
        WriteLine();
        WriteLine("#pragma warning disable CS1591");
        WriteLine();
        return this;
    }

    public CodeWriter Begin(string str)
    {
        WriteLine(str);
        WriteLine("{");
        level++;
        return this;
    }

    public CodeWriter Begin()
    {
        WriteLine("{");
        level++;
        return this;
    }

    public CodeWriter Finish(bool semicolon = false, bool colon = false)
    {
        level--;
        WriteLine("}" + (semicolon ? ";" : "") + (colon ? "," : ""));
        return this;
    }

    public override string ToString()
    {
        WriteLine();
        WriteLine("#pragma warning restore CS1591");
        return sb.ToString();
    }
}
